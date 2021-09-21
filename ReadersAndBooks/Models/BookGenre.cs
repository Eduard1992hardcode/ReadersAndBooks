﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadersAndBooks.Models
{
    public class BookGenre
    {
        public virtual Book Book { get; set; }
        public int BookId { get; set;}
        public virtual Genre Genre { get; set; }
        public  int GenreId { get; set; }
    }
}
