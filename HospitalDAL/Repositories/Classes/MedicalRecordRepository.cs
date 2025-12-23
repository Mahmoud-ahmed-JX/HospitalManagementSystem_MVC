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
    public class MedicalRecordRepository : IMedicalRecordRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public MedicalRecordRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<MedicalRecord?> GetMedicalRecordByAppointmentIdAsync(int appointmentId)
        {
            return await _dbContext.MedicalRecords
                .Where(mr => mr.AppointmentId == appointmentId)
                .FirstOrDefaultAsync();

        }

        public async Task<IEnumerable<MedicalRecord>> GetMedicalRecordsByPatientIdAsync(int patientId)
        {
           return await _dbContext.MedicalRecords
                .Include(mr => mr.Appointment)
                .Where(mr => mr.Appointment.PatientId == patientId)
                .AsNoTracking()
                .ToListAsync()
                .ContinueWith(t => (IEnumerable<MedicalRecord>)t.Result);
        }
    }
}
