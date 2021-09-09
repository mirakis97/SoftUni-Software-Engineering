CREATE DATABASE Hotel

USE Hotel

--Employes
CREATE TABLE Emlpoyees
(
	Id INT PRIMARY KEY,
	FirstName VARCHAR(90) NOT NULL,
	LastName VARCHAR(90) NOT NULL,
	Title VARCHAR(50) NOT NULL,
	Notes VARCHAR(MAX)
)

--Customers
CREATE TABLE Customers
(
	AccountNumber INT PRIMARY KEY,
	FirstName VARCHAR(90) NOT NULL,
	LastName VARCHAR(90) NOT NULL,
	PhoneName CHAR(10) NOT NULL,
	EmergencyName VARCHAR(90) NOT NULL,
	EmergencyNumber CHAR(10) NOT NULL,
	Notes VARCHAR(MAX)
)

--RoomStatus

CREATE TABLE RoomStatus
(
	RoomStatus BIT NOT NULL,
	Notes VARCHAR(MAX)
)

--RoomType

CREATE TABLE RoomTypes
(
	RoomType VARCHAR(20) NOT NULL,
	Notes VARCHAR(MAX)
)

--BedTypes

CREATE TABLE BedTypes
(
	BedTypes VARCHAR(20) NOT NULL,
	Notes VARCHAR(MAX)
)

--Rooms

CREATE TABLE Rooms
(
	RoomNumber INT PRIMARY KEY,
	RoomType VARCHAR(20) NOT NULL,
	BedType VARCHAR(20) NOT NULL,
	Rate INT NOT NULL,
	RoomStatus BIT NOT NULL,
	Notes VARCHAR(MAX)
)

--Payments
CREATE TABLE Payments
(
	Id INT PRIMARY KEY,
	EmployeeId INT NOT NULL,
	PaymentDate DATETIME NOT NULL,
	AccountNumber INT NOT NULL,
	FirstDateOccupied DATETIME NOT NULL,
	LastDateOccupied DATETIME NOT NULL,
	TotalDays INT NOT NULL,
	AmountCharged DECIMAL(15,2),
	TaxRate INT,
	TaxAmount INT,
	PaymentTotal DECIMAL(15,2),
	Notes VARCHAR(MAX)
)

--Occupancies 
CREATE TABLE Occupancies
(
	Id INT PRIMARY KEY,
	EmployeeId INT NOT NULL,
	DateOccupied DATETIME NOT NULL,
	AccountNumber INT NOT NULL,
	RoomNumber INT NOT NULL,
	RateApplied INT,
	PhoneCharge DECIMAL(15,2),
	Notes VARCHAR(MAX)
)

INSERT INTO Emlpoyees(Id,FirstName,LastName,Title,Notes) VALUES
(1,'Miro','Vasilev','CEO',NULL),
(2,'Kiko','Vasilev','CFO',NULL),
(3,'Nikolay','Vasilev','CTO',NULL)

INSERT INTO Customers VALUES
(123,'Miro','V','1234567890','N','1234567890',NULL),
(124,'Kiko','G','1234567890','T','1234567890',NULL),
(125,'NIki','VS','1234567890','Z','1234567890',NULL)

INSERT INTO RoomStatus VALUES
(0,NULL),
(1,NULL),
(2,NULL)

INSERT INTO RoomTypes VALUES
('Appartment',NULL),
('Single Room',NULL),
('Atic Room', NULL)

INSERT INTO BedTypes VALUES
('Single',NULL),
('Queen Size',NULL),
('King SIze', NULL)

INSERT INTO Rooms VALUES
(120,'Appartment','Queen Size',10,0,NULL),
(121,'Single Room','Single',15,1,NULL),
(122,'Atic Room','King SIze',10,2,NULL)

INSERT INTO Payments VALUES
(1,1,GETDATE(),123,'5/5/2012','5/8/2012',3,459.23,NULL,NULL,450.23,NULL),
(2,1,GETDATE(),124,'5/5/2012','5/8/2012',3,459.23,NULL,NULL,450.23,NULL),
(3,1,GETDATE(),125,'5/5/2012','5/8/2012',3,459.23,NULL,NULL,450.23,NULL)

INSERT INTO Occupancies VALUES
(1,1,GETDATE(),123,120,0,0,NULL),
(2,2,GETDATE(),124,120,0,0,NULL),
(3,3,GETDATE(),125,120,0,0,NULL)