CREATE OR ALTER PROC usp_GetHoldersWithBalanceHigherThan (@Number DECIMAL(18,4))
AS
	SELECT a.FirstName,a.LastName FROM AccountHolders AS a
	JOIN Accounts AS acc ON a.Id = acc.AccountHolderId
	GROUP BY a.FirstName,a.LastName
	HAVING SUM(acc.Balance) > @Number
	ORDER BY a.FirstName ASC ,a.LastName