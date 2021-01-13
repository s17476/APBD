using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cw5.DTO.Requests
{
    public class EnrollPromotionRequest
    {
        [Required]
        [MaxLength(100)]
        public string Studies { get; set; }
        [Required]
        public int? Semester { get; set; }
    }
}
