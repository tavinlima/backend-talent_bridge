using talentbridge_webAPI.Domains;

namespace talentbridge_webAPI.Interfaces
{
    public interface IProjetoRepository
    {
        Projeto Create(Projeto projeto);
        Task<string> Delete(int Id);
        Task<List<Projeto>> GetByCpf(string cpf);
        Task<Projeto> GetProjeto(int id);
    }
}
