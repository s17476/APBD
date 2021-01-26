using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Cw10.Models
{
    public partial class Student
    {
        public string IndexNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int IdEnrollment { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        [JsonIgnore]
        public string RefToken { get; set; }
        [JsonIgnore]
        public DateTime? TokenExpirationDate { get; set; }
        [JsonIgnore]
        public string Salt { get; set; }
        [JsonIgnore]
        public virtual Enrollment IdEnrollmentNavigation { get; set; }
    }
}
