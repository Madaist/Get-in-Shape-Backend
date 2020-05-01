using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetInShape.DTOs
{
    public class GymClubFitnessClassDTO
    {
        public int GymClubId { get; set; }
        public int FitnessClassId { get; set; }
        public DateTime TimeSchedule { get; set; }
    }
}
