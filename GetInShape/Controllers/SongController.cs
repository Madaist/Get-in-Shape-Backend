using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GetInShape.Models;
using GetInShape.DTOs;
using GetInShape.Repositories.SongRepository;
using GetInShape.Repositories.ClassRepository;

namespace GetInShape.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        public ISongRepository ISongRepository { get; set; }
        public IClassRepository IClassRepository { get; set; }

        public SongController(ISongRepository repository)
        {
            ISongRepository = repository;
        }

        // GET: api/Song
        [HttpGet]
        public ActionResult<IEnumerable<Song>> Get()
        {
            return ISongRepository.GetAll();
        }

        // GET: api/Song/5
        [HttpGet("{id}")]
        public ActionResult<Song> Get(int id)
        {
            return ISongRepository.Get(id);
        }

        // POST: api/Song
        [HttpPost]
        public Song Post(SongDTO value)
        {
            Song model = new Song()
            {
                Name = value.Name,
                Singer = value.Singer,
                Bpm = value.Bpm,
                ClassId = value.ClassId
            };
            return ISongRepository.Create(model);
        }

        // PUT: api/Song/5
        [HttpPut("{id}")]
        public Song Put(int id, SongDTO value)
        {
            Song model = ISongRepository.Get(id);
            if (value.Name != null)
            {
                model.Name = value.Name;
            }
            if (value.ClassId != 0)
            {
                model.ClassId = value.ClassId;
            }
            if (value.Singer != null)
            {
                model.Singer = value.Singer;
            }
            if (value.Bpm != 0)
            {
                model.Bpm = value.Bpm;
            }
            return ISongRepository.Update(model);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public Song Delete(int id)
        {
            Song model = ISongRepository.Get(id);
            return ISongRepository.Delete(model);
        }
    }
}
