using System.ComponentModel.DataAnnotations;

namespace TokenNet6.Models
{
    public class LoginModel
    {
        [Required]
        [MaxLength(50)]
        public string? Username { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Password { get; set; }
    }
}
