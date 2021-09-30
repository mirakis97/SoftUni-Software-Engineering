SELECT cur.CurrencyCode,cur.Description AS Currency,COUNT(c.CountryCode) AS NumberOfCountries FROM Currencies AS cur
LEFT JOIN Countries AS c ON c.CurrencyCode = cur.CurrencyCode
GROUP BY cur.CurrencyCode,cur.Description
ORDER BY NumberOfCountries DESC,cur.Description ASC