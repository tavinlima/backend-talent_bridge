using Microsoft.EntityFrameworkCore;
using talentbridge_webAPI.Domains;
using talentbridge_webAPI.Interfaces;
using TalentBridge_webAPI.data;

namespace talentbridge_webAPI.Repositories
{
    public class CertificacaoRepository : ICertificacaoRepository
    {
        private readonly TalentBridgeContext ctx = new();
        private readonly ICandidatoRepository candidatoRepository;
        public CertificacaoRepository(TalentBridgeContext ctx, ICandidatoRepository candidatoRepository)
        {
            this.ctx = ctx;
            this.candidatoRepository = candidatoRepository;
        }

        public Certificacao Create(Certificacao certificacao)
        {
            ctx.Certificacaos.Add(certificacao);
            ctx.SaveChanges();

            return certificacao;
        }

        public async Task<String> Delete(int Id)
        {
            Certificacao certificacao = await GetCertificacao(Id);

            if (certificacao != null) {
                ctx.Certificacaos.Remove(certificacao);
                await ctx.SaveChangesAsync();

                return "Certificação deletada com sucesso!";
            }

            return "Não foi possível apagar a certificação.";
        }

        public async Task<Certificacao> GetCertificacao(int id)
        {
            return await ctx.Certificacaos.Include(e => e.CpfNavigation).ThenInclude(e => e.IdUsuarioNavigation).FirstOrDefaultAsync(e => e.IdCertificacao == id);
        }

        public async Task<List<Certificacao>> GetByCpf(string cpf)
        {
            return await ctx.Certificacaos.Include(e => e.CpfNavigation).ThenInclude(e => e.IdUsuarioNavigation).Where(e => e.Cpf == cpf).ToListAsync();
        }
    }
}
