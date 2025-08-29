// // here we will geanerate and send it as response with the some token value


// using Microsoft.AspNetCore.Mvc;
// using Microsoft.IdentityModel.Tokens;
// using System.IdentityModel.Tokens.Jwt;
// using System.Security.Claims;
// using System.Text;
// using JwtOnlyDemo.Models;

// namespace JwtOnlyDemo.Controllers
// {
//     public class JwtController : ControllerBase
//     {
//         private readonly IConfiguration _configuration;

//         public JwtController(IConfiguration configuration)
//         {
//             _configuration = configuration;
//         }

//         [HttpPost]
//         public IActionResult GenerateToken([FromBody] UserModel user)
//         {
//             if (user == null || string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
//             {
//                 return BadRequest("Invalid client request");
//             }

//             // Validate the user credentials (this is just a simple example, implement your own logic)
//             if (user.Email == "test" && user.Password == "password")
//             {
//                 var token = GenerateJwtToken(user);
//                 return Ok(new { token });
//             }

//             return Unauthorized();
//         }

//         private string GenerateJwtToken(UserModel user)
//         {
//             var claims = new[]
//             {
//                 new Claim(JwtRegisteredClaimNames.Sub, user.Email),
//                 new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
//             };

//             var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
//             var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

//             var token = new JwtSecurityToken(
//                 issuer: _configuration["Jwt:Issuer"],
//                 audience: _configuration["Jwt:Audience"],
//                 claims: claims,
//                 expires: DateTime.Now.AddMinutes(30),
//                 signingCredentials: creds);

//             return new JwtSecurityTokenHandler().WriteToken(token);
//         }
//     }
// }
// using JwtAuthentication.Models
using JwtOnlyDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtAuthentication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JwtController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public JwtController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
// To get this for /api/jwt
        [HttpPost]
        public IActionResult GenerateToken([FromBody] UserModel userModel)
        {
            if (userModel == null || string.IsNullOrEmpty(userModel.Email) || string.IsNullOrEmpty(userModel.Password))
            {
                return BadRequest("Invalid client request");
            }
            // Validate the user credentials (this is just a simple example, in a real application you would check the credentials against a database)
            // if (userModel.Email == "test@example.com" && userModel.Password == "password")
            // {
            //     var token = GenerateJwtToken(userModel);
            //     return Ok(new { token });
            // }

            var token = GenerateJwtToken(userModel);
            return Ok(new { token });
        }
    
        private string GenerateJwtToken(UserModel userModel)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userModel.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}


