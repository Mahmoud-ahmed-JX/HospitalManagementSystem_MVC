using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalBLL.DTOs.DoctorDtos
{
    public class DoctorDto
    {
        //public int Id { get; set; }
        //public string Name { get; set; } = string.Empty;
        //public string Specialization { get; set; } = string.Empty;
        //public int DepartmentId { get; set; }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Specialization { get; set; }
        public int ExperienceYears { get; set; }
        public string DepartmentName { get; set; }
        public int DepartmentId { get; set; }
        public bool IsAvailable { get; set; }
    }
}
