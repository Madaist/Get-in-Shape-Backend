using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetInShape.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public List<InstructorSpecialization> InstructorSpecialization { get; set; }
        public List<InstructorClass> InstructorClass { get; set; }
    }
}
