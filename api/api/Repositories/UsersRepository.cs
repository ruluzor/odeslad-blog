using System.Collections.Generic;
using api.Models;

namespace api.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly Context _context;

        public UsersRepository(Context context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User GetById(int id)
        {
            return GetUser(id);
        }

        public void Create(User model)
        {
            if (_context.Users.Any(x => x.Email == model.Email))
            {
                throw new Exception("User with the email '" + model.Email + "' already exists");
            }
            model.PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.PasswordHash);
            _context.Users.Add(model);
            _context.SaveChanges();
        }

        public void Update(int id, User model)
        {
            var user = GetUser(id);
            if (model.Email != user.Email && _context.Users.Any(x => x.Email == model.Email))
            {
                throw new Exception("User with the email '" + model.Email + "' already exists");
            }
            if (!string.IsNullOrEmpty(model.PasswordHash))
            {
                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.PasswordHash);
            }
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = GetUser(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        private User GetUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found");
            }
            return user;
        }
    }

}