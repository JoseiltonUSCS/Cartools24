using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cartools.Migrations
{
    public partial class TabPlan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plans",
                columns: table => new
                {
                    PlanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlanTipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DescricaoCurta = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DescricaoDetalhada = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageThumbnailUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPlanPreferido = table.Column<bool>(type: "bit", nullable: false),
                    PlanStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OficinaId = table.Column<int>(type: "int", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plans", x => x.PlanId);
                    table.ForeignKey(
                        name: "FK_Plans_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Plans_Oficinas_OficinaId",
                        column: x => x.OficinaId,
                        principalTable: "Oficinas",
                        principalColumn: "OficinaId",
                        onDelete: ReferentialAction.Cascade);
                });

          

            migrationBuilder.CreateIndex(
                name: "IX_Plans_CategoriaId",
                table: "Plans",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_OficinaId",
                table: "Plans",
                column: "OficinaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropTable(
                name: "Plans");



        }
    }
}
