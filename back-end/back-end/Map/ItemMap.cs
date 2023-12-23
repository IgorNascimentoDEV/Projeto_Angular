using back.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace back.Map
{
    public class ItemMap : BaseMap<ItensModel>
    {
        public ItemMap() : base("tb_item")
        {
        }

        public override void Configure(EntityTypeBuilder<ItensModel> builder)
        {
            base.Configure(builder);

            builder.ToTable("tb_item");
            builder.Property(x => x.Codigo).HasColumnType("int").HasColumnName("codigo").IsRequired();
            builder.Property(x => x.Nome).HasColumnType("varchar(50)").HasColumnName("nome").IsRequired();
            builder.Property(x => x.Preco).HasColumnType("float").HasColumnName("preco").IsRequired();
            builder.Property(x => x.Quantidade).HasColumnType("int").HasColumnName("quantidade").IsRequired();
        }
    }
}
