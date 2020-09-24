﻿// <auto-generated />
using System;
using IExpress.Pagamentos.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IExpress.Pagamentos.Infrastructure.Data.Migrations
{
    [DbContext(typeof(PagamentoContext))]
    [Migration("20200924032945_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IExpress.Pagamentos.Domain.DomainObjects.Pagamento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PedidoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("Id");

                    b.ToTable("Pagamentos");
                });

            modelBuilder.Entity("IExpress.Pagamentos.Domain.DomainObjects.Transacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PagamentoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PedidoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("StatusTransacao")
                        .HasColumnType("int");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("Id");

                    b.HasIndex("PagamentoId")
                        .IsUnique();

                    b.ToTable("Transacoes");
                });

            modelBuilder.Entity("IExpress.Pagamentos.Domain.DomainObjects.Transacao", b =>
                {
                    b.HasOne("IExpress.Pagamentos.Domain.DomainObjects.Pagamento", "Pagamento")
                        .WithOne("Transacao")
                        .HasForeignKey("IExpress.Pagamentos.Domain.DomainObjects.Transacao", "PagamentoId")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
