using Microsoft.AspNetCore.Mvc;

namespace GestorMultiPessoas.Relatorios.Controllers
{
    [ApiController]
    [Route("api/relatorio")]
    [ApiExplorerSettings(GroupName = "relatorios")]
    public class RelatorioController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            // Implementation
            return Ok();
        }
    }
}
