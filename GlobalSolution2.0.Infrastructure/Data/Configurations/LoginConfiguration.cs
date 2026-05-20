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
                builder.ToTable("Customers");

                builder.HasKey(x => x.Id);

                builder.Property(x => x.Email)
                    .HasMaxLength(100);
            }

    }
}
