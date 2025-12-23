using HospitalDAL.Data;
using HospitalDAL.Entities;
using HospitalDAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HospitalDAL.Repositories.Classes
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly ApplicationDbContext _context;

        public DoctorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Doctor>> GetByDepartmentAsync(int departmentId)
        {
            return await _context.Doctors
                .Include(d => d.Department)
                .Include(d => d.User)
                .Where(d => d.DepartmentId == departmentId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Doctor>> GetBySpecializationAsync(string specialization)
        {
            return await _context.Doctors
                .Include(d => d.Department)
                .Include(d => d.User)
                .Where(d => d.Specialization == specialization)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
