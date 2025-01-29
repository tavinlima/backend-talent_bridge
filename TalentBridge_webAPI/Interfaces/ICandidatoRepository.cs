using talentbridge_webAPI.Domains;
using talentbridge_webAPI.ViewModel;
namespace talentbridge_webAPI.Interfaces
{
    public interface ICandidatoRepository
    {
        /// <summary>
        /// Busca as informações de todos os usuários candidatos da aplicação
        /// </summary>
        /// <returns>Dados do candidato</returns>
        Task<List<Candidato>> GetAll();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="candidato"></param>
        Task<Candidato> CreateCandidate(CadastroCandidato candidato);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="candidato"></param>
        /// <returns></returns>
        Task<Candidato> UpdateCandidate(CadastroCandidato candidato);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Candidato> GetCandidateByCpf(string cpf);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void DeleteCandidate(int id);
    }
}
