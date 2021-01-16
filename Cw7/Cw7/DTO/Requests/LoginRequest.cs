using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cw7.DTO.Requests
{
    public class LoginRequest
    {
        [Required]
        [RegularExpression("^s[0-9]+$")]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
