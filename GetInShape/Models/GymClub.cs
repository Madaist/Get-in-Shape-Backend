using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetInShape.Models
{
    public class GymClub
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AddressId { get; set; }

        public virtual Address Address { get; set; }
        public List<GymClubFitnessClass> GymClubFitnessClass { get; set; }
    }
}
