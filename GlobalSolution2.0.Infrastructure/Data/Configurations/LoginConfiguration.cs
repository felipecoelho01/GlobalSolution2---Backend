using GlobalSolution2._0.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalSolution2._0.Infrastructure.Data.Configurations
{
    public class LoginConfiguration : IEntityTypeConfiguration<LoginModel>
    {

        public void Configure(EntityTypeBuilder<LoginModel> builder)
        {
            builder.ToTable("Login");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasIndex(x => x.Email)
                .IsUnique();

            builder.Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.Role)
                .IsRequired()
                .HasMaxLength(20)
                .HasConversion<string>();

            builder.Property(x => x.CreatedOn)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            builder.Property(x => x.ModifiedOn)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
