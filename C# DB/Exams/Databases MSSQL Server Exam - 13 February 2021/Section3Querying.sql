--5.Commits

SELECT Id,Message,RepositoryId,ContributorId FROM Commits
ORDER BY Id ASC,Message ASC,RepositoryId ASC, ContributorId ASC

--06. Front-end
SELECT	Id,Name,Size FROM Files
WHERE Size > 1000 AND Name LIKE '%html%'
ORDER BY Size DESC,Id ASC, Name ASC

--07. Issue Assignment
SELECT i.Id,CONCAT(u.Username + ' : ',+ i.Title) AS IssueAssignee FROM Issues AS i
JOIN Users AS u ON i.AssigneeId = u.Id
ORDER BY i.Id DESC,i.AssigneeId

--08. Single Files
SELECT f2.Id,f2.Name,CONCAT(f2.Size , 'KB') AS Size FROM Files AS f
RIGHT JOIN Files AS f2 ON f.ParentId = f2.Id
WHERE f.ParentId IS NULL
ORDER BY f2.Id ASC,f2.Name ASC,f2.Size DESC

--9.Commits in Repositories
SELECT TOP(5)r.Id,r.Name,COUNT(c.Id) AS Commits FROM Repositories AS r
JOIN Commits AS c ON r.Id = c.RepositoryId
JOIN RepositoriesContributors AS rc ON rc.RepositoryId = r.Id
GROUP BY r.Id,r.Name
ORDER BY Commits DESC,r.Id ASC,r.Name 

--10.	Average Size

SELECT u.Username,AVG(f.Size) AS Size FROM Users AS u
JOIN Commits AS c ON u.Id = c.ContributorId
JOIN Files AS f ON c.Id = f.CommitId
GROUP BY u.Username
ORDER BY AVG(f.Size) DESC,u.Username ASC

--11. All User Commits

CREATE FUNCTION udf_AllUserCommits(@username VARCHAR(30))
RETURNS INT AS
BEGIN
DECLARE @returnvalue INT;

SELECT  @returnvalue = COUNT(c.Id) FROM Users AS u
JOIN Commits AS c ON u.Id = c.ContributorId
WHERE u.Username = @username

RETURN @returnvalue
END
--

SELECT dbo.udf_AllUserCommits('UnderSinduxrein')

--12. Search for Files
/*
Create a user defined stored procedure, named usp_SearchForFiles(@fileExtension), that receives files extensions.
The procedure must print the id, name and size of the file. Add "KB" in the end of the size. Order them by id (ascending), file name (ascending) and file size (descending)

*/
CREATE PROC usp_SearchForFiles(@fileExtension VARCHAR(30))
AS
	SELECT Id,Name,CONCAT(Size , 'KB') AS Size FROM Files 
	WHERE Name LIKE '%' + @fileExtension
GO



EXEC usp_SearchForFiles 'txt'