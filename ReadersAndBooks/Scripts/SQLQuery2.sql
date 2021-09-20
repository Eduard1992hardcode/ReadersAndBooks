USE [master]
GO
INSERT INTO [dbo].[person]
           ([id]
           ,[birth_date]
           ,[first_name]
           ,[last_name]
           ,[middle_name])
     VALUES
           (1,'1992-09-10', 'Эдуард','Челядинов','Игоревич'),
		   (2,'1972-12-06', 'Олег','Борисов','Семенов'),
		   (3,'1982-07-25', 'Дмитрий','Кожемякин','Виталиевич'),
		   (4,'1962-03-08', 'Роман','Головко','Сергеевич'),
		   (5,'1972-01-07', 'Виталий','Ненашев','Васильевич')
GO
INSERT INTO [dbo].[genre]
([id]
,[genre_name])
VALUES
(1,'roman'),
(2,'detective'),
(3,'triller'),
(4,'horror'),
(5,'fantasy')
GO
INSERT INTO [dbo].[author]
([id]
,[first_name]
,[last_name]
,[middle_name])
Values
(1,'Эрих','Мария ','Ремарк' ),
(2,'Джордж','','О́руэлл'),
(3,'Виктор','','ГЮГО')
GO
INSERT INTO [dbo].[book]
([id]
,[name]
,[author_id])
VALUES
(1,'Три товарища',1),
(2, 'Триумфальная арка',1),
(3,'1984',2),
(4,'Скотный двор',2),
(5,'Воспоминания книготворца',2),
(6,'Gavroche',3),
(7,'Девяносто третий год',3),
(8,'Отверженные',3)
GO
INSERT INTO [dbo].[book_genre]
([book_id]
,[genre_id])
VALUES
(1,1),
(1,2),
(2,1),
(2,6),
(3,5),
(3,4),
(7,1),
(4,4)
GO

INSERT INTO [dbo].[library_card]
([book_id]
,[person_id])
VALUES
(1,1),
(2,4),
(3,2),
(4,1),
(5,2),
(6,4),
(7,3),
(8,4)
GO