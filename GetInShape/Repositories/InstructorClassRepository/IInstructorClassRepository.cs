using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetInShape.Models;

namespace GetInShape.Repositories.InstructorClassRepository
{
    public interface IInstructorClassRepository
    {
        List<InstructorClass> GetAll();
        InstructorClass Get(int Id);
        InstructorClass Create(InstructorClass InstructorClass);
        InstructorClass Update(InstructorClass InstructorClass);
        InstructorClass Delete(InstructorClass InstructorClass);
    }
}
