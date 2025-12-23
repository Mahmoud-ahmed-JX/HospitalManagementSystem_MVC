using HospitalBLL.DTOs.DepartmentDtos;
using HospitalBLL.DTOs.DoctorDtos;
using HospitalDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalBLL.Helpers
{
    public class MappingProfile: AutoMapper.Profile
    {
        public MappingProfile()
        {
            // Doctor mappings
            CreateMap<Doctor, DoctorDto>().ReverseMap();
            // Department mappings
            CreateMap<Department, DepartmentDto>().ReverseMap();
        }
    }
}
