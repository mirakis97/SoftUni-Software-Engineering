--01. DDL
CREATE DATABASE Bakery
USE Bakery

CREATE TABLE Countries
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] NVARCHAR(50) UNIQUE NOT NULL
)
CREATE TABLE Customers
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName NVARCHAR(25),
	LastName NVARCHAR(25),
	Gender CHAR(1),
	Age INT,
	PhoneNumber CHAR(10),
	CountryId INT REFERENCES Countries(Id)
)
CREATE TABLE Products
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] NVARCHAR(25) UNIQUE,
	[Description] NVARCHAR(250),
	Recipe NVARCHAR(MAX),
	Price DECIMAL (12,2) CHECK(Price >= 0) 
)
CREATE TABLE Feedbacks
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Description] NVARCHAR(255),
	Rate DECIMAL(10,2),
	ProductId INT REFERENCES Products(Id),
	CustomerId INT REFERENCES Customers(Id)
)

CREATE TABLE Distributors
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] NVARCHAR(25) UNIQUE,
	AddressText NVARCHAR(30),
	Summary NVARCHAR(200),
	CountryId INT REFERENCES Countries(Id)
)
CREATE TABLE Ingredients
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] NVARCHAR(30) ,
	[Description] NVARCHAR(200),
	OriginCountryId INT REFERENCES Countries(Id),
	DistributorId INT REFERENCES Distributors(Id)
)

CREATE TABLE ProductsIngredients
(
	ProductId INT REFERENCES Products(Id),
	IngredientId INT REFERENCES Ingredients(Id),
	PRIMARY KEY (ProductId,IngredientId)
)

--2.Insert

INSERT INTO Distributors VALUES
('Deloitte & Touche',2,'6 Arch St #9757','Customizable neutral traveling'),
('Congress Title',13,'58 Hancock St','Customer loyalty'),
('Kitchen People',1,'3 E 31st St #77','Triple-buffered stable delivery'),
('General Color Co Inc',21,'6185 Bohn St #72','Focus group'),
('Beck Corporation',23,'21 E 64th Ave','Quality-focused 4th generation hardware')

INSERT INTO Customers VALUES
('Francoise','Rautenstrauch',15,'M','0195698399',5),
('Kendra','Loud',22,'F','0063631526',5),
('Lourdes','Bauswell',50,'M','0139037043',8),
('Hannah','Edmison',18,'F','0043343686',1),
('Tom','Loeza',31,'M','0144876096',23),
('Queenie','Kramarczyk',30,'F','0064215793',29),
('Hiu','Portaro',25,'M','0068277755',16),
('Josefa','Opitz',43,'F','0197887645',17)
--03. Update

UPDATE Ingredients
SET DistributorId = 35
WHERE Name ='Bay Leaf' OR Name ='Paprika' OR Name ='Poppy'

UPDATE Ingredients 
SET OriginCountryId = 14
WHERE OriginCountryId = 8

--04. Delete
DELETE FROM Feedbacks
WHERE CustomerId = 14 OR ProductId = 5

--05. Products By Price

SELECT Name,Price,Description FROM Products
ORDER BY Price DESC,Name ASC

--06. Negative Feedback

SELECT f.ProductId,f.Rate,f.Description,f.CustomerId,c.Age,c.Gender FROM Feedbacks AS f
JOIN Customers AS c ON c.Id = f.CustomerId
WHERE f.Rate < 5.0
ORDER BY f.ProductId DESC,f.Rate ASC

--07. Customers without Feedback
SELECT CONCAT(c.FirstName,+ ' ',+ c.LastName) AS CustomerName,c.PhoneNumber,c.Gender FROM Customers AS c
LEFT JOIN Feedbacks AS f ON f.CustomerId = c.Id
WHERE f.CustomerId IS NULL
ORDER BY c.Id ASC

--08. Customers by Criteria
SELECT c.FirstName, c.Age, c.PhoneNumber FROM Customers AS c
JOIN Countries AS con ON con.Id = c.CountryId
WHERE c.Age >= 21 AND c.FirstName LIKE '%an%' OR  c.PhoneNumber LIKE '%38' AND con.Name != 'Greece'
ORDER BY c.FirstName ASC, c.Age DESC

--09. Middle Range Distributors
SELECT d.Name AS DistributorName,i.Name AS IngredientName,p.Name AS ProductName, AVG(f.Rate) AS AverageRate FROM Distributors AS d
JOIN Ingredients AS i ON i.DistributorId = d.Id
JOIN ProductsIngredients AS prodi ON prodi.IngredientId = i.Id
JOIN Products AS p ON p.Id = prodi.ProductId
JOIN Feedbacks AS f ON f.ProductId = p.Id
GROUP BY d.Name,i.Name,p.Name
HAVING AVG(f.Rate) BETWEEN 5 AND 8
ORDER BY d.Name,i.Name,p.Name

--10.Country Representative

SELECT r.CountryName, r.DistributorName FROM (
SELECT c.Name AS CountryName ,d.Name AS DistributorName, DENSE_RANK() OVER (PARTITION BY c.Name ORDER BY COUNT(i.Id) DESC) AS Ranking FROM  Countries AS c
JOIN Distributors AS d ON d.CountryId = c.Id
LEFT JOIN Ingredients AS i ON i.DistributorId = d.Id
GROUP BY c.Name,d.Name) 
AS r
WHERE r.Ranking = 1
ORDER BY r.CountryName, r.DistributorName 

--11.Customers with Countries
CREATE VIEW v_UserWithCountries  AS
SELECT
CONCAT(c.FirstName,+ ' ',+ c.LastName) AS CustomerName,
c.Age,c.Gender,coun.Name AS CountryName
FROM Customers AS C
JOIN Countries AS coun ON coun.Id = c.CountryId

SELECT TOP 5 *
  FROM v_UserWithCountries
 ORDER BY Age

 --12.Delete Products
CREATE TRIGGER tr_DeleteProducts
ON Products INSTEAD OF DELETE
AS
BEGIN
	DECLARE @DeletedProductId INT = (SELECT p.Id FROM Products AS p
												 JOIN deleted AS d ON p.Id = d.Id)

	DELETE
	FROM Feedbacks
	WHERE ProductId = @DeletedProductId

	DELETE FROM ProductsIngredients
	WHERE ProductId = @DeletedProductId

	DELETE
	FROM Products
	WHERE Id =@DeletedProductId
END