using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cartools.Migrations
{
    public partial class Oficina : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "IsOficinaPreferida",
                table: "Oficinas",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
