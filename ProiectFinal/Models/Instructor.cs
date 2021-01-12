using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectFinal.Models
{
    public class Instructor
    {
        public int InstructorID { get; set; }
        public string Name { get; set; }
        public int Experience { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}

