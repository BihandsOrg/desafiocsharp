using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Desafio_Bihands.Controllers
{
    /// <summary>
    /// Controlador para autenticação de usuários.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        /// <summary>
        /// Realiza a autenticação do usuário e gera um token JWT.
        /// </summary>
        /// <param name="userLogin">As credenciais de login do usuário.</param>
        /// <returns>Um token JWT se a autenticação for bem-sucedida.</returns>
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLogin userLogin)
        {
            if (userLogin.Username == "string" && userLogin.Password == "string")
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("sAH7tgNKAcnkn&ADkjnaI&AES77y7KJNkjh7sjfnskI&ESfnjkseflihs7ef");
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, userLogin.Username)
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);
                return Ok(new { Token = tokenString });
            }
            return Unauthorized();
        }
    }

    /// <summary>
    /// Representa as credenciais de login do usuário.
    /// </summary>
    public class UserLogin
    {
        /// <summary>
        /// Nome de usuário.
        /// </summary>
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// Senha do usuário.
        /// </summary>
        public string Password { get; set; } = string.Empty;
    }
}
