using talentbridge_webAPI.Domains;

namespace talentbridge_webAPI.Interfaces
{
    public interface IContatoRepository
    {
        Contato CadastrarContato(Contato contato);
    }
}
