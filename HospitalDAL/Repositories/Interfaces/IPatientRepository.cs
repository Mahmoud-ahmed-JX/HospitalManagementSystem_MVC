using HospitalDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDAL.Repositories.Interfaces
{
    public interface IPatientRepository
    {
        
        Task<Patient?> GetPatientByUserIdAsync(int userId);
        Task<Patient?> GetPatientWithAppointmentsAsync(int patientId);
        Task<IEnumerable<Patient>> SearchPatientsAsync(string namePart);
    }
}
