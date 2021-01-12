using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProiectFinal.Models;

namespace ProiectFinal.Data
{
    public class ProgramContext : DbContext
    {
        public ProgramContext(DbContextOptions<ProgramContext> options):base(options)
        { 
        }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Instructor>().ToTable("Instructor");
            modelBuilder.Entity<Appointment>().ToTable("Appointment");
            modelBuilder.Entity<Training>().ToTable("Training");
        }
    }
}
