using System.ComponentModel.DataAnnotations;

namespace Talabat.DTOS
{
    public class RejsterDto
    {
        [Required]
        public string DesplyName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string PhoneNumer { get; set; }
        //shloud add RGX here
        public string Passwroed { get; set; }


    }
}
