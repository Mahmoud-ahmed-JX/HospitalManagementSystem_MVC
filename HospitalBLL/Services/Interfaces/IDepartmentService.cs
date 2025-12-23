using HospitalBLL.DTOs.DepartmentDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalBLL.Services.Interfaces
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentDto>> GetDepartmentsByNameAsync(string partialName);
        Task<DepartmentWithDoctorsDto?> GetDepartmentWithDoctorsAsync(int departmentId);

        Task<IEnumerable<DepartmentDto>> GetAllDepartmentsAsync();
        Task<DepartmentDto?> GetDepartmentByIdAsync(int departmentId);
        Task DeleteDepartment(int departmentId);
        Task CreateDepartment(DepartmentDto departmentDto);
        Task UpdateDepartment(DepartmentDto departmentDto);

    }
}
