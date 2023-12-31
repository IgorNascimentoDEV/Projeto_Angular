﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using back.Infrastructure.Context;

#nullable disable

namespace back.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("back.Domain.Models.ItensModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("Codigo")
                        .HasColumnType("int")
                        .HasColumnName("codigo");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nome");

                    b.Property<double>("Preco")
                        .HasColumnType("float")
                        .HasColumnName("preco");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int")
                        .HasColumnName("quantidade");

                    b.HasKey("Id");

                    b.ToTable("tb_item", (string)null);
                });

            modelBuilder.Entity("back.Domain.Models.SolicitacoesModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("CentroDeCusto")
                        .HasColumnType("int")
                        .HasColumnName("centro_custo");

                    b.Property<string>("DataSolicitacao")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("data_solicitacao");

                    b.Property<long>("ItemId")
                        .HasColumnType("bigint");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int")
                        .HasColumnName("quantidade");

                    b.Property<string>("Setor")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("setor");

                    b.Property<string>("Solicitante")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("solicitante");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.ToTable("tb_solicitacoes", (string)null);
                });

            modelBuilder.Entity("back.Domain.Models.SolicitacoesModel", b =>
                {
                    b.HasOne("back.Domain.Models.ItensModel", "Item")
                        .WithMany("Solicitacoes")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("back.Domain.Models.ItensModel", b =>
                {
                    b.Navigation("Solicitacoes");
                });
#pragma warning restore 612, 618
        }
    }
}
