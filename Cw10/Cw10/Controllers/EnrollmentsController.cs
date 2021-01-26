using Cw10.DTO.Requests;
using Cw10.DTO.Response;
using Cw10.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Cw10.Controllers
{
    [Route("api/enrollments")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {

        private s17476Context _db = new s17476Context();

        [HttpPost]
        public IActionResult EnrollStudent(EnrollStudentRequest request)
        {
            var enrollmentId = 1;

            using var transaction = _db.Database.BeginTransaction();
            try
            {
               
                var idStudy = _db.Studies.Where(s => s.Name == request.Studies)
                                        .Select(s => s.IdStudy);

                //studies doesn't exist
                if (!idStudy.Any()) return BadRequest("Studies does not exist!");

                var enrollment = _db.Enrollment.Where(en => (en.IdStudy == idStudy.ToList()[0]) && (en.Semester == 1));
                
                //create new enrollment if doesn't exist
                if (!enrollment.Any())
                {
                    
                    enrollmentId += _db.Enrollment.Max(en => en.IdEnrollment);

                    _db.Enrollment.Add(new Enrollment()
                    {
                        IdEnrollment = enrollmentId,
                        Semester = 1,
                        IdStudy = idStudy.ToList()[0],
                        StartDate = DateTime.Today
                    });

                    _db.SaveChanges();
                    
                }
                else
                {
                    enrollmentId = enrollment.Max(en => en.IdEnrollment);
                }

                if(_db.Student.Where(st => st.IndexNumber == request.IndexNumber).Any())
                    return BadRequest("Student with given index number alleready exists");

                //add new student
                _db.Student.Add(new Student()
                {
                    IndexNumber = request.IndexNumber,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    BirthDate = (DateTime)request.BirthDate,
                    IdEnrollment = enrollmentId,
                });

                _db.SaveChanges();

                transaction.Commit();
            }
            catch(Exception exc)
            {
                return BadRequest(exc);
            }

            var res = _db.Enrollment.Where(en => en.IdEnrollment == enrollmentId);

            return Created("", res);
        }

        [HttpPost("promotions")]
        public IActionResult Promote(EnrollPromotionRequest request)
        {
            using var transaction = _db.Database.BeginTransaction();
            try
            {
                //find enrollment
                var enrollment = _db.Enrollment
                                    .Where(en => (en.Semester == request.Semester) && (en.IdStudyNavigation.Name == request.Studies));

                if (!enrollment.Any()) return NotFound();

                //find next enrollment
                var newEnrollmentDb = _db.Enrollment
                                    .Where(en => (en.Semester == (int)request.Semester + 1) && (en.IdStudyNavigation.Name == request.Studies));

                //create next enrollment if does not exist
                Enrollment newEnrollment;

                if (!newEnrollmentDb.Any())
                {
                    newEnrollment = new Enrollment()
                    {
                        IdEnrollment = _db.Enrollment.Max(en => en.IdEnrollment) +1,
                        Semester = (int)request.Semester + 1,
                        IdStudy = enrollment.Select(en => en.IdStudy).ToList()[0],
                        StartDate = DateTime.Today
                    };
                    _db.Enrollment.Add(newEnrollment);
                    _db.SaveChanges();
                }
                else
                {
                    newEnrollment = newEnrollmentDb.ToList()[0];
                }

                // update students
                var students = _db.Student.Where(st => st.IdEnrollment == enrollment.ToList()[0].IdEnrollment).ToList();

                students.ForEach(st =>
                {
                    st.IdEnrollment = newEnrollment.IdEnrollment;
                    _db.Entry(st).Property("IdEnrollment").IsModified = true;
                });
                
                _db.SaveChanges();


                transaction.Commit();

                return Created("", new EnrollStudentEnrollmentResponse(newEnrollment));
            }
            catch(Exception exc)
            {
                return BadRequest(exc.Message);
            }

        }
    }
}
