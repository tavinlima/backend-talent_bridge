using Microsoft.EntityFrameworkCore;
using talentbridge_webAPI.Domains;
using talentbridge_webAPI.Interfaces;
using talentbridge_webAPI.ViewModel;
using TalentBridge_webAPI.data;

namespace talentbridge_webAPI.Repositories
{
    public class CandidatoRepository : ICandidatoRepository
    {
        readonly TalentBridgeContext ctx = new();
        private readonly IUsuarioRepository usuarioRepository;

        public CandidatoRepository(TalentBridgeContext ctx, IUsuarioRepository usuarioRepository)
        {
            this.ctx = ctx;
            this.usuarioRepository = usuarioRepository;
        }

        public async Task<Candidato> CreateCandidate(CadastroCandidato candidato)
        {
            using (var transaction = await ctx.Database.BeginTransactionAsync())
                try
                {

                    Usuario novoUsuario = await usuarioRepository.CreateUser(candidato.Usuario);

                    Candidato novoCandidato = new()
                    {
                        DataNascimento = candidato.DataNascimento,
                        Cpf = candidato.Cpf,
                        IdUsuario = novoUsuario.IdUsuario
                    };

                    await ctx.Candidatos.AddAsync(novoCandidato);

                    await ctx.SaveChangesAsync();

                    // Confirmar a transação
                    await transaction.CommitAsync();

                    return novoCandidato;

                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new Exception(ex.Message);
                }
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
