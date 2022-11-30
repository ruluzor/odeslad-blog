using Api.Models;
using Api.Repositories;
using Api.UseCases.Users;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private IUsersRepository _repository;

        public UsersController(IUsersRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            GetAllUsersUC uc = new(_repository);
            List<User> result = await uc.Execute();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            GetByIdUserUC uc = new(_repository)
            {
                Id = id
            };
            User result = await uc.Execute();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(User model)
        {
            CreateUserUC uc = new(_repository)
            {
                Model = model
            };
            User result = await uc.Execute();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, User model)
        {
            UpdateUserUC uc = new(_repository)
            {
                Model = model,
                Id = id
            };
            User result = await uc.Execute();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            DeleteUserUC uc = new(_repository)
            {
                Id = id
            };
            User result = await uc.Execute();
            return Ok(result);
        }
    }
}