CREATE DATABASE CarRental

Use CarRental

CREATE TABLE Categories
(
	Id INT PRIMARY KEY NOT NULL,
	CategoryName NVARCHAR(MAX) NOT NULL,
	DailyRate DECIMAL(2,1) NOT NULL,
	WeeklyRate DECIMAL(2,1) NOT NULL,
	MonthlyRate DECIMAL(2,1) NOT NULL,
	WeekendRate DECIMAL(2,1) NOT NULL,
)

CREATE TABLE Cars
(
	Id INT PRIMARY KEY NOT NULL,
	PlateNumber VARCHAR (5) NOT NULL,
	Manufacturer VARCHAR(20) NOT NULL,
	Model VARCHAR(20) NOT NULL,
	CarYear INT NOT NULL,
	CategoryId NVARCHAR(MAX) NOT NULL,
	Doors TINYINT NOT NULL,
	Picture VARBINARY(MAX),
	Condition VARCHAR(20) NOT NULL,
	Available BIT NOT NULL
)
CREATE TABLE Employees 
(
	Id INT PRIMARY KEY NOT NULL,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	Title VARCHAR(30) NOT NULL,
	Notes VARCHAR(MAX)
)

CREATE TABLE Customers  
(
	Id INT PRIMARY KEY NOT NULL,
	DriverLicenceNumber INT NOT NULL,
	FullName NVARCHAR(30) NOT NULL,
	[Address] VARCHAR(MAX) NOT NULL,
	City VARCHAR(30) NOT NULL,
	ZIPCode SMALLINT NOT NULL,
	Notes VARCHAR(MAX)
)

CREATE TABLE RentalOrders(
	Id BIGINT PRIMARY KEY IDENTITY NOT NULL,
	EmployeeId BIGINT NOT NULL,
	CustomerId BIGINT NOT NULL,
	CarId BIGINT NOT NULL,
	TankLevel TINYINT NOT NULL,
	KilometrageStart INT NOT NULL,
	KilometrageEnd INT NOT NULL,
	TotalKilometrage INT NOT NULL,
	StartDate DATE NOT NULL,
	EndDate DATE NOT NULL,
	TotalDays SMALLINT NOT NULL,
	RateApplied DECIMAL(2,1) NOT NULL,
	TaxRate DECIMAL(2,1) NOT NULL,
	OrderStatus BIT NOT NULL,
	Notes VARCHAR(MAX)
)


INSERT INTO Categories VALUES
(1,'SportsCar',1.1,2.2,3.3,4.4),
(2,'CityCar',1.1,2.2,3.3,4.4),
(3,'Motorcicle',1.1,2.2,3.3,4.4)

INSERT INTO Cars VALUES
(1,'KIKO','BMW','M3',2012,1,4,NULL,'New',1),
(2,'DIKO','AUDI','Q7',2012,2,4,NULL,'New',0),
(3,'MIRO','NISSAN','SKYLINE',2021,3,4,NULL,'Used',1)

INSERT INTO Employees VALUES
(1,'Gogi','Gogiev','BEST GUY',NULL),
(2,'Mirkos','Mirakos','JUST GUY',NULL),
(3,'Ivan','Petrov','GOOD GUY',NULL)

INSERT INTO Customers VALUES
(1,1,'Miroslav Svetlinov Vasilev', 'Zona 13', 'Pleven', 1615, NULL),
(2,2,'Nikolay Svetlinov Vasilev', 'Kona 13', 'Sofia', 1615, NULL),
(3,3,'Svetlin Neikov Vasilev', 'Nase 13', 'Plovdiv', 1615, NULL)

INSERT INTO RentalOrders
	VALUES
		(1, 2, 3, 80, 60000, 60300, 300, '08-18-2021', '08-27-2021', 9, 9.8, 3.4, 1, NULL),
		(2, 2, 2, 70, 60000, 60300, 300, '08-18-2021', '08-27-2021', 9, 9.8, 3.4, 1, NULL),
		(2, 1, 1, 90, 60000, 60300, 300, '08-18-2021', '08-27-2021', 9, 9.8, 3.4, 1, 'smth')