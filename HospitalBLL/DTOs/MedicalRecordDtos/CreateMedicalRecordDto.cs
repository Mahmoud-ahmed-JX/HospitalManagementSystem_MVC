using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalBLL.DTOs.MedicalRecordDtos
{
    public class CreateMedicalRecordDto
    {
        public int AppointmentId { get; set; } // required to tie record to an appointment
        public string Diagnosis { get; set; } = string.Empty;
        public string Prescription { get; set; } = string.Empty;
        public string? Notes { get; set; }
        // Date/CreatedAt should be set by server
    }
}
