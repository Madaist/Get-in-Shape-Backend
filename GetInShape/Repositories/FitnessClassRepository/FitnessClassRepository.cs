using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetInShape.Repositories.FitnessClassRepository;
using GetInShape.Contexts;
using GetInShape.Models;

namespace GetInShape.Repositories.FitnessClassRepository
{
    public class FitnessClassRepository : IFitnessClassRepository
    {
        public Context _context { get; set; }
        public FitnessClassRepository(Context context)
        {
            _context = context;
        }

        public FitnessClass Create(FitnessClass FitnessClass)
        {
            var result = _context.Add<FitnessClass>(FitnessClass);
            _context.SaveChanges();
            return result.Entity;
        }

        public FitnessClass Get(int Id)
        {
            return _context.FitnessClasses.SingleOrDefault(x => x.Id == Id);
        }

        public List<FitnessClass> GetAll()
        {
            return _context.FitnessClasses.ToList();
        }

        public FitnessClass Update(FitnessClass Class)
        {
            _context.Entry(Class).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return Class;
        }

        public FitnessClass Delete(FitnessClass Class)
        {
            var result = _context.Remove(Class);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
