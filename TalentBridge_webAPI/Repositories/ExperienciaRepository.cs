using Microsoft.EntityFrameworkCore;
using talentbridge_webAPI.Domains;
using talentbridge_webAPI.Interfaces;
using TalentBridge_webAPI.data;

namespace talentbridge_webAPI.Repositories
{
    public class ExperienciaRepository : IExperienciaRepository
    {
        private readonly TalentBridgeContext ctx = new();
        private readonly ICandidatoRepository candidatoRepository;
        public ExperienciaRepository(TalentBridgeContext ctx, ICandidatoRepository candidatoRepository)
        {
            this.ctx = ctx;
            this.candidatoRepository = candidatoRepository;
        }
        public Experiencium Create(Experiencium experiencium)
        {
            ctx.Experiencia.Add(experiencium);
            ctx.SaveChanges();

            return experiencium;
        }

        public async Task<string> Delete(int Id)
        {
            Experiencium experiencia = await GetExperiencia(Id);

            if (experiencia != null)
            {
                ctx.Experiencia.Remove(experiencia);
                await ctx.SaveChangesAsync();

                return "Experiencia deletada com sucesso!";
            }

            return "Não foi possível apagar a experiencia.";
        }

        public async Task<List<Experiencium>> GetByCpf(string cpf)
        {
            return await ctx.Experiencia.AsNoTracking()
                .Include(e => e.CpfNavigation)
                .ThenInclude(e => e.IdUsuarioNavigation)
                .Where(e => e.Cpf == cpf).ToListAsync();
        }

        public async  Task<Experiencium> GetExperiencia(int id)
        {
            return await ctx.Experiencia.Include(e => e.CpfNavigation).ThenInclude(e => e.IdUsuarioNavigation).FirstOrDefaultAsync(e => e.IdExperiencia == id);
        }
    }
}
