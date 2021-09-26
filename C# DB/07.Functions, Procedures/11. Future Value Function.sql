CREATE FUNCTION ufn_CalculateFutureValue(@sum DECIMAL(18,4),@yearlyRate FLOAT, @numberYears INT)
RETURNS DECIMAL(18,4)
AS BEGIN
	DECLARE @InitialSum DECIMAL(18,4)
	SET @InitialSum = @sum *(POWER((1 + @yearlyRate),@numberYears))
	RETURN @InitialSum
END