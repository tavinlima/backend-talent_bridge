using Microsoft.EntityFrameworkCore;
using talentbridge_webAPI.Domains;
using talentbridge_webAPI.Interfaces;
using TalentBridge_webAPI.data;

namespace talentbridge_webAPI.Repositories
{
    public class ProjetoRepository : IProjetoRepository
    {
        private readonly TalentBridgeContext ctx = new();
        private readonly ICandidatoRepository candidatoRepository;
        public ProjetoRepository(TalentBridgeContext ctx, ICandidatoRepository candidatoRepository)
        {
            this.ctx = ctx;
            this.candidatoRepository = candidatoRepository;
        }
        public Projeto Create(Projeto projeto)
        {
            ctx.Projetos.Add(projeto);
            ctx.SaveChanges();

            return projeto;
        }

        public async Task<string> Delete(int Id)
        {
            Projeto projeto = await GetProjeto(Id);

            if (projeto != null)
            {
                ctx.Projetos.Remove(projeto);
                await ctx.SaveChangesAsync();

                return "Projeto deletada com sucesso!";
            }

            return "Não foi possível apagar o projeto.";
        }

        public async Task<List<Projeto>> GetByCpf(string cpf)
        {
            return await ctx.Projetos.Include(e => e.CpfNavigation).ThenInclude(e => e.IdUsuarioNavigation).Where(e => e.Cpf == cpf).ToListAsync();
        }

        public async Task<Projeto> GetProjeto(int id)
        {
            return await ctx.Projetos.Include(e => e.CpfNavigation).ThenInclude(e => e.IdUsuarioNavigation).FirstOrDefaultAsync(e => e.IdProjeto == id);
        }
    }
}
