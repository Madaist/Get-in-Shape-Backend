using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetInShape.DTOs
{
    // pentru inserare
    public class FitnessClassDTO
    {
        public string Name { get; set; }
        public string Img { get; set; }
       

        public List<int> InstructorId { get; set; }
        public List<int> SongId { get; set; }
        public List<int> GymClubId { get; set; }

    }
}
