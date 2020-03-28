using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetInShape.Models
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime TimeSchedule { get; set; }

        public List<InstructorClass> InstructorClass { get; set; }
        public List<Song> Song { get; set; }
        public List<GymClubClass> GymClubClass { get; set; }
    }
}
