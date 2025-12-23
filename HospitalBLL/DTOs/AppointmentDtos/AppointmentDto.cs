using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalBLL.DTOs.AppointmentDtos
{
    public class AppointmentDto
    {
        //Id, PatientName, DoctorName, Date, Status
        public int Id { get; set; }
        public string PatientName { get; set; } = null!;
        public string DoctorName { get; set; } = null!;
        public DateTime Date { get; set; }
        public string Status { get; set; } = null!;


    }
}
