using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectFinal.Models
{
    public class Appointment
    {
        public int AppointmentID { get; set; }
     
        public int InstructorID { get; set; }
        public int TrainingID { get; set; }
        public string Client { get; set; }
        public DateTime Date { get; set; }
        public Instructor Instructor{ get; set; }
        public Training Training { get; set; }
    }
}
