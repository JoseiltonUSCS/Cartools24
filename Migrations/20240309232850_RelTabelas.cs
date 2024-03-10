using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cartools.Migrations
{
    public partial class RelTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LocalServico",
                columns: table => new
                {
                    LocalId = table.Column<int>(type: "int", nullable: false),
                    ServicosServicoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalServico", x => new { x.LocalId, x.ServicosServicoId });
                    table.ForeignKey(
                        name: "FK_LocalServico_Locals_LocalId",
                        column: x => x.LocalId,
                        principalTable: "Locals",
                        principalColumn: "LocalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocalServico_Servicos_ServicosServicoId",
                        column: x => x.ServicosServicoId,
                        principalTable: "Servicos",
                        principalColumn: "ServicoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OficinaServico",
                columns: table => new
                {
                    OficinaId = table.Column<int>(type: "int", nullable: false),
                    ServicosServicoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OficinaServico", x => new { x.OficinaId, x.ServicosServicoId });
                    table.ForeignKey(
                        name: "FK_OficinaServico_Oficinas_OficinaId",
                        column: x => x.OficinaId,
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
                name: "IX_LocalServico_ServicosServicoId",
                table: "LocalServico",
                column: "ServicosServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_OficinaServico_ServicosServicoId",
                table: "OficinaServico",
                column: "ServicosServicoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Oficinas_Locals_LocalId",
                table: "Oficinas");

            migrationBuilder.DropTable(
                name: "LocalServico");

            migrationBuilder.DropTable(
                name: "OficinaServico");

            migrationBuilder.DropIndex(
                name: "IX_Oficinas_LocalId",
                table: "Oficinas");

            migrationBuilder.DropColumn(
                name: "LocalId",
                table: "Servicos");

            migrationBuilder.DropColumn(
                name: "OficinaId",
                table: "Servicos");

            migrationBuilder.DropColumn(
                name: "LocalId",
                table: "Oficinas");

            migrationBuilder.DropColumn(
                name: "ServicoId",
                table: "Locals");
        }
    }
}
