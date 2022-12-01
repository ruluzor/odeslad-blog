using System.Text;
using Api.Models;
using Api.Repositories;

namespace Api.UseCases.Users
{
    public class LoginUC : IUseCase<string>
    {

        public readonly IUsersRepository _repository;
        public readonly IConfiguration _configuration;

        public User Model { get; set; }

        public LoginUC(IUsersRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        public async Task<string> Execute()
        {
            User user = GetExistingUser(await _repository.GetAll());
            if (user != null)
            {
                return JwtSettings.GetJWTToken(_configuration, user);
            }
            throw new UnauthorizedAccessException("Unauthorized");
        }

        private User GetExistingUser(List<User> users)
        {
            User user = users.Find(x => x.Title == Model.Title && BCrypt.Net.BCrypt.Verify(Model.PasswordHash, x.PasswordHash));
            return user ?? null;
        }
    }
}