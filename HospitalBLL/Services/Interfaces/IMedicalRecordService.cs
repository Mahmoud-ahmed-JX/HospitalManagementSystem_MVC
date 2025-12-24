using HospitalBLL.DTOs.MedicalRecordDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalBLL.Services.Interfaces
{
    public interface IMedicalRecordService
    {
        Task<MedicalRecordDto> CreateMedicalRecordAsync(CreateMedicalRecordDto dto);
        Task<MedicalRecordDto?> GetMedicalRecordByAppointmentIdAsync(int appointmentId);
        Task<IEnumerable<MedicalRecordDto>> GetMedicalRecordsByPatientIdAsync(int patientId);
        Task UpdateMedicalRecordAsync( MedicalRecordUpdateDto dto);
    }
}
