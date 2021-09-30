using Microsoft.Extensions.Logging;
using ReadersAndBooks.Dto;
using ReadersAndBooks.Models;
using ReadersAndBooks.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReadersAndBooks.Services
{
    public class BookService : IBookService
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IBookRepository _bookRepository;

        public BookService(ILogger<BookService> logger,
            IGenreRepository genreRepository,
            IBookRepository bookRepository)
        {
            _genreRepository = genreRepository;
            _bookRepository = bookRepository;
        }
        public async Task<Book> AddBook(BookCreateDto dto)
        {
            var book = new Book
            {
                Name = dto.Title,
                AuthorId = dto.AuthorId
            };
            
            book.Genres = _genreRepository.Genres(dto.GenreIds);
            return await _bookRepository.AddBook(book);
        }

        public void DeleteBook(int id)
        {
            _bookRepository.DeleteBook(id);
        }

        public  List<Book> GetBookByAuthor(int authorId)
        {
            return _bookRepository.GetBookByAuthor(authorId);
        }

        public List<Book> GetBooksByGenre(int genreId)
        {
            return _bookRepository.GetBooksByGenre(genreId);
        }

        public Book UpdateBook(BookDto dto)
        {
            var book = new Book
            {
                Name = dto.Title,
                AuthorId = dto.AuthorId
            };
            return _bookRepository.UpdateBook(book);
        }
    }
}
