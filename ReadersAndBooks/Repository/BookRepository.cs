using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ReadersAndBooks.Data;
using ReadersAndBooks.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadersAndBooks.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _dataContext;
        private readonly ILogger<BookRepository> _logger;

        public BookRepository(DataContext dataContext,
            ILogger<BookRepository> logger)
        {
            _dataContext = dataContext;
            _logger = logger;
        }
        public  Book AddBook(Book book)
        {
           
            _dataContext.Books.Add(book);
            _dataContext.SaveChanges();

            return  _dataContext.Books
                .Include(b => b.Author)
                .Include(b => b.Genres)
                .SingleOrDefault(b => b.Id == book.Id);
        }

        public List<Book> GetBookByAuthor(int authorId)
        {
            return _dataContext.Books
                .Include(b => b.Author)
                .Include(b => b.Genres)
                .Where(b => b.AuthorId == authorId).ToList();
        }
        public List<Book> GetBooksByGenre(int genreId)
        {
            var genre = _dataContext.Genres.Find(genreId);
            return _dataContext.Books
                .Include(b => b.Author)
                .Include(b => b.Genres)
                .Where(b => b.Genres.Contains(genre)).ToList();
        }
        public Book UpdateBook(Book book)
        {
            var removeBook = _dataContext.Books.Find(book.Id);
            _dataContext.Books.Remove(removeBook);
            _dataContext.Books.Add(book);
            _dataContext.SaveChanges();
            return _dataContext.Books
                .Include(b => b.Author)
                .Include(b => b.Genres)
                .SingleOrDefault(b => b.Id == book.Id);
        }
        public void DeleteBook(int id)
        {
            var libraryCard = _dataContext.LibraryCards.Where(l => l.BookId == id).FirstOrDefault();
            if (libraryCard.Equals(null))
            {
                var book = _dataContext.Books.Find(id);
                _dataContext.Books.Remove(book);
                _dataContext.SaveChanges();
            }
            else _logger.LogInformation("Книга недоступна для удаления");
        }
        public Book GetBook(int id)
        {
            return _dataContext.Books.Find(id);
        }
    }
}
