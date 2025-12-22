using HospitalDAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDAL.Data.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<Entities.ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasKey(au => au.Id);
            builder.Property(au => au.Email)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(au => au.PasswordHash)
                .IsRequired();
            builder.Property(au => au.FullName)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(au => au.PhoneNumber)
                .HasMaxLength(15);
            builder.Property(au => au.Role)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(au => au.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            builder.ToTable(tb =>
            {
                tb.HasCheckConstraint("EmailValidCheck", "Email like '_%@_%._%'");
                tb.HasCheckConstraint("PhoneNumberValidCheck", "PhoneNumber like '01%' and PhoneNumber not like '%[^0-9]%'");
            });

        }
    }
}
