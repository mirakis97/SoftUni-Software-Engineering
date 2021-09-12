CREATE TABLE Manufacturers
(
	ManufacturerID INT PRIMARY KEY NOT NULL,
	Name NVARCHAR(50) NOT NULL,
	EstablishedOn DATE NOT NULL
)

INSERT INTO Manufacturers VALUES
(1,'BWM','07/03/1916'),
(2,'Tesla','01/01/2003'),
(3,'Lada','01/05/1966')

CREATE TABLE Models
(
	ModelID INT PRIMARY KEY NOT NULL,
	NAME NVARCHAR(50) NOT NULL,
	ManufacturerID INT REFERENCES Manufacturers(ManufacturerID)
)
INSERT INTO Models VALUES 
(101,'X1',1),
(102,'i6',1),
(103,'Model S',2),
(104,'Model X',2),
(105,'Model 3',2),
(106,'Nova',3)

SELECT * FROM Models
SELECT * FROM Manufacturers