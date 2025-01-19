using System;
using System.Collections.Generic;

namespace talentbridge_webAPI.Domains;

public partial class Requisito
{
    public int IdRequisitos { get; set; }

    public int? IdVaga { get; set; }

    public string? Requisito1 { get; set; }

    public virtual Vaga? IdVagaNavigation { get; set; }
}
