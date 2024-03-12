using Cartools.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cartools.Context
{    
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<CarrinhoCompraItem> CarrinhoCompraItens { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoDetalhe> PedidoDetalhes { get; set; }
        public DbSet<EmailTicket> EmailTickets { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }
        public DbSet<Local> Locals { get; set; }
        public DbSet<Oficina> Oficinas { get; set; }
        public DbSet<Plan> Plans { get; set; }
    }
}
