using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GetInShape.Models;
using GetInShape.DTOs;
using GetInShape.Repositories.InstructorSpecializationRepository;

namespace GetInShape.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorSpecializationController : ControllerBase
    {
        public IInstructorSpecializationRepository IInstructorSpecializationRepository { get; set; }

        public InstructorSpecializationController(IInstructorSpecializationRepository repository)
        {
            IInstructorSpecializationRepository = repository;
        }

        // GET: api/Provider
        [HttpGet]
        public ActionResult<IEnumerable<InstructorSpecialization>> Get()
        {
            return IInstructorSpecializationRepository.GetAll();
        }

        // GET: api/Provider/5
        [HttpGet("{id}")]
        public ActionResult<InstructorSpecialization> Get(int id)
        {
            return IInstructorSpecializationRepository.Get(id);
        }

        // POST: api/Provider
        [HttpPost]
        public InstructorSpecialization Post(InstructorSpecializationDTO value)
        {
            InstructorSpecialization model = new InstructorSpecialization()
            {
                InstructorId = value.InstructorId,
                SpecializationId = value.SpecializationId

            };
            return IInstructorSpecializationRepository.Create(model);
        }

        // PUT: api/Provider/5
        [HttpPut("{id}")]
        public InstructorSpecialization Put(int id, InstructorSpecializationDTO value)
        {
            InstructorSpecialization model = IInstructorSpecializationRepository.Get(id);
            if (value.InstructorId != 0)
            {
                model.InstructorId = value.InstructorId;
            }
            if (value.SpecializationId != 0)
            {
                model.SpecializationId = value.SpecializationId;
            }
            return IInstructorSpecializationRepository.Update(model);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public InstructorSpecialization Delete(int id)
        {
            InstructorSpecialization model = IInstructorSpecializationRepository.Get(id);
            return IInstructorSpecializationRepository.Delete(model);
        }
    }
}
