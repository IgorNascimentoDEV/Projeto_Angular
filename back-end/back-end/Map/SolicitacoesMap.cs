using back.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace back.Map
{
    public class SolicitacoesMap : BaseMap<SolicitacoesModel>
    {
        public SolicitacoesMap() : base("tb_solicitacoes")
        {
        }

        public override void Configure(EntityTypeBuilder<SolicitacoesModel> builder)
        {
            base.Configure(builder);

            builder.ToTable("tb_solicitacoes");
            builder.Property(x => x.Solicitante).HasColumnType("varchar(50)").HasColumnName("solicitante").IsRequired();
            builder.Property(x => x.Setor).HasColumnType("varchar(50)").HasColumnName("setor").IsRequired();
            builder.Property(x => x.Quantidade).HasColumnType("int").HasColumnName("quantidade").IsRequired();
            builder.Property(x => x.CentroDeCusto).HasColumnType("int").HasColumnName("centro_custo").IsRequired();
            builder.Property(x => x.DataSolicitacao).HasColumnType("varchar(50)").HasColumnName("data_solicitacao").IsRequired();
            builder.Property(x => x.Status).HasColumnType("varchar(50)").HasColumnName("status").IsRequired();

            // Correção do relacionamento para indicar que cada Solicitacao está associada a um único Item
            builder.HasOne(x => x.Item).WithMany(x => x.Solicitacoes).IsRequired();
        }
    }
}
