using HospitalDAL.Data;
using HospitalDAL.Entities;
using HospitalDAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalDAL.Repositories.Classes
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _dbcontext;

        public DepartmentRepository(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        // Return all departments whose name contains the partial text (case-insensitive)
        public async Task<IEnumerable<Department>> GetDepartmentsByNameAsync(string partialName)
        {
            if (string.IsNullOrWhiteSpace(partialName))
                return Enumerable.Empty<Department>();


            // Option B (less efficient, provider-dependent translation):
            return await _dbcontext.Departments
                .AsNoTracking()
                .Where(d => d.Name.ToLower().Contains(partialName.ToLower()))
                .ToListAsync();
        }

        public async Task<Department?> GetDepartmentWithDoctorsAsync(int departmentId)
        {
            return await _dbcontext.Departments
                .Include(d => d.Doctors)
                .AsNoTracking()
                .FirstOrDefaultAsync(d => d.Id == departmentId);
        }
    }
}
