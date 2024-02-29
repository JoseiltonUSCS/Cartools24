using Cartools.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cartools.Context
{
    //AppDbContext é uma classe de contexto que vai herdar da classe DbContext que é uma classe do EntityFrameworkCore.
    //Nesta classe eu vou definir quais são as classes do meu Modelo de Domínio que eu quero mapear.
    //AppDbContext é a classe de contexto. Ela carrega informações de configurações do DbContext e define as classes que estou mapeando e pra quais tabelas
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        //Aqui nós criamos e construtor e usamos a classe DbContextOptions e referenciamos ao nosso contexto (classe de contexto AppDbContext)
        //definimos como options e passamos ao construtor da classe base, que é a classe DbContext
        //Essa classe DbContextOptions define as opções a serem usadas pelo DbContext e vai carregar as informações de configurações necessa-
        //rias para configurar o DbContext


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        //Tabelas a serem criadas quando aplicar o Migrations ("Categorias e Servicos")
        //Estou mapeando as minhas classes "Categoria e Servico" para as tabelas acima que serão criadas a partir do Migrations.
        //O nome das propriedades "Categorias" e "Servicos" é o nome das tabelas que serão criadas pelo EntityFramework Core através do Migrations.

        //    <classe>          |    Tabela
        //  Categoria           |   Categorias 
        //  Servico             |   Servicos 
        //  CarrinhoCompraItem  |   CarrinhoCompraItens 
        //  Pedido              |   Pedidos 
        //  PedidoDetalhe       |   PedidoDetalhes 
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<CarrinhoCompraItem> CarrinhoCompraItens { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoDetalhe> PedidoDetalhes { get; set; }


    }
}
