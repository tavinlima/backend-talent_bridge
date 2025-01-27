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

        public Task<Aplicaco> GetCandidates(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
