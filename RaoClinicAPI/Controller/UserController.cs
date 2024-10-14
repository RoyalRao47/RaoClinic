using RaoClinicAPI.Database;
using Microsoft.AspNetCore.Mvc;
using RaoClinicAPI.DbTable;
using RaoClinicAPI.Service;
using Microsoft.AspNetCore.Authorization;
using RaoClinicAPI.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RaoClinicAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IUserService _userService;
         private readonly IConfiguration _configuration;

        public UserController(DataContext context, IUserService userService, IConfiguration configuration)
        {
            _context = context;
            _userService = userService;
             _configuration = configuration;
        }

        [HttpGet("GetAllUsers")]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            return _userService.GetUserList();
        }
        [HttpGet("GetUserById")]
        public ActionResult<User> GetUserById(int userId)
        {
            return _userService.GetUserById(userId);
        }

        [HttpPost("SaveUser")]
        public IActionResult SaveUser(User user)
        {
            try
            {
                _userService.SaveUser(user);
                return Ok(new { status = true, message = "ThankYou" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel login)
        {
            var user = _userService.CheckLoginUser(login);
            if (user != null)
            {
                var tokenString = GenerateJWTToken(user);
                return Ok(new { status = true , userId = user.UserID, userType = user.UserTypeId, Token = tokenString });
            }

            return Ok(new { status = false, message = "Chala Ja B..K" });
        }

        private string GenerateJWTToken(User user)
        {
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]);
            var issuer = _configuration["Jwt:Issuer"].ToString();
            var audience = _configuration["Jwt:Audience"].ToString();
            var securityKey = new SymmetricSecurityKey(key);
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.UserID.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.UserTypeId.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        

    }
}