--11.	Client with Cigars
CREATE OR ALTER FUNCTION udf_ClientWithCigars(@name NVARCHAR(30))
RETURNS INT
AS
BEGIN
	RETURN (SELECT COUNT(*) FROM Clients AS c 
										LEFT JOIN ClientsCigars AS cc ON c.Id = cc.ClientId
										WHERE c.FirstName = @name)
END

SELECT dbo.udf_ClientWithCigars('Betty')

--12.

CREATE PROCEDURE usp_SearchByTaste(@taste VARCHAR(20))
AS
	SELECT c.CigarName,CONCAT('$',c.PriceForSingleCigar),t.TasteType,b.BrandName,CONCAT(s.Length,' cm') AS CigarLength,CONCAT(s.RingRange,' cm') AS CigarRingRange FROM Cigars AS c
	JOIN Tastes AS t ON c.TastId = t.Id
	JOIN Sizes AS s ON c.SizeId = s.Id
	JOIN Brands AS b ON c.BrandId = b.Id
	WHERE t.TasteType = @taste
	ORDER BY CigarLength ASC,CigarRingRange DESC
GO

EXEC usp_SearchByTaste 'Woody'