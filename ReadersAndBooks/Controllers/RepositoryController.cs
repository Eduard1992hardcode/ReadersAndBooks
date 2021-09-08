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
        private readonly ILogger<RepositoryController> _logger;

        public RepositoryController(IRepository repositoryService, ILogger<RepositoryController> logger)
        {
            _repositoryService = repositoryService;
            _logger = logger;
        }


        [Route("api/getHuman")]
        public IActionResult GetHuman(string query) {
            try
            {
                var search = new StringBuilder("Найдены авторы:" + "/n");
                foreach (var humen in _repositoryService.GetWriters())
                {
                    _logger.LogInformation($"Получен список: {humen}");
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
                    _logger.LogInformation($"Получен список: {humen}");
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
        public void DeleteHuman(int id)
        {
            _logger.LogInformation("Человек с id: " + id + " удален");
            _repositoryService.DeleteHuman(id);
        }

        [Route("api/addHuman")]
        public void AddHuman([FromBody] HumanDTO human)
        {
            _logger.LogInformation("Человек : " + human.Name + " " + human.Surname + " добавлен");
            _repositoryService.AddHuman(human);
        }

        [Route("api/addBook")]
        public void AddBook([FromBody] BookDTO book)
        {
            _logger.LogInformation("Книга : " + book.Title + " добавленa");
            _repositoryService.AddBook(book);
        }
        [Route("api/delBook")]
        [HttpDelete("{id}")]
        public void DeleteBook(int id)
        {
            _logger.LogInformation("Книга : " + _repositoryService.GetBook(id).Title + " добавленa");
            _repositoryService.DeleteBook(id);
        }

        [Route("api/bookBiAuhorId")]
        [HttpGet("{id}")]
        public ActionResult<List<BookDTO>> GetBooksBiAuhorId(int id) {
            _logger.LogInformation("Получен список книг состоящий из " + _repositoryService.GetBookBiAuthorId(id).Count + " книг");
            return _repositoryService.GetBookBiAuthorId(id);
        }

           
    }
}
