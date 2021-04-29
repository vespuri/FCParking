using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiCurso.Data.Configurations
{
    public class PedidoItem
    {
        public object Id { get; private set; }
        public object Quantidade { get; private set; }
        public object Valor { get; private set; }
        public object Desconto { get; private set; }

        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {
            builder.ToTable("PedidoItens");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Quantidade).HasDefaultValue(0).IsRequired();
            builder.Property(p => p.Valor).HasDefaultValue(0).IsRequired();
            builder.Property(p => p.Desconto).HasDefaultValue(0).IsRequired();
        }
    }
}
