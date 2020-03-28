using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetInShape.Contexts;
using GetInShape.Models;

namespace GetInShape.Repositories.GymClubClassRepository
{
    public class GymClubClassRepository : IGymClubClassRepository
    {
        public Context _context { get; set; }
        public GymClubClassRepository(Context context)
        {
            _context = context;
        }

        public GymClubClass Create(GymClubClass GymClubClass)
        {
            var result = _context.Add<GymClubClass>(GymClubClass);
            _context.SaveChanges();
            return result.Entity;
        }

        public GymClubClass Get(int Id)
        {
            return _context.GymClubClasses.SingleOrDefault(x => x.Id == Id);
        }

        public List<GymClubClass> GetAll()
        {
            return _context.GymClubClasses.ToList();
        }

        public GymClubClass Update(GymClubClass GymClubClass)
        {
            _context.Entry(GymClubClass).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return GymClubClass;
        }

        public GymClubClass Delete(GymClubClass GymClubClass)
        {
            var result = _context.Remove(GymClubClass);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
