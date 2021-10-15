--5. Teen Students
SELECT FirstName,LastName,Age FROM Students
WHERE Age >= 12
ORDER BY FirstName ASC, LastName ASC

--6. Cool Addresses

SELECT CONCAT(FirstName,' ',MiddleName,' ',LastName) AS [Full Name],Address  FROM Students
WHERE Address LIKE '%road%'
ORDER BY FirstName ASC,LastName ASC, Address ASC


--7. 42 Phones
SELECT FirstName,Address,Phone FROM Students
WHERE Phone LIKE '42%' AND MiddleName IS NOT NULL
ORDER BY FirstName 

--8. Students Teachers
SELECT s.FirstName,s.LastName,COUNT(t.Id) AS TeachersCount FROM Students AS s
JOIN StudentsTeachers AS st ON s.Id = st.StudentId
JOIN Teachers AS t ON st.TeacherId = t.Id
GROUP BY s.LastName,s.Id,s.FirstName


--9. Subjects with Students
SELECT CONCAT(t.FirstName,' ',t.LastName)AS FullName ,CONCAT(s.Name,'-',s.Lessons) AS Subjects,COUNT(st.StudentId) AS Students FROM Teachers AS t
JOIN Subjects AS s ON t.SubjectId = s.Id
JOIN StudentsTeachers AS st ON t.Id = st.TeacherId
GROUP BY t.Id,t.FirstName,t.LastName,s.Name,s.Lessons
ORDER BY COUNT(st.StudentId) DESC,FullName ASC,Subjects ASC

--10. Students to Go
SELECT FROM Students AS s
JOIN StudentsExams  AS se ON s.Id = se.StudentId
