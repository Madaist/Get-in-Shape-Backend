using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetInShape.Models;
using GetInShape.Contexts;

namespace GetInShape.Repositories.SpecializationRepository
{
    public class SpecializationRepository : ISpecializationRepository
    {
        public Context _context { get; set; }
        public SpecializationRepository(Context context)
        {
            _context = context;
        }

        public Specialization Create(Specialization Specialization)
        {
            var result = _context.Add<Specialization>(Specialization);
            _context.SaveChanges();
            return result.Entity;
        }

        public Specialization Get(int Id)
        {
            return _context.Specializations.SingleOrDefault(x => x.Id == Id);
        }

        public List<Specialization> GetAll()
        {
            return _context.Specializations.ToList();
        }

        public Specialization Update(Specialization Specialization)
        {
            _context.Entry(Specialization).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return Specialization;
        }

        public Specialization Delete(Specialization Specialization)
        {
            var result = _context.Remove(Specialization);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
