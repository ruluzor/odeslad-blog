using Api.Controllers;
using Api.Models;
using Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;
using Xunit;

namespace Tests.Controllers
{
    public class UsersControllerTest
    {

        [Fact]
        public async Task ShouldGetAll()
        {
            Mock<IUsersRepository> mockRepository = new();
            _ = mockRepository.Setup(p => p.GetAll()).ReturnsAsync(GetMockListUsers());

            UsersController controller = new(mockRepository.Object);

            ObjectResult result = await controller.GetAll() as ObjectResult;

            _ = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)result.StatusCode);

            mockRepository.Verify(c => c.GetAll(), Times.Once);

            Assert.Equal(GetMockListUsers().Count, ((List<User>)result.Value).Count);
        }

        [Fact]
        public async Task ShouldGetById()
        {
            Mock<IUsersRepository> mockRepository = new();
            _ = mockRepository.Setup(p => p.GetById(It.IsAny<int>())).ReturnsAsync(GetMockListUsers().First());

            UsersController controller = new(mockRepository.Object);

            ObjectResult result = await controller.GetById(It.IsAny<int>()) as ObjectResult;

            _ = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)result.StatusCode);

            mockRepository.Verify(c => c.GetById(It.IsAny<int>()), Times.Once);

            Assert.Equal(1, ((User)result.Value).Id);
        }

        [Fact]
        public async Task ShouldCreate()
        {
            Mock<IUsersRepository> mockRepository = new();
            _ = mockRepository.Setup(p => p.Create(It.IsAny<User>())).ReturnsAsync(GetMockListUsers().First());

            UsersController controller = new(mockRepository.Object);

            ObjectResult result = await controller.Create(It.IsAny<User>()) as ObjectResult;

            _ = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)result.StatusCode);

            mockRepository.Verify(c => c.Create(It.IsAny<User>()), Times.Once);

            Assert.Equal(1, ((User)result.Value).Id);
        }

        [Fact]
        public async Task ShouldUpdate()
        {
            Mock<IUsersRepository> mockRepository = new();
            _ = mockRepository.Setup(p => p.Update(It.IsAny<int>(), It.IsAny<User>())).ReturnsAsync(GetMockListUsers().First());

            UsersController controller = new(mockRepository.Object);

            ObjectResult result = await controller.Update(It.IsAny<int>(), It.IsAny<User>()) as ObjectResult;

            _ = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)result.StatusCode);

            mockRepository.Verify(c => c.Update(It.IsAny<int>(), It.IsAny<User>()), Times.Once);

            Assert.Equal(1, ((User)result.Value).Id);
        }

        [Fact]
        public async Task ShouldDelete()
        {
            Mock<IUsersRepository> mockRepository = new();
            _ = mockRepository.Setup(p => p.Delete(It.IsAny<int>())).ReturnsAsync(GetMockListUsers().First());

            UsersController controller = new(mockRepository.Object);

            ObjectResult result = await controller.Delete(It.IsAny<int>()) as ObjectResult;

            _ = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)result.StatusCode);

            mockRepository.Verify(c => c.Delete(It.IsAny<int>()), Times.Once);

            Assert.Equal(1, ((User)result.Value).Id);
        }


        private static List<User> GetMockListUsers()
        {
            return new List<User>
            {
                new User()
                {
                    Id = 1,
                    Title = "Test 1"
                },
                new User()
                {
                    Id = 2,
                    Title = "Test 2"
                }
            };
        }
    }
}