using System.ComponentModel.DataAnnotations;

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
