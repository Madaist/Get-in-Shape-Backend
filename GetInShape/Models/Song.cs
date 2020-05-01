using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetInShape.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Singer { get; set; }
        public int Bpm { get; set; }

        public int FitnessClassId { get; set; }
        public virtual FitnessClass FitnessClass { get; set; }
    }
}
