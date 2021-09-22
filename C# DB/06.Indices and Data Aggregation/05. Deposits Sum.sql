SELECT W.DepositGroup,SUM(DepositAmount) AS TotalSum FROM WizzardDeposits AS W
GROUP BY W.DepositGroup