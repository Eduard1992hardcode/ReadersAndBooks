using Microsoft.AspNetCore.Mvc;
using ReadersAndBooks.Dto;
using ReadersAndBooks.Models;
using ReadersAndBooks.Services;
using System.Text;
using System.Threading.Tasks;

namespace ReadersAndBooks.Controllers
{
    
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        { 
            _bookService = bookService;
        }

        [HttpPost("api/addBook")]
        public async Task<Book> AddBook(BookCreateDto book)
        {
            return await _bookService.AddBook(book);
        }

        [HttpDelete("api/deleteBook")]
        public IActionResult DeleteBook(int id)
        {
            _bookService.DeleteBook(id);
            return Ok();
        }

        [HttpGet("api/getBookByAuthor")]
        public IActionResult GetBookByAuthor(int authorId)
        {
            var search = new StringBuilder("Найдены книги: " + "\n");
            foreach (var book in _bookService.GetBookByAuthor(authorId))
                search.AppendLine(book.ToString());
            return Ok(search.ToString());
        }

        [HttpGet("api/getBooksByGenre")]
        public IActionResult GetBooksByGenre(int genreId)
        {
            var search = new StringBuilder("Найдены книги: " + "\n");
            foreach (var book in _bookService.GetBooksByGenre(genreId))
                search.AppendLine(book.ToString());
            return Ok(search.ToString());
        }

        [HttpPut("api/updateBook")]
        public IActionResult UpdateBook(BookDto book)
        {
            _bookService.UpdateBook(book);
            return Ok(book);
        }
    }
}
