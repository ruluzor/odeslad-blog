using Api.Models;
using Api.Repositories;

namespace Api.UseCases.Users
{
    public class DeleteUserUC : IUseCase<User>
    {

        public IUsersRepository _repository;

        public int Id { get; set; }

        public DeleteUserUC(IUsersRepository repository)
        {
            _repository = repository;
        }

        public async Task<User> Execute()
        {
            return await _repository.Delete(Id);
        }
    }
}