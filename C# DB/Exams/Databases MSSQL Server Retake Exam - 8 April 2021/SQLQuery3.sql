--5.Unassigned Reports
SELECT Description,CONVERT(varchar,OpenDate,105) FROM Reports
WHERE EmployeeId IS NULL
ORDER BY OpenDate ASC ,Description ASC 
--06. Reports & Categories
SELECT r.Description,c.Name FROM Reports AS r
JOIN Categories AS c ON c.Id = r.CategoryId
ORDER BY r.Description ASC,c.Name ASC
--07. Most Reported Category
SELECT TOP(5)c.Name,COUNT(*) AS ReportsNumber FROM Reports AS R
JOIN Categories AS c ON R.CategoryId = c.Id
GROUP BY r.CategoryId,c.Name
ORDER BY ReportsNumber DESC ,c.Name

--08. Birthday Report
SELECT u.Username,c.Name FROM Reports AS r
JOIN Users AS u ON u.Id = r.UserId
JOIN Categories AS c ON r.CategoryId = c.Id
WHERE DATEPART(MONTH,u.Birthdate) = DATEPART(MONTH,r.OpenDate) AND DATEPART(DAY,u.Birthdate) = DATEPART(DAY,r.OpenDate)
ORDER BY u.Username ASC,c.Name ASC


--09. User per Employee
SELECT CONCAT(E.FirstName,' ',E.LastName) AS FullName ,COUNT(U.Id) AS UsersCount FROM Employees AS E
LEFT JOIN Reports AS R ON E.Id = R.EmployeeId
LEFT JOIN Users AS U ON R.UserId = U.Id
GROUP BY E.Id,E.FirstName,E.LastName
ORDER BY UsersCount DESC,FullName ASC

--10. Full Info
SELECT ISNULL(E.FirstName + ' ' + E.LastName ,'None') AS Employee,ISNULL(D.Name,'None') AS Department,ISNULL(C.Name,'None') AS Category,ISNULL(R.Description,'None') AS [Description],FORMAT(R.OpenDate,'dd.MM.yyyy') AS OpenDate,ISNULL(S.Label,'None') AS [Status], ISNULL(U.Name ,'None')AS [User] FROM Reports AS R
LEFT JOIN Employees AS E ON R.EmployeeId = E.Id
LEFT JOIN Categories AS C ON C.Id = R.CategoryId
LEFT JOIN Status AS S ON R.StatusId = S.Id
LEFT JOIN Users AS U ON R.UserId = U.Id
LEFT JOIN Departments AS D ON E.DepartmentId = D.Id

ORDER BY E.FirstName DESC,E.LastName DESC,D.Name ASC,C.Name ASC,R.Description ASC,OpenDate ASC,S.Label ASC,U.Name ASC



