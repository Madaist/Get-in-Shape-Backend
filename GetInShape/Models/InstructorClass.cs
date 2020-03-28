using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetInShape.Models
{
    public class InstructorClass
    {
        public int Id { get; set; }
        public int InstructorId { get; set; }
        public int ClassId { get; set; }

        public virtual Instructor Instructor { get; set; }
        public virtual Class Class { get; set; }
    }
}
