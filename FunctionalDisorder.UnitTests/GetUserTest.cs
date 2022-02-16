using Domain.Entities;
using FunctionalDisorder.Logic.UnitTests.Setup;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Persistence;
using Persistence.Repositories;
using System;
using System.Threading.Tasks;

namespace FunctionalDisorder.Logic.UnitTests.Services.UserService
{
    internal class UserGetTests
    {
        [Test]
        public async Task UserGetById_Successful()
        {
            //Arrange
            var ioc = TestIoc.Create();

            var context = ioc.ServiceProvider.GetRequiredService<ApplicationContext>();

            var repositoryManager = new RepositoryManager(context);

            await AddDataToDB(context);

            //Act
            var result = await repositoryManager.User.GetUserByIdAsync(1);

            //Assert
            Assert.NotNull(result);
        }

        private async Task AddDataToDB(ApplicationContext context)
        {
            await context.Users.AddAsync(new User()
            {
                Id = 1,
                Name = "Nazar",
                DateOfBirth = DateTime.Now,
                Address = "Lukasha, 5"
            });

            await context.SaveChangesAsync();
        }
    }
}
