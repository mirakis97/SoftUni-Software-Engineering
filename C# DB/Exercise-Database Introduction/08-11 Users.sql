CREATE TABLE [Users] (
    [Id] INT IDENTITY PRIMARY KEY,
    [Username] VARCHAR  (30) UNIQUE NOT NULL,
    [Password] VARCHAR(30) NOT NULL,
    [ProfilePicture] VARBINARY(MAX)
	CHECK (DATALENGTH(ProfilePicture) <= 900*1024), 
    [LastLoginTime] DATETIME,
    [IsDeleted ] BIT NOT NULL,
)
 
INSERT INTO [Users] ( [Username],[Password], [ProfilePicture],[LastLoginTime],[IsDeleted ])
VALUES
('Mirakos','ASDa23a',NULL,'1998/08/05',0),
('Kiko','sasd123',NULL,'1998/08/05',1),
('Asko','sdasdc',NULL,'1998/08/05',0),
('Adok','asddds2',NULL,'1998/08/05',1),
('Afoasd','AS123D',NULL,'1998/08/05',0)

--9 Change Primary Key
ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC0776D199CC

ALTER TABLE Users
ADD CONSTRAINT PK_IdUsername PRIMARY KEY (Id,Username)
--10.

ALTER TABLE Users
ADD CONSTRAINT CH_PasswordIsAtLeast5Symbols CHECK (LEN([Password]) >=5)

--11.