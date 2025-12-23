using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalBLL.DTOs.DoctorDtos
{
    public class DoctorCreateDto
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        [Required, MaxLength(100)]
        public string Specialization { get; set; }= string.Empty;
        [Range(0, 50)]
        public int ExperienceYears { get; set; }
    }
}
