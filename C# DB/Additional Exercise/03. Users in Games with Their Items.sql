SELECT u.Username, g.Name AS [Game],COUNT(usg.ItemId) AS [Items Count],SUM(i.Price) AS [Items Price] FROM UsersGames AS ug
JOIN UserGameItems AS usg ON usg.UserGameId = ug.Id
JOIN Users AS u ON ug.UserId = u.Id
JOIN Games AS g ON  ug.GameId = g.Id 
JOIN Items AS i ON i.Id = usg.ItemId
GROUP BY u.Username,g.Name
HAVING COUNT(usg.ItemId) >= 10
ORDER BY [Items Count] DESC,[Items Price] DESC,u.Username