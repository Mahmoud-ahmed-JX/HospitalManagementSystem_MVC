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
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = default!;
        public string BloodType { get; set; } = default!;

        public string Address { get; set; } = default!;
        // Navigation properties
        //public User User { get; set; } = default!;
        public List<Appointment> Appointments { get; set; } = [];



    }
}
