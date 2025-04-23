using GestorMultiPessoas.Model.Cadastro;
using GestorMultiPessoas.Repository.Cadastro;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace GestorMultiPessoas.Controllers.Cadastro
{

    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioRepository _repository;

        public FuncionarioController(IFuncionarioRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Funcionario>>> GetFuncionarios()
        {
            return Ok(await _repository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Funcionario>> GetFuncionario(Guid id)
        {
            var funcionario = await _repository.GetByIdAsync(id);
            if (funcionario == null) return NotFound();
            return Ok(funcionario);
        }

        [HttpPost]
        public async Task<IActionResult> PostFuncionario(Funcionario funcionario)
        {
            await _repository.AddAsync(funcionario);
            return CreatedAtAction(nameof(GetFuncionario), new { id = funcionario.FuncionarioId }, funcionario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFuncionario(Guid id, Funcionario funcionario)
        {
            if (id != funcionario.FuncionarioId) return BadRequest();
            await _repository.UpdateAsync(funcionario);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFuncionario(Guid id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }


}
