using Microsoft.EntityFrameworkCore;
using talentbridge_webAPI.Domains;
using talentbridge_webAPI.Interfaces;
using TalentBridge_webAPI.data;

namespace talentbridge_webAPI.Repositories
{
    public class IdiomaRepository : IIdiomaRepository
    {
        private readonly TalentBridgeContext ctx = new();
        private readonly ICandidatoRepository candidatoRepository;
        public IdiomaRepository(TalentBridgeContext ctx, ICandidatoRepository candidatoRepository)
        {
            this.ctx = ctx;
            this.candidatoRepository = candidatoRepository;
        }
        public Idioma Create(string CPF, string fluencia, string idioma)
        {
            try
            {
                Idioma newIdioma = new Idioma
                {
                    Cpf = CPF,
                    Fluencia = fluencia,
                    Idioma1 = idioma
                };

                ctx.Idiomas.Add(newIdioma);
                ctx.SaveChanges();

                return newIdioma;
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        public async Task<string> Delete(int Id)
        {
            Idioma idioma = await GetIdioma(Id);

            if (idioma != null)
            {
                ctx.Idiomas.Remove(idioma);
                await ctx.SaveChangesAsync();

                return "Certificação deletada com sucesso!";
            }

            return "Não foi possível apagar a certificação.";
        }

        public async Task<List<Idioma>> GetByCpf(string cpf)
        {
            return await ctx.Idiomas.Include(e => e.CpfNavigation).ThenInclude(e => e.IdUsuarioNavigation).Where(e => e.Cpf == cpf).ToListAsync();
        }

        public async Task<Idioma> GetIdioma(int id)
        {
            return await ctx.Idiomas.Include(e => e.CpfNavigation).ThenInclude(e => e.IdUsuarioNavigation).FirstOrDefaultAsync(e => e.IdIdioma == id);
        }
    }
}
