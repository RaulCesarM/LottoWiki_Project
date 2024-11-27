using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LottoWiki.Data.Migrations
{
    /// <inheritdoc />
    public partial class Name : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "base.lotoFacil",
                columns: table => new
                {
                    Concurso = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    ConcursoAnterior = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    ProximoConcurso = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    Casa_01 = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    Casa_02 = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    Casa_03 = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    Casa_04 = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    Casa_05 = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    Casa_06 = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    Casa_07 = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    Casa_08 = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    Casa_09 = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    Casa_10 = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    Casa_11 = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    Casa_12 = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    Casa_13 = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    Casa_14 = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    Casa_15 = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    DataApuracao = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    NomeMunicipioUFSorteio = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    LuaDoSorteio = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_base.lotoFacil", x => new { x.Concurso, x.ConcursoAnterior, x.ProximoConcurso });
                });

            migrationBuilder.CreateTable(
                name: "bola.atraso",
                columns: table => new
                {
                    Concurso = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    ConcursoAnterior = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    ProximoConcurso = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    Bola_01 = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Bola_02 = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Bola_03 = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Bola_04 = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Bola_05 = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Bola_06 = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Bola_07 = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Bola_08 = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Bola_09 = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Bola_10 = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Bola_11 = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Bola_12 = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Bola_13 = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Bola_14 = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Bola_15 = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Bola_16 = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Bola_17 = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Bola_18 = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Bola_19 = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Bola_20 = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Bola_21 = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Bola_22 = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Bola_23 = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Bola_24 = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Bola_25 = table.Column<int>(type: "int", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bola.atraso", x => new { x.Concurso, x.ConcursoAnterior, x.ProximoConcurso });
                });

            migrationBuilder.CreateTable(
                name: "bola.repetida",
                columns: table => new
                {
                    Concurso = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    ConcursoAnterior = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    ProximoConcurso = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    Bola_01 = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Bola_02 = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Bola_03 = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Bola_04 = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Bola_05 = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Bola_06 = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Bola_07 = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Bola_08 = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Bola_09 = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Bola_10 = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Bola_11 = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Bola_12 = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Bola_13 = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Bola_14 = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Bola_15 = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Bola_16 = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Bola_17 = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Bola_18 = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Bola_19 = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Bola_20 = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Bola_21 = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Bola_22 = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Bola_23 = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Bola_24 = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Bola_25 = table.Column<int>(type: "int", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bola.repetida", x => new { x.Concurso, x.ConcursoAnterior, x.ProximoConcurso });
                });

            migrationBuilder.CreateTable(
                name: "bola.status",
                columns: table => new
                {
                    Concurso = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    ConcursoAnterior = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    ProximoConcurso = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    Bola_01 = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    Bola_02 = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    Bola_03 = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    Bola_04 = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    Bola_05 = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    Bola_06 = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    Bola_07 = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    Bola_08 = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    Bola_09 = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    Bola_10 = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    Bola_11 = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    Bola_12 = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    Bola_13 = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    Bola_14 = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    Bola_15 = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    Bola_16 = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    Bola_17 = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    Bola_18 = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    Bola_19 = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    Bola_20 = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    Bola_21 = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    Bola_22 = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    Bola_23 = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    Bola_24 = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    Bola_25 = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bola.status", x => new { x.Concurso, x.ConcursoAnterior, x.ProximoConcurso });
                });

            migrationBuilder.InsertData(
                table: "base.lotoFacil",
                columns: new[] { "Concurso", "ConcursoAnterior", "ProximoConcurso", "Casa_01", "Casa_02", "Casa_03", "Casa_04", "Casa_05", "Casa_06", "Casa_07", "Casa_08", "Casa_09", "Casa_10", "Casa_11", "Casa_12", "Casa_13", "Casa_14", "Casa_15", "DataApuracao", "LuaDoSorteio", "NomeMunicipioUFSorteio" },
                values: new object[,]
                {
                    { 1, 0, 2, 18, 20, 25, 23, 10, 11, 24, 14, 6, 2, 13, 9, 5, 16, 3, "01/02/1989", "Crescente", "CRUZ ALTA, RS" },
                    { 2, 1, 3, 23, 15, 5, 4, 12, 16, 20, 6, 11, 19, 24, 1, 9, 13, 7, "02/02/1989", "Crescente", "CRUZ ALTA, RS" },
                    { 3, 2, 4, 20, 23, 12, 8, 6, 1, 7, 11, 14, 4, 16, 10, 9, 17, 24, "02/02/1989", "Crescente", "CRUZ ALTA, RS" }
                });

            migrationBuilder.InsertData(
                table: "bola.atraso",
                columns: new[] { "Concurso", "ConcursoAnterior", "ProximoConcurso", "Bola_01", "Bola_02", "Bola_03", "Bola_04", "Bola_05", "Bola_06", "Bola_07", "Bola_08", "Bola_09", "Bola_10", "Bola_11", "Bola_12", "Bola_13", "Bola_14", "Bola_15", "Bola_16", "Bola_17", "Bola_18", "Bola_19", "Bola_20", "Bola_21", "Bola_22", "Bola_23", "Bola_24", "Bola_25" },
                values: new object[,]
                {
                    { 1, 0, 2, 1, 0, 1, 1, 0, 0, 1, 1, 0, 0, 0, 1, 0, 0, 1, 0, 0, 1, 1, 0, 1, 1, 0, 0, 0 },
                    { 2, 1, 3, 2, 1, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 1, 1, 0, 0, 2, 2, 0, 0, 1 },
                    { 3, 2, 4, 0, 2, 2, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 2, 1, 0, 3, 3, 0, 0, 2 }
                });

            migrationBuilder.InsertData(
                table: "bola.status",
                columns: new[] { "Concurso", "ConcursoAnterior", "ProximoConcurso", "Bola_01", "Bola_02", "Bola_03", "Bola_04", "Bola_05", "Bola_06", "Bola_07", "Bola_08", "Bola_09", "Bola_10", "Bola_11", "Bola_12", "Bola_13", "Bola_14", "Bola_15", "Bola_16", "Bola_17", "Bola_18", "Bola_19", "Bola_20", "Bola_21", "Bola_22", "Bola_23", "Bola_24", "Bola_25" },
                values: new object[,]
                {
                    { 1, 0, 2, "A", "N", "N", "A", "N", "N", "A", "A", "N", "N", "N", "A", "N", "N", "A", "N", "A", "N", "A", "N", "A", "A", "N", "N", "N" },
                    { 2, 1, 3, "R", "R", "R", "R", "R", "R", "R", "R", "R", "R", "R", "R", "R", "R", "R", "R", "R", "R", "R", "R", "R", "R", "R", "R", "R" },
                    { 3, 2, 4, "A", "A", "A", "A", "A", "A", "A", "A", "A", "A", "A", "A", "A", "A", "A", "A", "A", "A", "A", "A", "A", "A", "A", "A", "A" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "base.lotoFacil");

            migrationBuilder.DropTable(
                name: "bola.atraso");

            migrationBuilder.DropTable(
                name: "bola.repetida");

            migrationBuilder.DropTable(
                name: "bola.status");
        }
    }
}
