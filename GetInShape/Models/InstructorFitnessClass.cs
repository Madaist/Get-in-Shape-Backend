using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetInShape.Models
{
    public class InstructorFitnessClass
    {
        public int Id { get; set; }
        public int InstructorId { get; set; }
        public int FitnessClassId { get; set; }

        public virtual Instructor Instructor { get; set; }
        public virtual FitnessClass FitnessClass { get; set; }
    }
}
