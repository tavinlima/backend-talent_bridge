using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using talentbridge_webAPI.Interfaces;
using talentbridge_webAPI.ViewModel;

namespace talentbridge_webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AplicacaoController : ControllerBase
    {
        private IAplicacaoRepository aplicacaoRepo { get; set; }
        public AplicacaoController(IAplicacaoRepository repo) 
        {
            aplicacaoRepo = repo;
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        [Authorize(Roles ="candidato")]
        public async Task<IActionResult> SeCandidatar([FromForm] CandidaturaViewModel candidatura)
        {
            try
            {
                return Ok(await aplicacaoRepo.Create(candidatura));
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpPatch]
        //[Authorize(Roles = "candidato")]
        public async Task<IActionResult> darFeedback(int idAplicacao, string feeback)
        {
            try
            {
                return Ok(await aplicacaoRepo.AdicionarFeedback(idAplicacao, feeback));
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
    }
}
