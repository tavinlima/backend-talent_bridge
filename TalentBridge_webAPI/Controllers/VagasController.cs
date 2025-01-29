using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using talentbridge_webAPI.Interfaces;

namespace talentbridge_webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class VagasController : ControllerBase
    {
        private IVagaRepository vagaRepo { get; set; }
        public VagasController(IVagaRepository repo)
        {
            vagaRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await vagaRepo.GetAll());
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
    }
}
