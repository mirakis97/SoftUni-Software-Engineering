SELECT c.CountryName,con.ContinentName,COUNT(r.RiverName) AS RiversCount ,ISNULL(SUM(r.Length),0) AS TotalLength FROM Countries AS c
JOIN Continents AS con ON con.ContinentCode = c.ContinentCode
LEFT JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
LEFT JOIN Rivers AS r ON r.Id = cr.RiverId
GROUP BY c.CountryName,con.ContinentName
ORDER BY RiversCount DESC,TotalLength DESC,c.CountryName