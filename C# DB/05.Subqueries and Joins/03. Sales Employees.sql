SELECT EmployeeID,FirstName AS [First Name],LastName AS [Last Name],d.Name AS [Department Name]
FROM Employees e
JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'