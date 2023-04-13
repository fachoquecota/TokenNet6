using System.ComponentModel.DataAnnotations;
namespace TokenNet6.Models
{
    public class ErrorResult
    {
        [Required]
        public static string? ErrorMessage { get; set; }
    }
}
