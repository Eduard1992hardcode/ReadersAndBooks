using ReadersAndBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadersAndBooks.Repository
{
    public interface IGenreRepository
    {
        public List<Genre> Genres(ICollection<int> ids);
    }
}
