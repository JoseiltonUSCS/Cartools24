using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cartools.Migrations
{
    public partial class OficinaLocalTabs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocalOficina");

            migrationBuilder.DropTable(
                name: "LocalServico");

            migrationBuilder.DropTable(
                name: "OficinaServico");

            migrationBuilder.DropColumn(
                name: "LocalId",
                table: "Servicos");


            migrationBuilder.DropColumn(
                name: "LocalId",
                table: "Oficinas");

            migrationBuilder.DropColumn(
                name: "ServicoId",
                table: "Oficinas");

            migrationBuilder.DropColumn(
                name: "OficinaId",
                table: "Locals");

            migrationBuilder.DropColumn(
                name: "ServicoId",
                table: "Locals");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocalId",
                table: "Servicos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OficinaId",
                table: "Servicos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LocalId",
                table: "Oficinas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ServicoId",
                table: "Oficinas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OficinaId",
                table: "Locals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ServicoId",
                table: "Locals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "LocalOficina",
                columns: table => new
                {
                    LocalsLocalId = table.Column<int>(type: "int", nullable: false),
                    OficinasOficinaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalOficina", x => new { x.LocalsLocalId, x.OficinasOficinaId });
                    table.ForeignKey(
                        name: "FK_LocalOficina_Locals_LocalsLocalId",
                        column: x => x.LocalsLocalId,
                        principalTable: "Locals",
                        principalColumn: "LocalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocalOficina_Oficinas_OficinasOficinaId",
                        column: x => x.OficinasOficinaId,
                        principalTable: "Oficinas",
                        principalColumn: "OficinaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocalServico",
                columns: table => new
                {
                    LocalsLocalId = table.Column<int>(type: "int", nullable: false),
                    ServicosServicoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalServico", x => new { x.LocalsLocalId, x.ServicosServicoId });
                    table.ForeignKey(
                        name: "FK_LocalServico_Locals_LocalsLocalId",
                        column: x => x.LocalsLocalId,
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
                name: "IX_LocalOficina_OficinasOficinaId",
                table: "LocalOficina",
                column: "OficinasOficinaId");

            migrationBuilder.CreateIndex(
                name: "IX_LocalServico_ServicosServicoId",
                table: "LocalServico",
                column: "ServicosServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_OficinaServico_ServicosServicoId",
                table: "OficinaServico",
                column: "ServicosServicoId");
        }
    }
}
