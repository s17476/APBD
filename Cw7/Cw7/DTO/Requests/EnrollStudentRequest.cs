using System;
using System.ComponentModel.DataAnnotations;

namespace Cw7.DTO.Requests
{
    public class EnrollStudentRequest
    {
        [Required]
        [RegularExpression("^s[0-9]+$")]
        public string IndexNumber { get; set; }
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }
        //date format "yyyy-MM-dd"
        [Required]
        public DateTime? BirthDate { get; set; }
        [Required]
        public string Studies { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }

    }
}
