using talentbridge_webAPI.data;
using talentbridge_webAPI.Domains;
using talentbridge_webAPI.Interfaces;

namespace talentbridge_webAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        readonly TalentBridgeContext ctx = new();

        public UsuarioRepository(TalentBridgeContext ctx)
        {
            this.ctx = ctx;
        }

        public List<Usuario> GetAll()
        {
            return ctx.Usuarios.ToList();
        }
    }
}
