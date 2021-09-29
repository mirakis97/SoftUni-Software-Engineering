CREATE TABLE NotificationEmails
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Recipient INT REFERENCES Accounts(Id) NOT NULL,
	[Subject] NVARCHAR(MAX) NOT NULL,
	Body  NVARCHAR(MAX) NOT NULL
)

CREATE TRIGGER tr_NotificationForNewEmail ON Logs
FOR INSERT
AS
	DECLARE @recipient INT = (SELECT AccountId FROM inserted)
	DECLARE @balance NVARCHAR(MAX) = (SELECT 'Balance change for account:' + CAST(AccountId AS nvarchar) FROM inserted)
	DECLARE @body NVARCHAR(MAX) = (SELECT 'On ' + CAST(GETDATE()as nvarchar)+ ' your balance was changed from ' + CAST(OldSum as nvarchar) + ' to ' + CAST(NewSum AS nvarchar) FROM inserted)

	INSERT INTO NotificationEmails(Recipient,[Subject],Body) 
	VALUES(@recipient,@balance,@body)
GO

UPDATE Accounts
SET Balance += 100
WHERE Id = 1

SELECT * FROM Logs
SELECT * FROM NotificationEmails