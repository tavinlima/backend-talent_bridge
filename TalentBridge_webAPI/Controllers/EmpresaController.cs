﻿using Microsoft.AspNetCore.Mvc;
using talentbridge_webAPI.Interfaces;
using talentbridge_webAPI.ViewModel;

namespace talentbridge_webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private IEmpresaRepository empresaRepo { get; set; }
        public EmpresaController(IEmpresaRepository repo)
        {
            empresaRepo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEnterprise([FromForm] CadastroEmpresa empresa)
        {
            try
            {
                //Inserir validação para tirar pontos e verificar se é valido
                return Ok(await empresaRepo.CreateEnterprise(empresa));
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await empresaRepo.GetAll());
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
                return Ok(await empresaRepo.GetEnterpriseByCnpj(cnpj));
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] CadastroEmpresa empresa)
        {
            try
            {
                await empresaRepo.UpdateEnterprise(empresa);

                return Ok("Empresa atualizada com sucesso!");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
    }
}
