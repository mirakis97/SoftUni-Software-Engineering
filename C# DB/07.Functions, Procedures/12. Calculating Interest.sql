CREATE PROC usp_CalculateFutureValueForAccount(@accountId INT, @interestRate FLOAT = 0.1)
AS
	SELECT a.Id AS [Account Id],a.FirstName,a.LastName,acc.Balance,dbo.ufn_CalculateFutureValue(acc.Balance,@interestRate,5) AS [Balance in 5 years] FROM AccountHolders AS a
	JOIN Accounts AS acc ON acc.Id = a.Id
	WHERE acc.Id = @accountId