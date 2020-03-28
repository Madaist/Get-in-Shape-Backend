using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetInShape.Models;
using GetInShape.Contexts;
using GetInShape.Repositories.AddressRepository;

namespace GetInShape.Repositories.AddressRepository
{
    public class AddressRepository : IAddressRepository
    {
        public Context _context { get; set; }
        public AddressRepository(Context context)
        {
            _context = context;
        }

        public Address Create(Address Address)
        {
            var result = _context.Add<Address>(Address);
            _context.SaveChanges();
            return result.Entity;
        }

        public Address Get(int Id)
        {
            return _context.Addresses.SingleOrDefault(x => x.Id == Id);
        }

        public List<Address> GetAll()
        {
            return _context.Addresses.ToList();
        }

        public Address Update(Address Address)
        {
            _context.Entry(Address).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return Address;
        }

        public Address Delete(Address Address)
        {
            var result = _context.Remove(Address);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
