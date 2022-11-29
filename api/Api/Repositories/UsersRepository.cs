using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly Context _context;

        public UsersRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.Users.ToListAsync();;
        }

        public async Task<User> GetById(int id)
        {
            try
            {
                return await GetUserAsync(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<User> Create(User model)
        {
            ValidateEMailForCreate(model);
            model.PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.PasswordHash);
            var result = _context.Users.Add(model);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<User> Update(int id, User model)
        {
            var user = await GetUserAsync(id);
            ValidateEMailForUpdate(model, user);
            if (!string.IsNullOrEmpty(model.PasswordHash))
            {
                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.PasswordHash);
            }
            var result = _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<User> Delete(int id)
        {
            var user = await GetUserAsync(id);
            var result =_context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return result.Entity;

        }

        private async Task<User> GetUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
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