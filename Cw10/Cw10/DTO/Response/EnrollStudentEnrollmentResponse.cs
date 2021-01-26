using Cw10.Models;

namespace Cw10.DTO.Response
{
    public class EnrollStudentEnrollmentResponse
    {
        public EnrollStudentEnrollmentResponse(Enrollment enr)
        {
            IdEnrollment = enr.IdEnrollment;
            Semester = enr.Semester;
            IdStudy = enr.IdStudy;
            StartDate = enr.StartDate.ToString("yyyy-MM-dd");
        }

        public int IdEnrollment { get; set; }
        public int Semester { get; set; }
        public int IdStudy { get; set; }
        public string StartDate { get; set; }
    }
}
