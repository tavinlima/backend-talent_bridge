using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using talentbridge_webAPI.Interfaces;
using talentbridge_webAPI.ViewModel;

namespace talentbridge_webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private IEmpresaRepository empresaRepo {get; set;}
        public EmpresaController(IEmpresaRepository repo)
        {
            empresaRepo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEnterprise([FromForm] CadastroEmpresa empresa)
        {
            try
            {
                return Ok(await empresaRepo.CreateEnterprise(empresa));
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
    }
}
