using System;

namespace FunctionalDisorder.Models.ViewDTOs
{
    public class UserDto
    {
        public Guid GuidId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
    }
}
