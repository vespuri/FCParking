using FCPark.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FCPark.DAL
{
    public class EstabelecimentoConfiguration : IEntityTypeConfiguration<Estabelecimento>
    {
        public void Configure(EntityTypeBuilder<Estabelecimento> builder)
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
                .Property(m => m.CNPJ)
                .IsRequired()
                .HasMaxLength(14);
            builder
                .Property(m => m.Endereco)
                .IsRequired()
                .HasMaxLength(250);
            builder
                .Property(m => m.Telefone)
                .IsRequired()
                .HasMaxLength(25);
            builder
                .Property(m => m.QtdVagasCarros)
                .IsRequired();
            builder
                .Property(m => m.QtdVagasMotos)
                .IsRequired();

        }
    }
}
