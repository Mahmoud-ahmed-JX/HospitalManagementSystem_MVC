using HospitalDAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalDAL.Repositories.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetDepartmentsByNameAsync(string partialName);
        Task<Department?> GetDepartmentWithDoctorsAsync(int departmentId);
    }
}
