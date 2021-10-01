using Moq;
using ReadersAndBooks.Controllers;
using ReadersAndBooks.Dto;
using ReadersAndBooks.Models;
using ReadersAndBooks.Repository;
using ReadersAndBooks.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;


namespace ReadersAndBooks.Tests.Sevices
{
    public class BookServiceTests
    {
        private readonly Mock<IBookRepository> _mockBookRepository;
        private readonly Mock<IGenreRepository> _mockGenreRepository;

        public BookServiceTests()
        {
            _mockBookRepository = new Mock<IBookRepository>();
            _mockGenreRepository = new Mock<IGenreRepository>();
        }


        [Fact]
        public void AddBook_WithExistBookDto_ShouldReturn_BookAsync()
        {
            //arrange
            var bookDto = new BookCreateDto {Title = "War and Peace", AuthorId = 1 };
            var book = new Book {Id = 1, Name = "War and Peace", AuthorId = 1 };
            _mockBookRepository.Setup(a => a.AddBook(book)).Returns(Task.FromResult(new Book()));
            
            //act
            var service = new BookService(_mockGenreRepository.Object, _mockBookRepository.Object);
            service.AddBook(bookDto);
            var bookRes = service.GetBook(book.Id);
            var result = service.GetBook(book.Id);
            //assert
            Assert.IsType<Book>(result);
        }
        

    }
}
