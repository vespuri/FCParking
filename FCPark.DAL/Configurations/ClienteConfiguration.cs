using FCPark.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FCPark.DAL
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder
                .Property(l => l.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder
                .Property(m => m.Nome)
                .IsRequired()
                .HasMaxLength(250);

            builder
                .Property(m => m.Endereco)
                .IsRequired()
                .HasMaxLength(250);
            builder
                .Property(m => m.Telefone)
                .IsRequired()
                .HasMaxLength(25);

        }
    }
}
