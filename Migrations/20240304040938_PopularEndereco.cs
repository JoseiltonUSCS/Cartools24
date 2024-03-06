using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cartools.Migrations
{
    public partial class PopularEndereco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Enderecos(CEP, Logradouro, Numero, Complemento, Bairro, Cidade, Estado) VALUES('09588-450', 'Rua Sena Madureira', '234', 'Loja2', 'Saude', 'São Paulo', 'SP')");

            migrationBuilder.Sql("INSERT INTO Enderecos(CEP, Logradouro, Numero, Complemento, Bairro, Cidade, Estado) VALUES('09628-458', 'Rua Sabará', '546', 'Loja1', 'Interlagos', 'São Paulo', 'SP')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Enderecos");
        }
    }
}
