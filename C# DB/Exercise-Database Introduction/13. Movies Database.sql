CREATE DATABASE Movies

USE Movies

CREATE TABLE Directors
(
	Id INT PRIMARY KEY NOT NULL,
	DirectorName NVARCHAR(20) NOT NULL,
	Notes NVARCHAR(MAX),
)
CREATE TABLE Genres
(
	Id INT PRIMARY KEY NOT NULL,
	GenreName NVARCHAR(20) NOT NULL,
	Notes NVARCHAR(MAX),
)
CREATE TABLE Categories 
(
	Id INT PRIMARY KEY NOT NULL,
	CategoryName NVARCHAR(20) NOT NULL,
	Notes NVARCHAR(MAX),
)
CREATE TABLE Movies  
(
	Id INT PRIMARY KEY NOT NULL,
	Title NVARCHAR(20) NOT NULL,
	DirectorId INT NOT NULL,
	CopyrightYear DATE NOT NULL,
	[Length] DECIMAL(15,2) NOT NULL,
	GenreId INT NOT NULL,
	CategoryId INT NOT NULL,
	Rating DECIMAL(15,2) NOT NULL,
	Notes NVARCHAR(MAX),
)

INSERT INTO Directors VALUES
(1,'Miroslav',NULL),
(2,'Kiko',NULL),
(3,'Petur',NULL),
(4,'Ivan',NULL),
(5,'Gogi',NULL)

INSERT INTO Genres VALUES
(1,'Horror',NULL),
(2,'Action',NULL),
(3,'Hentai',NULL),
(4,'Comedy',NULL),
(5,'Romance',NULL)

INSERT INTO Categories VALUES
(1,'Europian',NULL),
(2,'Asia',NULL),
(3,'18+',NULL),
(4,'B-Rated',NULL),
(5,'American',NULL)

INSERT INTO Movies VALUES
(1,'Harry Potter',1,'2006',60.30,1,1,10,NULL),
(2,'Armagedon',2,'2008',60.30,1,1,10,NULL),
(3,'Kinuci Yamate',3,'2021',60.30,1,1,10,NULL),
(4,'Hangover',4,'2012',60.30,1,1,10,NULL),
(5,'War Dogs',5,'2018',60.30,1,1,10,NULL)
