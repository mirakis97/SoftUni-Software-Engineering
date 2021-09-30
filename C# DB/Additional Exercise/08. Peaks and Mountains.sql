SELECT p.PeakName,m.MountainRange AS Mountain,p.Elevation FROM Peaks AS p
JOIN Mountains AS m ON m.Id = p.MountainId
ORDER BY p.Elevation DESC,p.PeakName