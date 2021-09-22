SELECT TOP(10) e.FirstName,e.LastName,e.DepartmentID FROM Employees AS e
WHERE Salary > (SELECT AVG(Salary) FROM Employees
WHERE DepartmentID = e.DepartmentID
GROUP BY DepartmentID)
ORDER BY e.DepartmentID