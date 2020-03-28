using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetInShape.Models;

namespace GetInShape.Repositories.ClassRepository
{
    public interface IClassRepository
    {
        List<Class> GetAll();
        Class Get(int Id);
        Class Create(Class Class);
        Class Update(Class Class);
        Class Delete(Class Class);
    }
}
