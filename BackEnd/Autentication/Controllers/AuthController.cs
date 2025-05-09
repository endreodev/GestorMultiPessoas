using GestorMultiPessoas.Autentication.Dto;
using GestorMultiPessoas.Autentication.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestorMultiPessoas.Autentication.Controllers
{
    [ApiController]
    [Route("api/auth")]
    [ApiExplorerSettings(GroupName = "auth")]
    public class AuthController : ControllerBase
    {
        private readonly TokenService _tokenService;

        public AuthController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            // Validate user credentials (this is a placeholder, replace with actual validation logic)
            if (loginDto.Email == "user@example.com" && loginDto.Senha == "password")
            {
                var token = _tokenService.GenerateToken(loginDto.Email, "User");
                return Ok(new { Token = token });
            }

            return Unauthorized("Credenciais inválidas.");
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterDto registerDto)
        {
            // Placeholder for user registration logic
            return Ok("Usuário registrado com sucesso.");
        }
    }
}
