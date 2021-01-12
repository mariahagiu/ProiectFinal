using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectFinal.Models
{
    public class Training
    {
        public int ID { get; set; }
        public string Name { get; set; }
      
        public string Type  { get; set; }
        public Decimal Duration { get; set; }
        public string Difficulty { get; set; }
        public string Days { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}
