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
        public Task<Vaga> Create(Vaga vaga)
        {
            throw new NotImplementedException();
        }

        public Task<Vaga> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<Vaga> GetAll()
        {
            //Vaga vaga = ctx.v
            throw new NotImplementedException();
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
