using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDAL.Entities
{
    public class MedicalRecord
    {
        // Id, AppointmentId (FK), Diagnosis, Prescription, Notes, CreatedAt, Appointment (nav)
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public string Diagnosis { get; set; } = default!;
        public string Prescription { get; set; } = default!;
        public string? Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        // Navigation property
        public Appointment Appointment { get; set; } = default!;
    }
}
