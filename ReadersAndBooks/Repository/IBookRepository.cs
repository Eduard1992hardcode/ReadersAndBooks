using ReadersAndBooks.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReadersAndBooks.Repository
{
    public interface IBookRepository
    {
        public Task<Book> AddBook(Book book);
        public List<Book> GetBookByAuthor(int authorId);
        public List<Book> GetBooksByGenre(int genreId);
        public Book UpdateBook(Book book);
        public void DeleteBook(int id)
    }
}
