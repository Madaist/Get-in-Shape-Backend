﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetInShape.Models;

namespace GetInShape.Repositories.SongRepository
{
    public interface ISongRepository
    {
        List<Song> GetAll();
        Song Get(int Id);
        Song Create(Song Song);
        Song Update(Song Song);
        Song Delete(Song Song);
    }
}
