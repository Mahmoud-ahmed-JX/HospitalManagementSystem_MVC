using HospitalBLL.DTOs.AppointmentDtos;
using HospitalBLL.DTOs.DepartmentDtos;
using HospitalBLL.DTOs.DoctorDtos;
using HospitalBLL.DTOs.MedicalRecordDtos;
using HospitalBLL.DTOs.PatientDtos;
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

            #region Doctor mappings
            CreateMap<Doctor, DoctorDto>().ReverseMap();
            CreateMap<DoctorCreateDto, Doctor>();
            CreateMap<DoctorUpdateDto, Doctor>();
            #endregion



            #region Department mappings
            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<Department, DepartmentWithDoctorsDto>()
                .ForMember(dest => dest.Doctors, opt => opt.MapFrom(src => src.Doctors))
                .ReverseMap();

            #endregion


            #region Patient Mappings 

            CreateMap<Patient, PatientDto>().ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.User.FullName));
            CreateMap<PatientCreateDto, Patient>();

            #endregion

            #region Appointment Mappings
            CreateMap<Appointment, AppointmentDto>()
                .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient.User.FullName))
                .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctor.User.FullName));
            CreateMap<AppointmentCreateDto, Appointment>();
            CreateMap<AppointmentUpdateDto, Appointment>();


            #endregion

            #region Medical Record
            CreateMap<MedicalRecord, MedicalRecordDto>()
               .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.CreatedAt));
            CreateMap<CreateMedicalRecordDto, MedicalRecord>()
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore()); // set server-side
            CreateMap<MedicalRecordUpdateDto, MedicalRecord>()
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.AppointmentId, opt => opt.Ignore()); // unless you allow changing

            #endregion



        }
    }
}
