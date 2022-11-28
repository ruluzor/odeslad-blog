using api.Repositories;
using Xunit;

namespace tests.Repositories
{
    public class UsersRepositoryTest
    {
        private readonly IUsersRepository _repository;

        public UsersRepositoryTest(IUsersRepository repository) {
            _repository = repository;
        }

        [Fact]
        public void ShouldGetAll()
        {
            var user = CreateTestUser();

            var models = _repository.GetAll();

            Assert.NotEmpty(models);
            DeleteTestUser(user.Id);
        }

        [Fact]
        public void ShouldGetNullByIdNotFound()
        {
            var model = _repository.GetById(2);
            Assert.Null(model);
        }

        [Fact]
        public void ShouldGetModelById()
        {
            var user = CreateTestUser();

            var model = _repository.GetById(user.Id);

            Assert.Equal(user.Id, model.Id);
            DeleteTestUser(user.Id);
        }

        [Fact]
        public void ShouldCreate()
        {
            var user = CreateTestUser();

            var models = _repository.GetAll();

            Assert.NotEmpty(models);
            DeleteTestUser(user.Id);

        }

        [Fact]
        public void ShouldUpdate()
        {
            var user = CreateTestUser();
            var model = _repository.GetById(user.Id);
            model.Title = "updated";

            var result = _repository.Update(model.Id, model);

            Assert.Equal("updated", result.Title);
            DeleteTestUser(user.Id);

        }

        [Fact]
        public void ShouldDelete()
        {
            var user = CreateTestUser();

            _repository.Delete(user.Id);

            var models = _repository.GetAll();
            Assert.Empty(models);
        }

        private api.Models.User CreateTestUser()
        {
            var model = new api.Models.User
            {
                Id = 0,
                Title = "Rubén",
                FirstName = "Rubén",
                LastName = "Lucas",
                Email = "rubenlucas@gmail.com",
                PasswordHash = "1234",
                Role = api.Models.Role.Admin
            };
            var user = _repository.Create(model);
            return _repository.GetById(user.Id);
        }

        private void DeleteTestUser(int id)
        {
            _repository.Delete(id);
        }
    }
}