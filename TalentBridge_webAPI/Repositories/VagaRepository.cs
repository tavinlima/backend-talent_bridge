using Microsoft.EntityFrameworkCore;
using talentbridge_webAPI.Domains;
using talentbridge_webAPI.Interfaces;
using TalentBridge_webAPI.data;

namespace talentbridge_webAPI.Repositories
{
    public class VagaRepository : IVagaRepository
    {
        private readonly TalentBridgeContext ctx = new();
        readonly IUsuarioRepository usuarioRepository;
        readonly IEmpresaRepository empresaRepository;
        public VagaRepository(TalentBridgeContext ctx, IEmpresaRepository empresaRepository, IUsuarioRepository usuarioRepository)
        {
            this.ctx = ctx;
            this.empresaRepository = empresaRepository;
            this.usuarioRepository = usuarioRepository;
        }
        public async Task<Vaga> Create(Vaga vaga)
        {
            ctx.Vagas.Add(vaga);
            await ctx.SaveChangesAsync();

            return vaga;
        }

        public Task<Vaga> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Vaga>> GetAll()
        {
            try
            {
                return await ctx.Vagas.AsNoTracking()
                    .Include(e => e.CnpjNavigation)
                    .ThenInclude(e => e.IdUsuarioNavigation)
                    .ToListAsync();
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
            
        }

        public async Task<List<Vaga>> GetByCNPJ(string CNPJ)
        {
            return await ctx.Vagas
                .Include(e => e.CnpjNavigation)
                .Where(v => v.CnpjNavigation.Cnpj == CNPJ)
                .ToListAsync();
        }

        public async Task<Vaga> GetById(int Id)
        {
            return await ctx.Vagas.Include(e => e.CnpjNavigation).FirstOrDefaultAsync(v => v.IdVaga == Id);
        }
    }
}
