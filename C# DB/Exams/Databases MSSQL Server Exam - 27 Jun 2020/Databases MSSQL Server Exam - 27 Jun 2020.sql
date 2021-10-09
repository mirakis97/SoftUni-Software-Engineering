

CREATE DATABASE WMS
USE WMS

CREATE TABLE Clients
(
	ClientId INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName NVARCHAR(50),
	LastName NVARCHAR(50),
	Phone CHAR(12)
)

CREATE TABLE Mechanics
(
	MechanicId INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName NVARCHAR(50),
	LastName NVARCHAR(50),
	[Address] NVARCHAR(255)
)

CREATE TABLE Models
(
	ModelId INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) UNIQUE
)

CREATE TABLE Jobs
(
	JobId INT PRIMARY KEY IDENTITY NOT NULL,
	ModelId INT REFERENCES Models(ModelId),
	[Status] CHAR(11) DEFAULT 'Pending',
	ClientId INT REFERENCES Clients(ClientId),
	MechanicId INT REFERENCES Mechanics(MechanicId),
	IssueDate DATE,
	FinishDate DATE
)

CREATE TABLE Orders
(
	OrderId INT PRIMARY KEY IDENTITY NOT NULL,
	JobId INT REFERENCES Jobs(JobId),
	IssueDate DATE,
	Delivered  BIT DEFAULT 0 NOT NULL,
)

CREATE TABLE Vendors
(
	VendorId INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] NVARCHAR(50) UNIQUE
)

CREATE TABLE Parts
(
	PartId INT PRIMARY KEY IDENTITY NOT NULL,
	SerialNumber NVARCHAR(50) UNIQUE,
	[Description] NVARCHAR(255),
	Price DECIMAL(15,2) NOT NULL CHECK(Price > 0),
	VendorId INT REFERENCES Vendors(VendorId),
	StockQty INT CHECK (StockQty > 0) DEFAULT 0
)

CREATE TABLE OrderParts
(
	OrderId INT REFERENCES Orders(OrderId),
	PartId INT REFERENCES Parts(PartId),
	Quantity INT CHECK(Quantity > 0) DEFAULT 1
		PRIMARY KEY (OrderId, PartId)
)

CREATE TABLE PartsNeeded
(
	JobId INT REFERENCES Jobs(JobId),
	PartId INT REFERENCES Parts(PartId),
	Quantity INT CHECK(Quantity > 0) DEFAULT 1
		PRIMARY KEY (JobId, PartId)
)

--02 Insert

INSERT INTO Clients VALUES
('Teri','Ennaco','570-889-5187'),
('Merlyn','Lawler','201-588-7810'),
('Georgene','Montezuma','925-615-5185'),
('Jettie','Mconnell','908-802-3564'),
('Lemuel','Latzke','631-748-6479'),
('Melodie','Knipp','805-690-1682'),
('Candida','Corbley','908-275-8357')

INSERT INTO  Parts(SerialNumber,Description,Price,VendorId) VALUES
('WP8182119','Door Boot Seal',117.86,2),
('W10780048','Suspension Rod',42.81,1),
('W10841140','Silicone Adhesive ',6.77,4),
('WPY055980','High Temperature Adhesive',13.94,3)

--03.Update

UPDATE Jobs
SET MechanicId = 3,Status = 'In Progress'
WHERE Status LIKE 'Pending'

--04. Delete
DELETE FROM OrderParts
WHERE OrderId = 19
DELETE FROM Orders
WHERE OrderId = 19

--05. Mechanic Assignments
SELECT CONCAT(m.FirstName,+ ' ',+ m.LastName) AS Mechanic,j.Status,j.IssueDate FROM Mechanics AS m
JOIN Jobs AS j ON j.MechanicId = m.MechanicId
ORDER BY m.MechanicId ASC,j.IssueDate ASC,j.JobId ASC

--06. Current Clients
SELECT CONCAT(c.FirstName,+ ' ',+ c.LastName) AS Client,DATEDIFF(DAY,j.IssueDate,'2017-04-24') AS [Days going],j.Status  FROM Clients AS c
JOIN Jobs AS j ON j.ClientId = c.ClientId
WHERE j.Status != 'Finished'
ORDER BY [Days going] DESC,c.ClientId ASC

