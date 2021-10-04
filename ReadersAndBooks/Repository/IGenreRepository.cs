using ReadersAndBooks.Models;
using System.Collections.Generic;

namespace ReadersAndBooks.Repository
{
    public interface IGenreRepository
    {
        public List<Genre> Genres(ICollection<int> ids);
    }
}
