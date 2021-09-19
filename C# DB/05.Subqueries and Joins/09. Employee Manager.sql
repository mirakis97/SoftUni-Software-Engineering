SELECT e.EmployeeID,e.FirstName,e.ManagerID,d.FirstName AS [ManagerName] FROM Employees AS e
JOIN Employees d ON d.EmployeeID = e.ManagerID
WHERE e.ManagerID = 3 OR e.ManagerID = 7
ORDER BY e.EmployeeID