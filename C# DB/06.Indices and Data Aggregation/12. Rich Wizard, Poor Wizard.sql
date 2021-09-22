SELECT SUM(G.DepositAmount - W.DepositAmount) FROM WizzardDeposits AS W
JOIN WizzardDeposits AS G ON G.Id + 1 = W.Id