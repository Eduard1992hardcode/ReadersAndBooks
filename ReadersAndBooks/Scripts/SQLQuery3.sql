/*3.1.	Получить список всех взятых пользователем книг в качестве параметра поиска - ID пользователя. Полное дерево: Книги - автор - */
SELECT person.first_name, book.name, author.first_name, author.last_name, author.middle_name, [dbo].[genre].genre_name
From person
INNER JOIN library_card ON library_card.person_id = person.id
INNER JOIN book ON library_card.book_id = book.id
INNER JOIN author ON book.author_id = author.id
INNER JOIN book_genre ON  book_genre.book_id = book.id
INNER JOIN genre ON genre.id = book_genre.genre_id


/*3.2.	Получить список книг автора (книг может и не быть). автор + книги + жанры*/
SELECT book.name, author.first_name, author.last_name, author.middle_name, genre.genre_name
FROM author
INNER JOIN book ON book.author_id = author.id
INNER JOIN book_genre on book_genre.book_id = book.id
INNER JOIN genre on genre.id = book_genre.genre_id

/*3.3.	Вывод статистики Жанр - количество книг*/
SELECT genre.genre_name, COUNT(*) book
FROM genre
LEFT JOIN book_genre ON genre.id = book_genre.genre_id
Left JOIN book ON book.id = book_genre.book_id
GROUP BY (genre.genre_name)

/*3.4.	Вывод статистики Авторов - количество книг по жанрам*/
SELECT author.first_name, author.last_name, author.middle_name,
    (SELECT Count(*)
     FROM book
     WHERE author.Id = book.author_id) AS books_count
FROM author;
