using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Api.Repositories
{
    public class UsersRepository : IUsersRepository
    {

        private readonly DbContextOptions _options;
        public UsersRepository(DbContextOptions options)
        {
            _options = options;
        }

        public async Task<List<User>> GetAll()
        {
            using Context context = new(_options);
            return await context.Users.ToListAsync();;
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
            using Context context = new(_options);
            ValidateEMailForCreate(model);
            model.PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.PasswordHash);
            EntityEntry<User> result = context.Users.Add(model);
            _ = await context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<User> Update(int id, User model)
        {
            using Context context = new(_options);
            User user = await GetUserAsync(id);
            ValidateEMailForUpdate(model, user);
            EntityEntry<User> result = context.Users.Update(model);
            _ = await context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<User> Delete(int id)
        {
            using Context context = new(_options);
            User user = await GetUserAsync(id);
            EntityEntry<User> result = context.Users.Remove(user);
            _ = await context.SaveChangesAsync();
            return result.Entity;
        }

        private async Task<User> GetUserAsync(int id)
        {
            using Context context = new(_options);
            User user = await context.Users.FindAsync(id);
            return user ?? throw new KeyNotFoundException("User not found");
        }

        private void ValidateEMailForUpdate(User model, User user)
        {
            using Context context = new(_options);
            if (model.Email != user.Email && context.Users.Any(x => x.Email == model.Email))
            {
                throw new InvalidOperationException("User with the email '" + model.Email + "' already exists");
            }
        }

        private void ValidateEMailForCreate(User model)
        {
            using Context context = new(_options);
            if (context.Users.Any(x => x.Email == model.Email))
            {
                throw new InvalidOperationException("User with the email '" + model.Email + "' already exists");
            }
        }
    }
}