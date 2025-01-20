using Microsoft.EntityFrameworkCore;
using talentbridge_webAPI.data;
using talentbridge_webAPI.Domains;
using talentbridge_webAPI.Interfaces;

namespace talentbridge_webAPI.Repositories
{
    public class CandidatoRepository : ICandidatoRepository
    {
        readonly TalentBridgeContext ctx = new();

        public CandidatoRepository(TalentBridgeContext ctx)
        {
            this.ctx = ctx;
        }

        public void CreateCandidate(Candidato candidato)
        {
            throw new NotImplementedException();
        }

        public void DeleteCandidate(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Candidato>> GetAll()
        {
            return await ctx.Candidatos.AsNoTracking()
                .Include(c => c.IdUsuarioNavigation)
                .Include(u => u.IdUsuarioNavigation.IdContatoNavigation)
                .Include(u => u.IdUsuarioNavigation.IdEnderecoNavigation)
                .Include(c => c.Projetos)
                .Include(c => c.Skills)
                .Include(c => c.Aplicacos)
                .Include(c => c.Escolaridades)
                .Include(c => c.Certificacaos)
                .Include(c => c.Experiencia)
                .Include(c => c.Idiomas)
                .ToListAsync();
        }

        public async Task<Candidato> GetCandidateByCpf(string cpf)
        {
            return await ctx.Candidatos.AsNoTracking()
                .Include(c => c.IdUsuarioNavigation)
                .Include(u => u.IdUsuarioNavigation.IdContatoNavigation)
                .Include(u => u.IdUsuarioNavigation.IdEnderecoNavigation)
                .Include(c => c.Projetos)
                .Include(c => c.Skills)
                .Include(c => c.Aplicacos)
                .Include(c => c.Escolaridades)
                .Include(c => c.Certificacaos)
                .Include(c => c.Experiencia)
                .Include(c => c.Idiomas)
                .FirstOrDefaultAsync(c => c.Cpf == cpf) ?? throw new Exception("Candidato não encontrado. Tente com outro cpf"); ;
        }

        public Task<Candidato> UpdateCandidate(Candidato candidato)
        {
            throw new NotImplementedException();
        }
    }
}
