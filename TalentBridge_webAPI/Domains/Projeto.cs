using System;
using System.Collections.Generic;

namespace talentbridge_webAPI.Domains;

public partial class Projeto
{
    public int IdProjeto { get; set; }

    public string? Cpf { get; set; }

    public string? Titulo { get; set; }

    public string? Descricao { get; set; }

    public DateOnly? DataInicio { get; set; }

    public DateOnly? DataConclusao { get; set; }

    public virtual Candidato? CpfNavigation { get; set; }
}
