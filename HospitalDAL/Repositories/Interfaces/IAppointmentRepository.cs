using HospitalDAL.Entities;
using HospitalDAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDAL.Repositories.Interfaces
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointment>> GetAppointmentsByDoctorAsync(int doctorId);
        Task<IEnumerable<Appointment>> GetAppointmentsByPatientAsync(int patientId);
        

        Task<IEnumerable<Appointment>> GetTodayAppointmentsAsync(int doctorId);
    }
}
