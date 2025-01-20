using talentbridge_webAPI.data;
using talentbridge_webAPI.Domains;
using talentbridge_webAPI.Interfaces;

namespace talentbridge_webAPI.Repositories
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly TalentBridgeContext ctx = new();
        public ContatoRepository(TalentBridgeContext ctx)
        {
            this.ctx = ctx;
        }

        public Contato CadastrarContato(Contato contato)
        {
            ctx.Contatos.Add(contato);
            ctx.SaveChanges();
            return contato;
        }
    }
}
