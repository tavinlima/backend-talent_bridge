using talentbridge_webAPI.Domains;

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
        void CreateCandidate(Candidato candidato);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="candidato"></param>
        /// <returns></returns>
        Task<Candidato> UpdateCandidate(Candidato candidato);
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
