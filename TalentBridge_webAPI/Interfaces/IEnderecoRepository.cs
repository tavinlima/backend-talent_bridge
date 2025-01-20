using talentbridge_webAPI.Domains;

namespace talentbridge_webAPI.Interfaces
{
    public interface IEnderecoRepository
    {
        Task<Endereco> CadastrarEndereco(Endereco endereco);
    }
}
