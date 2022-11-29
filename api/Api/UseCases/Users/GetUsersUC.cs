using Api.Models;
using Api.Repositories;

namespace Api.UseCases.Users
{
    public class GetUsersUC : IUseCase<List<User>>
    {

        public IUsersRepository _repository;

        public GetUsersUC(IUsersRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<User>> Execute()
        {
            return await _repository.GetAll();
        }
    }
}