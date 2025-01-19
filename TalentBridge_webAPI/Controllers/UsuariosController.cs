using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using talentbridge_webAPI.Domains;
using talentbridge_webAPI.data;
using talentbridge_webAPI.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace talentbridge_webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuariosController(IUsuarioRepository repo)
        {
            _usuarioRepository = repo;
        }

        // GET: api/Usuarios
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_usuarioRepository.GetAll());
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
            
        }

    }
}
