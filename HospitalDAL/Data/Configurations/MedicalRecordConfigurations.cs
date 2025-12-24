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
    public class MedicalRecordConfigurations : IEntityTypeConfiguration<MedicalRecord>
    {
        public void Configure(EntityTypeBuilder<MedicalRecord> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreatedAt)
              .HasDefaultValueSql("GETDATE()");

            builder.Property(x => x.Diagnosis)
                .HasColumnType("varchar")
                .HasMaxLength(100).IsRequired();
            builder.Property(x => x.Prescription)
               .HasColumnType("varchar")
               .HasMaxLength(100).IsRequired();
            builder.Property(x => x.CreatedAt)
             .HasDefaultValueSql("GETDATE()")
             .ValueGeneratedOnAdd(); // ADD THIS

        }
    }
}
