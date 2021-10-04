/*3.1.	�������� ������ ���� ������ ������������� ���� � �������� ��������� ������ - ID ������������. ������ ������: ����� - ����� - */
SELECT person.first_name, book.name, author.first_name, author.last_name, author.middle_name, [dbo].[genre].genre_name
From person
INNER JOIN library_card ON library_card.person_id = person.id
INNER JOIN book ON library_card.book_id = book.id
INNER JOIN author ON book.author_id = author.id
INNER JOIN book_genre ON  book_genre.book_id = book.id
INNER JOIN genre ON genre.id = book_genre.genre_id


/*3.2.	�������� ������ ���� ������ (���� ����� � �� ����). ����� + ����� + �����*/
SELECT book.name, author.first_name, author.last_name, author.middle_name, genre.genre_name
FROM author
INNER JOIN book ON book.author_id = author.id
INNER JOIN book_genre on book_genre.book_id = book.id
INNER JOIN genre on genre.id = book_genre.genre_id

/*3.3.	����� ���������� ���� - ���������� ����*/
SELECT genre.genre_name, COUNT(*) book
FROM genre
LEFT JOIN book_genre ON genre.id = book_genre.genre_id
Left JOIN book ON book.id = book_genre.book_id
GROUP BY (genre.genre_name)

/*3.4.	����� ���������� ������� - ���������� ���� �� ������*/
SELECT author.first_name, author.last_name, author.middle_name,
    (SELECT Count(*)
     FROM book
     WHERE author.Id = book.author_id) AS books_count
FROM author;
