using Api.Models;
using Api.Repositories;
using Api.UseCases.Users;
using Moq;
using Xunit;

namespace Tests.UseCases
{
    public class UsersUseCasesTest
    {

        [Fact]
        public async Task ShouldGetAll()
        {
            Mock<IUsersRepository> mockRepository = new();
            _ = mockRepository.Setup(p => p.GetAll()).ReturnsAsync(Helpers.GetMockDbListUsers());
            GetAllUsersUC uc = new(mockRepository.Object);
            List<User> result = await uc.Execute();
            mockRepository.Verify(c => c.GetAll(), Times.Once);
            Assert.Equal(Helpers.GetMockDbListUsers().Count, result.Count);
        }

        [Fact]
        public async Task ShouldGetById()
        {
            Mock<IUsersRepository> mockRepository = new();
            _ = mockRepository.Setup(p => p.GetById(It.IsAny<int>())).ReturnsAsync(Helpers.GetMockDbListUsers().First());
            GetByIdUserUC uc = new(mockRepository.Object);
            User result = await uc.Execute();
            mockRepository.Verify(c => c.GetById(It.IsAny<int>()), Times.Once);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task ShouldCreate()
        {
            Mock<IUsersRepository> mockRepository = new();
            _ = mockRepository.Setup(p => p.Create(It.IsAny<User>())).ReturnsAsync(Helpers.GetMockDbListUsers().First());
            CreateUserUC uc = new(mockRepository.Object);
            User result = await uc.Execute();
            mockRepository.Verify(c => c.Create(It.IsAny<User>()), Times.Once);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task ShouldUpdate()
        {
            Mock<IUsersRepository> mockRepository = new();
            _ = mockRepository.Setup(p => p.Update(It.IsAny<int>(), It.IsAny<User>())).ReturnsAsync(Helpers.GetMockDbListUsers().First());
            UpdateUserUC uc = new(mockRepository.Object);
            User result = await uc.Execute();
            mockRepository.Verify(c => c.Update(It.IsAny<int>(), It.IsAny<User>()), Times.Once);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task ShouldDelete()
        {
            Mock<IUsersRepository> mockRepository = new();
            _ = mockRepository.Setup(p => p.Delete(It.IsAny<int>())).ReturnsAsync(Helpers.GetMockDbListUsers().First());
            DeleteUserUC uc = new(mockRepository.Object);
            User result = await uc.Execute();
            mockRepository.Verify(c => c.Delete(It.IsAny<int>()), Times.Once);
            Assert.Equal(1, result.Id);
        }
    }
}