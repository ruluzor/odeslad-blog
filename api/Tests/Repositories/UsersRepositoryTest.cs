using Api.Repositories;
using Api.Models;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Tests.Repositories
{
    public class UsersRepositoryTest
    {

        private readonly DbContextOptions<Context> _options;

        public UsersRepositoryTest()
        {
            _options = new DbContextOptionsBuilder<Context>()
                .UseSqlServer(Api.Helpers.GetConfiguration().GetConnectionString("Test")).Options;
        }

        [Fact]
        public async Task ShouldGetAll()
        {
            IUsersRepository repository = new UsersRepository(_options);
            var testUser = await repository.Create(Helpers.GetMockNewUser());
            var models = await repository.GetAll();
            Assert.NotEmpty(models);
            await repository.Delete(testUser.Id);
        }

        [Fact]
        public async Task ShouldGetNullByIdNotFound()
        {
            IUsersRepository repository = new UsersRepository(_options);
            var testUser = await repository.Create(Helpers.GetMockNewUser());
            var model = await repository.GetById(2);
            Assert.Null(model);
            await repository.Delete(testUser.Id);
        }

        [Fact]
        public async Task ShouldGetModelById()
        {
            IUsersRepository repository = new UsersRepository(_options);
            var testUser = await repository.Create(Helpers.GetMockNewUser());
            var model = await repository.GetById(testUser.Id);
            Assert.Equal(testUser.Id, model.Id);
            await repository.Delete(testUser.Id);
        }

        [Fact]
        public async Task ShouldCreate()
        {
            IUsersRepository repository = new UsersRepository(_options);
            var testUser = await repository.Create(Helpers.GetMockNewUser());
            var models = await repository.GetAll();
            Assert.Single(models);
            await repository.Delete(testUser.Id);
        }

        [Fact]
        public async Task ShouldUpdate()
        {
            IUsersRepository repository = new UsersRepository(_options);
            var testUser = await repository.Create(Helpers.GetMockNewUser());
            var model = await repository.GetById(testUser.Id);
            model.Title = "updated";
            await repository.Update(testUser.Id, model);
            model = await repository.GetById(model.Id);
            Assert.Equal("updated", model.Title);
            await repository.Delete(testUser.Id);
        }

        [Fact]
        public async Task ShouldDelete()
        {
            IUsersRepository repository = new UsersRepository(_options);
            var testUser = await repository.Create(Helpers.GetMockNewUser());
            await repository.Delete(testUser.Id);
            var models = await repository.GetAll();
            Assert.Empty(models);
        }
    }
}