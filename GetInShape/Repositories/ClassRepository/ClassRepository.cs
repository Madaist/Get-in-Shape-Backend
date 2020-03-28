using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetInShape.Repositories.ClassRepository;
using GetInShape.Contexts;
using GetInShape.Models;

namespace GetInShape.Repositories.ClassRepository
{
    public class ClassRepository : IClassRepository
    {
        public Context _context { get; set; }
        public ClassRepository(Context context)
        {
            _context = context;
        }

        public Class Create(Class Class)
        {
            var result = _context.Add<Class>(Class);
            _context.SaveChanges();
            return result.Entity;
        }

        public Class Get(int Id)
        {
            return _context.Classes.SingleOrDefault(x => x.Id == Id);
        }

        public List<Class> GetAll()
        {
            return _context.Classes.ToList();
        }

        public Class Update(Class Class)
        {
            _context.Entry(Class).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return Class;
        }

        public Class Delete(Class Class)
        {
            var result = _context.Remove(Class);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
