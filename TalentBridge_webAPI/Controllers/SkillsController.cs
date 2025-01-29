using Microsoft.AspNetCore.Mvc;
using talentbridge_webAPI.Interfaces;


namespace talentbridge_webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private ISkillRepository skillRepository {  get; set; }

        public SkillsController(ISkillRepository skillRepository)
        {
            this.skillRepository = skillRepository;
        }

        // POST: api/Skills
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostSkill([FromForm] string cpf, [FromForm] string titulo, [FromForm] string descricao)
        {
            try
            {
                skillRepository.Create(cpf, titulo, descricao);

                return StatusCode(201, "Skill cadastrada com sucesso!");

                
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
            
        }

        
    }
}
