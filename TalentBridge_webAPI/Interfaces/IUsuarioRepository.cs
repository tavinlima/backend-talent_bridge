using Microsoft.EntityFrameworkCore.Storage;
using talentbridge_webAPI.Domains;
using talentbridge_webAPI.ViewModel;

namespace talentbridge_webAPI.Interfaces

{
    public interface IUsuarioRepository
    {
        List<Usuario> GetAll();
        Task<Usuario> CreateUser(CadastroUsuario usuario;
    }
}
