using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using talentbridge_webAPI.Domains;
using talentbridge_webAPI.Interfaces;
using talentbridge_webAPI.Utils;
using talentbridge_webAPI.ViewModel;
using TalentBridge_webAPI.data;

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
            // using (var transaction = await ctx.Database.BeginTransactionAsync()) // Iniciando a transação assíncrona
            {
                try
                {
                    // Criando o contato
                    Contato contato = new()
                    {
                        TipoContato = usuario.TipoContato,
                        Numero = usuario.NumContato
                    };
                    Contato novoContato = contatoRepository.CadastrarContato(contato);

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
                    Endereco novoEndereco = enderecoRepository.CadastrarEndereco(endereco);

                    // Criando o usuário
                    Usuario user = new()
                    {
                        Email = usuario.Email,
                        Nome = usuario.Nome,
                        Senha = usuario.Senha,
                        IdContato = novoContato.IdContato,
                        IdEndereco = novoEndereco.IdEndereco
                    };

                    // Adicionando o usuário ao contexto e salvando
                    await ctx.Usuarios.AddAsync(user);
                    await ctx.SaveChangesAsync();

                    

                    return user;
                }
                catch (Exception ex)
                {
                    
                    throw new Exception(ex.Message);
                }
            }
        }

        public async Task<string> Delete(string email)
        {
            try
            {
                Usuario usuarioBuscado = await GetByEmail(email);

                if (usuarioBuscado != null)
                {
                    ctx.Remove(usuarioBuscado);

                    await ctx.SaveChangesAsync();

                    return "Usuário excluído com sucesso";
                }
                return "Usuário não encontrada";
            }
            catch (Exception error)
            {
                return error.Message;
            }
            
        }

        public List<Usuario> GetAll()
        {
            return ctx.Usuarios.ToList();
        }

        public async Task<Usuario> GetByEmail(string email)
        {
            return await ctx.Usuarios.AsNoTracking()
                .Include(e => e.IdContatoNavigation)
                .Include(e => e.IdEnderecoNavigation)
                .FirstOrDefaultAsync(e => e.Email == email);
        }

        public Usuario Login(string email, string senha)
        {
            try
            {
                var usuario = ctx.Usuarios.FirstOrDefault(u => u.Email == email);

                if (usuario != null && usuario.Senha[0] != '$' && usuario.Senha.Length < 32)
                {
                    usuario.Senha = Criptografia.GerarHash(usuario.Senha);
                    ctx.SaveChanges();
                }

                if (usuario != null)
                {
                    bool confere = Criptografia.Comparar(senha, usuario.Senha);
                    if (confere) return usuario;
                }

                return null;
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
            
        }

        public async Task<Usuario> UpdateUser(CadastroUsuario usuario)
        {
            try
            {
                Usuario usuarioBuscado = await GetByEmail(usuario.Email);

                string email = usuario.Email ?? usuarioBuscado.Email;
                string nome = usuario.Nome ?? usuarioBuscado.Nome;

                // Criando o usuário
                Usuario user = new()
                {
                    Email = email,
                    Nome = nome,
                    IdContato = usuarioBuscado.IdContato,
                    IdEndereco = usuarioBuscado.IdEndereco,
                    IdUsuario = usuarioBuscado.IdUsuario,
                    Senha = usuarioBuscado.Senha,
                };

                // Adicionando o usuário ao contexto e salvando
                ctx.Usuarios.Update(user);
                await ctx.SaveChangesAsync();

                return user;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
