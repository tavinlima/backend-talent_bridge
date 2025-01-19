using System;
using System.Collections.Generic;

namespace talentbridge_webAPI.Domains;

public partial class Contato
{
    public int IdContato { get; set; }

    public string? TipoContato { get; set; }

    public string? Numero { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
