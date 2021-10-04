using System.Collections.Generic;

namespace ReadersAndBooks.Dto
{
    public class BookCreateDto
    {
        public string Title { get; set; }

        public int AuthorId { get; set; }

        public ICollection<int> GenreIds { get; set; }
    }
}