--07. Mechanic Performance
SELECT CONCAT(m.FirstName,+ ' ',+ m.LastName) AS Mechanic,AVG(DATEDIFF(DAY,j.IssueDate,j.FinishDate)) AS [Average Days] FROM Mechanics AS m
JOIN Jobs AS j ON j.MechanicId = m.MechanicId
GROUP BY m.FirstName,m.LastName,m.MechanicId
ORDER BY m.MechanicId

--08. Available Mechanics
SELECT M.FirstName +' '+M.LastName
FROM Mechanics AS M
LEFT JOIN Jobs J on M.MechanicId = J.MechanicId
WHERE J.Status ='Finished' OR J.JobId IS NULL
ORDER BY M.MechanicId

--09. Past Expenses
SELECT j.JobId, ISNULL(SUM(p.Price * op.Quantity),0) AS Total FROM Jobs AS j
LEFT JOIN Orders AS o ON o.JobId = j.JobId
LEFT JOIN OrderParts AS op ON op.OrderId = o.OrderId
LEFT JOIN Parts AS p ON op.PartId = p.PartId
WHERE j.Status = 'Finished'
GROUP BY j.JobId
ORDER BY SUM(p.Price) DESC, j.JobId ASC

--10. Missing Parts
SELECT 
	   P.PartId,
       P.Description,
       PN.Quantity as Required,
       P.StockQty,
	   IIF(O.Delivered = 0, OP.Quantity, 0)
FROM Parts AS P
	LEFT JOIN PartsNeeded AS PN ON P.PartId  = PN.PartId
	LEFT JOIN OrderParts  AS OP ON P.PartId  = OP.PartId
	LEFT JOIN Orders      AS O  ON O.OrderId = OP.OrderId
	LEFT JOIN Jobs        AS J  ON J.JobId   = PN.JobId
	WHERE J.Status !='Finished'  AND 
	(P.StockQty +  IIF(O.Delivered = 0, OP.Quantity, 0))< PN.Quantity
	ORDER BY PartId

--11. Place Order
CREATE OR ALTER PROCEDURE usp_PlaceOrder(@jobID INT, @PartSerialNumber NVARCHAR(50),@Quantity INT )
AS
BEGIN
	IF(@Quantity <= 0)
	THROW  50012,'Part quantity must be more than zero!',1

	IF(@jobID IN ((SELECT JobId FROM Jobs WHERE Status LIKE 'Finished')))
	THROW 50011 ,'This job is not active!',1

	IF(@jobID NOT IN ((SELECT JobId FROM Jobs)))
	THROW 50013,'Job not found!',1

	IF(@PartSerialNumber NOT IN (SELECT SerialNumber FROM Parts))
	THROW 50014,'Part not found!',1

	IF(@jobID IN (SELECT JobId FROM Jobs) AND (SELECT IssueDate FROM Orders WHERE JobId = @jobID) IS NULL)
	BEGIN
		DECLARE @OrderId INT = (SELECT OrderId FROM Orders WHERE JobId =@jobID AND IssueDate IS NULL)
		DECLARE @PartId INT = (SELECT PartId FROM Parts WHERE SerialNumber = @PartSerialNumber)
		IF (@OrderId IN (SELECT OrderId FROM Orders) AND @PartId IN (SELECT PartId FROM OrderParts))
			BEGIN
			UPDATE OrderParts
			SET Quantity += @Quantity
			WHERE OrderId = @OrderId AND PartId =@PartId
			END
		ELSE
		BEGIN 
			INSERT INTO OrderParts(OrderId,PartId,Quantity)
			VALUES(@OrderId,@PartId,@Quantity)
		END
	END
END

DECLARE @err_msg AS NVARCHAR(MAX);
BEGIN TRY
  EXEC usp_PlaceOrder 1, 'ZeroQuantity', 0
END TRY

BEGIN CATCH
  SET @err_msg = ERROR_MESSAGE();
  SELECT @err_msg
END CATCH


--12. Cost Of Order

CREATE FUNCTION udf_GetCost(@JobId INT)
RETURNS DECIMAL(18,2)
AS
BEGIN
	DECLARE @Result DECIMAL(18,2) =	(SELECT SUM(Price) AS Result FROM Parts AS p
	JOIN OrderParts AS op ON p.PartId = op.PartId
	JOIN Orders AS o ON o.OrderId = op.OrderId
	JOIN Jobs AS j ON j.JobId = o.JobId
	WHERE j.JobId = @jobID)

RETURN ISNULL(@Result,0)
END

SELECT dbo.udf_GetCost(1)