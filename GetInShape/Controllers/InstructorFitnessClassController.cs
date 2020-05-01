using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GetInShape.DTOs;
using GetInShape.Models;
using GetInShape.Repositories.InstructorClassRepository;

namespace GetInShape.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorFitnessClassController : ControllerBase
    {
        public IInstructorFitnessClassRepository IInstructorClassRepository { get; set; }

        public InstructorFitnessClassController(IInstructorFitnessClassRepository repository)
        {
            IInstructorClassRepository = repository;
        }

        // GET: api/Provider
        [HttpGet]
        public ActionResult<IEnumerable<InstructorFitnessClass>> Get()
        {
            return IInstructorClassRepository.GetAll();
        }

        // GET: api/Provider/5
        [HttpGet("{id}")]
        public ActionResult<InstructorFitnessClass> Get(int id)
        {
            return IInstructorClassRepository.Get(id);
        }

        // POST: api/Provider
        [HttpPost]
        public InstructorFitnessClass Post(InstructorClassDTO value)
        {
            InstructorFitnessClass model = new InstructorFitnessClass()
            {
                InstructorId = value.InstructorId,
                FitnessClassId = value.FitnessClassId
            };
            return IInstructorClassRepository.Create(model);
        }

        // PUT: api/Provider/5
        [HttpPut("{id}")]
        public InstructorFitnessClass Put(int id, InstructorClassDTO value)
        {
            InstructorFitnessClass model = IInstructorClassRepository.Get(id);
            if (value.InstructorId != 0)
            {
                model.InstructorId = value.InstructorId;
            }
            if (value.FitnessClassId != 0)
            {
                model.FitnessClassId = value.FitnessClassId;
            }
            return IInstructorClassRepository.Update(model);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public InstructorFitnessClass Delete(int id)
        {
            InstructorFitnessClass model = IInstructorClassRepository.Get(id);
            return IInstructorClassRepository.Delete(model);
        }
    }
}
