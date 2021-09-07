using ReadersAndBooks.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadersAndBooks.Services
{
    public class MuteDb
    {
        public static List<BookDTO> GetBooks() {
            var books = new List<BookDTO>(){
            new BookDTO {Title = "War and Peace", Author = "Tolstoy",Genre = "Action", AuthorId = 1},
            new BookDTO {Title = "A Hunter's Sketches", Author = "Turgenev",Genre = "Biopic", AuthorId = 2},
            new BookDTO {Title = "Three comrades", Author = "Remark",Genre = "Tragedy", AuthorId = 3},
            new BookDTO {Title = "Black obelisk", Author = "Remark",Genre = "Tragedy", AuthorId = 3}
          };
            return books;
        }

        public static List<HumanDTO> GetHumen() {
            var humen = new List<HumanDTO>() {
                 new HumanDTO {Id = 1,Name = "Lev", Surname = "Tolstoy",Patronymic = "Nikolaevich",Birthday = new DateTime(09, 09, 1928) },
                 new HumanDTO{Id = 2,Name = "Ivan", Surname = "Turgenev",Patronymic = "Sergeevich",Birthday = new DateTime(09, 11, 1818) },
                 new HumanDTO {Id = 3,Name = "Erich", Surname = "Remarque ",Patronymic = "",Birthday = new DateTime(22, 07, 1898)  }
             };
            return humen;
             }
            

    }
}
