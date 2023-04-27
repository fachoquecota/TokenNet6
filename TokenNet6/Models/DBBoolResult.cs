using System.ComponentModel.DataAnnotations;
namespace TokenNet6.Models
{
    public class DBBoolResult
    {
        [Required]
        public int result { get; set; }
        public string value { get; set; }
    }
}
