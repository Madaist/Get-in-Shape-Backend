using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetInShape.Models;

namespace GetInShape.Repositories.GymClubRepository
{
    public interface IGymClubRepository
    {
        List<GymClub> GetAll();
        GymClub Get(int Id);
        GymClub Create(GymClub GymClub);
        GymClub Update(GymClub GymClub);
        GymClub Delete(GymClub GymClub);
    }
}
