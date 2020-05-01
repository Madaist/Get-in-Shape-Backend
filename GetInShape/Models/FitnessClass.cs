using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetInShape.Models
{
    public class FitnessClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        

        public List<InstructorFitnessClass> InstructorClass { get; set; }
        public List<Song> Song { get; set; }
        public List<GymClubFitnessClass> GymClubClass { get; set; }
    }
}
