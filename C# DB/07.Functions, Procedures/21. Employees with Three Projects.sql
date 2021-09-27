CREATE PROC usp_AssignProject(@EmployeeId INT, @ProjectId INT)
AS
BEGIN
	DECLARE @maxEmployeeProjectsCount INT = 3

	DECLARE @employeeProjectsCount INT

	SET @employeeProjectsCount =

(	SELECT COUNT(*)
	FROM [dbo].[EmployeesProjects] AS ep
	WHERE ep.EmployeeId = @EmployeeID)

	IF(@employeeProjectsCount >= @maxEmployeeProjectsCount)
	THROW 50001, 'The employee has too many projects!', 1;


	INSERT INTO EmployeesProjects (EmployeeID,ProjectID)
		VALUES (@EmployeeId,@ProjectId)
END