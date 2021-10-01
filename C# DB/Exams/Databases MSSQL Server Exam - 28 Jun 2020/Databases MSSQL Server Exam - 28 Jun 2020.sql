--01. DDL
CREATE DATABASE ColonialJourney 

CREATE TABLE Planets 
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Name NVARCHAR(30) NOT NULL,
)
CREATE TABLE Spaceports
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Name NVARCHAR(50) NOT NULL,
	PlanetId INT FOREIGN KEY REFERENCES Planets(Id)
)
CREATE TABLE Spaceships
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Name NVARCHAR(50) NOT NULL,
	Manufacturer NVARCHAR (50) NOT NULL,
	LightSpeedRate INT DEFAULT 0
)
CREATE TABLE Colonists
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	Ucn NVARCHAR(10) UNIQUE NOT NULL,
	BirthDate DATE NOT NULL
)
CREATE TABLE Journeys
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	JourneyStart DATETIME NOT NULL,
	JourneyEnd DATETIME NOT NULL,
	Purpose NVARCHAR(11),
	DestinationSpaceportId INT FOREIGN KEY REFERENCES Spaceports(Id) NOT NULL,
	SpaceshipId INT FOREIGN KEY REFERENCES Spaceships(Id) NOT NULL
)
CREATE TABLE TravelCards
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	CardNumber NVARCHAR(10) UNIQUE NOT NULL,
	JobDuringJourney NVARCHAR(8),
	ColonistId INT FOREIGN KEY REFERENCES Colonists(Id),
	JourneyId INT FOREIGN KEY REFERENCES Journeys(Id)
)
--02. Insert

INSERT INTO Planets VALUES
('Mars'),
('Earth'),
('Jupiter'),
('Saturn')

INSERT INTO Spaceships VALUES
('Golf','VW',3),
('WakaWaka','Wakanda',4),
('Falcon9','SpaceX',1),
('Bed','Vidolov',6)

--03. Update
UPDATE Spaceships
SET LightSpeedRate += 1
WHERE Id  BETWEEN 8 AND 12

--04. Delete
DELETE TravelCards
WHERE JourneyId BETWEEN 1 AND 3
DELETE FROM Journeys
WHERE Id BETWEEN 1 AND 3

--05. Select All Military Journeys
SELECT Id,FORMAT(JourneyStart,'dd/MM/yyyy'),FORMAT(JourneyEnd,'dd/MM/yyyy') FROM Journeys
WHERE Purpose = 'Military'
ORDER BY JourneyStart ASC


--06. Select All Pilots
SELECT c.Id,c.FirstName + ' ' + c.LastName AS FullName FROM Colonists AS c
JOIN TravelCards AS tc ON tc.ColonistId = c.Id
WHERE tc.JobDuringJourney = 'Pilot'
ORDER BY c.Id ASC


--07. Count Colonists
SELECT COUNT(*) AS [Count] FROM Colonists AS c
JOIN TravelCards AS tc ON tc.ColonistId = c.Id
WHERE tc.JobDuringJourney = 'Engineer'


--08. Select Spaceships With Pilots
SELECT s.Name,s.Manufacturer FROM Spaceships AS s
JOIN Journeys AS j ON j.SpaceshipId = s.Id
JOIN TravelCards AS tc ON tc.JourneyId = j.Id
JOIN Colonists AS c ON c.Id = tc.ColonistId
WHERE DATEDIFf(YEAR,c.BirthDate,'01/01/2019') < 30 AND tc.JobDuringJourney = 'Pilot' 
ORDER BY s.Name ASC

--09. Planets And Journeys
SELECT p.Name AS PlanetName,COUNT(j.Purpose) AS JourneysCount FROM Planets AS p
JOIN Spaceports AS sp ON sp.PlanetId = p.Id
JOIN Journeys AS j ON j.DestinationSpaceportId = sp.Id
GROUP BY p.Name
ORDER BY JourneysCount DESC , p.Name ASC

--10. Select Special Colonists
SELECT JobDuringJourney,FullName,c.Ranked FROM 
(SELECT tc.JobDuringJourney,c.FirstName + ' ' + c.LastName AS FullName, (DENSE_RANK() OVER (PARTITION BY tc.JobDuringJourney ORDER BY c.BirthDate)) AS Ranked FROM Colonists AS c 
JOIN TravelCards AS tc ON tc.ColonistId = c.Id) AS c
WHERE Ranked = 2

--11. Get Colonists Count
CREATE FUNCTION dbo.udf_GetColonistsCount(@PlanetName VARCHAR (30))
 RETURNS INT
AS
BEGIN 
	RETURN(SELECT COUNT(*) FROM Colonists AS c
	JOIN TravelCards AS tc ON tc.ColonistId = c.Id
	JOIN Journeys AS j ON j.Id = tc.JourneyId
	JOIN Spaceports AS sp ON sp.Id = j.DestinationSpaceportId
	JOIN Planets AS p ON p.Id = sp.PlanetId
	WHERE p.Name = @PlanetName)
END
GO
SELECT dbo.udf_GetColonistsCount('Otroyphus')

--12. Change Journey Purpose
CREATE PROCEDURE usp_ChangeJourneyPurpose(@JourneyId INT,
                                          @NewPurpose VARCHAR(11))
AS
BEGIN
    IF (@JourneyId NOT IN (SELECT Id
                           FROM Journeys))
        THROW 50001, 'The journey does not exist!',1
    IF ((SELECT COUNT(*)
         FROM Journeys
         WHERE Id = @JourneyId
           AND Purpose = @NewPurpose) != 0)
        THROW 50002,'You cannot change the purpose!',1

    UPDATE Journeys
    SET Purpose=@NewPurpose
    WHERE Id = @JourneyId

END

EXEC usp_ChangeJourneyPurpose 4, 'Technical'
EXEC usp_ChangeJourneyPurpose 2, 'Educational'
EXEC usp_ChangeJourneyPurpose 196, 'Technical'