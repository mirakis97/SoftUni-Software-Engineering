SELECT FirstName AS [First Name],LastName AS [Last Name],HireDate,d.Name AS [DeptName]
FROM Employees e
JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE e.HireDate > '1999-01-01' AND
(d.Name = 'Sales' OR d.Name ='Finance')
ORDER BY HireDate