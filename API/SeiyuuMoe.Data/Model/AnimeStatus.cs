﻿using System;
using System.Collections.Generic;

namespace SeiyuuMoe.Data.Model
{
    public partial class AnimeStatus
    {
        public AnimeStatus()
        {
            Anime = new HashSet<Anime>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Anime> Anime { get; set; }
    }
}
