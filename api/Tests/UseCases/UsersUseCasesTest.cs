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
            _ = mockRepository.Setup(p => p.GetAll()).ReturnsAsync(GetMockListUsers());

            GetAllUsersUC uc = new(mockRepository.Object);

            List<User> result = await uc.Execute();

            mockRepository.Verify(c => c.GetAll(), Times.Once);

            Assert.Equal(GetMockListUsers().Count, result.Count);
        }

        [Fact]
        public async Task ShouldGetById()
        {
            Mock<IUsersRepository> mockRepository = new();
            _ = mockRepository.Setup(p => p.GetById(It.IsAny<int>())).ReturnsAsync(GetMockListUsers().First());

            GetByIdUserUC uc = new(mockRepository.Object);

            User result = await uc.Execute();

            mockRepository.Verify(c => c.GetById(It.IsAny<int>()), Times.Once);

            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task ShouldCreate()
        {
            Mock<IUsersRepository> mockRepository = new();
            _ = mockRepository.Setup(p => p.Create(It.IsAny<User>())).ReturnsAsync(GetMockListUsers().First());

            CreateUserUC uc = new(mockRepository.Object);

            User result = await uc.Execute();

            mockRepository.Verify(c => c.Create(It.IsAny<User>()), Times.Once);

            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task ShouldUpdate()
        {
            Mock<IUsersRepository> mockRepository = new();
            _ = mockRepository.Setup(p => p.Update(It.IsAny<int>(), It.IsAny<User>())).ReturnsAsync(GetMockListUsers().First());

            UpdateUserUC uc = new(mockRepository.Object);

            User result = await uc.Execute();

            mockRepository.Verify(c => c.Update(It.IsAny<int>(), It.IsAny<User>()), Times.Once);

            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task ShouldDelete()
        {
            Mock<IUsersRepository> mockRepository = new();
            _ = mockRepository.Setup(p => p.Delete(It.IsAny<int>())).ReturnsAsync(GetMockListUsers().First());

            DeleteUserUC uc = new(mockRepository.Object);

            User result = await uc.Execute();

            mockRepository.Verify(c => c.Delete(It.IsAny<int>()), Times.Once);

            Assert.Equal(1, result.Id);
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