using Microsoft.EntityFrameworkCore;
using talentbridge_webAPI.Domains;
using talentbridge_webAPI.Interfaces;
using TalentBridge_webAPI.data;

namespace talentbridge_webAPI.Repositories
{
    public class EscolaridadeRepository : IEscolaridadeRepository
    {
        private readonly TalentBridgeContext ctx = new();
        private readonly ICandidatoRepository candidatoRepository;
        public EscolaridadeRepository(TalentBridgeContext ctx, ICandidatoRepository candidatoRepository)
        {
            this.ctx = ctx;
            this.candidatoRepository = candidatoRepository;
        }
        public Escolaridade Create(Escolaridade escolaridade)
        {
            ctx.Escolaridades.Add(escolaridade);
            ctx.SaveChanges();

            return escolaridade;
        }

        public async Task<string> Delete(int Id)
        {
            Escolaridade escolaridade = await GetEscolaridade(Id);

            if (escolaridade != null)
            {
                ctx.Escolaridades.Remove(escolaridade);
                await ctx.SaveChangesAsync();

                return "Escolaridade deletada com sucesso!";
            }

            return "Não foi possível apagar a escolaridade.";
        }

        public async Task<List<Escolaridade>> GetByCpf(string cpf)
        {
            return await ctx.Escolaridades.Include(e => e.CpfNavigation).ThenInclude(e => e.IdUsuarioNavigation).Where(e => e.Cpf == cpf).ToListAsync();
        }

        public async Task<Escolaridade> GetEscolaridade(int id)
        {
            return await ctx.Escolaridades.Include(e => e.CpfNavigation).ThenInclude(e => e.IdUsuarioNavigation).FirstOrDefaultAsync(e => e.IdEscolaridade == id);
        }
    }
}
