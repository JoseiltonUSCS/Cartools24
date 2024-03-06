using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cartools.Migrations
{
    public partial class Anuncios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Servicos(Nome, DescricaoCurta, DescricaoDetalhada,CategoriaId, Preco,  ImagemUrl) VALUES ('Detail Garage', 'Polimento', 'Polimento especializado','4', '230.00','https://localhost:7283/images/polimento.jpg')");

            migrationBuilder.Sql("INSERT INTO Servicos(Nome, DescricaoCurta, DescricaoDetalhada,CategoriaId, Preco,  ImagemUrl) VALUES ('Envelopa Cars', 'Envelopamento', 'Envelopamento de veículos de passeio','4', '420.00','https://localhost:7283/images/11.png')");

            migrationBuilder.Sql("INSERT INTO Servicos(Nome, DescricaoCurta, DescricaoDetalhada,CategoriaId, Preco,  ImagemUrl) VALUES ('Company99', 'Vitrificação', 'Vitrificação','4', '600.00','https://localhost:7283/images/vitrificacaoBlack.jpg')");

            migrationBuilder.Sql("INSERT INTO Servicos(Nome, DescricaoCurta, DescricaoDetalhada,CategoriaId, Preco,  ImagemUrl) VALUES ('DM AutoCare', 'Oxisanitização', 'Oxisanitização do sistema de ar','5', '60.00','https://localhost:7283/images/oxiSanitizacao.jpg')");

            migrationBuilder.Sql("INSERT INTO Servicos(Nome, DescricaoCurta, DescricaoDetalhada,CategoriaId, Preco,  ImagemUrl) VALUES ('Company99', 'Higienização', 'Higienização de painéis e bancos','5', '600.00','https://localhost:7283/images/higienizacao.jpg')");

            migrationBuilder.Sql("INSERT INTO Servicos(Nome, DescricaoCurta, DescricaoDetalhada,CategoriaId, Preco,  ImagemUrl) VALUES ('DM AutoCare', 'Cristalização', 'Cristalização da pintura','6', '60.00','https://localhost:7283/images/cristalizacao.jpg')");
        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Servicos");
        }
    }
}
