using System;
using System.ComponentModel.DataAnnotations;

namespace FunctionalDisorder.Models.ActionDTOs
{
    public class SignUpModelDto
    {
        [Required]
        public string Password { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Address { get; set; }
    }
}
