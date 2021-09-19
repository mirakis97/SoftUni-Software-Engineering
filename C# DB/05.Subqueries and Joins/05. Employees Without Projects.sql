SELECT TOP (3) e.EmployeeID,e.FirstName  FROM Employees e
  LEFT JOIN EmployeesProjects p ON e.EmployeeID = p.EmployeeID
WHERE p.ProjectID IS NULL
ORDER BY e.EmployeeID ASC