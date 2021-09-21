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
        public async Task<Book> AddBook(BookCreateDto dto)
        {
            var book = new Book
            {
                Name = dto.Title,
                AuthorId = dto.AuthorId
            };

            var genres = await _dataContext.Genres
                .Where(g => dto.GenreIds.Contains(g.Id))
                .ToListAsync();

            book.Genres = genres;

            _dataContext.Books.Add(book);
            _dataContext.SaveChanges();

            return await _dataContext.Books
                .Include(b => b.Author)
                .Include(b => b.Genres)
                .SingleOrDefaultAsync(b => b.Id == book.Id);
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
