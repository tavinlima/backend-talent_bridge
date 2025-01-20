using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using talentbridge_webAPI.data;
using talentbridge_webAPI.Domains;
using talentbridge_webAPI.Interfaces;
using talentbridge_webAPI.ViewModel;

namespace talentbridge_webAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        readonly TalentBridgeContext ctx = new();
        readonly IEnderecoRepository enderecoRepository;
        readonly IContatoRepository contatoRepository;

        public UsuarioRepository(TalentBridgeContext ctx, IContatoRepository contatoRepository, IEnderecoRepository enderecoRepository)
        {
            this.ctx = ctx;
            this.enderecoRepository = enderecoRepository;
            this.contatoRepository = contatoRepository;
        }

        public async Task<Usuario> CreateUser(CadastroUsuario usuario)
        {
            using (var transaction = await ctx.Database.BeginTransactionAsync()) // Iniciando a transação assíncrona
            {
                try
                {
                    // Criando o contato
                    Contato contato = new()
                    {
                        TipoContato = usuario.TipoContato,
                        Numero = usuario.NumContato
                    };
                    Contato novoContato = await contatoRepository.CadastrarContato(contato);

                    // Criando o endereço
                    Endereco endereco = new()
                    {
                        Logradouro = usuario.Logradouro,
                        Numero = usuario.NumEnder,
                        Complemento = usuario.Complemento,
                        Bairro = usuario.Bairro,
                        Cidade = usuario.Cidade,
                        Estado = usuario.UF,
                        Cep = usuario.Cep,
                        Pais = usuario.Pais,
                        TipoEndereco = usuario.TipoEndereco
                    };
                    Endereco novoEndereco = await enderecoRepository.CadastrarEndereco(endereco);

                    // Criando o usuário
                    Usuario user = new()
                    {
                        Email = usuario.Email,
                        Nome = usuario.Nome,
                        IdContato = novoContato.IdContato,
                        IdEndereco = novoEndereco.IdEndereco
                    };

                    // Adicionando o usuário ao contexto e salvando
                    await ctx.Usuarios.AddAsync(user);
                    await ctx.SaveChangesAsync();

                    // Commit da transação após todas as operações
                    await transaction.CommitAsync();

                    return user;
                }
                catch (Exception ex)
                {
                    // Rollback da transação em caso de erro
                    await transaction.RollbackAsync();
                    throw new Exception(ex.Message);
                }
            }
        }

        public List<Usuario> GetAll()
        {
            return ctx.Usuarios.ToList();
        }
    }
}
