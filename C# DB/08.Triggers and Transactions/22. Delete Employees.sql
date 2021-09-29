CREATE TABLE Deleted_Employees
(
	EmployeeId INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName NVARCHAR(MAX),
	MiddleName NVARCHAR(MAX),
	LastName NVARCHAR(MAX),
	JobTitle NVARCHAR(MAX),
	DepartmentId INT FOREIGN KEY REFERENCES Departments(DepartmentId),
	Salary MONEY 
)


CREATE TRIGGER tr_DeleteEmployees ON Employees FOR DELETE
AS
INSERT INTO Deleted_Employees
(FirstName,LastName,MiddleName,JobTitle,DepartmentId,Salary)
SELECT
	FirstName,
	LastName,
	MiddleName,
	JobTitle,
	DepartmentID,
	Salary
FROM deleted