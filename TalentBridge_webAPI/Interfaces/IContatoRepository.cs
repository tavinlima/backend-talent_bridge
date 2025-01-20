using talentbridge_webAPI.Domains;

namespace talentbridge_webAPI.Interfaces
{
    public interface IContatoRepository
    {
        Task<Contato> CadastrarContato(Contato contato);
    }
}
