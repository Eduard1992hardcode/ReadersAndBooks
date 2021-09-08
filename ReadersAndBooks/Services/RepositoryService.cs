using ReadersAndBooks.Dto;
using System.Collections.Generic;
using System.Linq;

namespace ReadersAndBooks.Services
{
    public class RepositoryService : IRepository
    {
        private List<HumanDTO> _humen;
        private List<BookDTO> _books;

        public RepositoryService() {

            _books = MuteDb.GetBooks();
            _humen = MuteDb.GetHumen();

        }


        public void AddBook(BookDTO book)
        {
            _books.Add(book);
        }

        public void AddHuman(HumanDTO human)
        {
            _humen.Add(human);
        }

        public void DeleteBook(int id)
        {
            var book = _books
                .Where(x => x.Id == id).FirstOrDefault();
            _books.Remove(book);
        }

        public void DeleteHuman(int id)
        {
            var human = _humen.
                Where(x => x.Id == id).FirstOrDefault();
            _humen.Remove(human);
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
            var books =  _books
                .Where(x => x.AuthorId == authorId).ToList(); ;
            return books;
        }

        public List<HumanDTO> GetHumen()
        {
            return _humen;
        }

        public List<HumanDTO> GetWriters()
        {
           var writes = _humen
               .Where(x => x.Books.Any())
               .ToList();
            return writes;
        }
        public List<HumanDTO> GetHuman(string query) {
            return _humen
                .Where(x => x.Name.Contains(query)
                || x.Surname.Contains(query)
                ||
         x.Patronymic.Contains(query)).ToList();
        }
    }
}
