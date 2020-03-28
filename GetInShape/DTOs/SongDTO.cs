using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetInShape.DTOs
{
    public class SongDTO
    {
        public string Name { get; set; }
        public string Singer { get; set; }
        public int Bpm { get; set; }
        public int ClassId { get; set; }
    }
}
