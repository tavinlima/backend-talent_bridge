using System;
using System.Collections.Generic;

namespace talentbridge_webAPI.Domains;

public partial class Skill
{
    public int IdSkill { get; set; }

    public string? Cpf { get; set; }

    public string? Titulo { get; set; }

    public string? Descricao { get; set; }

    public virtual Candidato? CpfNavigation { get; set; }
}
