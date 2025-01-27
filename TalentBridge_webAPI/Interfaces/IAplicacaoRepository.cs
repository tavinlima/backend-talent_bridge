using talentbridge_webAPI.Domains;
using talentbridge_webAPI.ViewModel;

namespace talentbridge_webAPI.Interfaces
{
    public interface IAplicacaoRepository
    {
        Task<Aplicaco> GetCandidates(int Id);
        Task<string> Create(CandidaturaViewModel candidatura);
        string Delete(int Id);
    }
}
