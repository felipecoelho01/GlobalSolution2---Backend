using GlobalSolution2._0.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalSolution2._0.Infrastructure.Data.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<UsuarioModel>
    {
        public void Configure(EntityTypeBuilder<UsuarioModel> builder)
        {
            builder.ToTable("Usuario");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.Cpf)
                .HasMaxLength(11)
                .IsFixedLength();

            builder.HasIndex(x => x.Cpf)
                .IsUnique()
                .HasFilter("[Cpf] IS NOT NULL");

            builder.Property(x => x.Telefone)
                .HasMaxLength(20);

            builder.Property(x => x.Cidade)
                .HasMaxLength(100);

            builder.Property(x => x.Estado)
                .HasMaxLength(2)
                .IsFixedLength();

            builder.Property(x => x.Curriculo_url)
                .HasMaxLength(500);

            builder.Property(x => x.Resumo)
                .HasColumnType("nvarchar(max)");

            builder.Property(x => x.CreatedOn)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            builder.HasOne(x => x.Login)
                .WithOne(x => x.Usuario)
                .HasForeignKey<UsuarioModel>(x => x.Login_id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
