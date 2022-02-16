using Persistence;
using System;

namespace AmstedDigital.Reports.Logic.FunctionalTests
{
    internal class SeedData
    {
        internal static void InitializeDatabase(ApplicationContext db)
        {
            db.Users.Add(new Domain.Entities.User()
            {
                Id = 1,
                Name = "Nazar",
                DateOfBirth = DateTime.Now,
                Address = "Lukasha, 5"
            });

            db.SaveChanges();
        }
    }
}