using Microsoft.AspNetCore.Mvc;

namespace GestorMultiPessoas.Cadastros.Controllers
{
    [ApiController]
    [Route("api/cadastro")]
    [ApiExplorerSettings(GroupName = "cadastros")]
    public class CadastroController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            // Implementation
            return Ok();
        }
    }
}
