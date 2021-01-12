using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectFinal.Models;

namespace ProiectFinal.Data
{
    public class DbInitializer
    {
        public static void Initialize(ProgramContext context)
        {
            context.Database.EnsureCreated();
            if (context.Trainings.Any())
            {
                return;
            }
            var trainings = new Training[]
            {
                new Training{Name="Step Aerobic",Type="General",Duration=Decimal.Parse("50"),Difficulty="Easy",Days="Monday, Tuesday, Friday"},
                new Training{Name="Circuit",Type="General",Duration=Decimal.Parse("50"),Difficulty="Medium",Days="Wednesday, Thursday, Friday" },
                new Training{Name="Kangoo Jumps",Type="Weight Loss",Duration=Decimal.Parse("50"),Difficulty="High",Days="Monday, Tuesday, Friday"},
                new Training{Name="Aerobic",Type="General",Duration=Decimal.Parse("50"),Difficulty="Medium",Days="Tuesday,Wednesday, Thursday, Friday" },
                new Training{Name="Pilates",Type="Resistence",Duration=Decimal.Parse("50"),Difficulty="Medium",Days="Monday, Tuesday, Friday"}
            };
            foreach (Training s in trainings)
            {
                context.Trainings.Add(s);
            }
            context.SaveChanges();

            var appointments = new Appointment[]
            {
                new Appointment{InstructorID=1,TrainingID=101,Client="Popescu Andreea",Date=DateTime.Parse("6/10/2020")},
                new Appointment{InstructorID=1,TrainingID=101,Client="Anghel Daniela",Date=DateTime.Parse("6/10/2020")},
                new Appointment{InstructorID=3,TrainingID=120,Client="Ionescu Paula",Date=DateTime.Parse("7/10/2020")},
                new Appointment{InstructorID=4,TrainingID=101,Client="Dan Alina",Date=DateTime.Parse("8/10/2020")},
                new Appointment{InstructorID=3,TrainingID=100,Client="Hagiu Maria",Date=DateTime.Parse("9/10/2020")}
            };
            foreach (Appointment e in appointments)
            {
                context.Appointments.Add(e);
            }
            context.SaveChanges();

            var instructors = new Instructor[]
               {
                new Instructor{Name="Voinea Irina",Experience=2},
                new Instructor{Name="Ionescu George",Experience=6},
                new Instructor{Name="Georgescu Camelia",Experience=5},
                new Instructor{Name="Mircea Paul",Experience=3},
                new Instructor{Name="Ciobanu Alexia",Experience=2}
               };
            foreach (Instructor f in instructors)
            {
                context.Instructors.Add(f);
            }
            context.SaveChanges();
        }
    }
}
