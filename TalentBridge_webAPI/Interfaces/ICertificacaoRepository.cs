using talentbridge_webAPI.Domains;

namespace talentbridge_webAPI.Interfaces
{
    public interface ICertificacaoRepository
    {
        Certificacao Create(Certificacao certificacao);
        Task<String> Delete(int Id);
        Task<List<Certificacao>> GetByCpf(string cpf);
        Task<Certificacao> GetCertificacao(int id);
    }
}
