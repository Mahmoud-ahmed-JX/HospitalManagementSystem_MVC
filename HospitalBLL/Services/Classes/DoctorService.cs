using HospitalBLL.Services.Interfaces;
using HospitalDAL.Entities;
using HospitalDAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HospitalBLL.DTOs.DoctorDtos;
namespace HospitalBLL.Services.Classes
{
    public class DoctorService(IUnintOfWork _unintOfWork,IDoctorRepository _doctorRepository,IMapper mapper) : IDoctorService
    {
       
        public async Task CreateDoctorAsync(DoctorDto doctorDto)
        {
            var doctor=mapper.Map<Doctor>(doctorDto);
           await _unintOfWork.GetRepository<Doctor>().AddAsync(doctor);
            await _unintOfWork.SaveChangesAsync();


        }

        public async Task DeleteDoctorAsync(int doctorId)
        {
            var doctor=await _unintOfWork.GetRepository<Doctor>().GetByIdAsync(doctorId);
            if (doctor is not null) {
              await  _unintOfWork.GetRepository<Doctor>().DeleteAsync(doctor);
               await _unintOfWork.SaveChangesAsync();

            }
        }

        public async Task<IEnumerable<DoctorDto>> GetAllDoctorsAsync()
        {
            var doctors=await _unintOfWork.GetRepository<Doctor>().GetAllAsync();
            var dtoDoctors=doctors.Select(doc=>mapper.Map<DoctorDto>(doc));
            return dtoDoctors;
        }

        public async Task<IEnumerable<DoctorDto>> GetByDepartmentAsync(int departmentId)
        {
            var doctors=await _doctorRepository.GetByDepartmentAsync(departmentId);
            var dtoDoctors=doctors.Select(doc=>mapper.Map<DoctorDto>(doc));
            return dtoDoctors;
        }

        public async Task<IEnumerable<DoctorDto>> GetBySpecializationAsync(string specialization)
        {
            var doctors=await _doctorRepository.GetBySpecializationAsync(specialization);
            var dtoDoctors=doctors.Select(doc=>mapper.Map<DoctorDto>(doc));
            return dtoDoctors;
        }

        public async Task<DoctorDto?> GetDoctorByIdAsync(int doctorId)
        {
            var doctor=await _unintOfWork.GetRepository<Doctor>().GetByIdAsync(doctorId);
            if (doctor is null) return null;
            return mapper.Map<DoctorDto>(doctor);
        }

        public async Task UpdateDoctorAsync(DoctorDto doctorDto)
        {
            var doctor = mapper.Map<Doctor>(doctorDto);
            await _unintOfWork.GetRepository<Doctor>().UpdateAsync(doctor);
            await _unintOfWork.SaveChangesAsync();
        }
    }
}
