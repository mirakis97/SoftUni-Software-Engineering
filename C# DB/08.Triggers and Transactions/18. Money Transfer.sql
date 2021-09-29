CREATE PROC usp_TransferMoney(@SenderId INT, @ReceiverId INT, @Amount DECIMAL(12,4))
AS
BEGIN TRANSACTION
	EXECUTE usp_DepositMoney @SenderId,@Amount
	EXECUTE usp_WithdrawMoney @ReceiverId,@Amount
COMMIT