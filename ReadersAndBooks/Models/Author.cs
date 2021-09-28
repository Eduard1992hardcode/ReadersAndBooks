using System.Collections.Generic;

namespace ReadersAndBooks.Models
{
    public class Author : BaseModel
    {
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public List<Book> Books {get; set;}
    }
}
