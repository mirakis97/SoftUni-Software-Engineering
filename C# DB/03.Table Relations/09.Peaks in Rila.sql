SELECT MountainRange,Peaks.PeakName,Peaks.Elevation 
FROM Mountains
JOIN Peaks ON Peaks.MountainId=Mountains.Id
AND Mountains.MountainRange='Rila'
ORDER BY Peaks.Elevation DESC;