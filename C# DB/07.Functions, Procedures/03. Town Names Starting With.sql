CREATE PROC usp_GetTownsStartingWith(@String NVARCHAR(50))
AS
	SELECT Name FROM Towns AS T
	WHERE SUBSTRING(LOWER(T.Name),1,LEN(@String)) = LOWER(@String)

EXECUTE usp_GetTownsStartingWith 'b'