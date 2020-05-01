using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetInShape.Models;

namespace GetInShape.Repositories.FitnessClassRepository
{
    public interface IFitnessClassRepository
    {
        List<FitnessClass> GetAll();
        FitnessClass Get(int Id);
        FitnessClass Create(FitnessClass FitnessClass);
        FitnessClass Update(FitnessClass FitnessClass);
        FitnessClass Delete(FitnessClass FitnessClass);
    }
}
