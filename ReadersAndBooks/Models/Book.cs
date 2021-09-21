using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadersAndBooks.Models
{
    public class Book : BaseModel
    {
        public int AuthorId { get; set; }

        public virtual Author Author { get; set; }
        public virtual List<Genre> Genres { get; set; }
    }
}
