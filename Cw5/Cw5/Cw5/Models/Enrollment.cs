using System.Text.Json.Serialization;

namespace Cw5.Models
{
    public class Enrollment
    {
        public int? IdEnrollment { get; set; }
        public int? Semester { get; set; }
        [JsonPropertyName("Studies")]
        public Studies IdStudies { get; set; }
        public string StartDate { get; set; }
    }
}
