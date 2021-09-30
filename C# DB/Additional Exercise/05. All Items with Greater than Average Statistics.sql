SELECT i.Name,i.Price,i.MinLevel,stat.Strength,stat.Defence,stat.Speed,stat.Luck,stat.Mind FROM Items AS i
INNER JOIN [Statistics] AS stat ON stat.Id = i.StatisticId
WHERE stat.Mind >
(SELECT AVG(Imind.Mind) FROM Items as avgMin
INNER JOIN [Statistics] AS Imind ON stat.Id = i.StatisticId )
	AND stat.Speed >
(SELECT AVG(iSpeed.Speed) FROM Items as avgSpeed
INNER JOIN [Statistics] AS iSpeed ON stat.Id = i.StatisticId )
	AND stat.Luck >
(SELECT AVG(iLuck.Luck) FROM Items as avgLuck
INNER JOIN [Statistics] AS iLuck ON stat.Id = i.StatisticId )
ORDER BY i.Name


