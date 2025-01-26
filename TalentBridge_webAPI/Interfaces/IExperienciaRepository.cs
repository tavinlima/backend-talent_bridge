using talentbridge_webAPI.Domains;

namespace talentbridge_webAPI.Interfaces
{
    public interface IExperienciaRepository
    {
        Experiencium Create(Experiencium experiencium);
        Task<String> Delete(int Id);
        Task<List<Experiencium>> GetByCpf(string cpf);
        Task<Experiencium> GetExperiencia(int id);
    }
}
