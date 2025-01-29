using talentbridge_webAPI.Domains;

namespace talentbridge_webAPI.Interfaces
{
    public interface ISkillRepository
    {
        Skill Create(Skill skill);
        Task<string> Delete(int Id);
        Task<List<Skill>> GetByCpf(string cpf);
        Task<Skill> GetSkill(int id);
    }
}
