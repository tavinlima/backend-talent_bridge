using talentbridge_webAPI.Domains;

namespace talentbridge_webAPI.Interfaces

{
    public interface IUsuarioRepository
    {
        List<Usuario> GetAll();
    }
}
