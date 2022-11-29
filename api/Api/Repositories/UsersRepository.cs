using Api.Models;

namespace Api.Repositories
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
            try
            {
                return GetUser(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public User Create(User model)
        {
            ValidateEMailForCreate(model);
            model.PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.PasswordHash);
            var result = _context.Users.Add(model);
            _context.SaveChanges();
            return result.Entity;
        }

        public User Update(int id, User model)
        {
            var user = GetUser(id);
            ValidateEMailForUpdate(model, user);
            if (!string.IsNullOrEmpty(model.PasswordHash))
            {
                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.PasswordHash);
            }
            var result = _context.Users.Update(user);
            _context.SaveChanges();
            return result.Entity;
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

        private void ValidateEMailForUpdate(User model, User user)
        {
            if (model.Email != user.Email && _context.Users.Any(x => x.Email == model.Email))
            {
                throw new Exception("User with the email '" + model.Email + "' already exists");
            }
        }

        private void ValidateEMailForCreate(User model)
        {
            if (_context.Users.Any(x => x.Email == model.Email))
            {
                throw new Exception("User with the email '" + model.Email + "' already exists");
            }
        }
    }

}