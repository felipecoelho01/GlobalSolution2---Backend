using GlobalSolution2._0.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalSolution2._0.Infrastructure.Data.Configurations
{
    public class VagaConfiguration : IEntityTypeConfiguration<VagaModel>
    {
        public void Configure(EntityTypeBuilder<VagaModel> builder)
        {
            builder.ToTable("Vaga");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Titulo)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Descricao)
                .IsRequired()
                .HasColumnType("nvarchar(max)");

            builder.Property(x => x.Tipo_contrato)
                .IsRequired()
                .HasMaxLength(30)
                .HasConversion<string>();

            builder.Property(x => x.Modalidade)
                .IsRequired()
                .HasMaxLength(20)
                .HasConversion<string>();

            builder.Property(x => x.Salario_min)
                .HasColumnType("decimal(10,2)");

            builder.Property(x => x.Salario_max)
                .HasColumnType("decimal(10,2)");

            builder.Property(x => x.Cidade)
                .HasMaxLength(100);

            builder.Property(x => x.Estado)
                .HasMaxLength(2)
                .IsFixedLength();

            builder.Property(x => x.Ativa)
                .IsRequired()
                .HasDefaultValue(true);

            builder.Property(x => x.CreatedOn)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            builder.HasIndex(x => x.Estado);
            builder.HasIndex(x => x.Cidade);
            builder.HasIndex(x => x.Ativa);
            builder.HasIndex(x => x.Empresa_id);
            builder.HasIndex(x => x.Categoria_id);

            builder.HasOne(x => x.Empresa)
                .WithMany(_ => _.Vagas)
                .HasForeignKey(x => x.Empresa_id)
                .OnDelete(DeleteBehavior.Cascade);


            builder.HasOne(x => x.Categoria)
                .WithMany(x => x.Vagas)
                .HasForeignKey(x => x.Categoria_id)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
