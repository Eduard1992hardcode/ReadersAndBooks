using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReadersAndBooks.Dto;
using ReadersAndBooks.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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



        public string GetHuman(string query) {
            try
            {
                string search = "Найдены записи:" + "/n";
                foreach (var h in _repositoryService.GetHuman(query)) {
                    _logger.LogInformation("Найдена запись: " + h.ToString());
                    search = h.ToString() + "/n";
                }
                return search;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string GetWriters()
        {
            try
            {
                string search = "Список людей:" + "/n";
                foreach (var h in _repositoryService.GetWriters())
                {
                   search = h.ToString() + "/n";
                }
                _logger.LogInformation("Получен список: " + search);
                return search;

            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpDelete("{id}")]
        public void DeleteHuman(int id)
        {
            _logger.LogInformation("Человек с id: " + id + " удален");
            _repositoryService.DeleteHuman(id);
        }

        public void AddHuman([FromBody] HumanDTO human)
        {
            _logger.LogInformation("Человек : " + human.Name + " " + human.Surname + " добавлен");
            _repositoryService.AddHuman(human);
        }

        public void AddBook([FromBody] BookDTO book)
        {
            _logger.LogInformation("Книга : " + book.Title + " добавленa");
            _repositoryService.AddBook(book);
        }

        [HttpDelete("{id}")]
        public void DeleteBook(int id)
        {
            _logger.LogInformation("Книга : " + _repositoryService.GetBook(id).Title + " добавленa");
            _repositoryService.DeleteBook(id);
        }

        public ActionResult<List<BookDTO>> GetBooksBiAuhorId(int id) {
           
           return _repositoryService.GetBookBiAuthorId(id);
        }

           
    }
}
