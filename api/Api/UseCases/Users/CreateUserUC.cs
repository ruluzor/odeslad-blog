using Api.Models;
using Api.Repositories;

namespace Api.UseCases.Users
{
    public class CreateUserUC : IUseCase<User>
    {

        public IUsersRepository _repository;

        public User Model { get; set; }

        public CreateUserUC(IUsersRepository repository)
        {
            _repository = repository;
        }

        public async Task<User> Execute()
        {
            return await _repository.Create(Model);
        }
    }
}