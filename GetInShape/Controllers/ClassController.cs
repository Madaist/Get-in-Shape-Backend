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
using GetInShape.Repositories.ClassRepository;

namespace GetInShape.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        public IClassRepository IClassRepository { get; set; }
        public IInstructorClassRepository IInstructorClassRepository { get; set; }
        public IInstructorRepository IInstructorRepository { get; set; }
        public IGymClubClassRepository IGymClubClassRepository { get; set; }
        public IGymClubRepository IGymClubRepository { get; set; }
        public ISongRepository ISongRepository { get; set; }

        public ClassController(IClassRepository classRepository, IInstructorClassRepository instructorClassRepository, IInstructorRepository instructorRepository, IGymClubClassRepository gymClubClassRepository, ISongRepository songRepository, IGymClubRepository gymClubRepository)
        {
            IClassRepository = classRepository;
            IInstructorClassRepository = instructorClassRepository;
            IInstructorRepository = instructorRepository;
            ISongRepository = songRepository;
            IGymClubClassRepository = gymClubClassRepository;
            IGymClubRepository = gymClubRepository;
        }


        // GET: api/Album
        [HttpGet]
        public ActionResult<IEnumerable<Class>> Get()
        {
            return IClassRepository.GetAll();
        }

        // GET: api/Album/5
        [HttpGet("{id}")]
        public ClassDetailsDTO Get(int id)
        {
            Class Class = IClassRepository.Get(id);
            ClassDetailsDTO MyClass = new ClassDetailsDTO()
            {
                Name = Class.Name,
                TimeSchedule = Class.TimeSchedule
            };

            IEnumerable<InstructorClass> MyInstructorClasses = IInstructorClassRepository.GetAll().Where(x => x.ClassId == Class.Id);
            if (MyInstructorClasses != null)
            {
                List<string> InstructorNameList = new List<string>();
                foreach (InstructorClass MyInstructorClass in MyInstructorClasses)
                {
                    Instructor MyInstructor = IInstructorRepository.GetAll().SingleOrDefault(x => x.Id == MyInstructorClass.InstructorId);
                    InstructorNameList.Add(MyInstructor.FirstName + MyInstructor.LastName);
                }
                MyClass.InstructorName = InstructorNameList;
            }

            IEnumerable<GymClubClass> MyGymClubClasses = IGymClubClassRepository.GetAll().Where(x => x.ClassId == Class.Id);
            if (MyGymClubClasses != null)
            {
                List<string> GymClubNameList = new List<string>();
                foreach (GymClubClass MyGymClubClass in MyGymClubClasses)
                {
                    GymClub MyGymClub = IGymClubRepository.GetAll().SingleOrDefault(x => x.Id == MyGymClubClass.GymClubId);
                    GymClubNameList.Add(MyGymClub.Name);
                }
                MyClass.GymClubName = GymClubNameList;
            }

            IEnumerable<Song> MySongs = ISongRepository.GetAll().Where(x => x.ClassId == Class.Id);
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
        public void Post(ClassDTO value)
        {
            Class model = new Class()
            {
                Name = value.Name,
                TimeSchedule = value.TimeSchedule,
            };
            IClassRepository.Create(model); // am creat o clasa

            // trebuie sa introducem si in tabela de intersectie
            for (int i = 0; i < value.InstructorId.Count; i++)
            {
                InstructorClass InstructorClass = new InstructorClass()
                {
                    ClassId = model.Id,
                    InstructorId = value.InstructorId[i]
                };
                IInstructorClassRepository.Create(InstructorClass);
            }

            for (int i = 0; i < value.GymClubId.Count; i++)
            {
                GymClubClass GymClubClass = new GymClubClass()
                {
                    ClassId = model.Id,
                    GymClubId = value.GymClubId[i]
                };
                IGymClubClassRepository.Create(GymClubClass);
            }
        }

        // PUT: api/Album/5
        [HttpPut("{id}")]
        public void Put(int id, ClassDTO value)
        {
            Class model = IClassRepository.Get(id);
            if (value.Name != null)
            {
                model.Name = value.Name;
            }
            if (value.TimeSchedule != null)
            {
                model.TimeSchedule = value.TimeSchedule;
            }

            IClassRepository.Update(model);

            //trebuie sa putem face update si la lista de instructori si sali de fitness

            if (value.InstructorId != null)
            {
                IEnumerable<InstructorClass> MyInstructorClasses = IInstructorClassRepository.GetAll().Where(x => x.ClassId == id);
                foreach (InstructorClass MyInstructorClass in MyInstructorClasses)
                    IInstructorClassRepository.Delete(MyInstructorClass);
                for (int i = 0; i < value.InstructorId.Count; i++)
                {
                    InstructorClass InstructorClass = new InstructorClass()
                    {
                        ClassId = model.Id,
                        InstructorId = value.InstructorId[i]
                    };
                    IInstructorClassRepository.Create(InstructorClass);
                }
            }
            if (value.GymClubId != null)
            {
                IEnumerable<GymClubClass> MyGymClubClasses = IGymClubClassRepository.GetAll().Where(x => x.ClassId == id);
                foreach (GymClubClass MyGymClubClass in MyGymClubClasses)
                    IGymClubClassRepository.Delete(MyGymClubClass);
                for (int i = 0; i < value.GymClubId.Count; i++)
                {
                    GymClubClass GymClubClass = new GymClubClass()
                    {
                        ClassId = model.Id,
                        GymClubId = value.GymClubId[i]
                    };
                    IGymClubClassRepository.Create(GymClubClass);
                }
            }

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public Class Delete(int id)
        {
            Class Class = IClassRepository.Get(id);
            return IClassRepository.Delete(Class);

            // trebuie sa sterg si din tabelele de legatura
            // deci facem controllere si pt songAlbum si artitAlbum
            
        }
    }
}
