using HospitalBLL.DTOs.AppointmentDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalBLL.Services.Interfaces
{
    public interface IAppointmentService
    {
        Task<IEnumerable<AppointmentDto>> GetAllAppointmentsAsync();
        Task<AppointmentDto?> GetAppointmentByIdAsync(int id);
        Task<IEnumerable<AppointmentDto>> GetAppointmentsByPatientAsync(int patientId);
        Task<IEnumerable<AppointmentDto>> GetAppointmentsByDoctorAsync(int doctorId);
        Task<IEnumerable<AppointmentDto>> GetTodayAppointmentsAsync(int doctorId);

        Task<AppointmentDto> BookAppointmentAsync(AppointmentCreateDto dto);
        Task<AppointmentDto?> UpdateAppointmentAsync(int id, AppointmentUpdateDto dto);
        Task<bool> CancelAppointmentAsync(int id);
      
    }
}
