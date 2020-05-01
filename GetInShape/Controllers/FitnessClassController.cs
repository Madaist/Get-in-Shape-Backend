using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GetInShape.DTOs;
using GetInShape.Models;
using GetInShape.Repositories.InstructorClassRepository;
using GetInShape.Repositories.InstructorRepository;
using GetInShape.Repositories.GymClubClassRepository;
using GetInShape.Repositories.GymClubRepository;
using GetInShape.Repositories.SongRepository;
using GetInShape.Repositories.FitnessClassRepository;

namespace GetInShape.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FitnessClassController : ControllerBase
    {
        public IFitnessClassRepository IFitnessClassRepository { get; set; }
        public IInstructorFitnessClassRepository IInstructorClassRepository { get; set; }
        public IInstructorRepository IInstructorRepository { get; set; }
        public IGymClubFitnessClassRepository IGymClubClassRepository { get; set; }
        public IGymClubRepository IGymClubRepository { get; set; }
        public ISongRepository ISongRepository { get; set; }

        public FitnessClassController(IFitnessClassRepository fitnessClassRepository, IInstructorFitnessClassRepository instructorClassRepository, IInstructorRepository instructorRepository, IGymClubFitnessClassRepository gymClubClassRepository, ISongRepository songRepository, IGymClubRepository gymClubRepository)
        {
            IFitnessClassRepository = fitnessClassRepository;
            IInstructorClassRepository = instructorClassRepository;
            IInstructorRepository = instructorRepository;
            ISongRepository = songRepository;
            IGymClubClassRepository = gymClubClassRepository;
            IGymClubRepository = gymClubRepository;
        }


        // GET: api/Album
        [HttpGet]
        public ActionResult<IEnumerable<FitnessClass>> Get()
        {
            return IFitnessClassRepository.GetAll();
        }

        // GET: api/Album/5
        [HttpGet("{id}")]
        public FitnessClassDetailsDTO Get(int id)
        {
            FitnessClass FitnessClass = IFitnessClassRepository.Get(id);
            FitnessClassDetailsDTO MyClass = new FitnessClassDetailsDTO()
            {
                Name = FitnessClass.Name,
                Img = FitnessClass.Img
               
            };

            IEnumerable<InstructorFitnessClass> MyInstructorClasses = IInstructorClassRepository.GetAll().Where(x => x.FitnessClassId == FitnessClass.Id);
            if (MyInstructorClasses != null)
            {
                List<string> InstructorNameList = new List<string>();
                foreach (InstructorFitnessClass MyInstructorClass in MyInstructorClasses)
                {
                    Instructor MyInstructor = IInstructorRepository.GetAll().SingleOrDefault(x => x.Id == MyInstructorClass.InstructorId);
                    InstructorNameList.Add(MyInstructor.FirstName + " " +  MyInstructor.LastName);
                }
                MyClass.InstructorName = InstructorNameList;
            }
            

            IEnumerable<GymClubFitnessClass> MyGymClubClasses = IGymClubClassRepository.GetAll().Where(x => x.FitnessClassId == FitnessClass.Id);
            if (MyGymClubClasses != null)
            {
                List<string> GymClubNameList = new List<string>();
                foreach (GymClubFitnessClass MyGymClubClass in MyGymClubClasses)
                {
                    GymClub MyGymClub = IGymClubRepository.GetAll().SingleOrDefault(x => x.Id == MyGymClubClass.GymClubId);
                    GymClubNameList.Add(MyGymClub.Name);
                }
                MyClass.GymClubName = GymClubNameList;
            }

            IEnumerable<Song> MySongs = ISongRepository.GetAll().Where(x => x.FitnessClassId == FitnessClass.Id);
            if (MySongs != null)
            {
                List<string> SongNameList = new List<string>();
                foreach (Song MySong in MySongs)
                {
                    SongNameList.Add(MySong.Name);
                }
                MyClass.SongName = SongNameList;

            }

            return MyClass;
        }

        // POST: api/Album
        [HttpPost]
        public void Post(FitnessClassDTO value)
        {
            FitnessClass model = new FitnessClass()
            {
                Name = value.Name,
                Img = value.Img
               
            };
            IFitnessClassRepository.Create(model); // am creat o clasa

            // trebuie sa introducem si in tabela de intersectie
            for (int i = 0; i < value.InstructorId.Count; i++)
            {
                InstructorFitnessClass InstructorClass = new InstructorFitnessClass()
                {
                    FitnessClassId = model.Id,
                    InstructorId = value.InstructorId[i]
                };
                IInstructorClassRepository.Create(InstructorClass);
            }

            for (int i = 0; i < value.GymClubId.Count; i++)
            {
                GymClubFitnessClass GymClubClass = new GymClubFitnessClass()
                {
                    FitnessClassId = model.Id,
                    GymClubId = value.GymClubId[i]
                };
                IGymClubClassRepository.Create(GymClubClass);
            }
        }

        // PUT: api/Album/5
        [HttpPut("{id}")]
        public void Put(int id, FitnessClassDTO value)
        {
            FitnessClass model = IFitnessClassRepository.Get(id);
            if (value.Name != null)
            {
                model.Name = value.Name;
            }
            if (value.Img != null)
            {
                model.Img = value.Img;
            }


            IFitnessClassRepository.Update(model);

            //trebuie sa putem face update si la lista de instructori si sali de fitness

            if (value.InstructorId != null)
            {
                IEnumerable<InstructorFitnessClass> MyInstructorClasses = IInstructorClassRepository.GetAll().Where(x => x.FitnessClassId == id);
                foreach (InstructorFitnessClass MyInstructorClass in MyInstructorClasses)
                    IInstructorClassRepository.Delete(MyInstructorClass);
                for (int i = 0; i < value.InstructorId.Count; i++)
                {
                    InstructorFitnessClass InstructorClass = new InstructorFitnessClass()
                    {
                        FitnessClassId = model.Id,
                        InstructorId = value.InstructorId[i]
                    };
                    IInstructorClassRepository.Create(InstructorClass);
                }
            }
            if (value.GymClubId != null)
            {
                IEnumerable<GymClubFitnessClass> MyGymClubClasses = IGymClubClassRepository.GetAll().Where(x => x.FitnessClassId == id);
                foreach (GymClubFitnessClass MyGymClubClass in MyGymClubClasses)
                    IGymClubClassRepository.Delete(MyGymClubClass);
                for (int i = 0; i < value.GymClubId.Count; i++)
                {
                    GymClubFitnessClass GymClubClass = new GymClubFitnessClass()
                    {
                        FitnessClassId = model.Id,
                        GymClubId = value.GymClubId[i]
                    };
                    IGymClubClassRepository.Create(GymClubClass);
                }
            }

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public FitnessClass Delete(int id)
        {
            FitnessClass FitnessClass = IFitnessClassRepository.Get(id);
            return IFitnessClassRepository.Delete(FitnessClass); 
        }
    }
}
