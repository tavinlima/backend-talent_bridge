using System;
using System.Collections.Generic;

namespace talentbridge_webAPI.Domains;

public partial class Aplicaco
{
    public int IdAplicacao { get; set; }

    public int? IdVaga { get; set; }

    public string? Cpf { get; set; }

    public DateTime DataCandidatura { get; set; }

    public string Observacoes { get; set; } = null!;

    public string? Avaliacao { get; set; }

    public string? Feedback { get; set; }

    public string? Situacao { get; set; }

    public virtual Candidato? CpfNavigation { get; set; }

    public virtual Vaga? IdVagaNavigation { get; set; }
}
