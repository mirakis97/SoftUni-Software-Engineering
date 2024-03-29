--1.Database Design

CREATE DATABASE Bitbucket
USE Bitbucket

CREATE TABLE Users 
(
	Id INT IDENTITY PRIMARY KEY NOT NULL,
	Username VARCHAR (30) NOT NULL,
	[Password] VARCHAR (30) NOT NULL,
	Email VARCHAR (50) NOT NULL,
)

CREATE TABLE Repositories
(
	Id INT IDENTITY PRIMARY KEY NOT NULL,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE RepositoriesContributors
(
	RepositoryId INT REFERENCES Repositories(Id) NOT NULL,
	ContributorId INT REFERENCES Users(Id) NOT NULL,
			PRIMARY KEY (RepositoryId, ContributorId)
)

CREATE TABLE Issues
(
	Id INT IDENTITY PRIMARY KEY NOT NULL,
	Title VARCHAR (255) NOT NULL,
	IssueStatus CHAR(6) NOT NULL,
	RepositoryId INT REFERENCES Repositories(Id) NOT NULL,
	AssigneeId INT REFERENCES Users(Id) NOT NULL,
)

CREATE TABLE Commits
(
	Id INT IDENTITY PRIMARY KEY NOT NULL,
	[Message] VARCHAR (255) NOT NULL,
	IssueId INT REFERENCES Issues(Id),
	RepositoryId INT REFERENCES Repositories(Id) NOT NULL,
	ContributorId INT REFERENCES Users(Id) NOT NULL,
)

CREATE TABLE Files
(
	Id INT IDENTITY PRIMARY KEY NOT NULL,
	[Name] VARCHAR (100) NOT NULL,
	Size DECIMAL(15,2) NOT NULL,
	ParentId INT REFERENCES Files(Id),
	CommitId INT REFERENCES Commits(Id) NOT NULL,
)