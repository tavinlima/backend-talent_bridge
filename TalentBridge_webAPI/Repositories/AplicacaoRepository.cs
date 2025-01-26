using talentbridge_webAPI.Domains;
using talentbridge_webAPI.Interfaces;
using TalentBridge_webAPI.data;

namespace talentbridge_webAPI.Repositories
{
    public class AplicacaoRepository : IAplicacaoRepository
    {
        private readonly TalentBridgeContext ctx = new();
        public AplicacaoRepository(TalentBridgeContext ctx)
        {
            this.ctx = ctx;
        }
        public Aplicaco Create(Aplicaco aplicaco)
        {
            ctx.Aplicacoes.Add(aplicaco);
            ctx.SaveChanges();
            return aplicaco;
        }

        public Aplicaco Delete(Aplicaco Id)
        {
            throw new NotImplementedException();
        }

        public Task<Aplicaco> GetCandidates(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
