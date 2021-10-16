--05
SELECT CigarName,PriceForSingleCigar,ImageURL FROM Cigars
ORDER BY PriceForSingleCigar ASC,CigarName DESC

--06. Cigars by Taste
SELECT c.Id,c.CigarName,c.PriceForSingleCigar,t.TasteType,t.TasteStrength  FROM Cigars AS c
JOIN Tastes AS t ON c.TastId = t.Id
WHERE t.TasteType = 'Earthy' OR t.TasteType = 'Woody'
ORDER BY c.PriceForSingleCigar DESC

--07. Clients without Cigars
SELECT c.Id,c.FirstName + ' ' + c.LastName AS ClientName, c.Email FROM Clients AS c
LEFT JOIN ClientsCigars AS cc ON cc.ClientId = c.Id
WHERE cc.CigarId IS NULL
ORDER BY ClientName ASC

--08. First 5 Cigars

SELECT TOP(5) c.CigarName,c.PriceForSingleCigar,c.ImageURL FROM Cigars AS c
LEFT JOIN Sizes AS s ON s.Id = c.SizeId
WHERE  s.Length >= 12 AND (c.CigarName LIKE '%ci%' OR c.PriceForSingleCigar > 50) AND s.RingRange > 2.55
ORDER BY c.CigarName ASC,c.PriceForSingleCigar DESC

--09. Clients with ZIP Codes
SELECT CONCAT(c.FirstName,' ',c.LastName) AS FullName,a.Country,a.ZIP,CONCAT('$',MAX(ci.PriceForSingleCigar)) AS CigarPrice FROM Clients AS c
JOIN Addresses AS a ON c.AddressId = a.Id
JOIN ClientsCigars AS cc ON c.Id = cc.ClientId
JOIN Cigars AS ci ON cc.CigarId = ci.Id
WHERE a.ZIP NOT LIKE '%[^0-9]%'
GROUP BY c.FirstName,c.LastName,a.Country,a.ZIP
ORDER BY FullName ASC

--10. Cigars by Size
SELECT c.LastName,AVG(s.Length) AS CiagrLength,ceiling(AVG(s.RingRange)) AS CiagrRingRange FROM Clients AS c
JOIN ClientsCigars AS cc ON  c.Id  = cc.ClientId 
JOIN Cigars AS ci ON cc.CigarId = ci.Id
JOIN Sizes AS s ON ci.SizeId = s.Id
GROUP BY c.LastName
ORDER BY CiagrLength DESC
