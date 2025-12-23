using HospitalDAL.Entities;
using HospitalDAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalBLL.DTOs.PatientDtos
{
    public class PatientCreateDto
    {
        //UserId, DOB, Gender, BloodType, Address

        public int UserId { get; set; }

        [Required(ErrorMessage = "Date Of Birth Is Required")]
        [DataType(DataType.Date)]
        public DateOnly DOB { get; set; }

        [Required(ErrorMessage = "Gender Is Required")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Blood Type Is Required")]
        public BloodType BloodType { get; set; }

        public Address Address { get; set; } = new();
    }
}
