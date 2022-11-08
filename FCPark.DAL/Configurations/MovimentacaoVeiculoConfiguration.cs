using FCPark.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FCPark.DAL
{
    public class MovimentacaoVeiculoConfiguration : IEntityTypeConfiguration<MovimentacaoVeiculo>
    {
        public void Configure(EntityTypeBuilder<MovimentacaoVeiculo> builder)
        {
            builder
                .Property(l => l.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();
            builder
                .Property(l => l.VeiculoId)
                .IsRequired();
            builder
                .Property(l => l.EstabelecimentoId)
                .IsRequired();
            builder
                .Property(l => l.ClienteId)
                .IsRequired();
        }
            
    }
}
