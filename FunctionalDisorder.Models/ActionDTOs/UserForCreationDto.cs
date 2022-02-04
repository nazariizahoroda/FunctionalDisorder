using System;
using System.ComponentModel.DataAnnotations;

namespace FunctionalDisorder.Models.ActionDTOs
{
    public class UserForCreationDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Address { get; set; }
    }
}