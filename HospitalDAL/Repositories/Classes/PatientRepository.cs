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
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PatientRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Patient?> GetPatientByUserIdAsync(int userId)
        {
            
            return await _dbContext.Patients
                .Where(p => p.UserId == userId)
                .FirstOrDefaultAsync();
        }

        public async Task<Patient?> GetPatientWithAppointmentsAsync(int patientId)
        {
            return await _dbContext.Patients
                .Include(p => p.Appointments)
                .ThenInclude(a => a.Doctor)
                .Include(p => p.Appointments)
                .ThenInclude(a => a.MedicalRecord)
                .Where(p => p.Id == patientId)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Patient>> SearchPatientsAsync(string namePart)
        {
            return await _dbContext.Patients
                .Include(p => p.User)
                .Where(p => (p.User.FullName).Contains(namePart))
                .AsNoTracking()
                .ToListAsync();
        }

       
    }
}
