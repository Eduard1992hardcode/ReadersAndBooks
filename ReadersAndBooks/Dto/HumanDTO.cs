using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReadersAndBooks.Dto
{
    public class HumanDTO
    {
       public int Id { get; set; }

        [Required(ErrorMessage = "Укажите имя писателя")]
        public string Name { get; set;}

        [Required(ErrorMessage = "Укажите фамилию писателя")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Укажите отчество писателя")]
        public string Patronymic { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
       public DateTime Birthday { get; set; }
       public List<BookDTO> Books { get; set; }

        public override string ToString()
        {
            return this.Name + " " + this.Patronymic + " " + this.Surname;
        }
    }
}
