using AmstedDigital.Reports.Logic.FunctionalTests;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalDisorder.IntegrationTests
{
    internal class UserGetFunctionalTest
    {
        private APIWebApplicationFactory<Startup> _factory;
        private HttpClient _client;

        [SetUp]
        public void Setup()
        {
            _factory = new APIWebApplicationFactory<Startup>();
            _client = _factory.CreateClient();
        }

        [Test]
        public async Task Read_WhenCalled_ReturnsOk_And_UserInfo()
        {
            var result = await _client.GetAsync("/api/User/getUser/24519D0E-3D84-47F8-A365-190CFE2BE609");

            var responseString = await result.Content.ReadAsStringAsync();

            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            Assert.IsTrue(responseString.Contains("Nazar"));
        }
    }
}
