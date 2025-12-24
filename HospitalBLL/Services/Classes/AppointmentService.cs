using AutoMapper;
using HospitalBLL.DTOs.AppointmentDtos;
using HospitalBLL.Services.Interfaces;
using HospitalDAL.Entities;
using HospitalDAL.Enums;
using HospitalDAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalBLL.Services.Classes
{
    public class AppointmentService(IUnintOfWork unintOfWork, IAppointmentRepository appointmentRepository, IMapper mapper) : IAppointmentService
    {
        private readonly IUnintOfWork _unintOfWork = unintOfWork;
        private readonly IAppointmentRepository _appointmentRepository = appointmentRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<AppointmentDto> BookAppointmentAsync(AppointmentCreateDto dto)
        {
            var appointment = _mapper.Map<Appointment>(dto);
             await _unintOfWork.GetRepository<Appointment>().AddAsync(appointment);
            await  _unintOfWork.SaveChangesAsync();
            return _mapper.Map<AppointmentDto>(appointment);
        }

        public async Task<bool> CancelAppointmentAsync(int id)
        {
            var appointment = await _unintOfWork.GetRepository<Appointment>().GetByIdAsync(id);
            if (appointment is null) return false;
            
            appointment.Status = AppointmentStatus.Cancelled;
            await _unintOfWork.GetRepository<Appointment>().UpdateAsync(appointment);
            await _unintOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<AppointmentDto>> GetAllAppointmentsAsync()
        {
            var appointments =await  _unintOfWork.GetRepository<Appointment>().GetAllAsync();
            return appointments.Select(app => _mapper.Map<AppointmentDto>(app));


        }

        public async Task<AppointmentDto?> GetAppointmentByIdAsync(int id)
        {
            var appointment = await _unintOfWork.GetRepository<Appointment>().GetByIdAsync(id);
            if (appointment is null) return null;
            return _mapper.Map<AppointmentDto>(appointment);
        }

        public async Task<IEnumerable<AppointmentDto>> GetAppointmentsByDoctorAsync(int doctorId)
        {
            var appointments =await  _appointmentRepository.GetAppointmentsByDoctorAsync(doctorId);
            return appointments.Select(app => _mapper.Map<AppointmentDto>(app));
        }

        public async Task<IEnumerable<AppointmentDto>> GetAppointmentsByPatientAsync(int patientId)
        {
            var appointments =await _appointmentRepository.GetAppointmentsByPatientAsync(patientId);
            return appointments.Select(app => _mapper.Map<AppointmentDto>(app));

        }

        public async Task<IEnumerable<AppointmentDto>> GetTodayAppointmentsAsync(int doctorId)
        {
            var appointments =await _appointmentRepository.GetTodayAppointmentsAsync(doctorId);
            return appointments.Select(app => _mapper.Map<AppointmentDto>(app));
        }

        public async Task<AppointmentDto?> UpdateAppointmentAsync(int id, AppointmentUpdateDto dto)
        {
            var appointment =await  _unintOfWork.GetRepository<Appointment>().GetByIdAsync(id);
            if (appointment is null) return null;
            _mapper.Map(dto, appointment);
            await _unintOfWork.GetRepository<Appointment>().UpdateAsync(appointment);
            await _unintOfWork.SaveChangesAsync();
            return _mapper.Map<AppointmentDto>(appointment);
        }
    }
}
