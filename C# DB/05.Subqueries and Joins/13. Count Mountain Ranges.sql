SELECT TOP(5) mc.CountryCode , COUNT(*) FROM Mountains m
	JOIN MountainsCountries mc ON m.Id = mc.MountainId
	WHERE mc.CountryCode = 'BG' OR mc.CountryCode = 'RU' OR mc.CountryCode = 'US'
	GROUP BY mc.CountryCode