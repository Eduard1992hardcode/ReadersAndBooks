using Moq;
using ReadersAndBooks.Models;
using ReadersAndBooks.Repository;
using ReadersAndBooks.Services;
using System.Collections.Generic;
using Xunit;

namespace ReadersAndBooks.Tests.Sevices
{
    public class BookServiceTests
    {
        [Fact]
        public void GetBook_WithExistBook_ShouldReturn_Book()
        {
            //arrange
            var book = new Book {  };
            var books = new List<Book> { book };

            var userRepositoryMock = new Mock<IBookRepository>();

            userRepositoryMock.Setup(r => r.GetBooksByGenre()).Returns(books);

            var service = new BookService(userRepositoryMock.Object);

            //act
            var result = service.GetBook(user.Id);

            //assert
            Assert.Equal(book, result);
        }


    }
}
