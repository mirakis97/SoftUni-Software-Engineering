--CREATE DATABASE TripService
--USE TripService
CREATE TABLE Cities 
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] NVARCHAR(20) NOT NULL,
	CountryCode CHAR(2) NOT NULL
)

CREATE TABLE Hotels
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] NVARCHAR(30) NOT NULL,
	CityId INT REFERENCES Cities(Id) NOT NULL,
	EmployeeCount INT NOT NULL,
	BaseRate DECIMAL(12,2)
)
CREATE TABLE Rooms
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Price DECIMAL(12,2) NOT NULL,
	[Type] NVARCHAR(20) NOT NULL,
	Beds INT NOT NULL,
	HotelId INT REFERENCES Hotels(Id) NOT NULL
)
CREATE TABLE Trips
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	RoomId INT REFERENCES Rooms(Id),
	BookDate DATE NOT NULL,
	ArrivalDate DATE NOT NULL,
	ReturnDate DATE NOT NULL,
	CancelDate DATE,
  	CHECK (BookDate < ArrivalDate),
  	CHECK (ArrivalDate < ReturnDate)
)

CREATE TABLE Accounts
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName NVARCHAR(50) NOT NULL,
	MIddleName NVARCHAR(50) ,
	LastName NVARCHAR(50) NOT NULL,
	CityId INT REFERENCES Cities(Id) NOT NULL,
	BirthDate DATE NOT NULL,
	Email NVARCHAR (100) UNIQUE NOT NULL
)
CREATE TABLE AccountsTrips
(
	AccountId INT NOT NULL FOREIGN KEY REFERENCES Accounts(Id),
	TripId INT NOT NULL FOREIGN KEY REFERENCES Trips(Id),
	Luggage INT CHECK(Luggage >= 0) NOT NULL,
		                  PRIMARY KEY (AccountId,TripId)
)
-- 02. Insert
INSERT INTO Accounts VALUES
('John','Smith','Smith',34,'1975-07-21','j_smith@gmail.com'),
('Gosho',NULL,'Petrov',11,'1978-05-16','g_petrov@gmail.com'),
('Ivan','Petrovich','Pavlov',59,'1849-09-26','i_pavlov@softuni.bg'),
('Friedrich','Wilhelm','Nietzsche',2,'1844-10-15','f_nietzsche@softuni.bg')

INSERT INTO Trips VALUES
(101,'2015-04-12','2015-04-14','2015-04-20','2015-02-02'),
(102,'2015-07-07','2015-07-15','2015-07-22','2015-04-29'),
(103,'2013-07-17','2013-07-23','2013-07-24',NULL),
(104,'2012-03-17','2012-03-31','2012-04-01','2012-01-10'),
(109,'2017-08-07','2017-08-28','2017-08-29',NULL)


--03. Update
UPDATE Rooms
SET Price *= 1.14
WHERE HotelId = 5 OR HotelId = 7 OR HotelId = 9

--04. Delete
DELETE 
	FROM AccountsTrips
WHERE AccountId = 47
--05.

SELECT acc.FirstName,acc.LastName,FORMAT(acc.BirthDate,'MM-dd-yyyy'),c.Name AS Hometown, acc.Email FROM Accounts AS acc
JOIN Cities AS c ON c.Id = acc.CityId
WHERE Email LIKE 'e%'
ORDER BY c.Name ASC

--6. City Statistics
SELECT c.Name,COUNT(h.Id) AS Hotels FROM Cities AS c
JOIN Hotels AS h ON c.Id = h.CityId
GROUP BY c.Name
ORDER BY Hotels DESC , c.Name 
--07. Longest and Shortest Trips
SELECT AccountId,
	   FirstName + ' ' + LastName AS FullName,
	   MAX(DATEDIFF(DAY,ArrivalDate,ReturnDate)) AS LongestTrip,
	   MIN(DATEDIFF(DAY,ArrivalDate,ReturnDate)) AS ShortestTrip
FROM AccountsTrips AS act
JOIN Accounts AS acc ON  act.AccountId = acc.Id 
JOIN Trips AS t ON act.TripId = t.Id
WHERE acc.MIddleName IS NULL AND t.CancelDate IS NULL
GROUP BY AccountId,FirstName ,LastName
ORDER BY LongestTrip DESC,ShortestTrip 

