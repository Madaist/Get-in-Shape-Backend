using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetInShape.DTOs
{
    public class GymClubDTO
    {
        public string Name { get; set; }
        public int AddressId { get; set; } ///////////////////////////////////
        public List<int> ClassId { get; set; }
    }
}
