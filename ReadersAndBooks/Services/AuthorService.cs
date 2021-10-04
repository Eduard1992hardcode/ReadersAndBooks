using Microsoft.Extensions.Logging;
using ReadersAndBooks.Data;
using ReadersAndBooks.Models;
using System.Collections.Generic;
using System.Linq;

namespace ReadersAndBooks.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly DataContext _dataContext;
        private readonly ILogger<AuthorService> _logger;

        public AuthorService(DataContext dataContext, ILogger<AuthorService> logger)
        {
            _dataContext = dataContext;
            _logger = logger;
        }


        public Author AddAuthor(Author author)
        {
            _dataContext.Authors.Add(author);
            _dataContext.SaveChanges();
            author.Books = _dataContext
                .Books.Where(b => b.AuthorId == author.Id).ToList();
            return author;
        }

        public void DeleteAuthor(int id)
        {
            var author = _dataContext.Authors.Find(id);
            if (author.Equals(null)) { }
            _dataContext.Authors.Remove(author);
            _dataContext.SaveChanges();
        }

        public List<Author> GetAuthors()
        {
            return _dataContext.Authors.ToList();
        }
    }
}
