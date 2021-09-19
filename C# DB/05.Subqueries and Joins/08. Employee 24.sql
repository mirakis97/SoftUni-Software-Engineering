SELECT e.EmployeeID,e.FirstName,CASE WHEN YEAR(d.StartDate)>=2005 THEN NULL
ELSE d.Name
END AS ProjectName FROM Employees e
JOIN EmployeesProjects p ON p.EmployeeID = e.EmployeeID
JOIN Projects d ON p.ProjectID = d.ProjectID
WHERE e.EmployeeID = 24 
