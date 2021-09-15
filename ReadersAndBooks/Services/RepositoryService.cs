using Microsoft.Extensions.Logging;
using ReadersAndBooks.Dto;
using System.Collections.Generic;
using System.Linq;

namespace ReadersAndBooks.Services
{
    public class RepositoryService : IRepository
    {
        private readonly List<HumanDTO> _humen;
        private readonly List<BookDTO> _books;
        private readonly ILogger<RepositoryService> _logger;

        public RepositoryService(ILogger<RepositoryService> logger)
        {
            _logger = logger;
            _books = MuteDb.GetBooks();
            _humen = MuteDb.GetHumen();

        }


        public void AddBook(BookDTO book)
        {
            _logger.LogInformation("Книга : " + book.Title + " добавленa");
            _books.Add(book);
        }

        public void AddHuman(HumanDTO human)
        {
            _logger.LogInformation("Человек : " + human.Name + " " + human.Surname + " добавлен");
            _humen.Add(human);
        }

        public void DeleteBook(int id)
        {
            if (GetBook(id).Equals(null))
            {
                _logger.LogInformation("Книга с Id: " + id + " не найдена");

            }
            else
            {
                var book = _books
                    .Where(x => x.Id == id).FirstOrDefault();

                _books.Remove(book);
            }
        }

        public string DeleteHuman(int id)
        {
            var human = _humen.
                Where(x => x.Id == id).FirstOrDefault();
            if (human.Equals(null))
            {
                _logger.LogInformation("Человек с id: " + id + " не найден");
                return null;
            }
            _logger.LogInformation("Человек с id: " + id + " удален");
            _humen.Remove(human);
            return "+";
        }

        public List<BookDTO> GetBook()
        {
            return _books;
        }

        public BookDTO GetBook(int id)
        {
            return _books
                .Where(x => x.Id == id).FirstOrDefault();
        }

        public List<BookDTO> GetBookBiAuthorId(int authorId)
        {
            var books = _books
                .Where(x => x.AuthorId == authorId).ToList(); ;
            return books;
        }

        public List<HumanDTO> GetHumen()
        {
            return _humen;
        }

        public List<HumanDTO> GetWriters()
        {
            var authorsId = _books.Select(o => o.AuthorId).Distinct().ToList();
            var writes = _humen
                .Where(a => authorsId.Contains(a.Id)).ToList();
            _logger.LogInformation($"Получен список: {writes}");
            return writes;
        }
        public List<HumanDTO> GetHuman(string query)
        {
            return _humen
                .Where(x => x.Name.Contains(query)
                || x.Surname.Contains(query)
                ||
         x.Patronymic.Contains(query)).ToList();
        }
        public List<BookDTO> GetBooksBiQuery(string query)
        {
            return _books
                .Where(x => x.Author.Contains(query)
                || x.Genre.Contains(query)
                ||
         x.Title.Contains(query)).ToList();
        }
    }
}