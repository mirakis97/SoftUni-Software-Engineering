SELECT SUBSTRING(W.FirstName,1,1) FROM WizzardDeposits AS W
WHERE W.DepositGroup = 'Troll Chest'
GROUP BY SUBSTRING(W.FirstName,1,1)


--SELECT DepositGroup FROM WizzardDeposits