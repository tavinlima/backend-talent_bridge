using Microsoft.EntityFrameworkCore;
using talentbridge_webAPI.Domains;
using talentbridge_webAPI.Interfaces;
using TalentBridge_webAPI.data;

namespace talentbridge_webAPI.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly TalentBridgeContext ctx = new();
        private readonly ICandidatoRepository candidatoRepository;
        public SkillRepository(TalentBridgeContext ctx, ICandidatoRepository candidatoRepository)
        {
            this.ctx = ctx;
            this.candidatoRepository = candidatoRepository;
        }
        public Skill Create(string cpf, string titulo, string descricao)
        {
            try
            {
                Skill skill = new Skill
                {
                    Cpf = cpf,
                    Descricao = descricao,
                    Titulo = titulo
                };

                ctx.Skills.Add(skill);
                ctx.SaveChanges();

                return skill;
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
            
        }

        public async Task<string> Delete(int Id)
        {
            Skill skill = await GetSkill(Id);

            if (skill != null)
            {
                ctx.Skills.Remove(skill);
                await ctx.SaveChangesAsync();

                return "Skill deletada com sucesso!";
            }

            return "Não foi possível apagar a skill.";
        }

        public async Task<List<Skill>> GetByCpf(string cpf)
        {
            return await ctx.Skills.Include(e => e.CpfNavigation).ThenInclude(e => e.IdUsuarioNavigation).Where(e => e.Cpf == cpf).ToListAsync();
        }

        public async Task<Skill> GetSkill(int id)
        {
            return await ctx.Skills.Include(e => e.CpfNavigation).ThenInclude(e => e.IdUsuarioNavigation).FirstOrDefaultAsync(e => e.IdSkill == id);
        }
    }
}
