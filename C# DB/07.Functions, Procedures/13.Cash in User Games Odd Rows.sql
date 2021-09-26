CREATE FUNCTION ufn_CashInUsersGames(@gameName NVARCHAR(MAX))
RETURNS TABLE
AS
	RETURN (SELECT SUM(Querry.Cash) AS SumCash
		FROM (
			SELECT ug.Cash AS Cash
			,ROW_NUMBER() OVER (ORDER BY ug.Cash DESC)  AS [Row Number]
			FROM UsersGames AS ug
			JOIN Games AS g ON g.Id = ug.GameId
			WHERE g.Name = @gameName

			 ) AS Querry
			WHERE Querry.[Row Number] % 2 = 1)

