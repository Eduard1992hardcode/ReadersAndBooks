using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadersAndBooks.Controllers
{
    public class GenresController : Controller
    {/*⦁	Контроллер жанры:
⦁	Просмотр всех жанров. (без книг) 
⦁	Добавление нового жанра. (без книги) 
⦁	Вывод статистики Жанр - количество книг
*/
        public IActionResult Index()
        {
            return View();
        }
    }
}
