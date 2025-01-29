using talentbridge_webAPI.Domains;
using talentbridge_webAPI.ViewModel;

namespace talentbridge_webAPI.Interfaces
{
    public interface IEmpresaRepository
    {
        Task<List<Empresa>> GetAll();
        Task<Empresa> CreateEnterprise(CadastroEmpresa empresa);
        Task<Empresa> UpdateEnterprise(CadastroEmpresa empresa);
        Task<Empresa> GetEnterpriseByCnpj(string Cnpj);
        Task<Empresa> GetEnterpriseByEmail(string email);
        Task<String> DeleteEnterprise(string Cnpj);
    }
}
