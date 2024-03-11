using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cartools.Migrations
{
    public partial class PlanoCarrinhoCompraItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlanoId",
                table: "CarrinhoCompraItens",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Planos",
                columns: table => new
                {
                    PlanoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanoTipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DescricaoCurta = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    OficinaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planos", x => x.PlanoId);
                    table.ForeignKey(
                        name: "FK_Planos_Oficinas_OficinaId",
                        column: x => x.OficinaId,
                        principalTable: "Oficinas",
                        principalColumn: "OficinaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarrinhoCompraItens_PlanoId",
                table: "CarrinhoCompraItens",
                column: "PlanoId");

            migrationBuilder.CreateIndex(
                name: "IX_Planos_OficinaId",
                table: "Planos",
                column: "OficinaId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarrinhoCompraItens_Planos_PlanoId",
                table: "CarrinhoCompraItens",
                column: "PlanoId",
                principalTable: "Planos",
                principalColumn: "PlanoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarrinhoCompraItens_Planos_PlanoId",
                table: "CarrinhoCompraItens");

            migrationBuilder.DropTable(
                name: "Planos");

            migrationBuilder.DropIndex(
                name: "IX_CarrinhoCompraItens_PlanoId",
                table: "CarrinhoCompraItens");

            migrationBuilder.DropColumn(
                name: "PlanoId",
                table: "CarrinhoCompraItens");
        }
    }
}
