using ReadersAndBooks.Dto;
using ReadersAndBooks.Models;
using System.Collections.Generic;

namespace ReadersAndBooks.Services
{
    public interface IGenreService
    {
        
        /// <summary>
        /// Просмотр всех жанров. (без книг).
        /// </summary>
        /// <returns></returns>
        public List<Genre> GetGenres();

        /// <summary>
        /// Добавление нового жанра. (без книги)
        /// </summary>
        /// <param name="genre"></param>
        /// <returns></returns>
        public Genre AddGenre(Genre genre);

        /// <summary>
        /// Вывод статистики Жанр - количество книг
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public GenreDto GetGenreStatistic(int id);
    }
}
