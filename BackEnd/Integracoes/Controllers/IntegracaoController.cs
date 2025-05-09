using Microsoft.AspNetCore.Mvc;

namespace GestorMultiPessoas.Integracoes.Controllers
{
    [ApiController]
    [Route("api/integracao")]
    [ApiExplorerSettings(GroupName = "integracoes")]
    public class IntegracaoController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            // Implementation
            return Ok();
        }
    }
}
