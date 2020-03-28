using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GetInShape.Repositories.AddressRepository;
using GetInShape.Repositories.GymClubClassRepository;
using GetInShape.Repositories.GymClubRepository;
using GetInShape.Repositories.ClassRepository;
using GetInShape.Models;
using GetInShape.DTOs;

namespace GetInShape.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GymClubController : ControllerBase
    {
        public IAddressRepository IAddressRepository { get; set; }
        public IGymClubClassRepository IGymClubClassRepository { get; set; }
        public IGymClubRepository IGymClubRepository { get; set; }
        public IClassRepository IClassRepository { get; set; }
    

        public GymClubController(IAddressRepository addressRepository, IGymClubClassRepository gymClubClassRepository, IGymClubRepository gymClubRepository, IClassRepository classRepository)
        {
            IAddressRepository = addressRepository;
            IGymClubClassRepository = gymClubClassRepository;
            IGymClubRepository = gymClubRepository;
            IClassRepository = classRepository;
            
        }


        // GET: api/Album
        [HttpGet]
        public ActionResult<IEnumerable<GymClub>> Get()
        {
            return IGymClubRepository.GetAll();
        }

        // GET: api/Album/5
        [HttpGet("{id}")]
        public ActionResult<GymClub> Get(int id)
        {
            return IGymClubRepository.Get(id);
        }

        // POST: api/Album
        [HttpPost]
        public void Post(GymClubDTO value)
        {
            GymClub model = new GymClub()
            {
                Name = value.Name,
                AddressId = value.AddressId,
            };
            IGymClubRepository.Create(model); // am creat un album

            // trebuie sa introducem si in tabela de intersectie
            for (int i = 0; i < value.ClassId.Count; i++)
            {
                GymClubClass GymClubClass = new GymClubClass()
                {
                    GymClubId = model.Id,
                    ClassId = value.ClassId[i]
                };
                IGymClubClassRepository.Create(GymClubClass);
            }

        }

        // PUT: api/Album/5
        [HttpPut("{id}")]
        public void Put(int id, GymClubDTO value)
        {
            GymClub model = IGymClubRepository.Get(id);
            if (value.Name != null)
            {
                model.Name = value.Name;
            }
            if (value.AddressId != 0)
            {
                model.AddressId = value.AddressId;
            }
            
            IGymClubRepository.Update(model);

            //trebuie sa putem face update si la lista de artisti si cantece

            if (value.ClassId != null)
            {
                IEnumerable<GymClubClass> MyGymClubClasses = IGymClubClassRepository.GetAll().Where(x => x.GymClubId == id);
                foreach (GymClubClass MyGymClubClass in MyGymClubClasses)
                    IGymClubClassRepository.Delete(MyGymClubClass);
                for (int i = 0; i < value.ClassId.Count; i++)
                {
                    GymClubClass GymClubClass = new GymClubClass()
                    {
                        GymClubId = model.Id,
                        ClassId = value.ClassId[i]
                    };
                    IGymClubClassRepository.Create(GymClubClass);
                }
            }

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public GymClub Delete(int id)
        {
            GymClub album = IGymClubRepository.Get(id);
            return IGymClubRepository.Delete(album);

            // trebuie sa sterg si din tabelele de legatura
            // deci facem controllere si pt songAlbum si artitAlbum

        }
    }
}
