using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadersAndBooks.Models
{
    public class Author : BaseModel
    {
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public List<Book> Books {get; set;}
    }
}
