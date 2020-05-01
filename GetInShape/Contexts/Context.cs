using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetInShape.Models;
using Microsoft.EntityFrameworkCore;

namespace GetInShape.Contexts
{
    public class Context : DbContext // implementeaza DbContext
    {
        public DbSet<Address> Addresses { get; set; } 
        public DbSet<FitnessClass> FitnessClasses { get; set; }
        public DbSet<GymClub> GymClubs { get; set; }
        public DbSet<GymClubFitnessClass> GymClubClasses { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<InstructorFitnessClass> InstructorClasses { get; set; }
        public DbSet<InstructorSpecialization> InstructorSpecializations { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
      

        public static bool isMigration = true;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (isMigration)
            {
                optionsBuilder.UseSqlServer(@"Server=.\;Database=DBGetInShape;Trusted_Connection=True;");
                // .\ inseamna ca db e locala
            }
        }

        public Context() { }

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

    }
}
