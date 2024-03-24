/*
Created		3/24/2024
Modified		3/24/2024
Project		
Model			
Company		
Author		
Version		
Database		MS SQL 2005 
*/

Create database SchoolManagement
Go
Use SchoolManagement
Go
Drop table [ClassUser] 
go
Drop table [Class] 
go
Drop table [GradeSheet] 
go
Drop table [Subject] 
go
Drop table [User] 
go


Create table [User]
(
	[UserID] Integer IDENTITY(1,1) NOT NULL,
	[UserCode] Varchar(15) NULL,
	[Surname] Nvarchar(100) NULL,
	[Name] Nvarchar(100) NULL,
	[Gender] Nvarchar(10) NULL,
	[DateOfBirth] Smalldatetime NULL,
	[PhoneNumber] Varchar(12) NULL,
	[Address] Nvarchar(100) NULL,
	[Email] Nvarchar(100) NULL,
	[Image] Nvarchar(1000) NULL,
	[Username] Varchar(100) NULL,
	[Password] Varchar(100) NULL,
	[ActiveStatus] Bit NULL,
	[StartDate] Smalldatetime NULL,
	[EndDate] Smalldatetime NULL,
Primary Key ([UserID])
) 
go

Create table [Subject]
(
	[SubjectID] Integer IDENTITY(1,1) NOT NULL,
	[SubjectCode] Varchar(15) NULL,
	[SubjectName] Nvarchar(100) NULL,
Primary Key ([SubjectID])
) 
go

Create table [GradeSheet]
(
	[GradeSheetID] Integer IDENTITY(1,1) NOT NULL,
	[GradeSheetCode] Varchar(20) NULL,
	[FirstScore] Float NULL,
	[SecondScore] Float NULL,
	[ThirdScore] Float NULL,
	[FinalScore] Float NULL,
	[AverageScore] Float NULL,
	[SubjectID] Integer NOT NULL,
	[UserID] Integer NOT NULL,
Primary Key ([GradeSheetID])
) 
go

Create table [Class]
(
	[ClassID] Integer IDENTITY(1,1) NOT NULL,
	[ClassCode] Smalldatetime NULL,
	[ClassName] Nvarchar(100) NULL,
Primary Key ([ClassID])
) 
go

Create table [ClassUser]
(
	[ClassID] Integer NOT NULL,
	[UserID] Integer NOT NULL,
	[Position] Nvarchar(100) NULL,
	[Status] Nvarchar(100) NULL,
	[StartDate] Smalldatetime NULL,
	[EndDate] Smalldatetime NULL,
Primary Key ([ClassID],[UserID])
) 
go


Set quoted_identifier on
go


Set quoted_identifier off
go


