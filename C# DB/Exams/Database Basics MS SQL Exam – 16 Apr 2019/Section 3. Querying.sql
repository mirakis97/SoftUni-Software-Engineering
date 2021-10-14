--5.The "Tr" Planes
SELECT * FROM Planes
WHERE Name LIKE '%tr%'
ORDER BY Id ASC,Name ASC,Seats ASC,Range ASC

--6.Flight Profits
SELECT f.Id, SUM(t.Price) AS Price FROM Flights AS F
JOIN Tickets AS t ON F.Id = t.FlightId
GROUP BY f.Id
ORDER BY Price DESC,f.Id ASC


--7.Passenger Trips
SELECT p.FirstName + ' ' + p.LastName AS [Full Name],f.Origin,f.Destination FROM Passengers AS p
JOIN Tickets AS t ON p.Id = t.PassengerId
JOIN Flights AS f ON t.FlightId = f.Id
ORDER BY [Full Name] ASC,f.Origin ASC,f.Destination ASC

--8.Non Adventures People

SELECT p.FirstName,p.LastName,p.Age FROM Passengers AS p
LEFT JOIN Tickets AS T ON p.Id = t.PassengerId
WHERE t.Id IS NULL
ORDER BY p.Age DESC,p.FirstName ASC, p.LastName ASC

--9.Full Info
SELECT p.FirstName + ' ' + p.LastName AS [Full Name],pl.Name AS [Plane Name],CONCAT(f.Origin,'-',f.Destination) AS Trip,lt.Type  FROM Passengers AS p
JOIN Tickets AS t ON p.Id = t.PassengerId
JOIN Flights AS f ON t.FlightId = f.Id
JOIN Planes AS pl ON f.PlaneId = pl.Id
JOIN Luggages AS l ON t.LuggageId = l.Id
JOIN LuggageTypes AS lt ON l.LuggageTypeId = lt.Id
ORDER BY [Full Name] ASC,pl.Name,Trip ASC, lt.Type ASC

--10.PSP

SELECT pl.Name,pl.Seats,COUNT(p.Id) AS [Passengers Count] FROM Planes AS pl
JOIN Flights AS f ON pl.Id = f.PlaneId
JOIN Tickets AS t ON f.Id = t.FlightId
JOIN Passengers AS p ON t.PassengerId = p.Id
GROUP BY pl.Id,pl.Name,pl.Seats
ORDER BY [Passengers Count] DESC,pl.Name ASC,pl.Seats ASC
