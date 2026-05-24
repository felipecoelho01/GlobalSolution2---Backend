using GlobalSolution2._0.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalSolution2._0.Infrastructure.Data.Configurations
{
    public class EmpresaConfiguration : IEntityTypeConfiguration<EmpresaModel>
    {
        public void Configure(EntityTypeBuilder<EmpresaModel> builder)
        {
            builder.ToTable("Empresa");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Cnpj)
                .HasMaxLength(14)
                .IsFixedLength();

            builder.HasIndex(x => x.Cnpj)
                .IsUnique()
                .HasFilter("[Cnpj] IS NOT NULL");

            builder.Property(x => x.Setor)
                .HasMaxLength(100);

            builder.Property(x => x.Cidade)
                .HasMaxLength(100);

            builder.Property(x => x.Estado)
                .HasMaxLength(2)
                .IsFixedLength();

            builder.Property(x => x.Site)
                .HasMaxLength(300);

            builder.Property(x => x.Descricao)
                .HasColumnType("nvarchar(max)");

            builder.Property(x => x.Logo_url)
                .HasMaxLength(500);

            builder.Property(x => x.CreatedOn)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            builder.HasOne(x => x.Login)
                .WithOne(x => x.Empresa)
                .HasForeignKey<EmpresaModel>(x => x.Login_id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
