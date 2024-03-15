using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cartools.Migrations
{
    public partial class PlanoTipoRelacmts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "Tipos",
                columns: table => new
                {
                    TipoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoDescricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipos", x => x.TipoId);
                });

            migrationBuilder.CreateTable(
                name: "Planos",
                columns: table => new
                {
                    PlanoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanoNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlanoDescricao = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    PlanoPreco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PlanoImagem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPlanoPreferido = table.Column<bool>(type: "bit", nullable: false),
                    TipoId = table.Column<int>(type: "int", nullable: false)
                },

                constraints: table =>
                {
                    table.PrimaryKey("PK_Planos", x => x.PlanoId);
                    table.ForeignKey(
                        name: "FK_Planos_Tipos_TipoId",
                        column: x => x.TipoId,
                        principalTable: "Tipos",
                        principalColumn: "TipoId",
                        onDelete: ReferentialAction.Cascade);
                });




            migrationBuilder.CreateIndex(
                name: "IX_Planos_TipoId",
                table: "Planos",
                column: "TipoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropTable(
                name: "Planos");


            migrationBuilder.DropTable(
                name: "Tipos");
        }
    }
}
