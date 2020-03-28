using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetInShape.Models;
using GetInShape.Contexts;

namespace GetInShape.Repositories.InstructorRepository
{
    public class InstructorRepository : IInstructorRepository
    {
        public Context _context { get; set; }
        public InstructorRepository(Context context)
        {
            _context = context;
        }

        public Instructor Create(Instructor Instructor)
        {
            var result = _context.Add<Instructor>(Instructor);
            _context.SaveChanges();
            return result.Entity;
        }

        public Instructor Get(int Id)
        {
            return _context.Instructors.SingleOrDefault(x => x.Id == Id);
        }

        public List<Instructor> GetAll()
        {
            return _context.Instructors.ToList();
        }

        public Instructor Update(Instructor Instructor)
        {
            _context.Entry(Instructor).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return Instructor;
        }

        public Instructor Delete(Instructor Instructor)
        {
            var result = _context.Remove(Instructor);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
