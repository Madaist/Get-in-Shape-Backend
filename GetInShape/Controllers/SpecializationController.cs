using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GetInShape.Models;
using GetInShape.DTOs;
using GetInShape.Repositories.SpecializationRepository;
using GetInShape.Repositories.InstructorSpecializationRepository;
using GetInShape.Repositories.InstructorRepository;

namespace GetInShape.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecializationController : ControllerBase
    {
        public ISpecializationRepository ISpecializationRepository { get; set; }
        
        

        public SpecializationController(ISpecializationRepository specializationRepository)
        {
            ISpecializationRepository = specializationRepository;
           
        }


        // GET: api/Provider
        [HttpGet]
        public ActionResult<IEnumerable<Specialization>> Get()
        {
            return ISpecializationRepository.GetAll();
        }

        // GET: api/Provider/5
        [HttpGet("{id}")]
        public ActionResult<Specialization> Get(int id)
        {
            return ISpecializationRepository.Get(id);
        }

        // POST: api/Provider
        [HttpPost]
        public Specialization Post(SpecializationDTO value)
        {
            Specialization model = new Specialization()
            {
                Name = value.Name,
                Description = value.Description
            };
            return ISpecializationRepository.Create(model);
        }

        // PUT: api/Provider/5
        [HttpPut("{id}")]
        public Specialization Put(int id, SpecializationDTO value)
        {
            Specialization model = ISpecializationRepository.Get(id);
            if (value.Name != null)
            {
                model.Name = value.Name;
            }
            if (value.Description != null)
            {
                model.Description = value.Description;
            }
            return ISpecializationRepository.Update(model);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public Specialization Delete(int id)
        {
            Specialization model = ISpecializationRepository.Get(id);
            return ISpecializationRepository.Delete(model);
        }
    }
}
