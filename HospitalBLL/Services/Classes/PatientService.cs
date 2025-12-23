using AutoMapper;
using HospitalBLL.DTOs.PatientDtos;
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
    public class PatientService : IPatientService
    {
        private readonly IUnintOfWork _unintOfWork;
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;

        public PatientService(IUnintOfWork unintOfWork,IPatientRepository patientRepository,IMapper mapper)
        {
            _unintOfWork = unintOfWork;
           _patientRepository = patientRepository;
            _mapper = mapper;
        }
        public async Task CreatePatientAsync(PatientCreateDto patientCreateDto)
        {
            try
            {
               var patient= _mapper.Map<Patient>(patientCreateDto);
                await _unintOfWork.GetRepository<Patient>().AddAsync(patient);
                await _unintOfWork.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task DeletePatientAsync(int patientId)
        {
           var patient=await _unintOfWork.GetRepository<Patient>().GetByIdAsync(patientId);
            if (patient is not null)
            {
              await  _unintOfWork.GetRepository<Patient>().DeleteAsync(patient);
              await  _unintOfWork.SaveChangesAsync();
            }
           
        }

        public async Task<IEnumerable<PatientDto>> GetAllPatientsAsync()
        {
            var patients= await _unintOfWork.GetRepository<Patient>().GetAllAsync();
            var dtoPatients=patients.Select(pat=>_mapper.Map<PatientDto>(pat));
            return dtoPatients;
        }

        public async Task<PatientDto?> GetPatientByIdAsync(int patientId)
        {
            var patient=await _unintOfWork.GetRepository<Patient>().GetByIdAsync(patientId);
            if (patient is null) return null;
            return _mapper.Map<PatientDto>(patient);
        }

        public async Task<PatientDto?> GetPatientByUserIdAsync(int userId)
        {
            var patient= await _patientRepository.GetPatientByUserIdAsync(userId);
            if (patient is null) return null;
            return _mapper.Map<PatientDto>(patient);
        }

        public async Task<PatientDto?> GetPatientWithAppointmentsAsync(int patientId)
        {
            var patient=await _patientRepository.GetPatientWithAppointmentsAsync(patientId);
            if (patient is null) return null;
            return _mapper.Map<PatientDto>(patient);
        }

        public async Task<IEnumerable<PatientDto>> SearchPatientsAsync(string namePart)
        {
            var patients=await _patientRepository.SearchPatientsAsync(namePart);
            var dtoPatients=patients.Select(pat=>_mapper.Map<PatientDto>(pat));
            return dtoPatients;
        }
    }
}
