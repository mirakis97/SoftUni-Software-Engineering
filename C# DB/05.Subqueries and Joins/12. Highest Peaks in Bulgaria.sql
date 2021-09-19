SELECT c.CountryCode,d.MountainRange, p.PeakName,p.Elevation FROM Countries c
	JOIN MountainsCountries m ON m.CountryCode = c.CountryCode
	JOIN Mountains d ON d.Id = m.MountainId
	JOIN Peaks p ON p.MountainId = m.MountainId
	WHERE c.CountryCode = 'BG' AND p.Elevation > 2835
	ORDER BY p.Elevation DESC