using talentbridge_webAPI.Domains;

namespace talentbridge_webAPI.Interfaces
{
    public interface IIdiomaRepository
    {
        Idioma Create(string CPF, string fluencia, string idioma);
        Task<String> Delete(int Id);
        Task<List<Idioma>> GetByCpf(string cpf);
        Task<Idioma> GetIdioma(int id);
    }
}
