using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetInShape.Models;

namespace GetInShape.Repositories.GymClubClassRepository
{
    public interface IGymClubClassRepository
    {
        List<GymClubClass> GetAll();
        GymClubClass Get(int Id);
        GymClubClass Create(GymClubClass GymClubClass);
        GymClubClass Update(GymClubClass GymClubClass);
        GymClubClass Delete(GymClubClass GymClubClass);
    }
}
