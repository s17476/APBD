using Cw10.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cw10.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private s17476Context _db = new s17476Context();

        [HttpGet]
        public IActionResult GetStudents()
        {
            //[JsonIgnore] annotation added to Enrollment and Studies
            var res = _db.Student.ToList();
            
            return Ok(res);
        }

        [HttpPatch]
        public IActionResult UpdateStudent(Student student)
        {
            _db.Attach(student);

            var props = student.GetType().GetProperties();
            foreach (var prop in props)
            {
                if (prop.GetValue(student, null) != null &&
                    prop.GetValue(student, null).ToString() != default(int).ToString() &&
                    prop.GetValue(student, null).ToString() != default(DateTime).ToString() &&
                    prop.Name != "IndexNumber")
                {
                    _db.Entry(student).Property(prop.Name).IsModified = true;
                }
            };

            var count = _db.SaveChanges();
            if (count > 0)
            {
                return Ok();
            }
            return Problem();
        }

        [HttpDelete]
        public IActionResult DeleteStudent(Student student)
        {
            _db.Attach(student);

            _db.Remove(student);

            var count = _db.SaveChanges();
            if (count > 0)
            {
                return Ok();
            }
            return BadRequest();
        }

    }
}
