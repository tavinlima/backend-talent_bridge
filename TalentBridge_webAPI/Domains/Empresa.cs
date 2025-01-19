using System;
using System.Collections.Generic;

namespace talentbridge_webAPI.Domains;

public partial class Empresa
{
    public string Cnpj { get; set; } = null!;

    public int? IdUsuario { get; set; }

    public string? Descricao { get; set; }

    public decimal? Avaliacao { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }

    public virtual ICollection<Vaga> Vagas { get; set; } = new List<Vaga>();
}
