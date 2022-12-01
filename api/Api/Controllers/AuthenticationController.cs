using System.Security.Claims;
using System.Text;
using Api.Models;
using Api.Repositories;
using Api.UseCases.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : Controller
    {
        private readonly IUsersRepository _repository;
        private readonly IConfiguration _configuration;

        public AuthenticationController(IUsersRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(User model)
        {
            try
            {
                LoginUC uc = new(_repository, _configuration)
                {
                    Model = model
                };
                string result = await uc.Execute();
                return Ok(result);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}