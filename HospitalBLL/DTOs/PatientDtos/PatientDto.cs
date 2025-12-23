using HospitalDAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalBLL.DTOs.PatientDtos
{
    public class PatientDto
    {
        // Id, FullName, DOB, Gender, BloodType
        public int Id { get; set; }
        public string FullName { get; set; }=default!;
        public DateOnly DOB { get; set; }

        public Gender Gender { get; set; } 
        public BloodType BloodType { get; set; } 
    }
}
