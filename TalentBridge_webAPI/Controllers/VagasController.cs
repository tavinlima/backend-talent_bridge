using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using talentbridge_webAPI.Interfaces;
using talentbridge_webAPI.ViewModel;
using TalentBridge_webAPI.ViewModel;

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

        [HttpGet("{cnpj}")]
        public async Task<IActionResult> GetByCnpj(string cnpj)
        {
            try
            {
                return Ok(await vagaRepo.GetByCNPJ(cnpj));
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpPatch("{idVaga}")]
        [Authorize(Roles = "empresa")]
        public async Task<IActionResult> darFeedback(int idVaga)
        {
            try
            {
                return Ok(await vagaRepo.UpdateSituation(idVaga));
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CadastroVagasViewModel vaga)
        {
            try
            {
                //Inserir validação para tirar pontos e verificar se é valido
                return Ok(await vagaRepo.Create(vaga));
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
    }
}
