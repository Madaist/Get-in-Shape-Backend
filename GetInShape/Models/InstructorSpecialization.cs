using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetInShape.Models
{
    public class InstructorSpecialization
    {
        public int Id { get; set; }
        public int InstructorId { get; set; }
        public int SpecializationId { get; set; }
        public DateTime GrantDate { get; set; }

        public virtual Instructor Instructor { get; set; }
        public virtual Specialization Specialization { get; set; }

    }
}
