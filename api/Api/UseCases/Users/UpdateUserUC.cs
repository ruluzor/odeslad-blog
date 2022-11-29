using Api.Models;
using Api.Repositories;

namespace Api.UseCases.Users
{
    public class UpdateUserUC : IUseCase<User>
    {

        public IUsersRepository _repository;

        public int Id { get; set; }
        public User Model { get; set; }

        public UpdateUserUC(IUsersRepository repository)
        {
            _repository = repository;
        }

        public async Task<User> Execute()
        {
            return await _repository.Update(Id, Model);
        }
    }
}