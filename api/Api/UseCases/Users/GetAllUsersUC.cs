using Api.Models;
using Api.Repositories;

namespace Api.UseCases.Users
{
    public class GetAllUsersUC : IUseCase<List<User>>
    {

        public IUsersRepository _repository;

        public GetAllUsersUC(IUsersRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<User>> Execute()
        {
            return await _repository.GetAll();
        }
    }
}