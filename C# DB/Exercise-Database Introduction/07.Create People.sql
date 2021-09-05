CREATE TABLE People
(
	[Id] INT  PRIMARY KEY NOT NULL,
	[Name] NVARCHAR (200) NOT NULL,
	[Picture] VARBINARY (2),
	[Hight] DECIMAL (18,2),
	[Weight] DECIMAL (18,2),
	[Gender] CHAR(1) NOT NULL,
	[Birthdate] DATE NOT NULL,
	[Biography] NVARCHAR (MAX)
)

SELECT * FROM People

INSERT INTO People
VALUES
(1,'Miroslav',NULL,182,83,'m','1997-jan-06','Programmer and musican'),
(2,'Kiko',NULL,177,81,'m','1989-jul-06','The Best!'),
(3,'Fiki',NULL,188,76,'m','1997-oct-06','Musican'),
(4,'Azis',NULL,NULL,NULL,'f','1977-jan-06','The Best Singer'),
(5,'Mimi',NULL,NULL,NULL,'f','1987-jan-06','The Best Singer')


SELECT * FROM People