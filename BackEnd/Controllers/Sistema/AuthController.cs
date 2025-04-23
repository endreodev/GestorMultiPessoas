using GestorMultiPessoas.Dto.Sistema;
using GestorMultiPessoas.Repository.Cadastro;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using GestorMultiPessoas.Model.Acessos;


namespace GestorMultiPessoas.Controllers.Sistema
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController(IConfiguration configuration, UsuarioRepository repository) : ControllerBase
    {

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthDto login)
        {
            var usuario = await repository.GetByEmailAsync(login.Email);
            if (usuario == null || !BCrypt.Net.BCrypt.Verify(login.Senha, usuario.SenhaHash))
                return Unauthorized("Usuário ou senha inválidos");

            var token = GenerateJwtToken(usuario);
            return Ok(new { token });
        }

        private string GenerateJwtToken(Usuario usuario)
        {
            var key = Encoding.ASCII.GetBytes(configuration["JwtSettings:Secret"]??"");

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                [
                    new Claim(ClaimTypes.Name, usuario.Nome),
                    new Claim(ClaimTypes.Email, usuario.Email),
                    new Claim(ClaimTypes.Role, usuario.Role)
                ]),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
