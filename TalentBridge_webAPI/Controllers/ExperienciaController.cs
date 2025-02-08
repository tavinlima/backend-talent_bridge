using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using talentbridge_webAPI.Interfaces;

namespace TalentBridge_webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienciaController : ControllerBase
    {
        private IExperienciaRepository expRepo {  get; set; }
        public ExperienciaController(IExperienciaRepository expRepo)
        {
            this.expRepo = expRepo;
        }

        [HttpGet("{cpf}")]
        public async Task<IActionResult> GetByCpf(string cpf)
        {
            try
            {
                return Ok(await expRepo.GetByCpf(cpf));
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
    }
}
