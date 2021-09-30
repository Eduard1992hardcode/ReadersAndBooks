using ReadersAndBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
