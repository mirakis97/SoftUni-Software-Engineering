SELECT ContinentCode,CurrencyCode,Total AS CurrencyUsege FROM (SELECT ContinentCode,CurrencyCode,COUNT(*) AS Total,
DENSE_RANK() OVER (PARTITION BY ContinentCode ORDER BY COUNT(*) DESC)AS Ranked
FROM Countries GROUP BY ContinentCode,CurrencyCode) AS k
WHERE Ranked = 1 AND Total > 1
ORDER BY ContinentCode,CurrencyCode