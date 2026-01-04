using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalBLL.DTOs.MedicalRecordDtos
{
    public class CreateMedicalRecordDto
    {
        [Required(ErrorMessage = "Appointment is required")]
        [Display(Name = "Appointment")]
        public int AppointmentId { get; set; } // required to tie record to an appointment

        [Required(ErrorMessage = "Diagnosis is required")]
        public string Diagnosis { get; set; } = string.Empty;

        [Required(ErrorMessage = "Prescription is required")]
        public string Prescription { get; set; } = string.Empty;

        [MaxLength(1000)]
        [Display(Name = "Notes (Optional)")]
        public string? Notes { get; set; }
        // Date/CreatedAt should be set by server
    }
}
