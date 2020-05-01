using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetInShape.Models;

namespace GetInShape.Repositories.InstructorClassRepository
{
    public interface IInstructorFitnessClassRepository
    {
        List<InstructorFitnessClass> GetAll();
        InstructorFitnessClass Get(int Id);
        InstructorFitnessClass Create(InstructorFitnessClass InstructorClass);
        InstructorFitnessClass Update(InstructorFitnessClass InstructorClass);
        InstructorFitnessClass Delete(InstructorFitnessClass InstructorClass);
    }
}
