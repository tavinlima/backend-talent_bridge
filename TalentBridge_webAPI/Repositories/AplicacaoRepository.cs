using Microsoft.EntityFrameworkCore;
using talentbridge_webAPI.Domains;
using talentbridge_webAPI.Interfaces;
using talentbridge_webAPI.ViewModel;
using TalentBridge_webAPI.data;

namespace talentbridge_webAPI.Repositories
{
    public class AplicacaoRepository : IAplicacaoRepository
    {
        private readonly TalentBridgeContext ctx = new();
        private readonly ICandidatoRepository candRepo;
        public AplicacaoRepository(TalentBridgeContext ctx, ICandidatoRepository candRepo)
        {
            this.ctx = ctx;
            this.candRepo = candRepo;
        }

        public async Task<string> AdicionarFeedback(int idAplicacao, string feedback)
        {
            Aplicaco aplicaco = await GetAplicacoById(idAplicacao);

            if (aplicaco != null)
            {
                var result = await ctx.Aplicacoes
                    .Where(x => x.IdAplicacao == idAplicacao)
                    .ExecuteUpdateAsync(x => x.SetProperty(x => x.Feedback, x => feedback));
                
                return "Feedback dado com sucesso;";
            }

            return "Ops! Houve um erro ao atribuir o feedback";
        }

        public async Task<string> Create(CandidaturaViewModel candidatura)
        {
            Candidato candidato = await candRepo.GetCandidateByCpf(candidatura.CPF);

            if (candidato.Cpf != null)
            {
                Aplicaco novaAplicacao = new Aplicaco
                {
                    Cpf = candidato.Cpf,
                    DataCandidatura = candidatura.DataCandidatura,
                    IdVaga = candidatura.idVaga,
                    Situacao = "Pendente"
                };

                ctx.Aplicacoes.Add(novaAplicacao);
                
                await ctx.SaveChangesAsync();

                return "Candidatura realizada com sucesso!";
            }

            return "Ops! Houve um problema com sua candidatura.";
        }

        public string Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<Aplicaco> GetAplicacoById(int id)
        {
            return await ctx.Aplicacoes.FromSqlRaw($"SELECT idAplicacao, A.CPF, dataCandidatura, observacoes, A.avaliacao, feedback, situacao, V.CNPJ, dataInicio, DataFim, V.descricao, titulo, disponivel, modeloTrabalho, senioridade, UE.nome AS 'nome_empresa', UE.email AS 'email_empresa', E.descricao, uc.nome AS 'nome_candidato', uc.email AS 'email_candidato', dataNascimento FROM Aplicacoes A JOIN Vagas V ON A.idVaga = V.idVaga JOIN Candidato C ON A.CPF = C.CPF JOIN Empresa E ON V.CNPJ = E.CNPJ JOIN Usuario UE ON UE.idUsuario = E.idUsuario JOIN Usuario UC ON UC.idUsuario = C.idUsuario WHERE idAplicacao = {id}").ToListAsync();
        }

        public Task<Aplicaco> GetCandidates(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
