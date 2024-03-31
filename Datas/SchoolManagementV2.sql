/*
Created		3/24/2024
Modified		3/29/2024
Project		
Model			
Company		
Author		
Version		
Database		MS SQL 2005 
*/


Drop table [GradeSheet] 
go
Drop table [Department] 
go
Drop table [Course] 
go
Drop table [Teacher] 
go
Drop table [Student] 
go
Drop table [Class] 
go
Drop table [Subject] 
go
Drop table [User] 
go


Create table [User]
(
	[UserID] Integer NOT NULL,
	[FirstName] Nvarchar(100) NULL,
	[LastName] Nvarchar(100) NULL,
	[Gender] Nvarchar(10) NULL,
	[DateOfBirth] Smalldatetime NULL,
	[PhoneNumber] Varchar(12) NULL,
	[Address] Nvarchar(100) NULL,
	[Email] Nvarchar(100) NULL,
	[Image] Nvarchar(1000) NULL,
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
	[SubjectID] Integer NOT NULL,
	[SubjectCode] Varchar(15) NULL,
	[SubjectName] Nvarchar(100) NULL,
Primary Key ([SubjectID])
) 
go

Create table [Class]
(
	[ClassID] Integer NOT NULL,
	[ClassCode] Smalldatetime NULL,
	[ClassName] Nvarchar(100) NULL,
	[TeacherID] Integer NOT NULL,
Primary Key ([ClassID])
) 
go

Create table [Student]
(
	[StudentID] Integer NOT NULL,
	[StudentCode] Nvarchar(20) NULL,
Primary Key ([StudentID])
) 
go

Create table [Teacher]
(
	[TeacherID] Integer NOT NULL,
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
	[ClassID] Integer NOT NULL,
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
	[DepartmentID] Integer NOT NULL,
	[DepartmentCode] Nvarchar(20) NULL,
	[DepartmentName] Nvarchar(100) NULL,
Primary Key ([DepartmentID])
) 
go

Create table [GradeSheet]
(
	[ClassID] Integer NOT NULL,
	[SubjectID] Integer NOT NULL,
	[StudentID] Integer NOT NULL,
	[FirstRegularScore] Decimal(2,2) NULL,
	[SecondRegularScore] Decimal(2,2) NULL,
	[ThirdRegularScore] Decimal(2,2) NULL,
	[FourRegularScore] Decimal(2,2) NULL,
	[MidtermScore] Decimal(2,2) NULL,
	[FinalScore] Decimal(2,2) NULL,
	[SemesterAverage] Decimal(2,2) NULL,
Primary Key ([ClassID],[SubjectID],[StudentID])
) 
go


Set quoted_identifier on
go


Set quoted_identifier off
go


