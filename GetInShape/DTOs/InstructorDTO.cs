using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetInShape.DTOs
{
    //pentru inserare
    public class InstructorDTO
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public List<int> SpecializationId { get; set; }
      
    }
}
