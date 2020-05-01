using System.Collections.Generic;

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
