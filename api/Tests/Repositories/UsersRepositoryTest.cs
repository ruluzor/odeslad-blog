using Api.Repositories;
using Api.Models;
using Xunit;

namespace Tests.Repositories
{
    public class UsersRepositoryTest
    {
        private readonly IUsersRepository _repository;

        public UsersRepositoryTest(IUsersRepository repository) {
            _repository = repository;
        }

        [Fact]
        public async Task ShouldGetAll()
        {
            var user = await CreateTestUser();

            var models = await _repository.GetAll();

            Assert.NotEmpty(models);
            await DeleteTestUser(user.Id);
        }

        [Fact]
        public async Task ShouldGetNullByIdNotFound()
        {
            var model = await _repository.GetById(2);
            Assert.Null(model);
        }

        [Fact]
        public async Task ShouldGetModelById()
        {
            var user = await CreateTestUser();

            var model = await _repository.GetById(user.Id);

            Assert.Equal(user.Id, model.Id);
            await DeleteTestUser(user.Id);
        }

        [Fact]
        public async Task ShouldCreate()
        {
            var user = await CreateTestUser();

            var models = await _repository.GetAll();

            Assert.NotEmpty(models);
            await DeleteTestUser(user.Id);

        }

        [Fact]
        public async Task ShouldUpdate()
        {
            var user = await CreateTestUser();
            var model = await _repository.GetById(user.Id);
            model.Title = "updated";

            var result = await _repository.Update(model.Id, model);

            Assert.Equal("updated", result.Title);
            await DeleteTestUser(user.Id);

        }

        [Fact]
        public async Task ShouldDelete()
        {
            var user = await CreateTestUser();

            var result = await _repository.Delete(user.Id);

            var models = await _repository.GetAll();
            Assert.Equal(result.Id, user.Id);
            Assert.Empty(models);
        }

        private async Task<User> CreateTestUser()
        {
            var model = new User
            {
                Id = 0,
                Title = "Rubén",
                FirstName = "Rubén",
                LastName = "Lucas",
                Email = "rubenlucas@gmail.com",
                PasswordHash = "1234",
                Role = Role.Admin
            };
            var user = await _repository.Create(model);
            return await _repository.GetById(user.Id);
        }

        private async Task DeleteTestUser(int id)
        {
            await _repository.Delete(id);
        }
    }
}