using System;
using System.Collections.Generic;

namespace talentbridge_webAPI.Domains;

public partial class Candidato
{
    public int? IdUsuario { get; set; }

    public string Cpf { get; set; } = null!;

    public DateOnly DataNascimento { get; set; }

    public virtual ICollection<Aplicaco> Aplicacos { get; set; } = new List<Aplicaco>();

    public virtual ICollection<Certificacao> Certificacaos { get; set; } = new List<Certificacao>();

    public virtual ICollection<Escolaridade> Escolaridades { get; set; } = new List<Escolaridade>();

    public virtual ICollection<Experiencium> Experiencia { get; set; } = new List<Experiencium>();

    public virtual Usuario? IdUsuarioNavigation { get; set; }

    public virtual ICollection<Idioma> Idiomas { get; set; } = new List<Idioma>();

    public virtual ICollection<Projeto> Projetos { get; set; } = new List<Projeto>();

    public virtual ICollection<Skill> Skills { get; set; } = new List<Skill>();
}
