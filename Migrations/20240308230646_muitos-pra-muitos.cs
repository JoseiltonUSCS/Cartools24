using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cartools.Migrations
{
    public partial class muitospramuitos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocalId",
                table: "Servicos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Locals",
                columns: table => new
                {
                    LocalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServicoId = table.Column<int>(type: "int", nullable: false),
                    OficinaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locals", x => x.LocalId);
                });

            migrationBuilder.CreateTable(
                name: "Oficinas",
                columns: table => new
                {
                    OficinaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CEP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logradouro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Complemento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocalId = table.Column<int>(type: "int", nullable: false),
                    ServicoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oficinas", x => x.OficinaId);
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocalOficina");

            migrationBuilder.DropTable(
                name: "LocalServico");

            migrationBuilder.DropTable(
                name: "OficinaServico");

            migrationBuilder.DropTable(
                name: "Locals");

            migrationBuilder.DropTable(
                name: "Oficinas");

            migrationBuilder.DropColumn(
                name: "LocalId",
                table: "Servicos");
        }
    }
}
