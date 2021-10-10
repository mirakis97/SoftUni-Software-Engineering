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