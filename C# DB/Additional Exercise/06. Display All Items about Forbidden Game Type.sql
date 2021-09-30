SELECT i.Name AS Item,i.Price,i.MinLevel,gp.Name AS [Forbidden Game Type] FROM Items AS i
LEFT JOIN GameTypeForbiddenItems AS gt ON gt.ItemId = i.Id
LEFT JOIN GameTypes AS gp ON gp.Id = gt.GameTypeId
ORDER BY gp.Name DESC,i.Name