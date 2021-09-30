UPDATE Countries
SET CountryName = 'Burma'
WHERE CountryName = 'Myanmar'

INSERT INTO Monasteries (Name,CountryCode) VALUES
('Hanga Abbey',(SELECT c.CountryCode FROM Countries AS c WHERE c.CountryName = 'Tanzania'))


INSERT INTO Monasteries (Name,CountryCode) VALUES
('Myin-Tin-Daik',(SELECT c.CountryCode FROM Countries AS c WHERE c.CountryName = 'Myanmar'))

SELECT con.ContinentName,c.CountryName,COUNT(m.Name) AS MonasteriesCount FROM Continents AS con
LEFT JOIN Countries AS c ON c.ContinentCode = con.ContinentCode
LEFT JOIN Monasteries AS m ON c.CountryCode = m.CountryCode
WHERE c.IsDeleted = 0
GROUP BY con.ContinentName,c.CountryName
ORDER BY MonasteriesCount DESC, c.CountryName

