using GestorMultiPessoas.Model.Acessos;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GestorMultiPessoas.Service.Sistema
{

    public class AuthService
    {
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateJwtToken(Usuario usuario)
        {
            // 🔹 Obtendo a chave secreta do appsettings.json
            var secretKey = _configuration["JwtSettings:Secret"];
            if (string.IsNullOrEmpty(secretKey) || secretKey.Length < 32)
            {
                throw new Exception("Chave JWT inválida. Certifique-se de que está configurada corretamente.");
            }

            var key = Encoding.ASCII.GetBytes(secretKey);
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Name, usuario.Nome),
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim(ClaimTypes.Role, usuario.Role)
            }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}