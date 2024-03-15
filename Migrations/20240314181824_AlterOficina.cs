using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cartools.Migrations
{
    public partial class AlterOficina : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Oficinas",
                newName: "OficinaNome");

            migrationBuilder.RenameColumn(
                name: "Telefone",
                table: "Oficinas",
                newName: "OficinaTelefone");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Oficinas",
                newName: "OficinaEmail");

            migrationBuilder.RenameColumn(
                name: "CEP",
                table: "Oficinas",
                newName: "OficinaCEP");

            migrationBuilder.RenameColumn(
                name: "Logradouro",
                table: "Oficinas",
                newName: "OficinaLogradouro");

            migrationBuilder.RenameColumn(
                name: "Numero",
                table: "Oficinas",
                newName: "OficinaNumero");

            migrationBuilder.RenameColumn(
                name: "Complemento",
                table: "Oficinas",
                newName: "OficinaComplemento");

            migrationBuilder.RenameColumn(
                name: "Bairro",
                table: "Oficinas",
                newName: "OficinaBairro");

            migrationBuilder.RenameColumn(
                name: "Cidade",
                table: "Oficinas",
                newName: "OficinaCidade");

            migrationBuilder.RenameColumn(
                name: "Estado",
                table: "Oficinas",
                newName: "OficinaEstado");

        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
