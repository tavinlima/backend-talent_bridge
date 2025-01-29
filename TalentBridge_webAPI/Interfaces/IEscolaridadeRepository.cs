using talentbridge_webAPI.Domains;

namespace talentbridge_webAPI.Interfaces
{
    public interface IEscolaridadeRepository
    {
        Escolaridade Create(Escolaridade escolaridade);
        Task<String> Delete(int Id);
        Task<List<Escolaridade>> GetByCpf(string cpf);
        Task<Escolaridade> GetEscolaridade(int id);
    }
}
