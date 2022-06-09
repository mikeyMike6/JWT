using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using jwt_token.DTOs;
using jwt_token.Exceptions;

namespace jwt_token.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly UserRepository _userRepository;
        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [Authorize]
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_userRepository.GetAll());
        }
        [HttpPost("LoginAndGetJWT")]
        public IActionResult Login(LoginUserDTO loginUser)
        {
            if(_userRepository.Exists(loginUser.UserName))
            {
                if(_userRepository.CredentialAreCorrect(loginUser.UserName, loginUser.Password))
                {
                    var jwtTokenGenerator = new JwtTokenGenerator();
                    var token = jwtTokenGenerator.Generate(loginUser.UserName, loginUser.Password);
                    return Ok(token);
                }
            }
            return NotFound();
        }
        [HttpPost("Add")]
        public IActionResult Add(AddUserDTO addUser)
        {
            if (_userRepository.Exists(addUser.UserName))
                throw new UserAlreadyExistsException(addUser.UserName);

            var user = new User(addUser.UserName, addUser.Role, addUser.Password);
            _userRepository.Add(user);
            return Ok();
        }
    }
}
