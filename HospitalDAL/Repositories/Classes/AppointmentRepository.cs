using HospitalDAL.Data;
using HospitalDAL.Entities;
using HospitalDAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDAL.Repositories.Classes
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AppointmentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctorAsync(int doctorId)
        {
            return await _dbContext.Appointments
                .Include(a => a.Doctor).ThenInclude(d => d.User)
                .Where(a => a.DoctorId == doctorId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatientAsync(int patientId)
        {
           
            return await _dbContext.Appointments
                .Where(a => a.PatientId == patientId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetTodayAppointmentsAsync(int doctorId)
        {
            return await _dbContext.Appointments
                .Where(a => a.DoctorId == doctorId && a.AppointmentDate.Date == DateTime.Today)
                .ToListAsync();
        }
    }
}
