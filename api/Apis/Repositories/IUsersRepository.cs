using Api.Models;

namespace Api.Repositories
{
    public interface IUsersRepository
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
        User Create(User model);
        User Update(int id, User model);
        void Delete(int id);
    }
}