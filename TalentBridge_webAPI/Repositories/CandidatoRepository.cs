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
        readonly IEnderecoRepository enderecoRepository;
        readonly IContatoRepository contatoRepository;

        public CandidatoRepository(TalentBridgeContext ctx)
        {
            this.ctx = ctx;
        }

        public async void CreateCandidate(CadastroCandidato candidato)
        {
            //using var transaction = ctx.Database.BeginTransaction();
            //try
            //{

            //    Candidato candidato = new()
            //    {

            //    }

            //    Usuario user = new()
            //    {
            //        Email = usuario.Email,
            //        Nome = usuario.Nome,
            //        IdContato = novoContato.IdContato,
            //        IdEndereco = novoEndereco.IdEndereco
            //    };

            //    await ctx.Usuarios.AddAsync(user);

            //    await ctx.SaveChangesAsync();

            //    await transaction.CommitAsync();

            //    return user;
            //}
            //catch (Exception ex)
            //{
            //    await transaction.RollbackAsync();
            //    throw new Exception(ex.Message);
            //}
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
