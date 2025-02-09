using talentbridge_webAPI.Domains;
using TalentBridge_webAPI.ViewModel;

namespace talentbridge_webAPI.Interfaces
{
    public interface IVagaRepository
    {
        Task<Vaga> Create(CadastroVagasViewModel vaga);
        Task<List<Vaga>> GetAll();
        Task<Vaga> Delete(int Id);
        Task<Vaga> GetById(int Id);
        Task<List<Vaga>> GetByCNPJ(string CNPJ);
        Task<string> UpdateSituation(int Id);

    }
}
