namespace GestorMultiPessoas.Controllers.Cadastro
{
    using GestorMultiPessoas.Model.Cadastro;
    using GestorMultiPessoas.Repository.Cadastro;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class BeneficioController : ControllerBase
    {
        private readonly IBeneficioRepository _repository;

        public BeneficioController(IBeneficioRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Beneficio>>> GetBeneficios()
        {
            return Ok(await _repository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Beneficio>> GetBeneficio(Guid id)
        {
            var beneficio = await _repository.GetByIdAsync(id);
            if (beneficio == null) return NotFound();
            return Ok(beneficio);
        }

        [HttpPost]
        public async Task<IActionResult> PostBeneficio(Beneficio beneficio)
        {
            await _repository.AddAsync(beneficio);
            return CreatedAtAction(nameof(GetBeneficio), new { id = beneficio.BeneficioId }, beneficio);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBeneficio(Guid id, Beneficio beneficio)
        {
            if (id != beneficio.BeneficioId) return BadRequest();
            await _repository.UpdateAsync(beneficio);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBeneficio(Guid id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }

}
