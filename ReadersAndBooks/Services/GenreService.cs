using Microsoft.Extensions.Logging;
using ReadersAndBooks.Data;
using ReadersAndBooks.Dto;
using ReadersAndBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadersAndBooks.Services
{
    public class GenreService : IGenreService
    {
        private readonly DataContext _dataContext;
        private readonly ILogger<GenreService> _logger;

        public GenreService(DataContext dataContext, ILogger<GenreService> logger)
        {
            _dataContext = dataContext;
            _logger = logger;
        }
        public Genre AddGenre(Genre genre)
        {
            _dataContext.Genres.Add(genre);
            _dataContext.SaveChanges();
            return genre;
        }

        public List<Genre> GetGenres()
        {
            return _dataContext.Genres.ToList();
        }

        public GenreDto GetGenreStatistic(int id)
        {
            var genre = _dataContext.Genres.Find(id);
            return new GenreDto { Name = genre.Name,
                BooksStatistic = _dataContext.BooksGenres.Count(b => b.GenreId == id) };
        }
    }
}
