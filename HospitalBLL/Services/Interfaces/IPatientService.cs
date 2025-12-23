using HospitalBLL.DTOs.PatientDtos;
using HospitalDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalBLL.Services.Interfaces
{
    public interface IPatientService
    {
        //GetAll, GetById, Create, Update, Delete
        Task<PatientDto?> GetPatientByUserIdAsync(int userId);
        Task<PatientDto?> GetPatientWithAppointmentsAsync(int patientId);
        Task<IEnumerable<PatientDto>> SearchPatientsAsync(string namePart);

        Task<IEnumerable<PatientDto>> GetAllPatientsAsync();

        Task<PatientDto?> GetPatientByIdAsync(int patientId);
        Task CreatePatientAsync(PatientCreateDto patientCreateDto);
        Task DeletePatientAsync(int patientId);



    }
}
