using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDAL.Data
{

    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Additional configuration can go here
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<Entities.ApplicationUser> ApplicationUsers { get; set; } = null!;
        public DbSet<Entities.Doctor> Doctors { get; set; } = null!;
        public DbSet<Entities.Department> Departments { get; set; } = null!;
        public DbSet<Entities.Appointment> Appointments { get; set; } = null!;
        public DbSet<Entities.Patient> Patients { get; set; } = null!;
        public DbSet<Entities.MedicalRecord> MedicalRecords { get; set; } = null!;



    }
}
