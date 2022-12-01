using System.Security.Claims;
using System.Text;
using Api.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

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
        [HttpGet("login")]
        public IActionResult Login()
        {
            return Ok(JwtSettings.GetJWTToken(_configuration));
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            return Ok("logout ok");
        }
    }
}