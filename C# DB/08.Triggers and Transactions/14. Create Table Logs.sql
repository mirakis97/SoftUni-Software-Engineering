CREATE TABLE Logs
(
	LogId INT PRIMARY KEY IDENTITY NOT NULL,
	AccountId INT REFERENCES Accounts(Id) NOT NULL,
	OldSum DECIMAL(12,2) NOT NULL,
	NewSum DECIMAL(12,2) NOT NULL
)

CREATE OR ALTER TRIGGER tr_AccountsChanges
ON Accounts FOR UPDATE
AS
	DECLARE @AccountId INT = (SELECT Id FROM inserted)
	DECLARE @NewSum DECIMAL(12,2) = (SELECT Balance FROM inserted)
	DECLARE @OldSum DECIMAL(12,2) = (SELECT Balance FROM deleted)

	INSERT INTO Logs(AccountId,NewSum,OldSum) VALUES
	(@AccountId,@NewSum,@OldSum)
GO

