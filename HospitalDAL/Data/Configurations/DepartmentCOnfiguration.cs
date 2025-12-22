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
    internal class DepartmentCOnfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(dep => dep.Id);
            builder.Property(dep => dep.Name)
                .IsRequired()
                .HasMaxLength(100);
            
        }
    }
}
