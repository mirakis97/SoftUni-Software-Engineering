--11.Vacation

CREATE OR ALTER FUNCTION udf_CalculateTickets(@origin VARCHAR(50), @destination VARCHAR(50), @peopleCount INT)
RETURNS VARCHAR(MAX)
BEGIN

	DECLARE @returnOrigin VARCHAR = (SELECT Destination FROM Flights WHERE Origin = @origin AND Destination = @destination)

	DECLARE @returnVarchar VARCHAR(MAX)

	IF(@peopleCount <= 0)
	RETURN 'Invalid people count!'
	

	IF(@returnOrigin IS NULL)
	RETURN 'Invalid flight!'
	


	DECLARE  @returnvalue DECIMAL(16,2) = (SELECT SUM(t.Price) FROM Flights AS f
	JOIN Tickets AS t ON f.Id= t.FlightId
	WHERE f.Origin = @origin AND f.Destination = @destination)

	SET @returnvalue *= @peopleCount

	SET @returnVarchar = CONCAT('Total price',' ', @returnvalue)
RETURN @returnVarchar
END



SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', 33)

SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', -1)

SELECT dbo.udf_CalculateTickets('Invalid','Rancabolang', 33)

--12.Wrong Data

CREATE PROCEDURE usp_CancelFlights
AS
	UPDATE Flights
	SET ArrivalTime = NULL , DepartureTime = NULL
	WHERE ArrivalTime >= DepartureTime
GO


EXEC usp_CancelFlights