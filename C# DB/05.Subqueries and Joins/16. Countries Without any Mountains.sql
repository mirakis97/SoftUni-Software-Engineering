SELECT COUNT(*)AS [Count] FROM Continents c 
	LEFT JOIN  Countries cr ON cr.ContinentCode = c.ContinentCode
	LEFT JOIN MountainsCountries mc ON mc.CountryCode = cr.CountryCode
	LEFT JOIN Mountains m ON m.Id = mc.MountainId
	WHERE m.Id IS NULL