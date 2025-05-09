using Microsoft.AspNetCore.Mvc;

namespace GestorMultiPessoas.Folha.Controllers
{
    [ApiController]
    [Route("api/folha")]
    [ApiExplorerSettings(GroupName = "folha")]
    public class FolhaController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            // Implementation
            return Ok();
        }
    }
}
