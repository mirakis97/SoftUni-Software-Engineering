SELECT TOP(5) e.EmployeeID,e.JobTitle,e.AddressID,a.AddressText FROM Employees AS e
LEFT JOIN Addresses a ON a.AddressID = e.AddressID
ORDER BY AddressID ASC