using System;
using System.Collections.Generic;
using talentbridge_webAPI.Domains;
using Microsoft.EntityFrameworkCore;

namespace TalentBridge_webAPI.data;

public partial class TalentBridgeContext : DbContext
{
    public TalentBridgeContext()
    {
    }

    public TalentBridgeContext(DbContextOptions<TalentBridgeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aplicaco> Aplicacoes { get; set; }

    public virtual DbSet<Candidato> Candidatos { get; set; }

    public virtual DbSet<Certificacao> Certificacaos { get; set; }

    public virtual DbSet<Contato> Contatos { get; set; }

    public virtual DbSet<Empresa> Empresas { get; set; }

    public virtual DbSet<Endereco> Enderecos { get; set; }

    public virtual DbSet<Escolaridade> Escolaridades { get; set; }

    public virtual DbSet<Experiencium> Experiencia { get; set; }

    public virtual DbSet<Idioma> Idiomas { get; set; }

    public virtual DbSet<Projeto> Projetos { get; set; }

    public virtual DbSet<Requisito> Requisitos { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Vaga> Vagas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aplicaco>(entity =>
        {
            entity.HasKey(e => e.IdAplicacao).HasName("PK__Aplicaco__6C5677E8D4683B83");

            entity.Property(e => e.IdAplicacao).HasColumnName("idAplicacao");
            entity.Property(e => e.Avaliacao)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("avaliacao");
            entity.Property(e => e.Cpf)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CPF");
            entity.Property(e => e.DataCandidatura)
                .HasColumnType("smalldatetime")
                .HasColumnName("dataCandidatura");
            entity.Property(e => e.Feedback)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("feedback");
            entity.Property(e => e.IdVaga).HasColumnName("idVaga");
            entity.Property(e => e.Observacoes)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("observacoes");
            entity.Property(e => e.Situacao)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("situacao");

            entity.HasOne(d => d.CpfNavigation).WithMany(p => p.Aplicacos)
                .HasForeignKey(d => d.Cpf)
                .HasConstraintName("FK__Aplicacoes__CPF__70DDC3D8");

            entity.HasOne(d => d.IdVagaNavigation).WithMany(p => p.Aplicacos)
                .HasForeignKey(d => d.IdVaga)
                .HasConstraintName("FK__Aplicacoe__idVag__6FE99F9F");
        });

        modelBuilder.Entity<Candidato>(entity =>
        {
            entity.HasKey(e => e.Cpf).HasName("PK__Candidat__C1F8973065306718");

            entity.ToTable("Candidato");

            entity.Property(e => e.Cpf)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CPF");
            entity.Property(e => e.DataNascimento).HasColumnName("dataNascimento");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Candidatos)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Candidato__idUsu__52593CB8");
        });

        modelBuilder.Entity<Certificacao>(entity =>
        {
            entity.HasKey(e => e.IdCertificacao).HasName("PK__Certific__23C2554A4853CEE3");

            entity.ToTable("Certificacao");

            entity.Property(e => e.IdCertificacao).HasColumnName("idCertificacao");
            entity.Property(e => e.Cpf)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CPF");
            entity.Property(e => e.DataConclusao).HasColumnName("dataConclusao");
            entity.Property(e => e.Descricao)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("descricao");
            entity.Property(e => e.Titulo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("titulo");

            entity.HasOne(d => d.CpfNavigation).WithMany(p => p.Certificacaos)
                .HasForeignKey(d => d.Cpf)
                .HasConstraintName("FK__Certificaca__CPF__6477ECF3");
        });

        modelBuilder.Entity<Contato>(entity =>
        {
            entity.HasKey(e => e.IdContato).HasName("PK__Contato__278E896D75450ADA");

            entity.ToTable("Contato");

            entity.Property(e => e.IdContato).HasColumnName("idContato");
            entity.Property(e => e.Numero)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("numero");
            entity.Property(e => e.TipoContato)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipoContato");
        });

        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.HasKey(e => e.Cnpj).HasName("PK__Empresa__AA57D6B56CD920C5");

            entity.ToTable("Empresa");

            entity.Property(e => e.Cnpj)
                .HasMaxLength(14)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CNPJ");
            entity.Property(e => e.Avaliacao)
                .HasColumnType("decimal(3, 2)")
                .HasColumnName("avaliacao");
            entity.Property(e => e.Descricao)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("descricao");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Empresas)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Empresa__idUsuar__5535A963");
        });

        modelBuilder.Entity<Endereco>(entity =>
        {
            entity.HasKey(e => e.IdEndereco).HasName("PK__Endereco__E45B8B2794F1B033");

            entity.ToTable("Endereco");

            entity.Property(e => e.IdEndereco).HasColumnName("idEndereco");
            entity.Property(e => e.Bairro)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("bairro");
            entity.Property(e => e.Cep)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cep");
            entity.Property(e => e.Cidade)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("cidade");
            entity.Property(e => e.Complemento)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("complemento");
            entity.Property(e => e.Estado)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("estado");
            entity.Property(e => e.Logradouro)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("logradouro");
            entity.Property(e => e.Numero)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("numero");
            entity.Property(e => e.Pais)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("pais");
            entity.Property(e => e.TipoEndereco)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tipoEndereco");
        });

        modelBuilder.Entity<Escolaridade>(entity =>
        {
            entity.HasKey(e => e.IdEscolaridade).HasName("PK__Escolari__074B135CC6345AC2");

            entity.ToTable("Escolaridade");

            entity.Property(e => e.IdEscolaridade).HasColumnName("idEscolaridade");
            entity.Property(e => e.Cpf)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CPF");
            entity.Property(e => e.DataConclusao).HasColumnName("dataConclusao");
            entity.Property(e => e.DataInicio).HasColumnName("dataInicio");
            entity.Property(e => e.Descricao)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("descricao");
            entity.Property(e => e.Titulo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("titulo");

            entity.HasOne(d => d.CpfNavigation).WithMany(p => p.Escolaridades)
                .HasForeignKey(d => d.Cpf)
                .HasConstraintName("FK__Escolaridad__CPF__59063A47");
        });

        modelBuilder.Entity<Experiencium>(entity =>
        {
            entity.HasKey(e => e.IdExperiencia).HasName("PK__Experien__77DCF294397262AE");

            entity.Property(e => e.IdExperiencia).HasColumnName("idExperiencia");
            entity.Property(e => e.Cpf)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CPF");
            entity.Property(e => e.DataConclusao).HasColumnName("dataConclusao");
            entity.Property(e => e.DataInicio).HasColumnName("dataInicio");
            entity.Property(e => e.Descricao)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("descricao");
            entity.Property(e => e.Titulo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("titulo");

            entity.HasOne(d => d.CpfNavigation).WithMany(p => p.Experiencia)
                .HasForeignKey(d => d.Cpf)
                .HasConstraintName("FK__Experiencia__CPF__5BE2A6F2");
        });

        modelBuilder.Entity<Idioma>(entity =>
        {
            entity.HasKey(e => e.IdIdioma).HasName("PK__Idioma__A96571FC1F4237B4");

            entity.ToTable("Idioma");

            entity.Property(e => e.IdIdioma).HasColumnName("idIdioma");
            entity.Property(e => e.Cpf)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CPF");
            entity.Property(e => e.Fluencia)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("fluencia");
            entity.Property(e => e.Idioma1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("idioma");

            entity.HasOne(d => d.CpfNavigation).WithMany(p => p.Idiomas)
                .HasForeignKey(d => d.Cpf)
                .HasConstraintName("FK__Idioma__CPF__6754599E");
        });

        modelBuilder.Entity<Projeto>(entity =>
        {
            entity.HasKey(e => e.IdProjeto).HasName("PK__Projeto__8FCCED7646A3D7D3");

            entity.ToTable("Projeto");

            entity.Property(e => e.IdProjeto).HasColumnName("idProjeto");
            entity.Property(e => e.Cpf)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CPF");
            entity.Property(e => e.DataConclusao).HasColumnName("dataConclusao");
            entity.Property(e => e.DataInicio).HasColumnName("dataInicio");
            entity.Property(e => e.Descricao)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("descricao");
            entity.Property(e => e.Titulo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("titulo");

            entity.HasOne(d => d.CpfNavigation).WithMany(p => p.Projetos)
                .HasForeignKey(d => d.Cpf)
                .HasConstraintName("FK__Projeto__CPF__619B8048");
        });

        modelBuilder.Entity<Requisito>(entity =>
        {
            entity.HasKey(e => e.IdRequisitos).HasName("PK__Requisit__894FA0C7D507D6A1");

            entity.Property(e => e.IdRequisitos).HasColumnName("idRequisitos");
            entity.Property(e => e.IdVaga).HasColumnName("idVaga");
            entity.Property(e => e.Requisito1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("requisito");

            entity.HasOne(d => d.IdVagaNavigation).WithMany(p => p.Requisitos)
                .HasForeignKey(d => d.IdVaga)
                .HasConstraintName("FK__Requisito__idVag__6D0D32F4");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.IdSkill).HasName("PK__Skills__C4CE4D6EF42652D1");

            entity.Property(e => e.IdSkill).HasColumnName("idSkill");
            entity.Property(e => e.Cpf)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CPF");
            entity.Property(e => e.Descricao)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descricao");
            entity.Property(e => e.Titulo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("titulo");

            entity.HasOne(d => d.CpfNavigation).WithMany(p => p.Skills)
                .HasForeignKey(d => d.Cpf)
                .HasConstraintName("FK__Skills__CPF__5EBF139D");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__645723A64B26A69B");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.Email, "UQ__Usuario__AB6E61646AB13C7F").IsUnique();

            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.IdContato).HasColumnName("idContato");
            entity.Property(e => e.IdEndereco).HasColumnName("idEndereco");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("senha");

            entity.HasOne(d => d.IdContatoNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdContato)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Usuario__idConta__4F7CD00D");

            entity.HasOne(d => d.IdEnderecoNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdEndereco)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Usuario__idEnder__4E88ABD4");
        });

        modelBuilder.Entity<Vaga>(entity =>
        {
            entity.HasKey(e => e.IdVaga).HasName("PK__Vagas__02E6F4AAE1B89A90");

            entity.Property(e => e.IdVaga).HasColumnName("idVaga");
            entity.Property(e => e.Cnpj)
                .HasMaxLength(14)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CNPJ");
            entity.Property(e => e.DataFim).HasColumnType("smalldatetime");
            entity.Property(e => e.DataInicio)
                .HasColumnType("smalldatetime")
                .HasColumnName("dataInicio");
            entity.Property(e => e.Descricao)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("descricao");
            entity.Property(e => e.Disponivel).HasColumnName("disponivel");
            entity.Property(e => e.ModeloTrabalho)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("modeloTrabalho");
            entity.Property(e => e.Senioridade)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("senioridade");
            entity.Property(e => e.Titulo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("titulo");

            entity.HasOne(d => d.CnpjNavigation).WithMany(p => p.Vagas)
                .HasForeignKey(d => d.Cnpj)
                .HasConstraintName("FK__Vagas__CNPJ__6A30C649");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
