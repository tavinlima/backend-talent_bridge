using talentbridge_webAPI.Domains;

namespace talentbridge_webAPI.Interfaces
{
    public interface IIdiomaRepository
    {
        Idioma Create(Idioma idioma);
        Task<String> Delete(int Id);
        Task<List<Idioma>> GetByCpf(string cpf);
        Task<Idioma> GetIdioma(int id);
    }
}
