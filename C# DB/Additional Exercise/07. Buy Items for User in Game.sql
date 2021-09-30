SELECT u.Id,u.Username, ug.GameId,ug.Id AS UserGameId,Cash INTO UserInfo FROM Users AS u
	INNER JOIN UsersGames AS ug ON ug.UserId = u.Id
	INNER JOIN Games AS g ON g.Id = ug.GameId
WHERE u.Username = 'Alex' AND g.Name = 'Edinburgh';

SELECT i.Id,i.Price,i.Name INTO ItemsInfo FROM Items AS i
WHERE i.Name IN('Blackguard', 'Bottomless Potion of Amplification', 'Eye of Etlich (Diablo III)', 'Gem of Efficacious Toxin', 'Golden Gorget of Leoric', 'Hellfire Amulet');
UPDATE UsersGames
	SET Cash -= (SELECT SUM(Price) FROM ItemsInfo)
	WHERE UsersGames.Id = 
	(
		SELECT UserInfo.UserGameId
		FROM UserInfo
	);
INSERT INTO UserGameItems
(UserGameId,ItemId)
		SELECT
		(SELECT UserGameId FROM UserInfo),Id FROM ItemsInfo
DROP TABLE ItemsInfo;
DROP TABLE UserInfo
SELECT u.Username,g.Name,ug.Cash,i.Name AS [Item Name] FROM UsersGames AS ug
	INNER JOIN Games AS g ON ug.GameId = g.Id
	INNER JOIN Users AS u ON ug.UserId = u.Id
	INNER JOIN UserGameItems AS ugt ON ugt.UserGameId = ug.Id
	INNER JOIN Items AS i ON i.Id = ugt.ItemId
WHERE g.Name= 'Edinburgh'
ORDER BY i.[Name];