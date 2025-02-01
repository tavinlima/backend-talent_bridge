using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using talentbridge_webAPI.Domains;
using talentbridge_webAPI.Interfaces;
using talentbridge_webAPI.Repositories;

namespace TalentBridge_webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class IdiomasController : ControllerBase
    {
        private IIdiomaRepository repo {  get; set; }
        public IdiomasController(IIdiomaRepository repo) { 
            this.repo = repo;
        }

        [HttpPost]
        public IActionResult PostIdioma(string CPF, string fluencia, string idioma)
        {
            try
            {
                repo.Create(CPF, fluencia, idioma);

                return StatusCode(201, "Idioma cadastrado com sucesso!");


            }
            catch (Exception error)
            {
                return BadRequest(error);
            }

        }
    }
}
