﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using talentbridge_webAPI.Domains;
using talentbridge_webAPI.Interfaces;

namespace talentbridge_webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatoController : ControllerBase
    {
        private ICandidatoRepository candidatoRepo { get; set; }

        public CandidatoController(ICandidatoRepository repo)
        {
            candidatoRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await candidatoRepo.GetAll());
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpGet("{cpf}")]
        public async Task<IActionResult> GetByCpf(string cpf)
        {
            try
            {
                Candidato userFound = await candidatoRepo.GetCandidateByCpf(cpf);
                
                return Ok(userFound);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
