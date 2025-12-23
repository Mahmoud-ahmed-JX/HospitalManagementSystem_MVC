using HospitalBLL.DTOs.DoctorDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HospitalBLL.DTOs.DepartmentDtos
{
    public class DepartmentWithDoctorsDto
    {
        
        //DepartmentWithDoctorsDto
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<DoctorDto> Doctors { get; set; } = new List<DoctorDto>();
        public string Description { get; set; }=string.Empty;

    }
}
