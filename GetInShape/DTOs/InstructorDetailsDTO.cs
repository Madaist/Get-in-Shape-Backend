using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetInShape.DTOs
{
    public class InstructorDetailsDTO
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public List<string> SpecializationName { get; set; }
    }
}
