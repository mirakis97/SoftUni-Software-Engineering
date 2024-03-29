CREATE TABLE Majors
(
	MajorID INT PRIMARY KEY NOT NULL,
	Name NVARCHAR(50)
)

CREATE TABLE Students
(
	StudentID INT PRIMARY KEY NOT NULL,
	StudentNumber CHAR(10) NOT NULL,
	StudentName NVARCHAR(50) NOT NULL,
	MajorID INT REFERENCES Majors(MajorID)
)
CREATE TABLE Payments
(
	PaymentID INT PRIMARY KEY NOT NULL,
	PaymentDate DATE NOT NULL,
	PaymentAmount DECIMAL(10,2),
	StudentID INT REFERENCES Students(StudentID)
)
CREATE TABLE Subjects
(
	SubjectID INT PRIMARY KEY NOT NULL,
	SubjectName NVARCHAR(50) NOT NULL
)

CREATE TABLE Agenda
(
	StudentID INT REFERENCES Students(StudentID),
	SubjectID INT REFERENCES Subjects(SubjectID)
	PRIMARY KEY (StudentID,SubjectID)
)