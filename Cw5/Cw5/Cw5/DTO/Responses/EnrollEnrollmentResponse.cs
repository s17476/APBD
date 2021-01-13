using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw5.DTO.Responses
{
    public class EnrollEnrollmentResponse
    {
        public int IdEnrollment { get; set; }
        public int Semester { get; set; }
        public int IdStudies { get; set; }
        public string StartDate { get; set; }
    }
}
