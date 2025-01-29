using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Transactions;
using talentbridge_webAPI.Domains;
using talentbridge_webAPI.Interfaces;
using talentbridge_webAPI.ViewModel;
using TalentBridge_webAPI.data;

namespace talentbridge_webAPI.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly TalentBridgeContext ctx = new();
        private readonly IUsuarioRepository usuarioRepository;
        public EmpresaRepository(TalentBridgeContext ctx, IUsuarioRepository usuarioRepository)
        {
            this.ctx = ctx;
            this.usuarioRepository = usuarioRepository;
        }

        public async Task<Empresa> CreateEnterprise(CadastroEmpresa empresa)
        {
            using (var transaction = await ctx.Database.BeginTransactionAsync())
                try
                {

                    Usuario novoUsuario = await usuarioRepository.CreateUser(empresa.Usuario);

                    Empresa novaEmp = new()
                    {
                        Avaliacao = empresa.Avaliacao,
                        Descricao = empresa.Descricao,
                        Cnpj = empresa.CNPJ,
                        IdUsuario = novoUsuario.IdUsuario
                    };


                    await ctx.Empresas.AddAsync(novaEmp);

                    await ctx.SaveChangesAsync();

                    // Confirmar a transação
                    await transaction.CommitAsync();

                    return novaEmp;

                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new Exception(ex.Message);
                }
        }

        public async Task<String> DeleteEnterprise(string Cnpj)
        {
            Empresa empresaBuscada = await GetEnterpriseByCnpj(Cnpj);
            if (empresaBuscada != null)
            {
                ctx.Remove(empresaBuscada);

                await ctx.SaveChangesAsync();

                return "Empresa excluída com sucesso";
            }
            return "Empresa não encontrada";
        }

        public Task<List<Empresa>> GetAll()
        {
            return ctx.Empresas.AsNoTracking()
                .Include(e => e.IdUsuarioNavigation)
                .Include(e => e.IdUsuarioNavigation.IdEnderecoNavigation)
                .Include(e => e.IdUsuarioNavigation.IdContatoNavigation)
                .ToListAsync();
        }

        public async Task<Empresa> GetEnterpriseByCnpj(string Cnpj)
        {
            return await ctx.Empresas.AsNoTracking()
                .Include(e => e.IdUsuarioNavigation)
                .Include(e => e.IdUsuarioNavigation).ThenInclude(u=> u.IdEnderecoNavigation)
                .Include(e => e.IdUsuarioNavigation).ThenInclude(u => u.IdContatoNavigation)
                .FirstOrDefaultAsync(e => e.Cnpj == Cnpj);
        }

        public async Task<Empresa> GetEnterpriseByEmail(string email)
        {
            return await ctx.Empresas.AsNoTracking()
                .Include(e => e.IdUsuarioNavigation)
                .Include(e => e.IdUsuarioNavigation.IdEnderecoNavigation)
                .Include(e => e.IdUsuarioNavigation.IdContatoNavigation)
                .FirstOrDefaultAsync(e => e.IdUsuarioNavigation.Email == email);
        }

        public async Task<Empresa> UpdateEnterprise(CadastroEmpresa empresa)
        {
            using (var transaction = await ctx.Database.BeginTransactionAsync())
                try
                {

                    Usuario novoUsuario = await usuarioRepository.UpdateUser(empresa.Usuario);

                    Empresa empresaBuscada = await GetEnterpriseByCnpj(empresa.CNPJ);

                    decimal? avaliacao = empresa.Avaliacao ?? empresaBuscada.Avaliacao;
                    string descricao = empresa.Descricao ?? empresaBuscada.Descricao;
                    string Cnpj = empresa.CNPJ ?? empresaBuscada.Cnpj;

                    Empresa novaEmp = new()
                    {
                        Avaliacao = avaliacao,
                        Descricao = descricao,
                        Cnpj = Cnpj,
                        IdUsuario = empresaBuscada.IdUsuario
                    };


                    ctx.Empresas.Update(novaEmp);

                    await ctx.SaveChangesAsync();

                    // Confirmar a transação
                    await transaction.CommitAsync();

                    return novaEmp;

                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new Exception(ex.Message);
                }
        }
    }
}
