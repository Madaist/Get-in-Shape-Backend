using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetInShape.Contexts;
using GetInShape.Models;

namespace GetInShape.Repositories.InstructorSpecializationRepository
{
    public class InstructorSpecializationRepository : IInstructorSpecializationRepository
    {
        public Context _context { get; set; }
        public InstructorSpecializationRepository(Context context)
        {
            _context = context;
        }

        public InstructorSpecialization Create(InstructorSpecialization InstructorSpecialization)
        {
            var result = _context.Add<InstructorSpecialization>(InstructorSpecialization);
            _context.SaveChanges();
            return result.Entity;
        }

        public InstructorSpecialization Get(int Id)
        {
            return _context.InstructorSpecializations.SingleOrDefault(x => x.Id == Id);
        }

        public List<InstructorSpecialization> GetAll()
        {
            return _context.InstructorSpecializations.ToList();
        }

        public InstructorSpecialization Update(InstructorSpecialization InstructorSpecialization)
        {
            _context.Entry(InstructorSpecialization).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return InstructorSpecialization;
        }

        public InstructorSpecialization Delete(InstructorSpecialization InstructorSpecialization)
        {
            var result = _context.Remove(InstructorSpecialization);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