--8. Metropolis
SELECT TOP(10) c.Id, c.Name,c.CountryCode AS Country,COUNT(acc.Id) FROM Cities AS c
JOIN Accounts AS acc ON acc.CityId = c.Id
GROUP BY c.Id,c.Name,c.CountryCode
ORDER BY COUNT(acc.Id) DESC
--9. Romantic Getaways
SELECT acc.Id,acc.Email,c.Name AS City, COUNT(*) AS Trips 
FROM Accounts AS acc
JOIN AccountsTrips AS act ON act.AccountId = acc.Id
JOIN Trips AS t ON t.Id = act.TripId
JOIN Rooms AS r ON r.Id = t.RoomId
JOIN Hotels AS h ON h.Id = r.HotelId
JOIN Cities AS c ON c.Id = h.CityId
WHERE acc.CityId = c.Id
GROUP BY acc.Id,acc.Email,c.Name
ORDER BY Trips DESC,acc.Id

--10. GDPR Violation
SELECT t.Id,
CASE
WHEN acc.MIddleName IS NULL THEN CONCAT(acc.FirstName,' ',LastName)
				ELSE CONCAT(acc.FirstName,+ ' ' + acc.MIddleName,' ',acc.LastName)
END AS FullName,c.Name AS [From],c2.Name [To],
CASE
WHEN t.CancelDate IS NULL THEN CONCAT(DATEDIFF(DAY,T.ArrivalDate, T.ReturnDate), ' ', 'days')
				ELSE 'Canceled'
END AS Duration 
FROM AccountsTrips AS act
JOIN Accounts AS acc ON act.AccountId = acc.Id
JOIN Cities AS c ON c.Id = acc.CityId
JOIN Trips AS t ON t.Id = act.TripId
JOIN Rooms AS r ON r.Id = t.RoomId
JOIN Hotels AS h ON h.Id = r.HotelId
JOIN Cities AS c2 ON c2.Id = h.CityId
ORDER BY FullName, T.Id



--11. Available Room

CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATETIME, @People INT) 
  RETURNS NVARCHAR(200)
AS 
	BEGIN
	DECLARE @RoomId INT = (SELECT TOP(1) R.Id 
							   FROM Trips AS T
								JOIN Rooms  AS R ON R.Id = T.RoomId
								JOIN Hotels AS H ON H.Id = R.HotelId
								   WHERE H.Id = @HotelId 
								   AND @Date NOT BETWEEN T.ArrivalDate AND T.ReturnDate
								   AND T.CancelDate IS NULL
								   AND R.Beds >= @People
								   AND YEAR(@Date) = YEAR(t.ArrivalDate)
								   ORDER BY R.Price DESC)
	IF(@RoomId IS NULL)
	RETURN 'No rooms available'

	DECLARE @RoomType NVARCHAR(20) = (SELECT [Type]
										    FROM Rooms
										    WHERE Id = @RoomId)

	DECLARE @Beds INT              = (SELECT R.Beds 
										    FROM Rooms AS R 
										    WHERE R.Id = @RoomId)

	DECLARE @HotelBaseRate DECIMAL(15,2) = (SELECT H.BaseRate 
										    FROM Hotels AS H 
										    WHERE H.Id = @HotelId)

	DECLARE @RoomPrice DECIMAL(18,2)     = (SELECT R.Price 
										    FROM Rooms AS R
										    WHERE R.Id = @RoomId)

	DECLARE @TotalPrice DECIMAL(18,2)    = (@HotelBaseRate + @RoomPrice) * @People

	RETURN CONCAT('Room',' ',@RoomId,':',' ',@RoomType,' ','(',@Beds,' ','beds',')',' ','-',' ','$',@TotalPrice )
	END

	--12.

CREATE OR ALTER PROCEDURE usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS
BEGIN
	DECLARE @SelectedTrip INT = (SELECT h.Id
								FROM Trips AS t
								JOIN Rooms AS r ON r.Id = t.RoomId
								JOIN Hotels AS h ON h.Id = r.HotelId
								WHERE t.Id = @TripId)

	DECLARE @SelectedRoom INT = (SELECT HotelId
									FROM Rooms 						
									WHERE Id = @TargetRoomId);

	IF(@SelectedTrip != @SelectedRoom)
	BEGIN
	THROW 50001,'Target room is in another hotel!',1
	END

	DECLARE @TipsForAccount INT = (SELECT COUNT(AccountId) FROM AccountsTrips
	WHERE TripId = @TripId)

	DECLARE @BedsInTargedRoom INT = (SELECT r.Beds FROM Rooms AS r
	WHERE r.Id = @TargetRoomId)

	
	IF(@TipsForAccount > @BedsInTargedRoom)
	BEGIN
	THROW 50002,'Not enough beds in target room!',2
	END
	UPDATE Trips
	SET RoomId =@TargetRoomId
	WHERE Id = @TripId
END

EXEC usp_SwitchRoom 10, 11
SELECT RoomId FROM Trips WHERE Id = 10

EXEC usp_SwitchRoom 10, 7
EXEC usp_SwitchRoom 10, 8