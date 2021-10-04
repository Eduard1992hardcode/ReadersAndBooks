using ReadersAndBooks.Data;
using ReadersAndBooks.Models;
using System.Collections.Generic;
using System.Linq;

namespace ReadersAndBooks.Repository
{
    public class GenreRepository : IGenreRepository
    {
        private readonly DataContext _dataContext;

        public GenreRepository(DataContext dataContext)
            {
            _dataContext = dataContext;
            }

        public List<Genre> Genres(ICollection<int> ids)
        {
           return _dataContext.Genres
                .Where(g => ids.Contains(g.Id))
                .ToList();
        }
    }
}
