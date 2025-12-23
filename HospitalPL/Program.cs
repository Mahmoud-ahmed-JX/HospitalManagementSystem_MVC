using HospitalBLL.Helpers;
using HospitalBLL.Services.Classes;
using HospitalBLL.Services.Interfaces;
using HospitalDAL.Data;
using HospitalDAL.Repositories.Classes;
using HospitalDAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HospitalPL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            #region DI containers

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            
            //Add Application Db Context
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            //Add Repositories
            builder.Services.AddScoped<IUnintOfWork, UnitOfWork>();
            builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
            builder.Services.AddScoped<IPatientRepository, PatientRepository>();
            builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();

            //Add Services
            builder.Services.AddScoped<IDoctorService, DoctorService>();
            builder.Services.AddScoped<IPatientService, PatientService>();
            builder.Services.AddScoped<IAppointmentService, AppointmentService>();

            //Add AutoMapper
            builder.Services.AddAutoMapper(x=>x.AddProfile(new MappingProfile()));
          

            #endregion
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

           

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
