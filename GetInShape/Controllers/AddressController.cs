using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GetInShape.DTOs;
using GetInShape.Models;
using GetInShape.Repositories.AddressRepository;

namespace GetInShape.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        public IAddressRepository IAddressRepository { get; set; }

        public AddressController(IAddressRepository repository)
        {
            IAddressRepository = repository;
        }

        // GET: api/Provider
        [HttpGet]
        public ActionResult<IEnumerable<Address>> Get()
        {
            return IAddressRepository.GetAll();
        }

        // GET: api/Provider/5
        [HttpGet("{id}")]
        public ActionResult<Address> Get(int id)
        {
            return IAddressRepository.Get(id);
        }

        // POST: api/Provider
        [HttpPost]
        public Address Post(AddressDTO value)
        {
            Address model = new Address()
            {
                City = value.City,
                Number = value.Number,
                Street = value.Street
            };
            return IAddressRepository.Create(model);
        }

        // PUT: api/Provider/5
        [HttpPut("{id}")]
        public Address Put(int id, AddressDTO value)
        {
            Address model = IAddressRepository.Get(id);
            if (value.City != null)
            {
                model.City = value.City;
            }

            if (value.Number != 0)
            {
                model.Number = value.Number;
            }
            if (value.Street != null)
            {
                model.Street = value.Street;
            }
            return IAddressRepository.Update(model);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public Address Delete(int id)
        {
            Address model = IAddressRepository.Get(id);
            return IAddressRepository.Delete(model);
        }
    }
}
