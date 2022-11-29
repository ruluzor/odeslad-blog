using Api.Models;

namespace Api.Repositories
{
    public interface IUsersRepository
    {
        Task<List<User>> GetAll();
        Task<User> GetById(int id);
        Task<User> Create(User model);
        Task<User> Update(int id, User model);
        Task<User> Delete(int id);
    }
}