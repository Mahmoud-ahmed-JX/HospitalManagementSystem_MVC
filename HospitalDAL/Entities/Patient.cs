using HospitalDAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDAL.Entities
{
    public class Patient
    {
        // Id, UserId (FK), DateOfBirth, Gender, BloodType, Address, User (nav), Appointments (nav)
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public Gender Gender { get; set; } = default!;
        public BloodType BloodType { get; set; } = default!;

        public Address Address { get; set; } = default!;
        // Navigation properties
        public ApplicationUser User { get; set; } = default!;
        public List<Appointment> Appointments { get; set; } = [];



    }
    public class Address
    {
        public string City { get; set; }= default!;
        public string Street { get; set; } = default!;

        public string Country { get; set; } = default!;

    }
}
