using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalBLL.DTOs.MedicalRecordDtos
{
    public class MedicalRecordUpdateDto
    {
        public int Id { get; set; } // identity to update
        public string Diagnosis { get; set; } = string.Empty;
        public string Prescription { get; set; } = string.Empty;
        public string? Notes { get; set; }
        
    }
}
