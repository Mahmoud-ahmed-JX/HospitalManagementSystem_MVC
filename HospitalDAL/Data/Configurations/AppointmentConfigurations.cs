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
    public class AppointmentConfigurations : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasKey(app => app.Id);
            builder.HasOne(app => app.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(app => app.PatientId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(app => app.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(app => app.DoctorId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
