using ClientManagement.Domain.UserAgg;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UniversityService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("{userName}/{password}")]
        public IActionResult Post(string userName, string password)
        {
            var token = _userRepository.LoginUser(userName, password);
            return Ok(token);
        }
    }
}
