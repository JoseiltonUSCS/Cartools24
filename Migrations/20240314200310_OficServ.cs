using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cartools.Migrations
{
    public partial class OficServ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OficinaServico");

            migrationBuilder.DropColumn(
                name: "ServicoId",
                table: "Oficinas");

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_OficinaId",
                table: "Servicos",
                column: "OficinaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Servicos_Oficinas_OficinaId",
                table: "Servicos",
                column: "OficinaId",
                principalTable: "Oficinas",
                principalColumn: "OficinaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servicos_Oficinas_OficinaId",
                table: "Servicos");

            migrationBuilder.DropIndex(
                name: "IX_Servicos_OficinaId",
                table: "Servicos");

            migrationBuilder.AddColumn<int>(
                name: "ServicoId",
                table: "Oficinas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "OficinaServico",
                columns: table => new
                {
                    OficinasOficinaId = table.Column<int>(type: "int", nullable: false),
                    ServicosServicoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OficinaServico", x => new { x.OficinasOficinaId, x.ServicosServicoId });
                    table.ForeignKey(
                        name: "FK_OficinaServico_Oficinas_OficinasOficinaId",
                        column: x => x.OficinasOficinaId,
                        principalTable: "Oficinas",
                        principalColumn: "OficinaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OficinaServico_Servicos_ServicosServicoId",
                        column: x => x.ServicosServicoId,
                        principalTable: "Servicos",
                        principalColumn: "ServicoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OficinaServico_ServicosServicoId",
                table: "OficinaServico",
                column: "ServicosServicoId");
        }
    }
}
