namespace GestorMultiPessoas.Controllers.Cadastro
{
    using GestorMultiPessoas.Model.Cadastro;
    using GestorMultiPessoas.Repository.Cadastro;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class SalarioController : ControllerBase
    {
        private readonly ISalarioRepository _repository;

        public SalarioController(ISalarioRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Salario>>> GetSalarios()
        {
            return Ok(await _repository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Salario>> GetSalario(Guid id)
        {
            var salario = await _repository.GetByIdAsync(id);
            if (salario == null) return NotFound();
            return Ok(salario);
        }

        [HttpPost]
        public async Task<IActionResult> PostSalario(Salario salario)
        {
            await _repository.AddAsync(salario);
            return CreatedAtAction(nameof(GetSalario), new { id = salario.SalarioId }, salario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalario(Guid id, Salario salario)
        {
            if (id != salario.SalarioId) return BadRequest();
            await _repository.UpdateAsync(salario);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalario(Guid id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }

}
