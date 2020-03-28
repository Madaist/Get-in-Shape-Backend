using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetInShape.Models;

namespace GetInShape.Repositories.AddressRepository
{
    public interface IAddressRepository
    {
        List<Address> GetAll();
        Address Get(int Id);
        Address Create(Address Address);
        Address Update(Address Address);
        Address Delete(Address Address);
    }
}
