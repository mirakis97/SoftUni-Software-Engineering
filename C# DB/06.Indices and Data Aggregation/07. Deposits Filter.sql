SELECT W.DepositGroup,SUM(DepositAmount) AS TotalSum FROM WizzardDeposits AS W
WHERE  W.MagicWandCreator = 'Ollivander family'
GROUP BY W.DepositGroup
HAVING SUM(DepositAmount) < 150000
ORDER BY TotalSum DESC

--SELECT MagicWandCreator FROM WizzardDeposits