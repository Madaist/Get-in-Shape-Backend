using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetInShape.Contexts;
using GetInShape.Models;

namespace GetInShape.Repositories.GymClubClassRepository
{
    public class GymClubFitnessClassRepository : IGymClubFitnessClassRepository
    {
        public Context _context { get; set; }
        public GymClubFitnessClassRepository(Context context)
        {
            _context = context;
        }

        public GymClubFitnessClass Create(GymClubFitnessClass GymClubClass)
        {
            var result = _context.Add<GymClubFitnessClass>(GymClubClass);
            _context.SaveChanges();
            return result.Entity;
        }

        public GymClubFitnessClass Get(int Id)
        {
            return _context.GymClubClasses.SingleOrDefault(x => x.Id == Id);
        }

        public List<GymClubFitnessClass> GetAll()
        {
            return _context.GymClubClasses.ToList();
        }

        public GymClubFitnessClass Update(GymClubFitnessClass GymClubClass)
        {
            _context.Entry(GymClubClass).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return GymClubClass;
        }

        public GymClubFitnessClass Delete(GymClubFitnessClass GymClubClass)
        {
            var result = _context.Remove(GymClubClass);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
