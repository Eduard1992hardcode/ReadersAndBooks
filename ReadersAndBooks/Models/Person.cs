using System;
using System.Collections.Generic;

namespace ReadersAndBooks.Models
{
    public class Person : BaseModel
    {
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime Date { get; set;}
        public List<Book> Books { get; set; }
    }
}
