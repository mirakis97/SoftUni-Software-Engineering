CREATE PROC usp_DepositMoney (@AccountId INT, @MoneyAmount DECIMAL(12,4))
AS
	BEGIN TRANSACTION
	IF (@MoneyAmount < 0)
	THROW 50001, 'Can`t make transaction with negative number!',1
	IF @AccountId = 0
	THROW 50002, 'There is no customer with that id!',1
	UPDATE Accounts SET Balance += @MoneyAmount
	WHERE Id = @AccountId

COMMIT

SELECT * FROM Accounts
WHERE Id = 1

EXECUTE usp_DepositMoney 1,100