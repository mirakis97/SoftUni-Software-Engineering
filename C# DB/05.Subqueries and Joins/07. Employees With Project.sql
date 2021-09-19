SELECT TOP(5) e.EmployeeID,e.FirstName,d.Name AS [ProjectName] FROM Employees e
JOIN EmployeesProjects p ON p.EmployeeID = e.EmployeeID
JOIN Projects d ON p.ProjectID = d.ProjectID
WHERE d.StartDate > '2002.08.13' AND d.StartDate IS NOT NULL
ORDER BY e.EmployeeID ASC