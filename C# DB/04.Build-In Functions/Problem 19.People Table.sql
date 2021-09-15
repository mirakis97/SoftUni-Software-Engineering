CREATE TABLE People
(
	Id INT PRIMARY KEY NOT NULL,
	Name NVARCHAR(50) NOT NULL,
	Birthdate  DATETIME2 NOT NUll
)
INSERT INTO People VALUES
(1,'Victor','2000-12-07 00:00:00.000'),
(2,'Steven','1992-09-10 00:00:00.000'),
(3,'Stephen','1910-09-19 00:00:00.000'),
(4,'John','2010-01-06 00:00:00.000')

SELECT 
	Name,
	DATEDIFF(YEAR,Birthdate,GETDATE()) AS [Age in Years],
	DATEDIFF(MONTH,Birthdate,GETDATE()) AS [Age in Months],
	DATEDIFF(DAY,Birthdate,GETDATE()) AS [Age in Days],
	DATEDIFF(MINUTE,Birthdate,GETDATE()) AS [Age in Minutes]
FROM People