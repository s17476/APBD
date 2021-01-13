using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Cw5.Models
{
    public class Student
    {
        public string IndexNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirtDate { get; set; }
        [JsonPropertyName("Enrollment")]
        public Enrollment IdEnrollment { get; set; }

    }
}
