using Microsoft.AspNetCore.Mvc;
using ReadersAndBooks.Dto;
using ReadersAndBooks.Services;
using System.Collections.Generic;
using System.Text;

namespace ReadersAndBooks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepositoryController : ControllerBase
    {
        private readonly IRepository _repositoryService;

        public RepositoryController(IRepository repositoryService)
        {
            _repositoryService = repositoryService;
        }


        [HttpGet("api/getHuman")]
        public IActionResult GetHuman()
        {
            var search = new StringBuilder("Найдены авторы: " + "\n");
            foreach (var humen in _repositoryService.GetHumen())
                search.AppendLine(humen.ToString());

            return Ok(search.ToString());
        }

        [HttpGet("api/getWriters")]
        public IActionResult GetWriters()
        {
            var result = new StringBuilder("Список людей:" + "\n");
            foreach (var humen in _repositoryService.GetWriters())
                result.AppendLine(humen.ToString());

            return Ok(result.ToString());
        }

        [HttpPut("api/delHuman")]
        public IActionResult DeleteHuman(int id)
        {

            if (_repositoryService.DeleteHuman(id).Equals(null))
                return BadRequest("Запись с Id: " + id + " не найдена.");

            return Ok("Человек : " + id + " удален");
        }

        [HttpPost("api/addHuman")]
        public IActionResult AddHuman([FromBody] HumanDTO human)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            _repositoryService.AddHuman(human);
            return Ok("Человек : " + human.Name + " " + human.Surname + " добавлен");
        }

        [HttpPost("api/addBook")]
        public IActionResult AddBook([FromBody] BookDTO book)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            _repositoryService.AddBook(book);
            return Ok("Книга : " + book.Title + " добавленa");
        }

        [HttpPut("api/delBook")]
        public IActionResult DeleteBook(int id)
        {
            if (_repositoryService.GetBook(id).Equals(null))
                return BadRequest("Книги с Id: " + id + " нет в списке");

            _repositoryService.DeleteBook(id);
            return Ok("Книга : " + _repositoryService.GetBook(id).Title + " удалена");

        }

        [HttpGet("api/bookBiAuhorId")]
        public ActionResult<List<BookDTO>> GetBooksBiAuhorId(int id)
        {
            if (_repositoryService.GetBookBiAuthorId(id).Count == 0)
                return BadRequest("Книги не найдены");

            return _repositoryService.GetBookBiAuthorId(id);
        }

        [HttpGet("api/getBookBiQuery")]
        public IActionResult GetBookBiQuery(string query)
        {
            var search = new StringBuilder("Найдены книги:" + "\n");
            foreach (var books in _repositoryService.GetBooksBiQuery(query))
            {
                search.AppendLine(books.ToString());
            }
            return Ok(search.ToString());
        }


    }
}