using talentbridge_webAPI.Domains;

namespace talentbridge_webAPI.Interfaces
{
    public interface IEnderecoRepository
    {
        Endereco CadastrarEndereco(Endereco endereco);
    }
}
