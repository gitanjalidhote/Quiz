
//using Microsoft.AspNetCore.Mvc;
//using Quiz.Server.DTOs;
//using Quiz.Server.Services;

//namespace Quiz.Server.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class AuthController(AuthenticationService authService) : ControllerBase
//    {
//        private readonly AuthenticationService _authService = authService;




//        [HttpPost("register")]
//        public async Task<IActionResult> Register(RegisterUserDTO registerUserDto)
//        {
//            var result = await _authService.RegisterUserAsync(registerUserDto);
//            if (!result.Success)
//            {
//                return BadRequest(result.Errors);
//            }
//            return Ok(result);
//        }

//        [HttpPost("login")]
//        public async Task<IActionResult> Login(LoginUserDTO loginUserDto)
//        {
//            var (Success, Token, Errors) = await _authService.LoginUserAsync(loginUserDto);
//            if (!Success)
//            {
//                return Unauthorized(Errors);
//            }
//            return Ok(new { token = Token });
//        }
//    }
//}




using Microsoft.AspNetCore.Mvc;
using Quiz.Server.DTOs;
using Quiz.Server.Services;
using System.Threading.Tasks;

namespace Quiz.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthenticationService _authService;

        // Constructor
        public AuthController(AuthenticationService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDTO registerUserDto)
        {
            var result = await _authService.RegisterUserAsync(registerUserDto);
            if (!result.Success)
            {
                return BadRequest(result.Errors);
            }
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO loginUserDto)
        {
            var (Success, Token, Errors) = await _authService.LoginUserAsync(loginUserDto);
            if (!Success)
            {
                return Unauthorized(Errors);
            }
            return Ok(new { token = Token });
        }
    }
}
