using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FairBankApi.Models;
using FairBankApi.Services.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace FairBank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IUserService _userService;
        private readonly ILogger<UsersController> _logger;
        private readonly IConfiguration _configuration;


        public UsersController(IUserService userService, ILogger<UsersController> logger, IConfiguration configuration)
        {
            _userService = userService;
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> GetUsers()
        {
            _logger.LogInformation("GetUsers method called.");
            var users = await _userService.GetUsers();

            return Ok(users);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
            var user = await _userService.GetUser(id);
            if (user == null)
            {
                return NotFound("User not found");
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> RegisterUser([FromBody] UserDto user)
        {
            var userResult = await _userService.CreateUser(user);
           

            if (userResult is null)
            {
                return NotFound("User not found");
            }
            return Ok(userResult);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<UserDto>> UpdateUser(UserDto request)
        {
            var user = await _userService.UpdateUser(request);

            if (user is null)
            {
                return NotFound("User not found");
            }

            return Ok(user);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserDto>> DeleteUser(int id)
        {

            var user = await _userService.DeleteUser(id);
            if (user is null)
            {
                return NotFound("User not found");
            }
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginDto login)
        {
            var user = await _userService.GetUserByUsername(login.Username);
            if (user is null)
            {
                return NotFound("User not found.");
            }
            var verifyLogin = await _userService.Login(user, login.Password);
            if (!verifyLogin)
            {
                return BadRequest("Wrong credentials");
            }
            string token = CreateToken(login);
            return Ok(token);
        }

        private string CreateToken(LoginDto login)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Name, login.Username),
                //new Claim(claimTypes.Role, "Admin")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Key").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
    }