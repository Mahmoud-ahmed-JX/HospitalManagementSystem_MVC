using HospitalDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDAL.Repositories.Interfaces
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<Doctor>> GetByDepartmentAsync(int departmentId);
        Task<IEnumerable<Doctor>> GetBySpecializationAsync(string specialization);
    }
}
