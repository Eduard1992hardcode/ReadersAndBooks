using System.ComponentModel.DataAnnotations;

namespace ReadersAndBooks.Dto
{
    public class BookDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Укажите название книги")]
        public string Title { get; set; }
        public string Author { get; set; }

        [Required(ErrorMessage = "Укажите жанр книги")]
        public string Genre { get; set; }
        public int AuthorId { get; set; }

        public override string ToString()
        {
            return this.Title;
        }

     }
}
