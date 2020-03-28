using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetInShape.Models;

namespace GetInShape.Repositories.SpecializationRepository
{
    public interface ISpecializationRepository
    {
        List<Specialization> GetAll();
        Specialization Get(int Id);
        Specialization Create(Specialization Specialization);
        Specialization Update(Specialization Specialization);
        Specialization Delete(Specialization Specialization);
    }
}
