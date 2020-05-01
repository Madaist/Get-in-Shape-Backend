using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetInShape.Contexts;
using GetInShape.Repositories;
using GetInShape.Models;

namespace GetInShape.Repositories.InstructorClassRepository
{
    public class InstructorFitnessClassRepository : IInstructorFitnessClassRepository
    {
        public Context _context { get; set; }
        public InstructorFitnessClassRepository(Context context)
        {
            _context = context;
        }

        public InstructorFitnessClass Create(InstructorFitnessClass InstructorClass)
        {
            var result = _context.Add<InstructorFitnessClass>(InstructorClass);
            _context.SaveChanges();
            return result.Entity;
        }

        public InstructorFitnessClass Get(int Id)
        {
            return _context.InstructorClasses.SingleOrDefault(x => x.Id == Id);
        }

        public List<InstructorFitnessClass> GetAll()
        {
            return _context.InstructorClasses.ToList();
        }

        public InstructorFitnessClass Update(InstructorFitnessClass InstructorClass)
        {
            _context.Entry(InstructorClass).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return InstructorClass;
        }

        public InstructorFitnessClass Delete(InstructorFitnessClass InstructorClass)
        {
            var result = _context.Remove(InstructorClass);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
