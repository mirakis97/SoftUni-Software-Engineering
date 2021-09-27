CREATE PROC usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS BEGIN TRANSACTION
	ALTER TABLE Employees ALTER COLUMN MangerID INT
	ALTER TABLE Employees ALTER COLUMN DepartmentID INT

	UPDATE Employees SET DepartmentID = NULL WHERE EmployeeID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmentId)
	UPDATE Employees SET ManagerID = NULL WHERE ManagerID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmentId)
	ALTER TABLE Departments ALTER COLUMN ManagerId INT
	UPDATE Departments SET ManagerID = NULL WHERE ManagerID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmentId)

	DELETE FROM EmployeesProjects WHERE EmployeeID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmentId)
	DELETE FROM Employees 
	WHERE DepartmentID = @departmentId
	DELETE FROM Departments
	WHERE DepartmentID = @departmentId
	SELECT COUNT(*) FROM Employees WHERE DepartmentID = @departmentId
COMMIT
