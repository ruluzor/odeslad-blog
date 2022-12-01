using System.Net;
using Api.Controllers;
using Api.Models;
using Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Tests.Controllers
{
    public class AuthenticationControllerTest
    {
        [Fact]
        public async Task ShouldLogin()
        {
            Mock<IUsersRepository> mockRepository = new();
            _ = mockRepository.Setup(p => p.GetAll()).ReturnsAsync(Helpers.GetMockListUsers());

            AuthenticationController controller = new(mockRepository.Object, Helpers.GetConfiguration());

            ObjectResult result = await controller.Login(Helpers.GetMockListUsers()[0]) as ObjectResult;

            _ = Assert.IsType<UnauthorizedObjectResult>(result);
            Assert.Equal(HttpStatusCode.Unauthorized, (HttpStatusCode)result.StatusCode);

            mockRepository.Verify(c => c.GetAll(), Times.Once);
        }
    }
}