-- insert 
-- Chèn dữ liệu vào bảng User
INSERT INTO [User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate])
VALUES 
(1, N'Hồng', N'Trần', N'Nữ', '1990-05-15', '0123456789', N'123 Đường ABC', 'hongtran@email.com', 'hong.jpg', 'hongtran', 'matkhau123', N'Sinh viên', 1, '2020-09-01', NULL),
(2, N'Tuấn', N'Nguyễn', N'Nam', '1985-08-20', '0987654321', N'456 Đường XYZ', 'tuannguyen@email.com', 'tuan.jpg', 'tuannguyen', 'password123', N'Giáo viên', 1, '2018-07-01', NULL),
(3, N'Tuấn', N'Nguyễn', N'Nam', '1985-08-20', '0987654321', N'456 Đường XYZ', 'tuannguyen@email.com', 'tuan.jpg', 'tuannguyen', 'password123', N'Giáo viên', 1, '2018-07-01', NULL),
(4, N'Tuấn', N'Nguyễn', N'Nam', '1985-08-20', '0987654321', N'456 Đường XYZ', 'tuannguyen@email.com', 'tuan.jpg', 'tuannguyen', 'password123', N'Giáo viên', 1, '2018-07-01', NULL),
(5, N'Tuấn', N'Nguyễn', N'Nam', '1985-08-20', '0987654321', N'456 Đường XYZ', 'tuannguyen@email.com', 'tuan.jpg', 'tuannguyen', 'password123', N'Giáo viên', 1, '2018-07-01', NULL),(2, N'Tuấn', N'Nguyễn', N'Nam', '1985-08-20', '0987654321', N'456 Đường XYZ', 'tuannguyen@email.com', 'tuan.jpg', 'tuannguyen', 'password123', N'Giáo viên', 1, '2018-07-01', NULL),
(6, N'Tuấn', N'Nguyễn', N'Nam', '1985-08-20', '0987654321', N'456 Đường XYZ', 'tuannguyen@email.com', 'tuan.jpg', 'tuannguyen', 'password123', N'Giáo viên', 1, '2018-07-01', NULL),
(7, N'Tuấn', N'Nguyễn', N'Nam', '1985-08-20', '0987654321', N'456 Đường XYZ', 'tuannguyen@email.com', 'tuan.jpg', 'tuannguyen', 'password123', N'Giáo viên', 1, '2018-07-01', NULL),
(8, N'Tuấn', N'Nguyễn', N'Nam', '1985-08-20', '0987654321', N'456 Đường XYZ', 'tuannguyen@email.com', 'tuan.jpg', 'tuannguyen', 'password123', N'Giáo viên', 1, '2018-07-01', NULL),
(9, N'Tuấn', N'Nguyễn', N'Nam', '1985-08-20', '0987654321', N'456 Đường XYZ', 'tuannguyen@email.com', 'tuan.jpg', 'tuannguyen', 'password123', N'Giáo viên', 1, '2018-07-01', NULL),
(10, N'Tuấn', N'Nguyễn', N'Nam', '1985-08-20', '0987654321', N'456 Đường XYZ', 'tuannguyen@email.com', 'tuan.jpg', 'tuannguyen', 'password123', N'Giáo viên', 1, '2018-07-01', NULL),
(11, N'Tuấn', N'Nguyễn', N'Nam', '1985-08-20', '0987654321', N'456 Đường XYZ', 'tuannguyen@email.com', 'tuan.jpg', 'tuannguyen', 'password123', N'Giáo viên', 1, '2018-07-01', NULL),
(12, N'Tuấn', N'Nguyễn', N'Nam', '1985-08-20', '0987654321', N'456 Đường XYZ', 'tuannguyen@email.com', 'tuan.jpg', 'tuannguyen', 'password123', N'Giáo viên', 1, '2018-07-01', NULL),
(13, N'Tuấn', N'Nguyễn', N'Nam', '1985-08-20', '0987654321', N'456 Đường XYZ', 'tuannguyen@email.com', 'tuan.jpg', 'tuannguyen', 'password123', N'Giáo viên', 1, '2018-07-01', NULL),
(14, N'Tuấn', N'Nguyễn', N'Nam', '1985-08-20', '0987654321', N'456 Đường XYZ', 'tuannguyen@email.com', 'tuan.jpg', 'tuannguyen', 'password123', N'Giáo viên', 1, '2018-07-01', NULL),
(15, N'Tuấn', N'Nguyễn', N'Nam', '1985-08-20', '0987654321', N'456 Đường XYZ', 'tuannguyen@email.com', 'tuan.jpg', 'tuannguyen', 'password123', N'Giáo viên', 1, '2018-07-01', NULL),
(16, N'Tuấn', N'Nguyễn', N'Nam', '1985-08-20', '0987654321', N'456 Đường XYZ', 'tuannguyen@email.com', 'tuan.jpg', 'tuannguyen', 'password123', N'Giáo viên', 1, '2018-07-01', NULL),
(17, N'Tuấn', N'Nguyễn', N'Nam', '1985-08-20', '0987654321', N'456 Đường XYZ', 'tuannguyen@email.com', 'tuan.jpg', 'tuannguyen', 'password123', N'Giáo viên', 1, '2018-07-01', NULL),
(18, N'Tuấn', N'Nguyễn', N'Nam', '1985-08-20', '0987654321', N'456 Đường XYZ', 'tuannguyen@email.com', 'tuan.jpg', 'tuannguyen', 'password123', N'Giáo viên', 1, '2018-07-01', NULL),
(19, N'Tuấn', N'Nguyễn', N'Nam', '1985-08-20', '0987654321', N'456 Đường XYZ', 'tuannguyen@email.com', 'tuan.jpg', 'tuannguyen', 'password123', N'Giáo viên', 1, '2018-07-01', NULL),
(20, N'Tuấn', N'Nguyễn', N'Nam', '1985-08-20', '0987654321', N'456 Đường XYZ', 'tuannguyen@email.com', 'tuan.jpg', 'tuannguyen', 'password123', N'Giáo viên', 1, '2018-07-01', NULL),
(21, N'Tuấn', N'Nguyễn', N'Nam', '1985-08-20', '0987654321', N'456 Đường XYZ', 'tuannguyen@email.com', 'tuan.jpg', 'tuannguyen', 'password123', N'Giáo viên', 1, '2018-07-01', NULL),
(22, N'Tuấn', N'Nguyễn', N'Nam', '1985-08-20', '0987654321', N'456 Đường XYZ', 'tuannguyen@email.com', 'tuan.jpg', 'tuannguyen', 'password123', N'Giáo viên', 1, '2018-07-01', NULL),
(23, N'Tuấn', N'Nguyễn', N'Nam', '1985-08-20', '0987654321', N'456 Đường XYZ', 'tuannguyen@email.com', 'tuan.jpg', 'tuannguyen', 'password123', N'Giáo viên', 1, '2018-07-01', NULL),
(24, N'Tuấn', N'Nguyễn', N'Nam', '1985-08-20', '0987654321', N'456 Đường XYZ', 'tuannguyen@email.com', 'tuan.jpg', 'tuannguyen', 'password123', N'Giáo viên', 1, '2018-07-01', NULL),
(25, N'Tuấn', N'Nguyễn', N'Nam', '1985-08-20', '0987654321', N'456 Đường XYZ', 'tuannguyen@email.com', 'tuan.jpg', 'tuannguyen', 'password123', N'Giáo viên', 1, '2018-07-01', NULL),
(26, N'Tuấn', N'Nguyễn', N'Nam', '1985-08-20', '0987654321', N'456 Đường XYZ', 'tuannguyen@email.com', 'tuan.jpg', 'tuannguyen', 'password123', N'Giáo viên', 1, '2018-07-01', NULL),
(27, N'Tuấn', N'Nguyễn', N'Nam', '1985-08-20', '0987654321', N'456 Đường XYZ', 'tuannguyen@email.com', 'tuan.jpg', 'tuannguyen', 'password123', N'Giáo viên', 1, '2018-07-01', NULL),
(28, N'Tuấn', N'Nguyễn', N'Nam', '1985-08-20', '0987654321', N'456 Đường XYZ', 'tuannguyen@email.com', 'tuan.jpg', 'tuannguyen', 'password123', N'Giáo viên', 1, '2018-07-01', NULL),
(29, N'Tuấn', N'Nguyễn', N'Nam', '1985-08-20', '0987654321', N'456 Đường XYZ', 'tuannguyen@email.com', 'tuan.jpg', 'tuannguyen', 'password123', N'Giáo viên', 1, '2018-07-01', NULL),
(30, N'Tuấn', N'Nguyễn', N'Nam', '1985-08-20', '0987654321', N'456 Đường XYZ', 'tuannguyen@email.com', 'tuan.jpg', 'tuannguyen', 'password123', N'Giáo viên', 1, '2018-07-01', NULL),
(31, N'Tuấn', N'Nguyễn', N'Nam', '1985-08-20', '0987654321', N'456 Đường XYZ', 'tuannguyen@email.com', 'tuan.jpg', 'tuannguyen', 'password123', N'Giáo viên', 1, '2018-07-01', NULL),
(32, N'Tuấn', N'Nguyễn', N'Nam', '1985-08-20', '0987654321', N'456 Đường XYZ', 'tuannguyen@email.com', 'tuan.jpg', 'tuannguyen', 'password123', N'Giáo viên', 1, '2018-07-01', NULL),
(33, N'Tuấn', N'Nguyễn', N'Nam', '1985-08-20', '0987654321', N'456 Đường XYZ', 'tuannguyen@email.com', 'tuan.jpg', 'tuannguyen', 'password123', N'Giáo viên', 1, '2018-07-01', NULL),
(34, N'Tuấn', N'Nguyễn', N'Nam', '1985-08-20', '0987654321', N'456 Đường XYZ', 'tuannguyen@email.com', 'tuan.jpg', 'tuannguyen', 'password123', N'Giáo viên', 1, '2018-07-01', NULL),
(35, N'Tuấn', N'Nguyễn', N'Nam', '1985-08-20', '0987654321', N'456 Đường XYZ', 'tuannguyen@email.com', 'tuan.jpg', 'tuannguyen', 'password123', N'Giáo viên', 1, '2018-07-01', NULL),
(36, N'Tuấn', N'Nguyễn', N'Nam', '1985-08-20', '0987654321', N'456 Đường XYZ', 'tuannguyen@email.com', 'tuan.jpg', 'tuannguyen', 'password123', N'Giáo viên', 1, '2018-07-01', NULL),
(37, N'Tuấn', N'Nguyễn', N'Nam', '1985-08-20', '0987654321', N'456 Đường XYZ', 'tuannguyen@email.com', 'tuan.jpg', 'tuannguyen', 'password123', N'Giáo viên', 1, '2018-07-01', NULL),
(38, N'Tuấn', N'Nguyễn', N'Nam', '1985-08-20', '0987654321', N'456 Đường XYZ', 'tuannguyen@email.com', 'tuan.jpg', 'tuannguyen', 'password123', N'Giáo viên', 1, '2018-07-01', NULL),
(39, N'Tuấn', N'Nguyễn', N'Nam', '1985-08-20', '0987654321', N'456 Đường XYZ', 'tuannguyen@email.com', 'tuan.jpg', 'tuannguyen', 'password123', N'Giáo viên', 1, '2018-07-01', NULL),
(40, N'Tuấn', N'Nguyễn', N'Nam', '1985-08-20', '0987654321', N'456 Đường XYZ', 'tuannguyen@email.com', 'tuan.jpg', 'tuannguyen', 'password123', N'Giáo viên', 1, '2018-07-01', NULL),
(41, N'Tuấn', N'Nguyễn', N'Nam', '1985-08-20', '0987654321', N'456 Đường XYZ', 'tuannguyen@email.com', 'tuan.jpg', 'tuannguyen', 'password123', N'Giáo viên', 1, '2018-07-01', NULL),
(42, N'Tuấn', N'Nguyễn', N'Nam', '1985-08-20', '0987654321', N'456 Đường XYZ', 'tuannguyen@email.com', 'tuan.jpg', 'tuannguyen', 'password123', N'Giáo viên', 1, '2018-07-01', NULL),
(43, N'Tuấn', N'Nguyễn', N'Nam', '1985-08-20', '0987654321', N'456 Đường XYZ', 'tuannguyen@email.com', 'tuan.jpg', 'tuannguyen', 'password123', N'Giáo viên', 1, '2018-07-01', NULL),
(44, N'Tuấn', N'Nguyễn', N'Nam', '1985-08-20', '0987654321', N'456 Đường XYZ', 'tuannguyen@email.com', 'tuan.jpg', 'tuannguyen', 'password123', N'Giáo viên', 1, '2018-07-01', NULL),
(45, N'Tuấn', N'Nguyễn', N'Nam', '1985-08-20', '0987654321', N'456 Đường XYZ', 'tuannguyen@email.com', 'tuan.jpg', 'tuannguyen', 'password123', N'Giáo viên', 1, '2018-07-01', NULL),
(46, N'Tuấn', N'Nguyễn', N'Nam', '1985-08-20', '0987654321', N'456 Đường XYZ', 'tuannguyen@email.com', 'tuan.jpg', 'tuannguyen', 'password123', N'Giáo viên', 1, '2018-07-01', NULL),

