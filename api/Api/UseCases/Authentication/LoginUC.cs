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
            var users = await _repository.GetAll();
            if (Exist(users))
            {
                return JwtSettings.GetJWTToken(_configuration);
            }
            throw new UnauthorizedAccessException("Unauthorized");
        }

        private bool Exist(List<User> users)
        {
            if (users.Find(x => x.Title == Model.Title && x.PasswordHash == BCrypt.Net.BCrypt.HashPassword(Model.PasswordHash)) != null)
            {
                return true;
            }
            return false;
        }
    }
}