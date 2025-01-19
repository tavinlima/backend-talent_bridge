using System;
using System.Collections.Generic;

namespace talentbridge_webAPI.Domains;

public partial class Certificacao
{
    public int IdCertificacao { get; set; }

    public string? Cpf { get; set; }

    public string? Titulo { get; set; }

    public string? Descricao { get; set; }

    public DateOnly? DataConclusao { get; set; }

    public virtual Candidato? CpfNavigation { get; set; }
}
