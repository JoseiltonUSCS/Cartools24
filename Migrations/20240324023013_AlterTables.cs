using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cartools.Migrations
{
    public partial class AlterTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarrinhoCompraItens_Servicos_ServicoId",
                table: "CarrinhoCompraItens");

            migrationBuilder.DropIndex(
                name: "IX_CarrinhoCompraItens_ServicoId",
                table: "CarrinhoCompraItens");

            migrationBuilder.AlterColumn<string>(
     name: "DescricaoDetalhada",
     table: "Servicos",
     type: "nvarchar(600)",
     maxLength: 600,
     nullable: false,
     oldClrType: typeof(string),
     oldType: "nvarchar(200)",
     oldMaxLength: 200);


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servicos_Oficinas_OficinaId",
                table: "Servicos");

            migrationBuilder.DropIndex(
                name: "IX_Servicos_OficinaId",
                table: "Servicos");

            migrationBuilder.DropColumn(
                name: "OficinaId",
                table: "Servicos");

            migrationBuilder.AlterColumn<string>(
                name: "DescricaoDetalhada",
                table: "Servicos",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(600)",
                oldMaxLength: 600);

            migrationBuilder.AddColumn<int>(
                name: "PlanoId",
                table: "CarrinhoCompraItens",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OficinaServico",
                columns: table => new
                {
                    OficinaId = table.Column<int>(type: "int", nullable: false),
                    ServicoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OficinaServico", x => new { x.OficinaId, x.ServicoId });
                    table.ForeignKey(
                        name: "FK_OficinaServico_Oficinas_OficinaId",
                        column: x => x.OficinaId,
                        principalTable: "Oficinas",
                        principalColumn: "OficinaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OficinaServico_Servicos_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "Servicos",
                        principalColumn: "ServicoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarrinhoCompraItens_ServicoId",
                table: "CarrinhoCompraItens",
                column: "ServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_OficinaServico_ServicoId",
                table: "OficinaServico",
                column: "ServicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarrinhoCompraItens_Servicos_ServicoId",
                table: "CarrinhoCompraItens",
                column: "ServicoId",
                principalTable: "Servicos",
                principalColumn: "ServicoId");
        }
    }
}
