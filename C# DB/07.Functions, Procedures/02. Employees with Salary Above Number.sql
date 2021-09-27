CREATE OR ALTER PROC usp_GetEmployeesSalaryAboveNumber  (@Number DECIMAL(18,4))
AS
	SELECT FirstName,LastName FROM Employees
	WHERE Salary >= @Number

EXEC usp_GetEmployeesSalaryAboveNumber 48100