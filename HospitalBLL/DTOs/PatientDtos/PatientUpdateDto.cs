using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HospitalDAL.Entities;
using HospitalDAL.Enums;

namespace HospitalBLL.DTOs.PatientDtos
{
    public class PatientUpdateDto
    {
        public int Id { get; set; }
        public DateOnly DOB { get; set; }
        public Gender Gender { get; set; }
        public BloodType BloodType { get; set; }

        public Address Address { get; set; } = new();
    }
}

