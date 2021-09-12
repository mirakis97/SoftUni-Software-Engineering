CREATE TABLE Passports
(
	PassportID INT PRIMARY KEY NOT NULL,
	PassportNumber CHAR(8) NOT NULL,
)

CREATE TABLE Persons
(
	PersonID INT IDENTITY PRIMARY KEY  NOT NULL,
	FirstName NVARCHAR(50) NOT NULL,
	Salary DECIMAL(12,2) NOT NULL,
	PassportID INT REFERENCES Passports(PassportID) NOT NULL
)

INSERT INTO Passports VALUES
(101,'N34FG21B'),
(102,'K65LO4R7'),
(103,'ZE657QP2')

SELECT * FROM Passports

INSERT INTO Persons VALUES
('Roberto',43300.00,102),
('Tom',56100.00,103),
('Yana',60200.00,101)

SELECT * FROM Persons