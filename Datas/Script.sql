/*
Created		3/24/2024
Modified		5/8/2024
Project		
Model			
Company		
Author		
Version		
Database		MS SQL 2005 
*/

Create database SchoolManagement
go
use SchoolManagement
go
--START USER--
Create table [User]
(
	[UserID] Integer IDENTITY(1,1) NOT NULL,
	[FirstName] nvarchar(100) NULL,
	[LastName] nvarchar(100) NULL,
	[Gender] nvarchar(10) NULL,
	[DateOfBirth] Datetime NULL,
	[PhoneNumber] nvarchar(12) NULL,
	[Address] nvarchar(100) NULL,
	[Email] nvarchar(100) NULL,
	[Image] nvarchar(max) NULL,
	[Username] nvarchar(100) NULL,
	[Password] nvarchar(100) NULL,
	[Role] nvarchar(100) NULL,
	[ActiveStatus] Tinyint NULL,
	[StartDate] Datetime NULL,
	[EndDate] Datetime NULL,
	[LockAccount] bit ,
Primary Key ([UserID])
) 
go
INSERT [dbo].[User] ([FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate],[LockAccount]) VALUES (N'Đoàn Văn', N'Quân', N'Nam', CAST(N'2002-05-21T00:00:00.000' AS DateTime), N'0987654321', N'Việt Tiến, Việt Yên, Bắc Giang', N'hoangnguyen@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'admin', N'admin', N'admin', 1, CAST(N'2017-01-01T00:00:00.000' AS DateTime), NULL,0)
INSERT [dbo].[User] ([FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate],[LockAccount]) VALUES (N'Đoàn Văn', N'Chính', N'Nam', CAST(N'2004-02-21T00:00:00.000' AS DateTime), N'0976543210', N'Việt Tiến, Việt Yên, Bắc Giang', N'doanvanchinh@gmail.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'chinh', N'chinh', N'teacher', 1, CAST(N'2019-12-10T00:00:00.000' AS DateTime), NULL,0)
INSERT [dbo].[User] ([FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate],[LockAccount]) VALUES (N'An Hương', N'Lan', N'Nữ', CAST(N'2002-05-07T00:00:00.000' AS DateTime), N'0965432109', N'Việt Tiến, Việt Yên, Bắc Giang', N'ducle@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'lan', N'lan', N'teacher', 1, CAST(N'2017-02-15T00:00:00.000' AS DateTime), NULL,0)
INSERT [dbo].[User] ([FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate],[LockAccount]) VALUES (N'Lê Thị Thu', N'Trà', N'Nữ', CAST(N'2002-05-12T00:00:00.000' AS DateTime), N'0954321098', N'Việt Tiến, Việt Yên, Bắc Giang', N'anhnguyen@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'tra', N'tra', N'teacher', 1, CAST(N'2017-03-20T00:00:00.000' AS DateTime), NULL,0)
INSERT [dbo].[User] ([FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate],[LockAccount]) VALUES (N'Đỗ Đăng', N'Kiên', N'Nam', CAST(N'2002-05-12T00:00:00.000' AS DateTime), N'0943210987', N'Việt Tiến, Việt Yên, Bắc Giang', N'thaopham@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'kien', N'kien', N'teacher', 1, CAST(N'2017-11-11T00:00:00.000' AS DateTime), NULL,0)
INSERT [dbo].[User] ([FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate],[LockAccount]) VALUES (N'Phạm Văn', N'Long', N'Nam', CAST(N'2002-05-12T00:00:00.000' AS DateTime), N'0932109876', N'Việt Tiến, Việt Yên, Bắc Giang', N'tuanhuynh@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'long', N'long', N'teacher', 1, CAST(N'2019-10-05T00:00:00.000' AS DateTime), NULL,0)
INSERT [dbo].[User] ([FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate],[LockAccount]) VALUES (N'Thành', N'Võ', N'Nam', CAST(N'2008-05-12T00:00:00.000' AS DateTime), N'0910987654', N'Việt Tiến, Việt Yên, Bắc Giang', N'thanhvo@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'student', N'student', N'student', 1, CAST(N'2020-05-15T00:00:00.000' AS DateTime), NULL,0)
INSERT [dbo].[User] ([FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate],[LockAccount]) VALUES (N'Loan', N'Trần', N'Nữ', CAST(N'2008-05-12T00:00:00.000' AS DateTime), N'0909876543', N'Việt Tiến, Việt Yên, Bắc Giang', N'loantran@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'loantran', N'loan@2022', N'student', 1, CAST(N'2017-09-20T00:00:00.000' AS DateTime), NULL,0)
INSERT [dbo].[User] ([FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate],[LockAccount]) VALUES (N'Hải', N'Lê', N'Nam', CAST(N'2008-05-12T00:00:00.000' AS DateTime), N'0898765432', N'Việt Tiến, Việt Yên, Bắc Giang', N'haile@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'haile', N'haile123', N'student', 1, CAST(N'2019-08-12T00:00:00.000' AS DateTime), NULL,0)
INSERT [dbo].[User] ([FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate],[LockAccount]) VALUES (N'Minh', N'Đặng', N'Nam', CAST(N'2008-05-12T00:00:00.000' AS DateTime), N'0887654321', N'Việt Tiến, Việt Yên, Bắc Giang', N'minhdang@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'minhdang', N'minh@123', N'student', 1, CAST(N'2018-04-25T00:00:00.000' AS DateTime), NULL,0)
INSERT [dbo].[User] ([FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate],[LockAccount]) VALUES (N'Thúy', N'Hoàng', N'Nữ', CAST(N'2008-05-12T00:00:00.000' AS DateTime), N'0876543210', N'Việt Tiến, Việt Yên, Bắc Giang', N'thuyhoang@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'thuyhoang', N'thuy@2023', N'student', 1, CAST(N'2020-11-30T00:00:00.000' AS DateTime), NULL,0)
INSERT [dbo].[User] ([FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate],[LockAccount]) VALUES (N'Dương', N'Lê', N'Nam', CAST(N'2008-05-12T00:00:00.000' AS DateTime), N'0865432109', N'Việt Tiến, Việt Yên, Bắc Giang', N'duongle@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'duongle', N'duong123', N'student', 1, CAST(N'2021-03-01T00:00:00.000' AS DateTime), NULL,0)
INSERT [dbo].[User] ([FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate],[LockAccount]) VALUES (N'Quỳnh', N'Nguyễn', N'Nữ', CAST(N'2008-05-12T00:00:00.000' AS DateTime), N'0854321098', N'Việt Tiến, Việt Yên, Bắc Giang', N'quynhnguyen@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'quynhnguyen', N'quynh@123', N'student', 1, CAST(N'2019-07-10T00:00:00.000' AS DateTime), NULL,0)
INSERT [dbo].[User] ([FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate],[LockAccount]) VALUES (N'Thắng', N'Huỳnh', N'Nam', CAST(N'2008-05-12T00:00:00.000' AS DateTime), N'0843210987', N'Việt Tiến, Việt Yên, Bắc Giang', N'thanghuynh@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'thanghuynh', N'thang789', N'teacher', 1, CAST(N'2017-12-05T00:00:00.000' AS DateTime), NULL,0)


Create table [Subject]
(
	[SubjectID] Integer IDENTITY(1,1)  NOT NULL,
	[SubjectCode] nvarchar(15) NULL,
	[SubjectName] nvarchar(100) NULL,
	[Image] nvarchar(max) NULL,
Primary Key ([SubjectID])
) 
go
INSERT [dbo].[Subject] ([SubjectCode], [SubjectName], [Image]) VALUES (N'MATH101', N'Toán', N'https://example.com/math101.jpg')
INSERT [dbo].[Subject] ([SubjectCode], [SubjectName], [Image]) VALUES (N'ENG101', N'Tiếng Anh', N'https://example.com/eng101.jpg')
INSERT [dbo].[Subject] ([SubjectCode], [SubjectName], [Image]) VALUES (N'PHY101', N'Vật lý', N'https://example.com/phy101.jpg')
INSERT [dbo].[Subject] ([SubjectCode], [SubjectName], [Image]) VALUES (N'CHEM101', N'Hóa học', N'https://example.com/chem101.jpg')
INSERT [dbo].[Subject] ([SubjectCode], [SubjectName], [Image]) VALUES (N'BIO101', N'Sinh học', N'https://example.com/bio101.jpg')
INSERT [dbo].[Subject] ([SubjectCode], [SubjectName], [Image]) VALUES (N'HIST101', N'Lịch sử', N'https://example.com/hist101.jpg')
INSERT [dbo].[Subject] ([SubjectCode], [SubjectName], [Image]) VALUES (N'GEOG101', N'Thể dục', N'https://example.com/geog101.jpg')
INSERT [dbo].[Subject] ([SubjectCode], [SubjectName], [Image]) VALUES (N'COMP101', N'Tin học', N'https://example.com/comp101.jpg')
INSERT [dbo].[Subject] ([SubjectCode], [SubjectName], [Image]) VALUES (N'MUS101', N'Văn học', N'https://example.com/mus101.jpg')
INSERT [dbo].[Subject] ([SubjectCode], [SubjectName], [Image]) VALUES ( N'ART101', N'Địa lý', N'https://example.com/art101.jpg')
-- end subject

Create table [Student]
(
	[StudentID] Integer IDENTITY(1,1) NOT NULL,
	[UserID] Integer NOT NULL Foreign key ([UserID]) REFERENCES [User]([UserID]) ON UPDATE CASCADE ON DELETE CASCADE,
	[StudentCode] nvarchar(20) NULL,
Primary Key ([StudentID])
) 
go

INSERT [dbo].[Student] ([UserID], [StudentCode]) VALUES (7, N'STD001')
INSERT [dbo].[Student] ([UserID], [StudentCode]) VALUES (8, N'STD002')
INSERT [dbo].[Student] ([UserID], [StudentCode]) VALUES (9, N'STD003')
INSERT [dbo].[Student] ([UserID], [StudentCode]) VALUES (10, N'STD004')
INSERT [dbo].[Student] ([UserID], [StudentCode]) VALUES (11, N'STD005')
INSERT [dbo].[Student] ([UserID], [StudentCode]) VALUES (12, N'STD005')
INSERT [dbo].[Student] ([UserID], [StudentCode]) VALUES (13, N'STD005')

-- end student 
Create table [Department]
(
	[DepartmentID] Integer IDENTITY(1,1) NOT NULL,
	[DepartmentCode] nvarchar(20) NULL,
	[DepartmentName] nvarchar(100) NULL,
	[FoundingDate] Datetime NULL,
	[Image] nvarchar(100) NULL,
Primary Key ([DepartmentID])
) 
go

INSERT [dbo].[Department] ([DepartmentCode], [DepartmentName], [FoundingDate], [Image]) VALUES (N'DEPT001', N'Toán học', CAST(N'1990-01-01T00:00:00.000' AS DateTime), N'https://example.com/toanhoc.jpg')
INSERT [dbo].[Department] ([DepartmentCode], [DepartmentName], [FoundingDate], [Image]) VALUES (N'DEPT002', N'Hóa học', CAST(N'1992-05-10T00:00:00.000' AS DateTime), N'https://example.com/hoahoc.jpg')
INSERT [dbo].[Department] ([DepartmentCode], [DepartmentName], [FoundingDate], [Image]) VALUES (N'DEPT003', N'Sinh học', CAST(N'1995-09-20T00:00:00.000' AS DateTime), N'https://example.com/sinhhoc.jpg')
INSERT [dbo].[Department] ([DepartmentCode], [DepartmentName], [FoundingDate], [Image]) VALUES (N'DEPT004', N'Lịch sử', CAST(N'1988-03-15T00:00:00.000' AS DateTime), N'https://example.com/lichsu.jpg')
INSERT [dbo].[Department] ([DepartmentCode], [DepartmentName], [FoundingDate], [Image]) VALUES (N'DEPT005', N'Văn học', CAST(N'1997-11-30T00:00:00.000' AS DateTime), N'https://example.com/vanhoc.jpg')
INSERT [dbo].[Department] ([DepartmentCode], [DepartmentName], [FoundingDate], [Image]) VALUES (N'DEPT006', N'Địa lý', CAST(N'1994-07-25T00:00:00.000' AS DateTime), N'https://example.com/diali.jpg')


-- end department
Create table [Teacher]
(
	[TeacherID] Integer IDENTITY(1,1) NOT NULL,
	[DepartmentID] Integer NOT NULL Foreign key ([DepartmentID]) REFERENCES [Department]([DepartmentID]) ON UPDATE NO ACTION ON DELETE NO ACTION,
	[UserID] Integer NOT NULL Foreign key ([UserID]) REFERENCES [User]([UserID]) ON UPDATE CASCADE ON DELETE CASCADE,
	[SubjectID] Integer NOT NULL Foreign key ([SubjectID]) REFERENCES [Subject]([SubjectID]) ON UPDATE NO ACTION ON DELETE NO ACTION,
	[TeacherCode] nvarchar(100) NULL,
	[Degree] nvarchar(200) NULL,
	[Expertise] nvarchar(100) NULL,
	[University] nvarchar(100) NULL,
	[GraduationYear] Datetime NULL,
	[Major] nvarchar(100) NULL,
	[OtherCertifications] nvarchar(200) NULL,
	[Position] nvarchar(100) NULL,
	[Salary] Decimal(18,0) NULL,
	[AdditionalBenifits] nvarchar(100) NULL,
	[CurrentHealthStatus] nvarchar(100) NULL,
	[HealthInsuranceInfo] nvarchar(100) NULL,
	[SelfIntroduction] Text NULL,
	[IsLeader] Bit NULL,
Primary Key ([TeacherID])
) 
go

INSERT [dbo].[Teacher] ([DepartmentID], [UserID], [TeacherCode], [Degree], [Expertise], [University], [GraduationYear], [Major], [OtherCertifications], [Position], [Salary], [AdditionalBenifits], [CurrentHealthStatus], [HealthInsuranceInfo], [SelfIntroduction], [SubjectID]  ,[IsLeader]) VALUES (4, 2, N'TC001', N'Thạc sĩ', N'Toán học', N'Đại học Quốc gia Hà Nội', CAST(N'2010-01-01T00:00:00.000' AS DateTime), N'Lịch sử', NULL, N'Giáo viên', CAST(30000000 AS Decimal(18, 0)), N'Bảo hiểm y tế', N'Bình thường', N'Bảo hiểm BHYT số 123456789', N'Tôi là m?t giáo viên Toán có kinh nghi?m', 6,1)
INSERT [dbo].[Teacher] ([DepartmentID], [UserID], [TeacherCode], [Degree], [Expertise], [University], [GraduationYear], [Major], [OtherCertifications], [Position], [Salary], [AdditionalBenifits], [CurrentHealthStatus], [HealthInsuranceInfo], [SelfIntroduction], [SubjectID]  ,[IsLeader]) VALUES (2, 3, N'TC001', N'Thạc sĩ', N'Toán học', N'Đại học Quốc gia Hà Nội', CAST(N'2010-01-01T00:00:00.000' AS DateTime), N'Hóa học', NULL, N'Giáo viên', CAST(30000000 AS Decimal(18, 0)), N'Bảo hiểm y tế', N'Bình thường', N'Bảo hiểm BHYT số 123456789', N'Tôi là m?t giáo viên Toán có kinh nghi?m', 4,1)
INSERT [dbo].[Teacher] ([DepartmentID], [UserID], [TeacherCode], [Degree], [Expertise], [University], [GraduationYear], [Major], [OtherCertifications], [Position], [Salary], [AdditionalBenifits], [CurrentHealthStatus], [HealthInsuranceInfo], [SelfIntroduction], [SubjectID]  ,[IsLeader]) VALUES (3, 4, N'TC001', N'Thạc sĩ', N'Toán học', N'Đại học Quốc gia Hà Nội', CAST(N'2010-01-01T00:00:00.000' AS DateTime), N'Sinh học', NULL, N'Giáo viên', CAST(30000000 AS Decimal(18, 0)), N'Bảo hiểm y tế', N'Bình thường', N'Bảo hiểm BHYT số 123456789', N'Tôi là m?t giáo viên Toán có kinh nghi?m', 5,1)
INSERT [dbo].[Teacher] ([DepartmentID], [UserID], [TeacherCode], [Degree], [Expertise], [University], [GraduationYear], [Major], [OtherCertifications], [Position], [Salary], [AdditionalBenifits], [CurrentHealthStatus], [HealthInsuranceInfo], [SelfIntroduction], [SubjectID]  ,[IsLeader]) VALUES (5, 5, N'TC001', N'Thạc sĩ', N'Toán học', N'Đại học Quốc gia Hà Nội', CAST(N'2010-01-01T00:00:00.000' AS DateTime), N'Văn học', NULL, N'Giáo viên', CAST(30000000 AS Decimal(18, 0)), N'Bảo hiểm y tế', N'Bình thường', N'Bảo hiểm BHYT số 123456789', N'Tôi là m?t giáo viên Toán có kinh nghi?m', 9,1)
INSERT [dbo].[Teacher] ([DepartmentID], [UserID], [TeacherCode], [Degree], [Expertise], [University], [GraduationYear], [Major], [OtherCertifications], [Position], [Salary], [AdditionalBenifits], [CurrentHealthStatus], [HealthInsuranceInfo], [SelfIntroduction], [SubjectID]  ,[IsLeader]) VALUES (6, 6, N'TC001', N'Thạc sĩ', N'Toán học', N'Đại học Quốc gia Hà Nội', CAST(N'2010-01-01T00:00:00.000' AS DateTime), N'Địa lý', NULL, N'Giáo viên', CAST(30000000 AS Decimal(18, 0)), N'Bảo hiểm y tế', N'Bình thường', N'Bảo hiểm BHYT số 123456789', N'Tôi là m?t giáo viên Toán có kinh nghi?m', 10,1)

--end teacher

--start  class--
Create table [Class]
(
	[ClassID] Integer IDENTITY(1,1) NOT NULL,
	[ClassCode] nvarchar(100) NULL,
	[ClassName] nvarchar(100) NULL,
	[NumberOfStudent] Integer NULL,
	[TeacherID] Integer NOT NULL Foreign key ([TeacherID]) REFERENCES Teacher(TeacherID) ON UPDATE no action ON DELETE NO ACTION,
Primary Key ([ClassID])
) 
go

INSERT [dbo].[Class] ([TeacherID], [ClassCode], [ClassName], [NumberOfStudent]) VALUES (1, N'CL10A1', N'10A1', 30)
INSERT [dbo].[Class] ([TeacherID], [ClassCode], [ClassName], [NumberOfStudent]) VALUES (2, N'CL10A2', N'10A2', 25)
INSERT [dbo].[Class] ([TeacherID], [ClassCode], [ClassName], [NumberOfStudent]) VALUES (3, N'CL10A3', N'10A3', 28)
INSERT [dbo].[Class] ([TeacherID], [ClassCode], [ClassName], [NumberOfStudent]) VALUES (4, N'CL10A4', N'10A4', 32)
INSERT [dbo].[Class] ([TeacherID], [ClassCode], [ClassName], [NumberOfStudent]) VALUES (5, N'CL10A5', N'10A5', 27)
INSERT [dbo].[Class] ([TeacherID], [ClassCode], [ClassName], [NumberOfStudent]) VALUES (6, N'CL10A6', N'10A6', 29)

--start  class--

Create table [StudentAssignment]
(
	[StudentID] Integer NOT NULL,
	[ClassID] Integer NOT NULL,
	[StartDate] Datetime NULL,
	[EndDate] Datetime NULL,
	[Status] Nvarchar(100) NULL,
Primary Key ([StudentID],[ClassID])
) 
go
SELECT * FROM Student
INSERT [dbo].[StudentAssignment] ([ClassID], [StudentID], [StartDate], [EndDate]) VALUES (1, 1,  CAST(N'2023-01-01T00:00:00.000' AS DateTime), CAST(N'2024-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[StudentAssignment] ([ClassID], [StudentID], [StartDate], [EndDate]) VALUES (1, 2,  CAST(N'2023-01-01T00:00:00.000' AS DateTime), CAST(N'2024-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[StudentAssignment] ([ClassID], [StudentID], [StartDate], [EndDate]) VALUES (1, 3,  CAST(N'2023-01-01T00:00:00.000' AS DateTime), CAST(N'2024-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[StudentAssignment] ([ClassID], [StudentID], [StartDate], [EndDate]) VALUES (1, 4,  CAST(N'2023-01-01T00:00:00.000' AS DateTime), CAST(N'2024-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[StudentAssignment] ([ClassID], [StudentID], [StartDate], [EndDate]) VALUES (1, 5,  CAST(N'2023-01-01T00:00:00.000' AS DateTime), CAST(N'2024-01-01T00:00:00.000' AS DateTime))

Create table [HomeroomAssignment]
(
	[ClassID] Integer NOT NULL,
	[TeacherID] Integer NOT NULL,
	[StartDate] Datetime NULL,
	[EndDate] Datetime NULL,
Primary Key ([ClassID],[TeacherID])
) 
go
INSERT [dbo].[HomeroomAssignment] ([ClassID], [TeacherID], [StartDate], [EndDate]) VALUES (1, 2,  CAST(N'2023-01-01T00:00:00.000' AS DateTime), CAST(N'2024-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[HomeroomAssignment] ([ClassID], [TeacherID], [StartDate], [EndDate]) VALUES (2, 3,  CAST(N'2023-01-01T00:00:00.000' AS DateTime), CAST(N'2024-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[HomeroomAssignment] ([ClassID], [TeacherID], [StartDate], [EndDate]) VALUES (3, 4,  CAST(N'2023-01-01T00:00:00.000' AS DateTime), CAST(N'2024-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[HomeroomAssignment] ([ClassID], [TeacherID], [StartDate], [EndDate]) VALUES (4, 5,  CAST(N'2023-01-01T00:00:00.000' AS DateTime), CAST(N'2024-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[HomeroomAssignment] ([ClassID], [TeacherID], [StartDate], [EndDate]) VALUES (6, 6,  CAST(N'2023-01-01T00:00:00.000' AS DateTime), CAST(N'2024-01-01T00:00:00.000' AS DateTime))
--end class--
Create table [EducationProgram]
(
	[EducationProgramID] Integer IDENTITY(1,1) NOT NULL,
	[EducationProgramCode] nvarchar(20) NULL,
	[EducationName] nvarchar(100) NULL,
	[NumberOfLesson] Integer NULL,
	[Status] nvarchar(100) NULL,
Primary Key ([EducationProgramID])
) 
go
INSERT INTO [EducationProgram] ([EducationProgramCode], [EducationName], [NumberOfLesson], [Status])
VALUES 
    (N'EP001', N'Chương trình Toán học', 30, N'Hoạt động'),
    (N'EP002', N'Chương trình hóa học', 35, N'Hoạt động'),
    (N'EP003', N'Chương trình Sinh học', 25, N'Hoạt động'),
    (N'EP004', N'Chương trình Lịch sử', 20, N'Không hoạt động'),
    (N'EP005', N'Chương trình Văn học', 40, N'Hoạt động'),
    (N'EP005', N'Chương trình Địa lý', 40, N'Hoạt động')


--end education

Create table [Course]
(
	[CourseID] Integer Identity(1,1) Not null,
	[ClassID] Integer NOT NULL Foreign key ([ClassID]) REFERENCES [Class]([ClassID]) ON UPDATE no action ON DELETE NO ACTION,
	[TeacherID] Integer NOT NULL Foreign key ([TeacherID]) REFERENCES Teacher(TeacherID) ON UPDATE no action ON DELETE NO ACTION,
	[SubjectID] Integer NOT NULL Foreign key ([SubjectID]) REFERENCES [Subject]([SubjectID]) ON UPDATE no action ON DELETE NO ACTION,
	[EducationProgramID] Integer NOT NULL Foreign key ([EducationProgramID]) REFERENCES EducationProgram([EducationProgramID]) ON UPDATE no action ON DELETE NO ACTION,
	[StartDate] Datetime NULL,
	[EndDate] Datetime NULL,
	[Status] nvarchar(100) NULL,
	[Semester] nvarchar(100) NULL,
Primary Key ([CourseID])
) 
go

INSERT [dbo].[Course] ([ClassID], [TeacherID], [SubjectID],[EducationProgramID], [StartDate], [EndDate],[Status],[Semester]) VALUES 
(2, 1, 1,1, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime),N'Đang học','ky_1')
INSERT [dbo].[Course] ([ClassID], [TeacherID], [SubjectID],[EducationProgramID], [StartDate], [EndDate],[Status],[Semester]) VALUES 
(1, 2, 6,4, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime),N'Đang học','ky_1')
INSERT [dbo].[Course] ([ClassID], [TeacherID], [SubjectID],[EducationProgramID], [StartDate], [EndDate],[Status],[Semester]) VALUES 
(1, 3, 4,2, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime),N'Đang học','ky_1')
INSERT [dbo].[Course] ([ClassID], [TeacherID], [SubjectID],[EducationProgramID], [StartDate], [EndDate],[Status],[Semester]) VALUES 
(1, 4, 5,3, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime),N'Đang học','ky_1')
INSERT [dbo].[Course] ([ClassID], [TeacherID], [SubjectID],[EducationProgramID], [StartDate], [EndDate],[Status],[Semester]) VALUES 
(1, 5, 9,5, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime),N'Đang học','ky_1')
INSERT [dbo].[Course] ([ClassID], [TeacherID], [SubjectID],[EducationProgramID], [StartDate], [EndDate],[Status],[Semester]) VALUES 
(1, 5, 10,6, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime),N'Đang học','ky_1')

Create table [GradeSheet]
(
	[GradeSheetID] Integer IDENTITY(1,1) NOT NULL,
	[CourseID] Integer NOT NULL Foreign key ([CourseID]) REFERENCES [Course]([CourseID]) ON UPDATE No action ON DELETE No action,
	[StudentID] Integer NOT NULL Foreign key ([StudentID]) REFERENCES [Student]([StudentID]) ON UPDATE no action ON DELETE NO ACTION,
	[FirstRegularScore] float NULL,
	[SecondRegularScore] float NULL,
	[ThirdRegularScore] float NULL,
	[FourRegularScore] float NULL,
	[MidtermScore] float NULL,
	[FinalScore] float  NULL,
	[SemesterAverage] float NULL,
	[PromotionDecision] bit null
Primary Key ([GradeSheetID])
) 
go

 Select * from Course
 Select * from Student
INSERT [dbo].[GradeSheet] ([CourseID],[StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage]) VALUES 
(1,1, 8.1, 8.3, 8.6, 8.5, 8.6, 8.3, 8.4)
INSERT [dbo].[GradeSheet] ([CourseID],[StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage]) VALUES 
(1,2, 8.1, 8.3, 8.6, 8.5, 8.6, 8.3, 8.4)
INSERT [dbo].[GradeSheet] ([CourseID],[StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage]) VALUES 
(1,3, 8.1, 8.3, 8.6, 8.5, 8.6, 8.3, 8.4)
INSERT [dbo].[GradeSheet] ([CourseID],[StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage]) VALUES 
(1,4, 8.1, 8.3, 8.6, 8.5, 8.6, 8.3, 8.4)
INSERT [dbo].[GradeSheet] ([CourseID],[StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage]) VALUES 
(1,5, 8.1, 8.3, 8.6, 8.5, 8.6, 8.3, 8.4)

INSERT [dbo].[GradeSheet] ([CourseID],[StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage]) VALUES 
(2,1, 8.1, 8.3, 8.6, 8.5, 8.6, 8.3, 8.4)
INSERT [dbo].[GradeSheet] ([CourseID],[StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage]) VALUES 
(2,2, 8.1, 8.3, 8.6, 8.5, 8.6, 8.3, 8.4)
INSERT [dbo].[GradeSheet] ([CourseID],[StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage]) VALUES 
(2,3, 8.1, 8.3, 8.6, 8.5, 8.6, 8.3, 8.4)
INSERT [dbo].[GradeSheet] ([CourseID],[StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage]) VALUES 
(2,4, 8.1, 8.3, 8.6, 8.5, 8.6, 8.3, 8.4)
INSERT [dbo].[GradeSheet] ([CourseID],[StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage]) VALUES 
(2,5, 8.1, 8.3, 8.6, 8.5, 8.6, 8.3, 8.4)

INSERT [dbo].[GradeSheet] ([CourseID],[StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage]) VALUES 
(3,1, 8.1, 8.3, 8.6, 8.5, 8.6, 8.3, 8.4)
INSERT [dbo].[GradeSheet] ([CourseID],[StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage]) VALUES 
(3,2, 8.1, 8.3, 8.6, 8.5, 8.6, 8.3, 8.4)
INSERT [dbo].[GradeSheet] ([CourseID],[StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage]) VALUES 
(3,3, 8.1, 8.3, 8.6, 8.5, 8.6, 8.3, 8.4)
INSERT [dbo].[GradeSheet] ([CourseID],[StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage]) VALUES 
(3,4, 8.1, 8.3, 8.6, 8.5, 8.6, 8.3, 8.4)
INSERT [dbo].[GradeSheet] ([CourseID],[StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage]) VALUES 
(3,5, 8.1, 8.3, 8.6, 8.5, 8.6, 8.3, 8.4)


INSERT [dbo].[GradeSheet] ([CourseID],[StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage]) VALUES 
(4,1, 8.1, 8.3, 8.6, 8.5, 8.6, 8.3, 8.4)
INSERT [dbo].[GradeSheet] ([CourseID],[StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage]) VALUES 
(4,2, 8.1, 8.3, 8.6, 8.5, 8.6, 8.3, 8.4)
INSERT [dbo].[GradeSheet] ([CourseID],[StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage]) VALUES 
(4,2, 8.1, 8.3, 8.6, 8.5, 8.6, 8.3, 8.4)
INSERT [dbo].[GradeSheet] ([CourseID],[StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage]) VALUES 
(4,2, 8.1, 8.3, 8.6, 8.5, 8.6, 8.3, 8.4)
INSERT [dbo].[GradeSheet] ([CourseID],[StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage]) VALUES 
(4,2, 8.1, 8.3, 8.6, 8.5, 8.6, 8.3, 8.4)


  --end grade sheet



Create table [Schedule]
(
	[ScheduleID] Integer NOT NULL,
	[ScheduleCode] Varchar(100) NULL,
	[Day] Datetime NULL,
	[Start] Datetime NULL,
	[End] Datetime NULL,
	[CourseID] Integer NOT NULL,
Primary Key ([ScheduleID])
) 
go



Create table [Lesson]
(
	[LessonID] Integer IDENTITY(1,1) NOT NULL,
	[LessonCode] nvarchar(100) NULL,
	[LessonName] nvarchar(100) NULL,
	[VideoUrl] nvarchar(max) NULL,
	[ImageUrl] nvarchar(max) NULL,
	[Status] nvarchar(100) NULL,
	[EducationProgramID] Integer NOT NULL Foreign key ([EducationProgramID]) REFERENCES EducationProgram([EducationProgramID]) ON UPDATE cascade ON DELETE cascade,
Primary Key ([LessonID])
) 
go
Create table [EditGradeSheetForm]
(
	[EditGradeSheetFormID] Integer Identity(1,1) NOT NULL primary key,
	[GradeSheetID] Integer NOT NULL Foreign key ([GradeSheetID]) REFERENCES GradeSheet([GradeSheetID]) ON UPDATE cascade ON DELETE cascade,
	[TeacherID] Integer NOT NULL Foreign key ([TeacherID]) REFERENCES Teacher(TeacherID) ON UPDATE no action ON DELETE NO ACTION,
	[Time] Datetime NULL,
	[Status] Nvarchar(100) NULL,
	[reason] Nvarchar(max) NOT NULL
) 

Set quoted_identifier on
go


Set quoted_identifier off
go



