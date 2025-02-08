using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace talentbridge_webAPI.Migrations
{
    /// <inheritdoc />
    public partial class CreateTBDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contato",
                columns: table => new
                {
                    idContato = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipoContato = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    numero = table.Column<string>(type: "varchar(14)", unicode: false, maxLength: 14, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Contato__278E896D75450ADA", x => x.idContato);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    idEndereco = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    logradouro = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    numero = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    complemento = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    bairro = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    cidade = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    estado = table.Column<string>(type: "char(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: true),
                    cep = table.Column<string>(type: "char(8)", unicode: false, fixedLength: true, maxLength: 8, nullable: true),
                    pais = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    tipoEndereco = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Endereco__E45B8B2794F1B033", x => x.idEndereco);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    idUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idEndereco = table.Column<int>(type: "int", nullable: true),
                    idContato = table.Column<int>(type: "int", nullable: true),
                    nome = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    senha = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuario__645723A64B26A69B", x => x.idUsuario);
                    table.ForeignKey(
                        name: "FK__Usuario__idConta__4F7CD00D",
                        column: x => x.idContato,
                        principalTable: "Contato",
                        principalColumn: "idContato",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Usuario__idEnder__4E88ABD4",
                        column: x => x.idEndereco,
                        principalTable: "Endereco",
                        principalColumn: "idEndereco",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Candidato",
                columns: table => new
                {
                    CPF = table.Column<string>(type: "char(11)", unicode: false, fixedLength: true, maxLength: 11, nullable: false),
                    idUsuario = table.Column<int>(type: "int", nullable: true),
                    dataNascimento = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Candidat__C1F8973065306718", x => x.CPF);
                    table.ForeignKey(
                        name: "FK__Candidato__idUsu__52593CB8",
                        column: x => x.idUsuario,
                        principalTable: "Usuario",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    CNPJ = table.Column<string>(type: "char(14)", unicode: false, fixedLength: true, maxLength: 14, nullable: false),
                    idUsuario = table.Column<int>(type: "int", nullable: true),
                    descricao = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    avaliacao = table.Column<decimal>(type: "decimal(3,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Empresa__AA57D6B56CD920C5", x => x.CNPJ);
                    table.ForeignKey(
                        name: "FK__Empresa__idUsuar__5535A963",
                        column: x => x.idUsuario,
                        principalTable: "Usuario",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Certificacao",
                columns: table => new
                {
                    idCertificacao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CPF = table.Column<string>(type: "char(11)", unicode: false, fixedLength: true, maxLength: 11, nullable: true),
                    titulo = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    descricao = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    dataConclusao = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Certific__23C2554A4853CEE3", x => x.idCertificacao);
                    table.ForeignKey(
                        name: "FK__Certificaca__CPF__6477ECF3",
                        column: x => x.CPF,
                        principalTable: "Candidato",
                        principalColumn: "CPF");
                });

            migrationBuilder.CreateTable(
                name: "Escolaridade",
                columns: table => new
                {
                    idEscolaridade = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CPF = table.Column<string>(type: "char(11)", unicode: false, fixedLength: true, maxLength: 11, nullable: true),
                    titulo = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    descricao = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    dataInicio = table.Column<DateOnly>(type: "date", nullable: true),
                    dataConclusao = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Escolari__074B135CC6345AC2", x => x.idEscolaridade);
                    table.ForeignKey(
                        name: "FK__Escolaridad__CPF__59063A47",
                        column: x => x.CPF,
                        principalTable: "Candidato",
                        principalColumn: "CPF");
                });

            migrationBuilder.CreateTable(
                name: "Experiencia",
                columns: table => new
                {
                    idExperiencia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CPF = table.Column<string>(type: "char(11)", unicode: false, fixedLength: true, maxLength: 11, nullable: true),
                    titulo = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    descricao = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    dataInicio = table.Column<DateOnly>(type: "date", nullable: true),
                    dataConclusao = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Experien__77DCF294397262AE", x => x.idExperiencia);
                    table.ForeignKey(
                        name: "FK__Experiencia__CPF__5BE2A6F2",
                        column: x => x.CPF,
                        principalTable: "Candidato",
                        principalColumn: "CPF");
                });

            migrationBuilder.CreateTable(
                name: "Idioma",
                columns: table => new
                {
                    idIdioma = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CPF = table.Column<string>(type: "char(11)", unicode: false, fixedLength: true, maxLength: 11, nullable: true),
                    fluencia = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    idioma = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Idioma__A96571FC1F4237B4", x => x.idIdioma);
                    table.ForeignKey(
                        name: "FK__Idioma__CPF__6754599E",
                        column: x => x.CPF,
                        principalTable: "Candidato",
                        principalColumn: "CPF");
                });

            migrationBuilder.CreateTable(
                name: "Projeto",
                columns: table => new
                {
                    idProjeto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CPF = table.Column<string>(type: "char(11)", unicode: false, fixedLength: true, maxLength: 11, nullable: true),
                    titulo = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    descricao = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    dataInicio = table.Column<DateOnly>(type: "date", nullable: true),
                    dataConclusao = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Projeto__8FCCED7646A3D7D3", x => x.idProjeto);
                    table.ForeignKey(
                        name: "FK__Projeto__CPF__619B8048",
                        column: x => x.CPF,
                        principalTable: "Candidato",
                        principalColumn: "CPF");
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    idSkill = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CPF = table.Column<string>(type: "char(11)", unicode: false, fixedLength: true, maxLength: 11, nullable: true),
                    titulo = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    descricao = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Skills__C4CE4D6EF42652D1", x => x.idSkill);
                    table.ForeignKey(
                        name: "FK__Skills__CPF__5EBF139D",
                        column: x => x.CPF,
                        principalTable: "Candidato",
                        principalColumn: "CPF");
                });

            migrationBuilder.CreateTable(
                name: "Vagas",
                columns: table => new
                {
                    idVaga = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNPJ = table.Column<string>(type: "char(14)", unicode: false, fixedLength: true, maxLength: 14, nullable: true),
                    dataInicio = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    DataFim = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    descricao = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    titulo = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    disponivel = table.Column<bool>(type: "bit", nullable: false),
                    modeloTrabalho = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    senioridade = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Vagas__02E6F4AAE1B89A90", x => x.idVaga);
                    table.ForeignKey(
                        name: "FK__Vagas__CNPJ__6A30C649",
                        column: x => x.CNPJ,
                        principalTable: "Empresa",
                        principalColumn: "CNPJ");
                });

            migrationBuilder.CreateTable(
                name: "Aplicacoes",
                columns: table => new
                {
                    idAplicacao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idVaga = table.Column<int>(type: "int", nullable: true),
                    CPF = table.Column<string>(type: "char(11)", unicode: false, fixedLength: true, maxLength: 11, nullable: true),
                    dataCandidatura = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    observacoes = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    avaliacao = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    feedback = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    situacao = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Aplicaco__6C5677E8D4683B83", x => x.idAplicacao);
                    table.ForeignKey(
                        name: "FK__Aplicacoe__idVag__6FE99F9F",
                        column: x => x.idVaga,
                        principalTable: "Vagas",
                        principalColumn: "idVaga");
                    table.ForeignKey(
                        name: "FK__Aplicacoes__CPF__70DDC3D8",
                        column: x => x.CPF,
                        principalTable: "Candidato",
                        principalColumn: "CPF");
                });

            migrationBuilder.CreateTable(
                name: "Requisitos",
                columns: table => new
                {
                    idRequisitos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idVaga = table.Column<int>(type: "int", nullable: true),
                    requisito = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Requisit__894FA0C7D507D6A1", x => x.idRequisitos);
                    table.ForeignKey(
                        name: "FK__Requisito__idVag__6D0D32F4",
                        column: x => x.idVaga,
                        principalTable: "Vagas",
                        principalColumn: "idVaga");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aplicacoes_CPF",
                table: "Aplicacoes",
                column: "CPF");

            migrationBuilder.CreateIndex(
                name: "IX_Aplicacoes_idVaga",
                table: "Aplicacoes",
                column: "idVaga");

            migrationBuilder.CreateIndex(
                name: "IX_Candidato_idUsuario",
                table: "Candidato",
                column: "idUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Certificacao_CPF",
                table: "Certificacao",
                column: "CPF");

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_idUsuario",
                table: "Empresa",
                column: "idUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Escolaridade_CPF",
                table: "Escolaridade",
                column: "CPF");

            migrationBuilder.CreateIndex(
                name: "IX_Experiencia_CPF",
                table: "Experiencia",
                column: "CPF");

            migrationBuilder.CreateIndex(
                name: "IX_Idioma_CPF",
                table: "Idioma",
                column: "CPF");

            migrationBuilder.CreateIndex(
                name: "IX_Projeto_CPF",
                table: "Projeto",
                column: "CPF");

            migrationBuilder.CreateIndex(
                name: "IX_Requisitos_idVaga",
                table: "Requisitos",
                column: "idVaga");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_CPF",
                table: "Skills",
                column: "CPF");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_idContato",
                table: "Usuario",
                column: "idContato");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_idEndereco",
                table: "Usuario",
                column: "idEndereco");

            migrationBuilder.CreateIndex(
                name: "UQ__Usuario__AB6E61646AB13C7F",
                table: "Usuario",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vagas_CNPJ",
                table: "Vagas",
                column: "CNPJ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aplicacoes");

            migrationBuilder.DropTable(
                name: "Certificacao");

            migrationBuilder.DropTable(
                name: "Escolaridade");

            migrationBuilder.DropTable(
                name: "Experiencia");

            migrationBuilder.DropTable(
                name: "Idioma");

            migrationBuilder.DropTable(
                name: "Projeto");

            migrationBuilder.DropTable(
                name: "Requisitos");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Vagas");

            migrationBuilder.DropTable(
                name: "Candidato");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Contato");

            migrationBuilder.DropTable(
                name: "Endereco");
        }
    }
}
