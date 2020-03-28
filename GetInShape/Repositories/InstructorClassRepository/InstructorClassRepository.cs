using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetInShape.Contexts;
using GetInShape.Repositories;
using GetInShape.Models;

namespace GetInShape.Repositories.InstructorClassRepository
{
    public class InstructorClassRepository : IInstructorClassRepository
    {
        public Context _context { get; set; }
        public InstructorClassRepository(Context context)
        {
            _context = context;
        }

        public InstructorClass Create(InstructorClass InstructorClass)
        {
            var result = _context.Add<InstructorClass>(InstructorClass);
            _context.SaveChanges();
            return result.Entity;
        }

        public InstructorClass Get(int Id)
        {
            return _context.InstructorClasses.SingleOrDefault(x => x.Id == Id);
        }

        public List<InstructorClass> GetAll()
        {
            return _context.InstructorClasses.ToList();
        }

        public InstructorClass Update(InstructorClass InstructorClass)
        {
            _context.Entry(InstructorClass).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return InstructorClass;
        }

        public InstructorClass Delete(InstructorClass InstructorClass)
        {
            var result = _context.Remove(InstructorClass);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
