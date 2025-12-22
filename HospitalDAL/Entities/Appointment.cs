
using HospitalDAL.Enums;

namespace HospitalDAL.Entities
{
    public class Appointment
    {
        //d, PatientId (FK), DoctorId (FK), AppointmentDate, Status, Notes, Patient (nav), Doctor (nav), MedicalRecord (nav)
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public AppointmentStatus Status { get; set; } 
        public string? Notes { get; set; }
        // Navigation properties
        public Patient Patient { get; set; } = default!;
        public Doctor Doctor { get; set; } = default!;
        public MedicalRecord MedicalRecord { get; set; } = default!;
    }
}
