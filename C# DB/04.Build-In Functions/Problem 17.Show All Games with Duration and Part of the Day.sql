SELECT Name AS [Game],[Part of the Day] =
			CASE
				WHEN DATEPART(HOUR,Start)< 12 THEN 'Morning'
				WHEN DATEPART(HOUR,Start)< 18 THEN 'Afternoon'
				ELSE 'Evning'
			END
			,[Duration] =
			CASE
				WHEN [Duration] <= 3 THEN 'Extra Short'
				WHEN [Duration] <= 6 THEN 'Short'
				WHEN [Duration] > 6 THEN 'Long'
				ELSE 'Extra Long'
			END
FROM Games
ORDER BY [Game],[Duration],[Part of the Day]