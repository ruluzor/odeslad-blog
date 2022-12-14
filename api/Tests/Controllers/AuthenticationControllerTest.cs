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
            _ = mockRepository.Setup(p => p.GetAll()).ReturnsAsync(Helpers.GetMockDbListUsers());
            AuthenticationController controller = new(mockRepository.Object, Api.Helpers.GetConfiguration());
            ObjectResult result = await controller.Login(Helpers.GetMockLoginUser()) as ObjectResult;
            _ = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)result.StatusCode);
            mockRepository.Verify(c => c.GetAll(), Times.Once);
        }
    }
}