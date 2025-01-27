using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using talentbridge_webAPI.Domains;
using talentbridge_webAPI.ViewModel;

namespace talentbridge_webAPI.Interfaces

{
    public interface IUsuarioRepository
    {
        List<Usuario> GetAll();
        Task<Usuario> CreateUser(CadastroUsuario usuario);
        Usuario Login(string email, string senha);
    }
}
