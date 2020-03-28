using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetInShape.Models;
using GetInShape.Contexts;

namespace GetInShape.Repositories.GymClubRepository
{
    public class GymClubRepository : IGymClubRepository
    {
        public Context _context { get; set; }
        public GymClubRepository(Context context)
        {
            _context = context;
        }

        public GymClub Create(GymClub GymClub)
        {
            var result = _context.Add<GymClub>(GymClub);
            _context.SaveChanges();
            return result.Entity;
        }

        public GymClub Get(int Id)
        {
            return _context.GymClubs.SingleOrDefault(x => x.Id == Id);
        }

        public List<GymClub> GetAll()
        {
            return _context.GymClubs.ToList();
        }

        public GymClub Update(GymClub GymClub)
        {
            _context.Entry(GymClub).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return GymClub;
        }

        public GymClub Delete(GymClub GymClub)
        {
            var result = _context.Remove(GymClub);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
