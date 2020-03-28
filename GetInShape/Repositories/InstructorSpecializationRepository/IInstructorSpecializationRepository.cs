using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetInShape.Models;

namespace GetInShape.Repositories.InstructorSpecializationRepository
{
   public interface IInstructorSpecializationRepository
    {
        List<InstructorSpecialization> GetAll();
        InstructorSpecialization Get(int Id);
        InstructorSpecialization Create(InstructorSpecialization InstructorSpecialization);
        InstructorSpecialization Update(InstructorSpecialization InstructorSpecialization);
        InstructorSpecialization Delete(InstructorSpecialization InstructorSpecialization);
    }
}
