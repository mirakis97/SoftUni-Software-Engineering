SELECT TOP(50) e.FirstName AS [First Name],e.LastName AS [Last Name],t.Name AS Town,a.AddressText FROM Employees e
	LEFT JOIN Addresses a ON e.AddressID = a.AddressID
	LEFT JOIN Towns t ON a.TownID = t.TownID
	ORDER BY [First Name],[Last Name] ASC