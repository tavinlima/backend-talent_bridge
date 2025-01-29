using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using talentbridge_webAPI.Domains;
using talentbridge_webAPI.Interfaces;
using talentbridge_webAPI.Repositories;
using talentbridge_webAPI.ViewModel;

namespace talentbridge_webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }
        private IEmpresaRepository empresaRepo { get; set; }
        private ICandidatoRepository candidatoRepo { get; set; }

        public LoginController(IUsuarioRepository repo, IEmpresaRepository empresaRepo, ICandidatoRepository candidatoRepo)
        {
            _usuarioRepository = repo;
            this.empresaRepo = empresaRepo;
            this.candidatoRepo = candidatoRepo;
        }

        [HttpPost]
        public async Task<IActionResult> LoginEmpresa(LoginViewModel login)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.Login(login.Email, login.Senha);

                Candidato candidato = await candidatoRepo.GetCandidateByEmail(login.Email);

                Empresa empresa = await empresaRepo.GetEnterpriseByEmail(login.Email);

                if (usuarioBuscado == null)
                {
                    return NotFound("E-mail ou senha inválidos!");
                }

                string role = candidato == null ? "empresa" : "candidato";

                var MinhaClaim = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                    new Claim(JwtRegisteredClaimNames.Name, usuarioBuscado.Nome),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Role, role),
                    new Claim("role", role )
                };
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("sua_chave_secreta_de_32_bytes_de_tamanho_!!!"));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var meuToken = new JwtSecurityToken(
                       issuer: "talentbridge_webapi",
                       audience: "talentbridge_webapi",
                       claims: MinhaClaim,
                       expires: DateTime.Now.AddMinutes(30),
                       signingCredentials: creds
                   );

                return Ok(
                    new
                    {
                        tokenGerado = new JwtSecurityTokenHandler().WriteToken(meuToken)
                    });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
