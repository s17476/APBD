using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Cw4.Model
{
    public class Enrollment
    {
        [JsonIgnore]
        public int IdEnrollment { get; set; }
        public int Semester { get; set; }
        [JsonPropertyName("Studies")]
        public Studies IdStudies { get; set; }
        [JsonIgnore]
        public string StartDate { get; set; }
    }
}
