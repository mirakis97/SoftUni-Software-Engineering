SELECT Username,SUBSTRING(Email,CHARINDEX('@',Email,1) + 1, LEN(Email)) AS [Email Provider] FROM Users
ORDER BY [Email Provider] ASC, Username ASC
