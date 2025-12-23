using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalBLL.DTOs.MedicalRecordDtos
{
    public class MedicalRecordDto
    {
        //Id, Diagnosis, Prescription, Date
        public int Id { get; set; }
        public string Diagnosis { get; set; } = default!;
        public string Prescription { get; set; } = default!;
        public DateTime Date { get; set; }
    }
}
