using Microsoft.AspNetCore.Mvc;
using Northwind_Backend.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Northwind_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            this.authRepository = authRepository;
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> Login(Credentials creds)
        {
            try
            {
                var userExists = authRepository.IsUsernameTakenAsync(creds.Username);
                if (!userExists)
                {
                    var user = await authRepository.LoginAsync(creds);
                    if (user != null)
                        return Ok(user);
                    return BadRequest("incorrect password");
                }

                return BadRequest("user doesn't exist");
            }
            catch (Exception ex)
            {
                return BadRequest("try again later");
            }
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(User user)
        {
            var userExists = authRepository.IsUsernameTakenAsync(user.Username);
            if (userExists)
            {
                var addedUser = await authRepository.RegisterUserAsync(user);
                if (addedUser)
                    return Ok(user);

                return BadRequest("server error try again later");
            }
            return BadRequest("username already exists");
        }

    }
}
