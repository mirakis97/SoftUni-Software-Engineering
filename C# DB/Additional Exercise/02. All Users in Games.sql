SELECT g.Name AS Game, gp.Name AS [Game Type], u.Username,ug.Level,ug.Cash,ch.Name AS [Character] FROM Users AS u
JOIN UsersGames AS ug ON ug.UserId = u.Id
JOIN Games AS g ON g.Id = ug.GameId
JOIN GameTypes AS gp ON gp.Id = g.GameTypeId
JOIN Characters AS ch ON ch.Id = ug.CharacterId
ORDER BY ug.Level DESC,u.Username ASC,g.Name ASC