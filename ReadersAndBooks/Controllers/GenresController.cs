using Microsoft.AspNetCore.Mvc;
using ReadersAndBooks.Models;
using ReadersAndBooks.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadersAndBooks.Controllers
{
    public class GenresController : Controller
    {/*⦁	Контроллер жанры:
⦁	Просмотр всех жанров. (без книг) 
⦁	Добавление нового жанра. (без книги) 
⦁	Вывод статистики Жанр - количество книг
*/
        private readonly IGenreService _genreService;

        public GenresController(IGenreService genreService)
        { _genreService = genreService; }

        [HttpGet("api/getGenres")]
        public IActionResult GetGenres()
        {
            
            var search = new StringBuilder("Найдены книги: " + "\n");
            foreach (var genre in _genreService.GetGenres())
                search.AppendLine(genre.ToString());

            return Ok(search.ToString());
        }

        [HttpPost("api/addGenre")]
        public IActionResult AddGenre(Genre genre)
        {
            _genreService.AddGenre(genre);
            return Ok();
        }

        [HttpGet("api/getGenreStatistic")]
        public IActionResult GetStatisticGenre(int id)
        {
            return Ok(_genreService.GetGenreStatistic(id));
        }
    }
}
