using ReadersAndBooks.Dto;
using System.Collections.Generic;

namespace ReadersAndBooks.Services
{
    public interface IRepository
    {
        /// <summary>
        /// Получить список всех людей
        /// </summary>
        /// <returns></returns>
        List<HumanDTO> GetHumen();

        /// <summary>
        /// Получить писателя по любому из реквизитов
        /// </summary>
        /// <param name="query"> Имя, фамилия и т.д.</param>
        /// <returns></returns>
        public List<HumanDTO> GetHuman(string query);

        /// <summary>
        /// Авторы у которых есть книги
        /// </summary>
        /// <returns></returns>
        List<HumanDTO> GetWriters();

        /// <summary>
        /// Поиск книги по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BookDTO GetBook(int id);

        /// <summary>
        /// Добавление человека
        /// </summary>
        /// <param name="human"> Добавляемый человек</param>
        void AddHuman(HumanDTO human);

        /// <summary>
        /// Удаление человека
        /// </summary>
        /// <param name="id"> Id человека, которого необходимо удалить</param>
        string DeleteHuman(int id);

        /// <summary>
        /// Получить список книг
        /// </summary>
        /// <returns></returns>
        List<BookDTO> GetBook();

        /// <summary>
        /// Получить список книг одного автора
        /// </summary>
        /// <param name="authorId"> Id автора</param>
        /// <returns></returns>
        List<BookDTO> GetBookBiAuthorId(int authorId);

        /// <summary>
        /// Добавление книги
        /// </summary>
        /// <param name="book"> Добавляемая книга</param>
        void AddBook(BookDTO book);

        /// <summary>
        /// Удалить книгу
        /// </summary>
        /// <param name="id">Id книги, которую необходимо удалить</param>
        void DeleteBook(int id);

    }
}
