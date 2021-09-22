SELECT W.DepositGroup,MAX(W.MagicWandSize) FROM WizzardDeposits AS W
GROUP BY W.DepositGroup