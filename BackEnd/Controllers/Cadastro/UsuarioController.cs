using GestorMultiPessoas.Model.Acessos;
using GestorMultiPessoas.Repository.Cadastro;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestorMultiPessoas.Controllers.Cadastro
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuarioController(UsuarioRepository repository) : ControllerBase
    {

        // 🔹 Retorna todos os usuários (apenas admin)
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var usuarios = await repository.GetAllAsync();
            return Ok(usuarios);
        }

        // 🔹 Retorna um usuário pelo ID
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var usuario = await repository.GetByIdAsync(id);
            return usuario == null ? NotFound() : Ok(usuario);
        }

        // 🔹 Cria um novo usuário (não requer autenticação)
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Usuario usuario)
        {
            if (usuario == null)
                return BadRequest("Dados inválidos");

            var existingUser = await repository.GetByEmailAsync(usuario.Email);
            if (existingUser != null)
                return BadRequest("Já existe um usuário com esse email.");

            await repository.AddAsync(usuario);
            return CreatedAtAction(nameof(GetById), new { id = usuario.Id }, usuario);
        }

        // 🔹 Atualiza um usuário (somente o próprio usuário ou admin)
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Usuario usuario)
        {
            if (usuario == null || id != usuario.Id)
                return BadRequest("Dados inválidos");

            var existingUser = await repository.GetByIdAsync(id);
            if (existingUser == null)
                return NotFound();

            await repository.UpdateAsync(usuario);
            return NoContent();
        }

        // 🔹 Remove um usuário (apenas admin)
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await repository.DeleteAsync(id);
            return NoContent();
        }
    }
}