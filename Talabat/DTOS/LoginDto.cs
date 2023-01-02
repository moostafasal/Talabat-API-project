using System.ComponentModel.DataAnnotations;

namespace Talabat.DTOS
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Passowrd { get; set; }

    }
}
