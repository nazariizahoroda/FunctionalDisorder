using System.ComponentModel.DataAnnotations;

namespace FunctionalDisorder.Models.ActionDTOs
{
    public class SignInModelDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
