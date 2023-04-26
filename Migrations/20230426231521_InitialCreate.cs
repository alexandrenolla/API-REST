using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RESTful_API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ALUNOS",
                columns: table => new
                {
                    Código = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", nullable: false),
                    Datadenascimento = table.Column<DateTime>(name: "Data de nascimento", type: "TEXT", nullable: false),
                    Cpf = table.Column<string>(type: "TEXT", nullable: false),
                    SituaçãodaMatrícula = table.Column<string>(name: "Situação da Matrícula", type: "TEXT", nullable: false),
                    Nota = table.Column<float>(type: "REAL", nullable: false),
                    QtdAtendimentos = table.Column<int>(name: "Qtd Atendimentos", type: "INTEGER", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ALUNOS", x => x.Código);
                });

            migrationBuilder.CreateTable(
                name: "PEDAGOGOS",
                columns: table => new
                {
                    Código = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", nullable: false),
                    Datadenascimento = table.Column<DateTime>(name: "Data de nascimento", type: "TEXT", nullable: false),
                    Cpf = table.Column<string>(type: "TEXT", nullable: false),
                    QtdAtendimentos = table.Column<int>(name: "Qtd Atendimentos", type: "INTEGER", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PEDAGOGOS", x => x.Código);
                });

            migrationBuilder.CreateTable(
                name: "PROFESSORES",
                columns: table => new
                {
                    Código = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", nullable: false),
                    Datadenascimento = table.Column<DateTime>(name: "Data de nascimento", type: "TEXT", nullable: false),
                    Cpf = table.Column<string>(type: "TEXT", nullable: false),
                    Estado = table.Column<string>(type: "TEXT", nullable: false),
                    Experiência = table.Column<string>(type: "TEXT", nullable: false),
                    FormaçãoAcadêmica = table.Column<string>(name: "Formação Acadêmica", type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROFESSORES", x => x.Código);
                });

            migrationBuilder.InsertData(
                table: "ALUNOS",
                columns: new[] { "Código", "Cpf", "Data de nascimento", "Nome", "Nota", "Situação da Matrícula", "Telefone" },
                values: new object[,]
                {
                    { 1, "11839750073", new DateTime(2014, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bart Simpson", 3.5f, "IRREGULAR", "11-11111-1212" },
                    { 2, "17158947076", new DateTime(2012, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lisa Simpson", 10f, "ATIVO", "11-22222-2222" },
                    { 3, "63701210020", new DateTime(2019, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Meggie Simpson", 9f, "ATIVO", "12-20002-2200" },
                    { 4, "30119137062", new DateTime(2014, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Milhouse Van Houten", 8f, "ATIVO", "11-33333-2222" },
                    { 5, "95704094015", new DateTime(2007, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nelson Muntz", 2f, "INATIVO", "11-44333-4444" }
                });

            migrationBuilder.InsertData(
                table: "PEDAGOGOS",
                columns: new[] { "Código", "Cpf", "Data de nascimento", "Nome", "Telefone" },
                values: new object[,]
                {
                    { 1, "62316840086", new DateTime(2000, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Snow", "11-67333-4454" },
                    { 2, "49850253053", new DateTime(2004, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sansa Stark", "22-22333-4454" },
                    { 3, "39125106015", new DateTime(1990, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tyrion Lannister", "33-77333-4454" },
                    { 4, "89089606009", new DateTime(1995, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sandor Clegane", "11-33333-2222" }
                });

            migrationBuilder.InsertData(
                table: "PROFESSORES",
                columns: new[] { "Código", "Cpf", "Data de nascimento", "Estado", "Experiência", "Formação Acadêmica", "Nome", "Telefone" },
                values: new object[,]
                {
                    { 1, "40539019011", new DateTime(1982, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "ATIVO", "FULL_STACK", "MESTRADO", "Walter White", "14-22998-1882" },
                    { 2, "96107295097", new DateTime(1997, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "ATIVO", "BACK_END", "GRADUACAO_INCOMPLETA", "Jesse Pinkman", "44-11111-1992" },
                    { 3, "70685977005", new DateTime(1984, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "ATIVO", "FULL_STACK", "MESTRADO", "Hank Schrader", "44-11111-1002" },
                    { 4, "57408927085", new DateTime(1977, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "INATIVO", "FRONT_END", "GRADUACAO_INCOMPLETA", "Gustavo Fring", "44-11001-1002" },
                    { 5, "86940162062", new DateTime(1980, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "ATIVO", "FULL_STACK", "MESTRADO", "Saul Goodman", "44-11998-1882" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ALUNOS");

            migrationBuilder.DropTable(
                name: "PEDAGOGOS");

            migrationBuilder.DropTable(
                name: "PROFESSORES");
        }
    }
}
