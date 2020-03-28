using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GetInShape.Repositories.InstructorRepository;
using GetInShape.Repositories.InstructorClassRepository;
using GetInShape.Repositories.SpecializationRepository;
using GetInShape.Repositories.InstructorSpecializationRepository;
using GetInShape.Repositories.ClassRepository;
using GetInShape.Models;
using GetInShape.DTOs;


namespace GetInShape.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        public IInstructorRepository IInstructorRepository { get; set; }
        public IInstructorClassRepository IInstructorClassRepository { get; set; }
        public ISpecializationRepository ISpecializationRepository { get; set; }
        public IInstructorSpecializationRepository IInstructorSpecializationRepository { get; set; }
        

        public InstructorController(IInstructorRepository instructorRepository, IInstructorClassRepository instructorClassRepository, ISpecializationRepository specializationRepository, IInstructorSpecializationRepository instructorSpecializationRepository)
        {
           
            IInstructorClassRepository = instructorClassRepository;
            IInstructorRepository = instructorRepository;
            ISpecializationRepository = specializationRepository;
            IInstructorSpecializationRepository = instructorSpecializationRepository;
        }


        // GET: api/Album
        [HttpGet]
        public ActionResult<IEnumerable<Instructor>> Get()
        {
            return IInstructorRepository.GetAll();
        }

        // GET: api/Album/5
        [HttpGet("{id}")]
        public InstructorDetailsDTO Get(int id)
        {
            Instructor Instructor = IInstructorRepository.Get(id);
            InstructorDetailsDTO MyInstructor = new InstructorDetailsDTO()
            {
                LastName = Instructor.LastName,
                FirstName = Instructor.FirstName
            };

            IEnumerable<InstructorSpecialization> MyInstructorSpecializations = IInstructorSpecializationRepository.GetAll().Where(x => x.InstructorId == Instructor.Id);
            if (MyInstructorSpecializations != null)
            {
                List<string> SpecializationNameList = new List<string>();
                foreach (InstructorSpecialization MyInstructorSpecialization in MyInstructorSpecializations)
                {
                    Specialization MySpecialization = ISpecializationRepository.GetAll().SingleOrDefault(x => x.Id == MyInstructorSpecialization.SpecializationId);
                    SpecializationNameList.Add(MySpecialization.Name);
                }
                MyInstructor.SpecializationName = SpecializationNameList;
            }
            return MyInstructor;
        }

        // POST: api/Album
        [HttpPost]
        public void Post(InstructorDTO value)
        {
            Instructor model = new Instructor()
            {
                LastName = value.LastName,
                FirstName = value.FirstName,
            };
            IInstructorRepository.Create(model); 

            // trebuie sa introducem si in tabela de intersectie
            for (int i = 0; i < value.SpecializationId.Count; i++)
            {
                InstructorSpecialization InstructorSpecialization = new InstructorSpecialization()
                {
                    InstructorId = model.Id,
                    SpecializationId = value.SpecializationId[i]
                };
                IInstructorSpecializationRepository.Create(InstructorSpecialization);
            }

    
        }

        // PUT: api/Album/5
        [HttpPut("{id}")]
        public void Put(int id, InstructorDTO value)
        {
            Instructor model = IInstructorRepository.Get(id);
            if (value.LastName != null)
            {
                model.LastName = value.LastName;
            }
            if (value.FirstName != null)
            {
                model.FirstName = value.FirstName;
            }

            IInstructorRepository.Update(model);

            //trebuie sa putem face update si la lista de instructori si sali de fitness

            //trebuie sa putem face update si la lista de artisti si cantece

          
            if (value.SpecializationId != null) // song -> specialization
            {
                IEnumerable<InstructorSpecialization> MyInstructorSpecializations = IInstructorSpecializationRepository.GetAll().Where(x => x.InstructorId == id);
                foreach (InstructorSpecialization MyInstructorSpecialization in MyInstructorSpecializations)
                    IInstructorSpecializationRepository.Delete(MyInstructorSpecialization);
                for (int i = 0; i < value.SpecializationId.Count; i++)
                {
                    InstructorSpecialization InstructorSpecialization = new InstructorSpecialization()
                    {
                        InstructorId = model.Id,
                        SpecializationId = value.SpecializationId[i]
                    };
                    IInstructorSpecializationRepository.Create(InstructorSpecialization);
                }
            }

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public Instructor Delete(int id)
        {
            Instructor Instructor = IInstructorRepository.Get(id);
            return IInstructorRepository.Delete(Instructor);

            // trebuie sa sterg si din tabelele de legatura
            // deci facem controllere si pt songAlbum si artitAlbum

        }
    }
}
