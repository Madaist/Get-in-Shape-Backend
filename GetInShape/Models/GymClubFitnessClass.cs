using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetInShape.Models
{
    public class GymClubFitnessClass
    {
        public int Id { get; set; }
        public DateTime TimeSchedule { get; set; }
        public int GymClubId { get; set; }
        public int FitnessClassId { get; set; }
        

        public virtual GymClub GymClub { get; set; }
        public virtual FitnessClass  FitnessClass { get; set; }
    }
}