(47, N'Tuấn', N'Nguyễn', N'Nam', '1985-08-20', '0987654321', N'456 Đường XYZ', 'tuannguyen@email.com', 'tuan.jpg', 'tuannguyen', 'password123', N'Giáo viên', 1, '2018-07-01', NULL),





















-- Chèn dữ liệu vào bảng Subject
INSERT INTO [Subject] ([SubjectID], [SubjectCode], [SubjectName])
VALUES 
(1, 'TOAN101', N'Toán học'),
(2, 'VAN101', N'Ngữ văn'),

INSERT INTO [Class] ([ClassID], [ClassCode], [ClassName], [TeacherID])
VALUES 
(1, 'L101', N'Lớp 1A', 2),
(2, 'L102', N'Lớp 1B', 3),



-- Chèn dữ liệu vào bảng Student
INSERT INTO [Student] ([StudentID], [StudentCode])
VALUES 
(1, N'MS001'),
(2, N'MS002'),




-- Chèn dữ liệu vào bảng Teacher
INSERT INTO [Teacher] ([TeacherID], [Degree], [Expertise_], [University], [GraduationYear], [Major], [OtherCertifications_], [Position], [Salary], [AdditionalBenifits], [CurrentHealthStatus], [HealthInsuranceInfo_], [SelfIntroduction_], [DepartmentID], [LeaderID])
VALUES 
(1, N'Tiến sĩ', N'Công nghệ thông tin', N'Đại học ABC', '2010-01-01', N'Công nghệ thông tin', NULL, N'Giáo viên', 15000000, NULL, N'Bình thường', NULL, N'Tôi là giáo viên dạy công nghệ thông tin', 1, NULL),
(2, N'Tiến sĩ', N'Toán học', N'Đại học XYZ', '2008-01-01', N'Toán học', NULL, N'Giáo viên', 18000000, NULL, N'Bình thường', NULL, N'Tôi là giáo viên dạy toán học', 2, NULL),




-- Chèn dữ liệu vào bảng Course
INSERT INTO [Course] ([ClassID], [SubjectID], [NumberOfLessons], [StartDate], [EndDate], [TeacherID])
VALUES 
(1, 1, 30, '2024-03-01', '2024-06-30', 2),
(1, 2, 30, '2024-03-01', '2024-06-30', 3),




-- Chèn dữ liệu vào bảng Department
INSERT INTO [Department] ([DepartmentID], [DepartmentCode], [DepartmentName])
VALUES 
(1, N'CNPM', N'Công nghệ phần mềm'),
(2, N'TH', N'Toán học'),




-- Chèn dữ liệu vào bảng GradeSheet
INSERT INTO [GradeSheet] ([ClassID], [SubjectID], [StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage])
VALUES 
(1, 1, 1, 8.5, 9.0, 8.8, 8.9, 7.5, 8.7, 8.6),
(1, 2, 1, 7.8, 8.0, 8.2, 7.9, 7.0, 8.5, 8.0),
