using System;
using System.Collections.Generic;

namespace talentbridge_webAPI.Domains;

public partial class Idioma
{
    public int IdIdioma { get; set; }

    public string? Cpf { get; set; }

    public string Fluencia { get; set; } = null!;

    public string? Idioma1 { get; set; }

    public virtual Candidato? CpfNavigation { get; set; }
}
