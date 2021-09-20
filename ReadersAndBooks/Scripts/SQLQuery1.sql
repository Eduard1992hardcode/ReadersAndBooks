
create table genre
(
 id integer not null  primary key,
 genre_name varchar(64) not null
);
create table author
(
 id integer not null  primary key,
 first_name varchar(64) not null,
 last_name varchar(64) not null,
 middle_name varchar(64) not null
);
create table book
(
 id integer not null  primary key,
 name varchar(64) not null,
 author_id integer foreign key references dbo.author(id),
);
create table book_genre
(
book_id integer foreign key references dbo.book(id),
genre_id integer foreign key references dbo.genre(id),
);
create table person
(
id integer not null primary key,
birth_date date,
first_name varchar(64) not null,
 last_name varchar(64) not null,
 middle_name varchar(64) not null
);
create table library_card
(
book_id integer foreign key references dbo.book(id),
person_id integer foreign key references dbo.person(id)
);