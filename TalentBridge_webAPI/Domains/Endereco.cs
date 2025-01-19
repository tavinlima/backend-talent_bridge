using System;
using System.Collections.Generic;

namespace talentbridge_webAPI.Domains;

public partial class Endereco
{
    public int IdEndereco { get; set; }

    public string? Logradouro { get; set; }

    public string? Numero { get; set; }

    public string? Complemento { get; set; }

    public string? Bairro { get; set; }

    public string? Cidade { get; set; }

    public string? Estado { get; set; }

    public string? Cep { get; set; }

    public string? Pais { get; set; }

    public string? TipoEndereco { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
