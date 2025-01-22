using talentbridge_webAPI.Domains;
using talentbridge_webAPI.Interfaces;
using TalentBridge_webAPI.data;

namespace talentbridge_webAPI.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly TalentBridgeContext ctx = new();
        public EnderecoRepository(TalentBridgeContext ctx)
        {
            this.ctx = ctx;
        }

        public Endereco CadastrarEndereco(Endereco endereco)
        {
            ctx.Enderecos.Add(endereco);
            ctx.SaveChanges();
            return endereco;
        }
    }
}
