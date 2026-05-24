using GlobalSolution2._0.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalSolution2._0.Infrastructure.Data.Configurations
{
    public class CandidaturaConfiguration : IEntityTypeConfiguration<CandidaturaModel>
    {
        public void Configure(EntityTypeBuilder<CandidaturaModel> builder)
        {
            builder.ToTable("Candidatura");

            builder.HasKey(x => x.Id);

            builder.HasIndex(x => new { x.Usuario_id, x.Vaga_id })
                .IsUnique();

            builder.Property(x => x.Status)
                .IsRequired()
                .HasMaxLength(30)
                .HasDefaultValue("pendente")
                .HasConversion<string>();

            builder.Property(x => x.Carta_apresentacao)
                .HasColumnType("nvarchar(max)");

            builder.Property(x => x.CreatedOn)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            builder.Property(x => x.UpdatedOn)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            builder.HasIndex(x => x.Usuario_id);
            builder.HasIndex(x => x.Vaga_id);
            builder.HasIndex(x => x.Status);

            builder.HasOne(x => x.Usuario)
                .WithMany(x => x.Candidaturas)
                .HasForeignKey(x => x.Usuario_id)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Vaga)
                .WithMany(x => x.Candidaturas)
                .HasForeignKey(x => x.Vaga_id)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
