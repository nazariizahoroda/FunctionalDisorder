using Microsoft.AspNetCore.Identity;
using System;

namespace Domain.Entities.ManyToMany
{
    public class UserRole : IdentityUserRole<int>
    {
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}
