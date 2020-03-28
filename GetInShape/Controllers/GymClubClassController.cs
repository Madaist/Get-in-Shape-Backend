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
    public class GymClubClassController : ControllerBase
    {
        public IGymClubClassRepository IGymClubClassRepository { get; set; }

        public GymClubClassController(IGymClubClassRepository repository)
        {
            IGymClubClassRepository = repository;
        }

        // GET: api/Provider
        [HttpGet]
        public ActionResult<IEnumerable<GymClubClass>> Get()
        {
            return IGymClubClassRepository.GetAll();
        }

        // GET: api/Provider/5
        [HttpGet("{id}")]
        public ActionResult<GymClubClass> Get(int id)
        {
            return IGymClubClassRepository.Get(id);
        }

        // POST: api/Provider
        [HttpPost]
        public GymClubClass Post(GymClubClassDTO value)
        {
            GymClubClass model = new GymClubClass()
            {
                GymClubId = value.GymClubId,
                ClassId = value.ClassId
            };
            return IGymClubClassRepository.Create(model);
        }

        // PUT: api/Provider/5
        [HttpPut("{id}")]
        public GymClubClass Put(int id, GymClubClassDTO value)
        {
            GymClubClass model = IGymClubClassRepository.Get(id);
            if (value.GymClubId != 0)
            {
                model.GymClubId = value.GymClubId;
            }
            if (value.ClassId != 0)
            {
                model.ClassId = value.ClassId;
            }
            return IGymClubClassRepository.Update(model);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public GymClubClass Delete(int id)
        {
            GymClubClass model = IGymClubClassRepository.Get(id);
            return IGymClubClassRepository.Delete(model);
        }
    }
}
