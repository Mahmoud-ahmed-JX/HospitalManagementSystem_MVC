using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalBLL.Services.Interfaces
{
    public interface IServiceManager
    {
        public IDepartmentService DepartmentService { get; }
        public IDoctorService DoctorService { get; }
        public IPatientService PatientService { get; }
        public IAppointmentService AppointmentService { get; }
        public IMedicalRecordService MedicalRecordService { get; }

    }
}
