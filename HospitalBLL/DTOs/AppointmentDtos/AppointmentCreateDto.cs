using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalBLL.DTOs.AppointmentDtos
{
    public class AppointmentCreateDto
    {
        //PatientId, DoctorId, Date, Notes

        [Required(ErrorMessage = "Patient is required")]
        [Display(Name = "Patient")]
        public int PatientId { get; set; }


        [Required(ErrorMessage = "Doctor is required")]
        [Display(Name = "Doctor")]
        public int DoctorId { get; set; } 
        [Required(ErrorMessage = "Date is required")]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        public string? Notes { get; set; } 
    }
}
