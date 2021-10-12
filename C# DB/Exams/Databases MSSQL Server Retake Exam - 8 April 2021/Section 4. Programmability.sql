--11.Hours to Complete
CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME) 
RETURNS INT
AS
BEGIN

DECLARE @projectWeeks INT;

IF(@StartDate IS NULL)
BEGIN
	SET @StartDate = 0
END

IF(@EndDate IS NULL)
	BEGIN
		SET @EndDate = 0
	END
SET @projectWeeks = DATEDIFF(HOUR, @StartDate, @EndDate)
RETURN @projectWeeks;
END


SELECT dbo.udf_HoursToComplete(OpenDate, CloseDate) AS TotalHours
   FROM Reports

--12.Assign Employee

CREATE PROC usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS

DECLARE @DepartmentIdOfEmploeey INT = (SELECT D.Id FROM Departments AS D
												JOIN Employees AS E ON E.DepartmentId = D.Id
												WHERE E.Id = @EmployeeId)

DECLARE @DepartmentIdOfReport INT = (SELECT D.Id FROM Departments AS D
												JOIN Categories AS C ON C.DepartmentId = D.Id
												JOIN Reports AS R ON R.CategoryId = C.Id
												WHERE R.Id = @ReportId)	
												
IF (@DepartmentIdOfEmploeey != @DepartmentIdOfReport)
THROW 50001,'Employee doesn''t belong to the appropriate department!',1

UPDATE Reports
SET EmployeeId = @EmployeeId
GO


EXEC usp_AssignEmployeeToReport 30, 1

EXEC usp_AssignEmployeeToReport 17, 2