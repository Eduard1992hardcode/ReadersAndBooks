using ReadersAndBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public Genre GetGenreStatistic(int id);
    }
}
