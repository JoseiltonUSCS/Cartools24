using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cartools.Migrations
{
    public partial class PopularServico2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Servicos(Nome, DescricaoCurta, DescricaoDetalhada, CategoriaId, Preco,  ImagemUrl) VALUES ('Detail Garage', 'Polimento', 'Polimento especializado','5', '230.00','localhost:7283/images/71.png')");

            migrationBuilder.Sql("INSERT INTO Servicos(Nome, DescricaoCurta, DescricaoDetalhada, CategoriaId, Preco,  ImagemUrl) VALUES ('Envelopa Cars', 'Envelopamento', 'Envelopamento de veículos de passeio', '5', '420.00','localhost:7283/images/11.png')");

            migrationBuilder.Sql("INSERT INTO Servicos(Nome, DescricaoCurta, DescricaoDetalhada,CategoriaId, Preco,  ImagemUrl) VALUES ('Company99', 'Cristalização', 'Cristalização da pintura','5', '600.00','localhost:7283/images/41.png')");

            migrationBuilder.Sql("INSERT INTO Servicos(Nome, DescricaoCurta, DescricaoDetalhada,CategoriaId, Preco,  ImagemUrl) VALUES ('DM AutoCare', 'Lavagem simples', 'Lavagem externa e aspiração interna do veículo', '5', '60.00','localhost:7283/images/lavagemCompleta.jpg')");
        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Servicos");
        }
    }
}
