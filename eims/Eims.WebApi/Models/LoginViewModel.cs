using System.ComponentModel.DataAnnotations;

namespace Eims.WebApi.Models
{
    public class LoginViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Password { get; set; }
    }
}