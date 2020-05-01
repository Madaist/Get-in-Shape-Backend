using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GetInShape.Repositories.GymClubClassRepository;
using GetInShape.Models;
using GetInShape.DTOs;

namespace GetInShape.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GymClubFitnessClassController : ControllerBase
    {
        public IGymClubFitnessClassRepository IGymClubClassRepository { get; set; }

        public GymClubFitnessClassController(IGymClubFitnessClassRepository repository)
        {
            IGymClubClassRepository = repository;
        }

        // GET: api/Provider
        [HttpGet]
        public ActionResult<IEnumerable<GymClubFitnessClass>> Get()
        {
            return IGymClubClassRepository.GetAll();
        }

        // GET: api/Provider/5
        [HttpGet("{id}")]
        public ActionResult<GymClubFitnessClass> Get(int id)
        {
            return IGymClubClassRepository.Get(id);
        }

        // POST: api/Provider
        [HttpPost]
        public GymClubFitnessClass Post(GymClubFitnessClassDTO value)
        {
            GymClubFitnessClass model = new GymClubFitnessClass()
            {
                GymClubId = value.GymClubId,
                FitnessClassId = value.FitnessClassId,
                TimeSchedule = value.TimeSchedule

            };
            return IGymClubClassRepository.Create(model);
        }

        // PUT: api/Provider/5
        [HttpPut("{id}")]
        public GymClubFitnessClass Put(int id, GymClubFitnessClassDTO value)
        {
            GymClubFitnessClass model = IGymClubClassRepository.Get(id);
            if (value.GymClubId != 0)
            {
                model.GymClubId = value.GymClubId;
            }
            if (value.FitnessClassId != 0)
            {
                model.FitnessClassId = value.FitnessClassId;
            }
            if (value.TimeSchedule != null)
            {
                model.TimeSchedule = value.TimeSchedule;
            }
            return IGymClubClassRepository.Update(model);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public GymClubFitnessClass Delete(int id)
        {
            GymClubFitnessClass model = IGymClubClassRepository.Get(id);
            return IGymClubClassRepository.Delete(model);
        }
    }
}
