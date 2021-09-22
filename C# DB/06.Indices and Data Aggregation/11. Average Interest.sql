SELECT W.DepositGroup,W.IsDepositExpired,AVG(W.DepositInterest) AS AverageInterest   FROM WizzardDeposits AS W
WHERE W.DepositStartDate > '1985.01.01' 
GROUP BY W.DepositGroup,W.IsDepositExpired
ORDER BY W.DepositGroup DESC,W.IsDepositExpired ASC
