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
            CreateMap<DoctorCreateDto, Doctor>();
            CreateMap<DoctorUpdateDto, Doctor>();
            // Department mappings
            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<Department, DepartmentWithDoctorsDto>()
                .ForMember(dest => dest.Doctors, opt => opt.MapFrom(src => src.Doctors))
                .ReverseMap();

        }
    }
}
