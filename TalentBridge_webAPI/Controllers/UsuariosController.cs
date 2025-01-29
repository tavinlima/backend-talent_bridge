using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using talentbridge_webAPI.Domains;
using talentbridge_webAPI.Interfaces;
using talentbridge_webAPI.ViewModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace talentbridge_webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository usuarioRepository { get; set; }

        public UsuariosController(IUsuarioRepository repo)
        {
            usuarioRepository = repo;
        }

        // GET: api/Usuarios
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(usuarioRepository.GetAll());
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
            
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> Delete(string email)
        {
            try
            {
                await usuarioRepository.Delete(email);

                return Ok("Usuário excluída com sucesso!");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

    }
}
