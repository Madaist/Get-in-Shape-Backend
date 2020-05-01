using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetInShape.Models;

namespace GetInShape.Repositories.GymClubClassRepository
{
    public interface IGymClubFitnessClassRepository
    {
        List<GymClubFitnessClass> GetAll();
        GymClubFitnessClass Get(int Id);
        GymClubFitnessClass Create(GymClubFitnessClass GymClubClass);
        GymClubFitnessClass Update(GymClubFitnessClass GymClubClass);
        GymClubFitnessClass Delete(GymClubFitnessClass GymClubClass);
    }
}
