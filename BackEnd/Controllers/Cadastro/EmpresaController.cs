
using GestorMultiPessoas.Model.Cadastro;
using GestorMultiPessoas.Repository.Cadastro;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestorMultiPessoas.Controllers.Cadastro
{
    [Route("api/empresas")]
    [ApiController]
    public class EmpresaController(EmpresaRepository repository) : ControllerBase
    {
        private readonly EmpresaRepository _repository = repository;

        // 🔹 Retorna todas as empresas
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var empresas = await _repository.GetAllAsync();
            return Ok(empresas);
        }

        // 🔹 Retorna uma empresa específica pelo ID
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var empresa = await _repository.GetByIdAsync(id);
            return empresa == null ? NotFound() : Ok(empresa);
        }

        // 🔹 Cria uma nova empresa
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Empresa empresa)
        {
            if (empresa == null)
                return BadRequest("Dados inválidos");

            await _repository.AddAsync(empresa);
            return CreatedAtAction(nameof(GetById), new { id = empresa.EmpresaId }, empresa);
        }

        // 🔹 Atualiza uma empresa existente
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Empresa empresa)
        {
            if (empresa == null || id != empresa.EmpresaId)
                return BadRequest("Dados inválidos");

            var existingEmpresa = await _repository.GetByIdAsync(id);
            if (existingEmpresa == null)
                return NotFound();

            await _repository.UpdateAsync(empresa);
            return NoContent();
        }

        // 🔹 Remove uma empresa pelo ID
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
