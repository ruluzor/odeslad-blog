using api.Models;

namespace api.Repositories
{
    public interface IUsersRepository
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
        void Create(User model);
        void Update(int id, User model);
        void Delete(int id);
    }
}