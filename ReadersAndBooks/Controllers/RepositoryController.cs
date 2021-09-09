using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReadersAndBooks.Dto;
using ReadersAndBooks.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadersAndBooks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepositoryController : Controller
    {
        private readonly IRepository _repositoryService;
        
        public RepositoryController(IRepository repositoryService)
        {
            _repositoryService = repositoryService;
        }


        [Route("api/getHuman")]
        public IActionResult GetHuman(string query) {
            try
            {
                var search = new StringBuilder("Найдены авторы:" + "/n");
                foreach (var humen in _repositoryService.GetWriters())
                {
                    search.AppendLine(humen.ToString());
                }
                return Ok(search.ToString());

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [Route("api/getWriters")]
        public IActionResult GetWriters()
        {
            try
            {
                var result = new StringBuilder("Список людей:" + "/n");

                foreach (var humen in _repositoryService.GetWriters())
                {
                    result.AppendLine(humen.ToString()); 
                }
                return Ok(result.ToString());

            }
            catch (Exception e)
            {
              return BadRequest(e.Message);
            }

        }

        [Route("api/delHuman")]
        [HttpDelete("{id}")]
        public IActionResult DeleteHuman(int id)
        {

            if (_repositoryService.DeleteHuman(id).Equals(null))
                return BadRequest("Запись с Id: " + id + " не найдена.");

            return Ok("Человек : " + id + " удален");
        }

        [Route("api/addHuman")]
        public IActionResult AddHuman([FromBody] HumanDTO human)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            _repositoryService.AddHuman(human);
            return Ok("Человек : " + human.Name + " " + human.Surname + " добавлен");
        }

        [Route("api/addBook")]
        public IActionResult AddBook([FromBody] BookDTO book)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            _repositoryService.AddBook(book);
            return Ok("Книга : " + book.Title + " добавленa");
        }
        [Route("api/delBook")]
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            if (_repositoryService.GetBook(id).Equals(null))
                return BadRequest("Книги с Id: " + id + " нет в списке");
            
            _repositoryService.DeleteBook(id);
            return Ok("Книга : " + _repositoryService.GetBook(id).Title + " удалена");
            
        }

        [Route("api/bookBiAuhorId")]
        [HttpGet("{id}")]
        public ActionResult<List<BookDTO>> GetBooksBiAuhorId(int id) {
            if (_repositoryService.GetBookBiAuthorId(id).Count == 0)
                return BadRequest("Книги не найдены");
            
            return _repositoryService.GetBookBiAuthorId(id);
        }

        [Route("api/getBookBiQuery")]
        public IActionResult GetBookBiQuery(string query)
        {
            try
            {
                var search = new StringBuilder("Найдены книги:" + "/n");
                foreach (var books in _repositoryService.GetBooksBiQuery(query))
                {
                    search.AppendLine(books.ToString());
                }
                return Ok(search.ToString());

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


    }
}
