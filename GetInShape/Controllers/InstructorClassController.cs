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
    public class InstructorClassController : ControllerBase
    {
        public IInstructorClassRepository IInstructorClassRepository { get; set; }

        public InstructorClassController(IInstructorClassRepository repository)
        {
            IInstructorClassRepository = repository;
        }

        // GET: api/Provider
        [HttpGet]
        public ActionResult<IEnumerable<InstructorClass>> Get()
        {
            return IInstructorClassRepository.GetAll();
        }

        // GET: api/Provider/5
        [HttpGet("{id}")]
        public ActionResult<InstructorClass> Get(int id)
        {
            return IInstructorClassRepository.Get(id);
        }

        // POST: api/Provider
        [HttpPost]
        public InstructorClass Post(InstructorClassDTO value)
        {
            InstructorClass model = new InstructorClass()
            {
                InstructorId = value.InstructorId,
                ClassId = value.ClassId
            };
            return IInstructorClassRepository.Create(model);
        }

        // PUT: api/Provider/5
        [HttpPut("{id}")]
        public InstructorClass Put(int id, InstructorClassDTO value)
        {
            InstructorClass model = IInstructorClassRepository.Get(id);
            if (value.InstructorId != 0)
            {
                model.InstructorId = value.InstructorId;
            }
            if (value.ClassId != 0)
            {
                model.ClassId = value.ClassId;
            }
            return IInstructorClassRepository.Update(model);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public InstructorClass Delete(int id)
        {
            InstructorClass model = IInstructorClassRepository.Get(id);
            return IInstructorClassRepository.Delete(model);
        }
    }
}
