SELECT Result.[Email Provider],COUNT(Result.[Email Provider]) AS 'Number Of Users' FROM (SELECT SUBSTRING(us.Email,CHARINDEX('@',us.Email,1) + 1, LEN(us.Email)) AS [Email Provider] FROM Users AS us
GROUP BY us.Email)AS Result
GROUP BY Result.[Email Provider]
ORDER BY [Number Of Users] DESC, Result.[Email Provider] ASC