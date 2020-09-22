using FCPark.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FCPark.DAL
{
    public class VeiculoConfiguration : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder
                .Property(l => l.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder
                .Property(m => m.Marca)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(m => m.Modelo)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(m => m.Cor)
                .IsRequired()
                .HasMaxLength(15);
            builder
                .Property(m => m.Placa)
                .IsRequired()
                .HasMaxLength(7);
            builder
                .Property(m => m.Tipo)
                .IsRequired()
                .HasMaxLength(25);

        }
    }
}
