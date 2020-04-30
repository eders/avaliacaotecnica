using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Marca",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marca", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modelo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: false),
                    Ano = table.Column<string>(nullable: false),
                    MarcaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modelo_Marca_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "Marca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Anuncio",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValorDeCompra = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ValorDeVenda = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Cor = table.Column<int>(nullable: false),
                    TipoDeCombustivel = table.Column<int>(nullable: false),
                    DataDeVenda = table.Column<DateTime>(nullable: true),
                    ModeloId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anuncio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Anuncio_Modelo_ModeloId",
                        column: x => x.ModeloId,
                        principalTable: "Modelo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Marca",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Chevrolet" },
                    { 2, "Fiat" },
                    { 3, "Ford" },
                    { 4, "Honda" }
                });

            migrationBuilder.InsertData(
                table: "Modelo",
                columns: new[] { "Id", "Ano", "MarcaId", "Nome" },
                values: new object[,]
                {
                    { 1, "2000", 1, "Corsa" },
                    { 22, "2009", 4, "CRV" },
                    { 21, "2018", 4, "Civic" },
                    { 20, "2016", 4, "Civic" },
                    { 19, "2014", 4, "Civic" },
                    { 18, "2019", 3, "Ranger" },
                    { 17, "2018", 3, "Ranger" },
                    { 16, "2016", 3, "Ranger" },
                    { 15, "2007", 3, "Fiesta" },
                    { 14, "2005", 3, "Fiesta" },
                    { 13, "2001", 3, "Fiesta" },
                    { 12, "2016", 2, "Fiorino" },
                    { 11, "2015", 2, "Fiorino" },
                    { 10, "2001", 2, "Fiorino" },
                    { 9, "2015", 2, "Uno" },
                    { 8, "2011", 2, "Uno" },
                    { 7, "2001", 2, "Uno" },
                    { 6, "2009", 1, "Montana" },
                    { 5, "2005", 1, "Montana" },
                    { 4, "2000", 1, "Montana" },
                    { 3, "2009", 1, "Corsa" },
                    { 2, "2005", 1, "Corsa" },
                    { 23, "2010", 4, "CRV" },
                    { 24, "2019", 4, "CRV" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Anuncio_ModeloId",
                table: "Anuncio",
                column: "ModeloId");

            migrationBuilder.CreateIndex(
                name: "IX_Modelo_MarcaId",
                table: "Modelo",
                column: "MarcaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Anuncio");

            migrationBuilder.DropTable(
                name: "Modelo");

            migrationBuilder.DropTable(
                name: "Marca");
        }
    }
}
