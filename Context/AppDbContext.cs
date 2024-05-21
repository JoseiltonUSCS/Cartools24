using Cartools.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
        public DbSet<Tipo> Tipos { get; set; }
        public DbSet<Plano> Planos { get; set; }
        public DbSet<Disponibilidade> Disponibilidades { get; set; }
        public DbSet<HoraDisponibilidade> HoraDisponibilidade { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração do relacionamento entre Disponibilidade e HoraDisponibilidade
            modelBuilder.Entity<Disponibilidade>()
                .HasMany(d => d.HorasDisponibilidade)
                .WithOne()
                .HasForeignKey(h => h.DisponibilidadeId);
        }
    }
}
