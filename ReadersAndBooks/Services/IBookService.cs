using ReadersAndBooks.Dto;
using ReadersAndBooks.Models;
using System.Collections.Generic;

namespace ReadersAndBooks.Services
{
    public interface IBookService
    {

        /// <summary>
        /// Добавление (POST) (вместе с автором и жанром) книга + автор + жанр
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public Book AddBook(BookCreateDto dto);
        /// <summary>
        /// Книга может быть удалена из списка библиотеки (но только если она не у пользователя) по ID (ок, или ошибка, что книга у пользователя)
        /// </summary>
        /// <param name="id"></param>
        public void DeleteBook(int id);

        /// <summary>
        /// Книге можно присвоить новый жанр, или удалить один из имеющихся (PUT с телом.На вход сущность Book или её Dto) При добавлении или удалении вы должны просто либо добавлять запись, либо удалять из списка жанров. Каскадно удалять все жанры и книги с таким жанром нельзя! Книга + жанр + автор
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public Book UpdateBook(BookDto dto);

        /// <summary>
        /// Можно получить список всех книг с фильтром по автору (По любой комбинации трёх полей сущности автор. Имеется  ввиду условие equals + and )
        /// </summary>
        /// <returns></returns>
        public List<Book> GetBookByAuthor(int authorId);

        /// <summary>
        /// Можно получить список книг по жанру. Книга + жанр + автор.
        /// </summary>
        /// <param name="genreId"></param>
        /// <returns></returns>
        public List<Book> GetBooksByGenre(int genreId);

        public Book GetBook(int id);
    }
}
