using System;

namespace Domain.Entities
{
    public class Account
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public string AccountType { get; set; }

        public int UserId { get; set; }
    }
}
