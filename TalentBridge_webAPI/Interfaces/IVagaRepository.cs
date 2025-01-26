using talentbridge_webAPI.Domains;

namespace talentbridge_webAPI.Interfaces
{
    public interface IVagaRepository
    {
        Task<Vaga> Create(Vaga vaga);
        Task<Vaga> GetAll();
        Task<Vaga> Delete(int Id);
        Task<Vaga> GetById(int Id);
        Task<List<Vaga>> GetByCNPJ(string CNPJ);

    }
}
