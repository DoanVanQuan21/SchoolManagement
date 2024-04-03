/*
Created		3/24/2024
Modified		4/3/2024
Project		
Model			
Company		
Author		
Version		
Database		MS SQL 2005 
*/


--Drop table [Lesson] 
--go
--Drop table [EducationProgram] 
--go
--Drop table [Schedule] 
--go
--Drop table [GradeSheet] 
--go
--Drop table [Department] 
--go
--Drop table [Course] 
--go
--Drop table [Teacher] 
--go
--Drop table [Student] 
--go
--Drop table [Class] 
--go
--Drop table [Subject] 
--go
--Drop table [User] 
--go
create database SchoolManagement
go
use SchoolManagement
go

Create table [User]
(
	[UserID] Integer IDENTITY(1,1) NOT NULL,
	[FirstName] Nvarchar(100) NULL,
	[LastName] Nvarchar(100) NULL,
	[Gender] Nvarchar(10) NULL,
	[DateOfBirth] Smalldatetime NULL,
	[PhoneNumber] Varchar(12) NULL,
	[Address] Nvarchar(100) NULL,
	[Email] Nvarchar(100) NULL,
	[Image] Nvarchar(max) NULL,
	[Username] Varchar(100) NULL,
	[Password] Varchar(100) NULL,
	[Role] Nvarchar(100) NULL,
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
	[Image] varchar(max),
Primary Key ([SubjectID])
) 
go

Create table [Class]
(
	[ClassID] Integer IDENTITY(1,1) NOT NULL,
	[ClassCode] Smalldatetime NULL,
	[ClassName] Nvarchar(100) NULL,
	[TeacherID] Integer NOT NULL,
	[Image] varchar(max),
Primary Key ([ClassID])
) 
go

Create table [Student]
(
	[StudentID] Integer IDENTITY(1,1) NOT NULL,
	[StudentCode] Nvarchar(20) NULL,
Primary Key ([StudentID])
) 
go

Create table [Teacher]
(
	[TeacherID] Integer IDENTITY(1,1) NOT NULL,
	[TeacherCode] Nvarchar(100) NULL,
	[Degree] Nvarchar(200) NULL,
	[Expertise_] Nvarchar(100) NULL,
	[University] Nvarchar(100) NULL,
	[GraduationYear] Smalldatetime NULL,
	[Major] Nvarchar(100) NULL,
	[OtherCertifications_] Nvarchar(200) NULL,
	[Position] Nvarchar(100) NULL,
	[Salary] Decimal(18,0) NULL,
	[AdditionalBenifits] Nvarchar(100) NULL,
	[CurrentHealthStatus] Nvarchar(100) NULL,
	[HealthInsuranceInfo_] Nvarchar(100) NULL,
	[SelfIntroduction_] Ntext NULL,
	[DepartmentID] Integer NOT NULL,
	[LeaderID] Integer NOT NULL,
Primary Key ([TeacherID])
) 
go

Create table [Course]
(
	[ClassID] Integer IDENTITY(1,1) NOT NULL,
	[SubjectID] Integer NOT NULL,
	[NumberOfLessons] Integer NULL,
	[StartDate] Smalldatetime NULL,
	[EndDate] Smalldatetime NULL,
	[TeacherID] Integer NOT NULL,
Primary Key ([ClassID],[SubjectID])
) 
go

Create table [Department]
(
	[DepartmentID] Integer IDENTITY(1,1) NOT NULL,
	[DepartmentCode] Nvarchar(20) NULL,
	[DepartmentName] Nvarchar(100) NULL,
	[Image] varchar(max),
Primary Key ([DepartmentID])
) 
go

Create table [GradeSheet]
(
	[GradeSheetID] Integer IDENTITY(1,1) NOT NULL,
	[FirstRegularScore] Decimal(2,2) NULL,
	[SecondRegularScore] Decimal(2,2) NULL,
	[ThirdRegularScore] Decimal(2,2) NULL,
	[FourRegularScore] Decimal(2,2) NULL,
	[MidtermScore] Decimal(2,2) NULL,
	[FinalScore] Decimal(2,2) NULL,
	[SemesterAverage] Decimal(2,2) NULL,
	[ClassID] Integer NOT NULL,
	[SubjectID] Integer NOT NULL,
	[StudentID] Integer NOT NULL,
Primary Key ([GradeSheetID])
) 
go

Create table [Schedule]
(
	[ScheduleID] Integer IDENTITY(1,1) NOT NULL,
	[ScheduleCode] Nvarchar(100) NULL,
	[Day] Smalldatetime NULL,
	[Start] Timestamp NULL,
	[End] Timestamp NULL,
	[ClassID] Integer NOT NULL,
	[SubjectID] Integer NOT NULL,
Primary Key ([ScheduleID])
) 
go

Create table [EducationProgram]
(
	[EducationProgramID] Integer IDENTITY(1,1) NOT NULL,
	[EducationProgramCode] Nvarchar(20) NULL,
	[EducationName] Nvarchar(100) NULL,
	[Status] Nvarchar(100) NULL,
	[ClassID] Integer NOT NULL,
	[SubjectID] Integer NOT NULL,
Primary Key ([EducationProgramID])
) 
go

Create table [Lesson]
(
	[LessonID] Integer IDENTITY(1,1) NOT NULL,
	[LessonCode] Nvarchar(100) NULL,
	[LessonName] Nvarchar(100) NULL,
	[VideoUrl] Varchar(max) NULL,
	[ImageUrl] Varchar(max) NULL,
	[Status] Nvarchar(100) NULL,
	[EducationProgramID] Integer NOT NULL,
Primary Key ([LessonID])
) 
go


Set quoted_identifier on
go


Set quoted_identifier off
go


