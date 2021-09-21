using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadersAndBooks.Controllers
{
    public class AuthorsController : Controller
    {/*⦁	Контроллер авторы:
⦁	Можно получить список всех авторов. (без книг, как и везде, где не указано обратное)
⦁	Можно получить список книг автора (книг может и не быть). автор + книги + жанры
⦁	Добавить автора (с книгами или без) ответ - автор + книги
⦁	Удалить автора (если только нет книг, иначе кидать ошибку с пояснением, что нельзя удалить автора пока есть его книги) - Ок или Ошибка*/
        public IActionResult Index()
        {
            return View();
        }
    }
}
