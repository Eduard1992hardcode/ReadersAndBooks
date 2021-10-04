using Moq;
using ReadersAndBooks.Dto;
using ReadersAndBooks.Models;
using ReadersAndBooks.Repository;
using ReadersAndBooks.Services;
using System.Collections.Generic;
using Xunit;


namespace ReadersAndBooks.Tests.Sevices
{
    public class BookServiceTests
    {
        private readonly Mock<IBookRepository> _mockBookRepository;
        private readonly Mock<IGenreRepository> _mockGenreRepository;
        private readonly Mock<BookService> _mockBookService;

        public BookServiceTests()
        {
            _mockBookRepository = new Mock<IBookRepository>();
            _mockGenreRepository = new Mock<IGenreRepository>();
            _mockBookService = new Mock<BookService>(_mockGenreRepository.Object, _mockBookRepository.Object);
        }

        [Fact]
        public void GetBookByAuthor_ActionExecutes_ReturnsBooksList()
        {
            //arrange
            var books = new List<Book>(){
            new Book {Name = "War and Peace", AuthorId = 1},
            new Book {Name = "A Hunter's Sketches", AuthorId = 2} };

            _mockBookRepository.Setup(r => r.GetBookByAuthor(1)).Returns(books);
            //act
            var result = _mockBookService.Object.GetBookByAuthor(1);
            //assert
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void GetBookByGenre_ActionExecutes_ReturnsBooksList()
        {
            //arrange
            var books = new List<Book>(){
            new Book {Name = "War and Peace", AuthorId = 1},
            new Book {Name = "A Hunter's Sketches", AuthorId = 2} };

            _mockBookRepository.Setup(r => r.GetBooksByGenre(1)).Returns(books);
            //act
            var result = _mockBookService.Object.GetBooksByGenre(1);
            //assert
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void CreateBook_ActionExecutes_ReturnsBook()
        {
            //arrange
            var bookDto = new BookCreateDto { Title = "War and Peace", AuthorId = 1 };
            var book = _mockBookService.Object.AddBook(bookDto);
            _mockBookRepository.Setup(r => r.AddBook(book)).Returns(book);
            //act
            var result = _mockBookRepository.Object.AddBook(book);
            //assert
            Assert.Equal(book, result);
        }

        [Fact]
        public void UpdateBook_ActionExecutes_ReturnsBook()
        {
            //arrange
            var bookDto = new BookCreateDto { Title = "War and Peace", AuthorId = 1 };
            var book = _mockBookService.Object.AddBook(bookDto);
            _mockBookRepository.Setup(r => r.AddBook(book)).Returns(book);
            //act
            var result = _mockBookRepository.Object.UpdateBook(book);
            //assert
            Assert.Equal(book, result);
        }
    }
}