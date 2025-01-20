using talentbridge_webAPI.Domains;
using talentbridge_webAPI.ViewModel;

namespace talentbridge_webAPI.Interfaces
{
    public interface IEmpresaRepository
    {
        Task<List<Empresa>> GetAll();
        Task<Empresa> CreateEnterprise(CadastroEmpresa empresa);
        Task<Empresa> UpdateEnterprise(Empresa empresa);
        Task<Empresa> GetEnterpriseByCnpj(string Cnpj);
        void DeleteEnterprise(int id);
    }
}
