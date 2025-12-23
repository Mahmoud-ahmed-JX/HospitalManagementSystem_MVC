using AutoMapper;
using HospitalBLL.DTOs.DepartmentDtos;
using HospitalBLL.Services.Interfaces;
using HospitalDAL.Entities;
using HospitalDAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalBLL.Services.Classes
{
    public class DepartmentService(IUnintOfWork _unitOfWork, IDepartmentRepository _deptRepository,IMapper mapper) : IDepartmentService
    {
         IGenericRepository<Department> _deptUOF =_unitOfWork.GetRepository<Department>();
        public async Task CreateDepartment(DepartmentDto departmentDto)
        {
            await _deptUOF.AddAsync(mapper.Map<Department>(departmentDto));
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteDepartment(int departmentId)
        {
            var department =await  _deptUOF.GetByIdAsync(departmentId);
            if(department is not null)
            {
                await _deptUOF.DeleteAsync(department);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<DepartmentDto>> GetAllDepartmentsAsync()
        {
            var departments=await  _deptUOF.GetAllAsync();
            return mapper.Map<IEnumerable<DepartmentDto>>(departments);
        }

        public async Task<DepartmentDto?> GetDepartmentByIdAsync(int departmentId)
        {
            var departmnet=await _deptUOF.GetByIdAsync(departmentId);
            if(departmnet is null) return null;
            return mapper.Map<DepartmentDto>(departmnet);
        }

        public async Task<IEnumerable<DepartmentDto>> GetDepartmentsByNameAsync(string partialName)
        {
            var departments=await _deptRepository.GetDepartmentsByNameAsync(partialName);
            return mapper.Map<IEnumerable<DepartmentDto>>(departments);
        }

        public async Task<DepartmentWithDoctorsDto?> GetDepartmentWithDoctorsAsync(int departmentId)
        {
            var department=await _deptRepository.GetDepartmentWithDoctorsAsync(departmentId);
            return mapper.Map<DepartmentWithDoctorsDto?>(department);
        }

        public async Task UpdateDepartment(DepartmentDto departmentDto)
        {
           await _deptUOF.UpdateAsync(mapper.Map<Department>(departmentDto));
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
