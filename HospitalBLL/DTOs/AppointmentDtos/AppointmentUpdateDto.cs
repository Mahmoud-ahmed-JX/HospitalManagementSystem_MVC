using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalBLL.DTOs.AppointmentDtos
{
    public class AppointmentUpdateDto
    {
        //AppointmentDate, Notes

        [Required(ErrorMessage = "Date is required")]
        [Display(Name = "Appointment Date")]
        [DataType(DataType.DateTime)]
        public DateTime AppointmentDate { get; set; }

        [MaxLength(1000)]
        [Display(Name = "Notes (Optional)")]
        public string? Notes { get; set; }
    }
}
