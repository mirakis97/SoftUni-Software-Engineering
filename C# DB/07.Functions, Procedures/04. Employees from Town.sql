CREATE PROC usp_GetEmployeesFromTown (@Town NVARCHAR(50))
AS
	SELECT FirstName,LastName FROM Employees E
	JOIN Addresses a ON a.AddressID = e.AddressID
	JOIN Towns t ON a.TownID = t.TownID
	WHERE  t.Name = @Town