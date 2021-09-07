using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadersAndBooks.Dto
{
    public class HumanDTO
    {
       public int Id { get; set; }
       public string Name { get; set;}
       public string Surname { get; set; }
       public string Patronymic { get; set; }
       public DateTime Birthday { get; set; }
       public List<BookDTO> Books { get; set; }
    }
}
