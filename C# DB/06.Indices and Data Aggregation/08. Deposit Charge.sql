SELECT W.DepositGroup,W.MagicWandCreator,MIN(W.DepositCharge) FROM WizzardDeposits AS W
GROUP BY W.DepositGroup,W.MagicWandCreator
ORDER BY W.MagicWandCreator,W.DepositGroup ASC