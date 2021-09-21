using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ReadersAndBooks.Data;
using ReadersAndBooks.Dto;
using ReadersAndBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadersAndBooks.Services
{
    public class BookService : IBookService
    {
        private readonly DataContext _dataContext;
        private readonly ILogger<BookService> _logger;

        public BookService(DataContext dataContext, ILogger<BookService> logger)
        {
            _dataContext = dataContext;
            _logger = logger;
        }
        public async Task<BookDTO> AddBook(BookCreateDto dto)
        {
            var book = new Book
            {
                Name = dto.Title,
                AuthorId = dto.AuthorId
            };

            var genres = new List<BookGenre>();

            foreach (var id in dto.GenreIds)
                genres.Add(new BookGenre { GenreId = id });

            book.Genres = genres;

            _dataContext.Books.Add(book);
            _dataContext.SaveChanges();

            var book = await _dataContext.Books
                .Include(b => b.Author)
                .Include(b => b.Genres).ThenInclude(bg => bg.Genre) /// подгружаем данные о жанрах 
                .FirstOrDefaultAsync(b => b.Id == book.Id);

            return new BookDTO
            {
                Author = book.Author.ToString(),
                Genres = book.Genres.Select(bg => bg.Genre.Name),
                Title = book.Title
            };
        }

        public void DeleteBook(int id)
        {
            var libraryCard = _dataContext.LibraryCards.Where(l => l.BookId == id).FirstOrDefault();
            if (libraryCard.Equals(null)) {
                var book =_dataContext.Books.Find(id);
                _dataContext.Books.Remove(book);
                _dataContext.SaveChanges();
            }
        }

        public List<Book> GetBookByAuthor(int authorId)
        {
            return _dataContext.Books.Where(b => b.AuthorId == authorId).ToList();
        }

        public List<Book> GetBooksByGenre(int genreId)
        {
            throw new NotImplementedException();
        }

        public Book UpdateBook(Book book)
        {
            var removeBook = _dataContext.Books.Find(book.Id);
            _dataContext.Books.Remove(removeBook);
            _dataContext.Books.Add(book);
        }
    }
}
