using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetInShape.Models;

namespace GetInShape.Repositories.InstructorRepository
{
    public interface IInstructorRepository
    {
        List<Instructor> GetAll();
        Instructor Get(int Id);
        Instructor Create(Instructor Instructor);
        Instructor Update(Instructor Instructor);
        Instructor Delete(Instructor Instructor);
    }
}
