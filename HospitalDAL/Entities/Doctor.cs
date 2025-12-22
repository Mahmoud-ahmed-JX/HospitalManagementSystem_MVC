using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDAL.Entities
{
    public class Doctor
    {
        public int Id { get; set; }
        public string specialization { get; set; } = string.Empty;
        public int ExperienceYears { get; set; }

        public int UserId { get; set; }

        public ApplicationUser User { get; set; } = null!; 
        public int DepartmentId { get; set; }
        // Navigation property
        public Department Department { get; set; } = null!;
        public IEnumerable<Appointment> Appointments { get; set; } = new List<Appointment>();

    }
}
