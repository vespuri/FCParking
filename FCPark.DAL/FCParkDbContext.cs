using FCPark.Core;
using Microsoft.EntityFrameworkCore;
using System;

namespace FCPark.DAL
{
    public class FCParkDbContext : DbContext
    {

        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Estabelecimento> Estabelecimentos { get; set; }
        public DbSet<MovimentacaoVeiculo> MovimentacaoVeiculos { get; set; }
        public FCParkDbContext(DbContextOptions<FCParkDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new VeiculoConfiguration());

            modelBuilder
                .ApplyConfiguration(new EstabelecimentoConfiguration());

            modelBuilder
                .ApplyConfiguration(new MovimentacaoVeiculoConfiguration());
        }
    }
}
