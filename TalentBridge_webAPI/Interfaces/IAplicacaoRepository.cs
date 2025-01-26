using talentbridge_webAPI.Domains;

namespace talentbridge_webAPI.Interfaces
{
    public interface IAplicacaoRepository
    {
        Task<Aplicaco> GetCandidates(int Id);
        Aplicaco Create(Aplicaco aplicaco);
        Aplicaco Delete(Aplicaco Id);


    }
}
