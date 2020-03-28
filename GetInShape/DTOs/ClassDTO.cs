using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetInShape.DTOs
{
    // pentru inserare
    public class ClassDTO
    {
        public string Name { get; set; }
        public DateTime TimeSchedule { get; set; }

        public List<int> InstructorId { get; set; }
        public List<int> SongId { get; set; }
        public List<int> GymClubId { get; set; }

    }
}
