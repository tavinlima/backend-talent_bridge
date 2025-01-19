using System;
using System.Collections.Generic;

namespace talentbridge_webAPI.Domains;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public int? IdEndereco { get; set; }

    public int? IdContato { get; set; }

    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public byte[]? FotoPerfil { get; set; }

    public virtual ICollection<Candidato> Candidatos { get; set; } = new List<Candidato>();

    public virtual ICollection<Empresa> Empresas { get; set; } = new List<Empresa>();

    public virtual Contato? IdContatoNavigation { get; set; }

    public virtual Endereco? IdEnderecoNavigation { get; set; }
}
