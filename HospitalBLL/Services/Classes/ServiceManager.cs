using AutoMapper;
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
    public class ServiceManager : IServiceManager
    {

        private readonly Lazy<IDepartmentService> _departmentService;
        private readonly Lazy<IDoctorService> _doctorService;
        private readonly Lazy<IPatientService> _patientService;
        private readonly Lazy<IAppointmentService> _appointmentService;
        private readonly Lazy<IMedicalRecordService> _medicalRecordService;

        public ServiceManager(
            IDepartmentService departmentService,
            IDoctorService doctorService,
            IPatientService patientService,
            IAppointmentService appointmentService,
            IMedicalRecordService medicalRecordService)
        {
            _departmentService = new Lazy<IDepartmentService>(departmentService);
            _doctorService = new Lazy<IDoctorService>(doctorService);
            _patientService = new Lazy<IPatientService>(patientService);
            _appointmentService = new Lazy<IAppointmentService>(appointmentService);
            _medicalRecordService = new Lazy<IMedicalRecordService>(medicalRecordService);
        }

        public IDepartmentService DepartmentService => _departmentService.Value;
        public IDoctorService DoctorService => _doctorService.Value;
        public IPatientService PatientService => _patientService.Value;
        public IAppointmentService AppointmentService => _appointmentService.Value;
        public IMedicalRecordService MedicalRecordService => _medicalRecordService.Value;

    }
}
