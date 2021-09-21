using ReadersAndBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadersAndBooks.Services
{
    public interface IPersonService
    {
        /// <summary>
        /// Добавление пользователя
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public Person AddPerson(Person person);

        /// <summary>
        /// Изменение пользователя
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public Person UpdatePerson(Person person);

        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <param name="id"> айди удаляемого пользователя</param>
        public bool DeletePerson(int id);

        /// <summary>
        /// Удаление пользователя по ФИО
        /// </summary>
        /// <param name="query">ФИО</param>
        public void DeletePerson(string query);

        /// <summary>
        /// Получение списка книг, взятых пользователем.
        /// </summary>
        /// <param name="id"> айди пользователя</param>
        /// <returns></returns>
        public Task<Person> GetUsersBooks(int id);

        /// <summary>
        /// Добавление книги в список используемых пользователем.
        /// </summary>
        /// <param name="bookId"> айди книги</param>
        /// <param name="PersonId"> айди пользователя</param>
        /// <returns></returns>
        public Book AddUseBook(int bookId, int personId);

        /// <summary>
        /// Удаление книги из списка используемых пользователем.
        /// </summary>
        /// <param name="bookId"> айди книги</param>
        /// <param name="PersonId"> айди пользователя</param>
        /// <returns></returns>
        public Book DelUseBook(int bookId, int personId);
    }
}
