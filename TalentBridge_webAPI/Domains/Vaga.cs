using System;
using System.Collections.Generic;

namespace talentbridge_webAPI.Domains;

public partial class Vaga
{
    public int IdVaga { get; set; }

    public string? Cnpj { get; set; }

    public DateTime DataInicio { get; set; }

    public DateTime DataFim { get; set; }

    public string? Descricao { get; set; }

    public string Titulo { get; set; } = null!;

    public bool Disponivel { get; set; }

    public string ModeloTrabalho { get; set; } = null!;

    public string Senioridade { get; set; } = null!;

    public virtual ICollection<Aplicaco> Aplicacos { get; set; } = new List<Aplicaco>();

    public virtual Empresa? CnpjNavigation { get; set; }

    public virtual ICollection<Requisito> Requisitos { get; set; } = new List<Requisito>();
}
