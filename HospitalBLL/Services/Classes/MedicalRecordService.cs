using AutoMapper;
using HospitalBLL.DTOs.MedicalRecordDtos;
using HospitalBLL.Services.Interfaces;
using HospitalDAL.Entities;
using HospitalDAL.Repositories.Classes;
using HospitalDAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalBLL.Services.Classes
{
    public class MedicalRecordService(IUnintOfWork _unintOfWork,IMedicalRecordRepository _medicalRep,IMapper mapper) : IMedicalRecordService
    {

        public async Task<MedicalRecordDto> CreateMedicalRecordAsync(CreateMedicalRecordDto dto)
        {
            var medicalRecord = mapper.Map<MedicalRecord>(dto);
            await _unintOfWork.GetRepository<MedicalRecord>().AddAsync(medicalRecord);
            await _unintOfWork.SaveChangesAsync();

            return mapper.Map<MedicalRecordDto>(medicalRecord);
        }

        public async Task<MedicalRecordDto?> GetMedicalRecordByAppointmentIdAsync(int appointmentId)
        {

            var medicalRecord=await _medicalRep.GetMedicalRecordByAppointmentIdAsync(appointmentId);
            return medicalRecord is null ? null : mapper.Map<MedicalRecordDto>(medicalRecord);
        }

        public async Task<IEnumerable<MedicalRecordDto>> GetMedicalRecordsByPatientIdAsync(int patientId)
        {
            var medicalRecords= await _medicalRep.GetMedicalRecordsByPatientIdAsync(patientId);
            return medicalRecords.Select(mr => mapper.Map<MedicalRecordDto>(mr));
        }

        public async Task UpdateMedicalRecordAsync(MedicalRecordUpdateDto dto)
        {
          await  _unintOfWork.GetRepository<MedicalRecord>().UpdateAsync(mapper.Map<MedicalRecord>(dto));
            await _unintOfWork.SaveChangesAsync();
        }
       

    }
}
