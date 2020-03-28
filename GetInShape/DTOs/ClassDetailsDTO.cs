using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetInShape.DTOs
{
    public class ClassDetailsDTO
    {
        public string Name { get; set; }
        public DateTime TimeSchedule { get; set; }
        // numele intructorilor ????????????????
        public List<string> InstructorName { get; set; }
        public List<string> SongName { get; set; }
        public List<string> GymClubName { get; set; }
    }
}
