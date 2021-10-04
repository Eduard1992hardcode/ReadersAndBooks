using ReadersAndBooks.Models;
using System.Collections.Generic;

namespace ReadersAndBooks.Services
{
    public interface IAuthorService
    {
     
        /// <summary>
        /// Можно получить список всех авторов. (без книг, как и везде, где не указано обратное)
        /// </summary>
        /// <returns></returns>
        public List<Author> GetAuthors();

        /// <summary>
        /// Добавить автора (с книгами или без) ответ - автор + книги
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        public Author AddAuthor(Author author);

        /// <summary>
        /// Удалить автора (если только нет книг, иначе кидать ошибку с пояснением, что нельзя удалить автора пока есть его книги) - Ок или Ошибка
        /// </summary>
        /// <param name="id"></param>
        public void DeleteAuthor(int id);
    }
}
