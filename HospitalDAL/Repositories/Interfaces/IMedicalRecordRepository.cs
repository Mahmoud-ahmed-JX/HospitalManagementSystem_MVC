using HospitalDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDAL.Repositories.Interfaces
{
    public interface IMedicalRecordRepository
    {
       

        Task<IEnumerable<MedicalRecord>> GetMedicalRecordsByPatientIdAsync(int patientId);

        Task<MedicalRecord?> GetMedicalRecordByAppointmentIdAsync(int appointmentId);
    }
}
