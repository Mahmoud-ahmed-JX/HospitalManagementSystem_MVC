using HospitalBLL.DTOs.DoctorDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalBLL.Services.Interfaces
{
    public interface IDoctorService
    {
        Task<IEnumerable<DoctorDto>> GetByDepartmentAsync(int departmentId);
        Task<IEnumerable<DoctorDto>> GetBySpecializationAsync(string specialization);
        Task<IEnumerable<DoctorDto>> GetAllDoctorsAsync();
        Task<DoctorDto?> GetDoctorByIdAsync(int doctorId);
        Task CreateDoctorAsync(DoctorDto doctorDto);
        Task UpdateDoctorAsync(DoctorDto doctorDto);
        Task DeleteDoctorAsync(int doctorId);
    }
}
