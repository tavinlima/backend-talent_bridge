using talentbridge_webAPI.data;
using talentbridge_webAPI.Domains;
using talentbridge_webAPI.Interfaces;
using talentbridge_webAPI.ViewModel;

namespace talentbridge_webAPI.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        readonly TalentBridgeContext ctx = new();
        readonly IUsuarioRepository usuarioRepository;
        public EmpresaRepository (TalentBridgeContext ctx, IUsuarioRepository usuarioRepo)
        {
            this.ctx = ctx;
            this.usuarioRepository = usuarioRepo;
        }

        public async Task<Empresa> CreateEnterprise(CadastroEmpresa empresa)
        {
            
            try
            {

                Usuario novoUsuario = await usuarioRepository.CreateUser(empresa.Usuario, transaction);

                Empresa novaEmp = new()
                {
                    Avaliacao = empresa.Avaliacao,
                    Descricao = empresa.Descricao,
                    Cnpj = empresa.CNPJ,
                    IdUsuario = novoUsuario.IdUsuario
                };
                

                await ctx.Empresas.AddAsync(novaEmp);

                await ctx.SaveChangesAsync();


                return novaEmp;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteEnterprise(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Empresa>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Empresa> GetEnterpriseByCnpj(string Cnpj)
        {
            throw new NotImplementedException();
        }

        public Task<Empresa> UpdateEnterprise(Empresa empresa)
        {
            throw new NotImplementedException();
        }
    }
}
