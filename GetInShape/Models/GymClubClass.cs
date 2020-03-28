using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetInShape.Models
{
    public class GymClubClass
    {
        public int Id { get; set; }
        public int GymClubId { get; set; }
        public int ClassId { get; set; }

        public virtual GymClub GymClub { get; set; }
        public virtual Class Class { get; set; }
    }
}
