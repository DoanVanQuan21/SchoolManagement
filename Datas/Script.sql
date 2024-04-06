/*
Created		3/24/2024
Modified		4/6/2024
Project		
Model			
Company		
Author		
Version		
Database		MS SQL 2005 
*/

USE SchoolManagement
go
Create table [User]
(
	[UserID] Integer NOT NULL,
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
Primary Key ([UserID])
) 
go

Create table [Subject]
(
	[SubjectID] Integer NOT NULL,
	[SubjectCode] nvarchar(15) NULL,
	[SubjectName] nvarchar(100) NULL,
	[Image] nvarchar(max),
Primary Key ([SubjectID])
) 
go


Create table [Student]
(
	[StudentID] Integer NOT NULL,
	[UserID] Integer NOT NULL foreign key([UserID]) references [User] ([UserID])  on update cascade on delete cascade ,
	[StudentCode] nvarchar(20) NULL,
Primary Key ([StudentID])
) 
go
Create table [Department]
(
	[DepartmentID] Integer NOT NULL,
	[DepartmentCode] nvarchar(20) NULL,
	[DepartmentName] Nvarchar(100) NULL,
	[Image] nvarchar(max),
	[FoundingDate] Datetime NULL,
Primary Key ([DepartmentID])
) 
go
Create table [Teacher]
(
	[TeacherID] Integer NOT NULL,
	[DepartmentID] Integer NOT NULL foreign key([DepartmentID]) references [Department] ([DepartmentID])  on update cascade on delete cascade,
	[UserID] Integer NOT NULL foreign key([UserID]) references [User] ([UserID])  on update cascade on delete cascade,
	[LeaderID] Integer NOT NULL,
	[TeacherCode] nvarchar(100) NULL,
	[Degree] nvarchar(200) NULL,
	[Expertise] nvarchar(100) NULL,
	[University] nvarchar(100) NULL,
	[GraduationYear] Datetime NULL,
	[Major] nvarchar(100) NULL,
	[OtherCertifications_] nvarchar(200) NULL,
	[Position] nvarchar(100) NULL,
	[Salary] Decimal(18,0) NULL,
	[AdditionalBenifits] nvarchar(100) NULL,
	[CurrentHealthStatus] nvarchar(100) NULL,
	[HealthInsuranceInfo_] nvarchar(100) NULL,
	[SelfIntroduction_] Text NULL,
Primary Key ([TeacherID])
) 
go
Create table [Class]
(
	[ClassID] Integer NOT NULL,
	[TeacherID] Integer NOT NULL,
	[ClassCode] Datetime NULL,
	[ClassName] nvarchar(100) NULL,
	[NumberOfStudent] Integer NULL,
Primary Key ([ClassID])
) 
go

Create table [Course]
(
	[ClassID] Integer NOT NULL,
	[SubjectID] Integer NOT NULL,
	[TeacherID] Integer NOT NULL foreign key([TeacherID]) references [Teacher] ([TeacherID])  on update cascade on delete cascade,
	[NumberOfLessons] Integer NULL,
	[StartDate] Datetime NULL,
	[EndDate] Datetime NULL,
Primary Key ([ClassID],[SubjectID])
) 
go



Create table [GradeSheet]
(
	[GradeSheetID] Integer NOT NULL,
	[ClassID] Integer NOT NULL foreign key([ClassID]) references [Class] ([ClassID])  on update no action on delete no action,
	[SubjectID] Integer NOT NULL foreign key([SubjectID]) references [Subject] ([SubjectID])  on update no action on delete no action,
	[StudentID] Integer NOT NULL foreign key([StudentID]) references [Student] ([StudentID])  on update no action on delete no action,
	[FirstRegularScore] Decimal(2,2) NULL,
	[SecondRegularScore] Decimal(2,2) NULL,
	[ThirdRegularScore] Decimal(2,2) NULL,
	[FourRegularScore] Decimal(2,2) NULL,
	[MidtermScore] Decimal(2,2) NULL,
	[FinalScore] Decimal(2,2) NULL,
	[SemesterAverage] Decimal(2,2) NULL,
Primary Key ([GradeSheetID])
) 
go

Create table [Schedule]
(
	[ScheduleID] Integer NOT NULL,
	[ClassID] Integer NOT NULL foreign key([ClassID]) references [Class] ([ClassID])  on update cascade on delete cascade,
	[SubjectID] Integer NOT NULL foreign key([SubjectID]) references [Subject] ([SubjectID])  on update cascade on delete cascade,
	[ScheduleCode] nvarchar(100) NULL,
	[Day] Datetime NULL,
	[Start] Datetime NULL,
	[End] Datetime NULL,
Primary Key ([ScheduleID])
) 
go

Create table [EducationProgram]
(
	[EducationProgramID] Integer NOT NULL,
	[ClassID] Integer NOT NULL foreign key([ClassID]) references [Class] ([ClassID])  on update cascade on delete cascade,
	[SubjectID] Integer NOT NULL foreign key([SubjectID]) references [Subject] ([SubjectID])  on update cascade on delete cascade,
	[EducationProgramCode] nvarchar(20) NULL,
	[EducationName] nvarchar(100) NULL,
	[Status] nvarchar(100) NULL,
Primary Key ([EducationProgramID])
) 
go

Create table [Lesson]
(
	[LessonID] Integer NOT NULL,
	[EducationProgramID] Integer NOT NULL foreign key([EducationProgramID]) references [EducationProgram] ([EducationProgramID])  on update cascade on delete cascade,
	[LessonCode] nvarchar(100) NULL,
	[LessonName] nvarchar(100) NULL,
	[VideoUrl] nvarchar(max) NULL,
	[ImageUrl] nvarchar(max) NULL,
	[Status] nvarchar(100) NULL,
Primary Key ([LessonID])
) 
go


Set quoted_identifier on
go


Set quoted_identifier off
go






--Generate record
-- user

INSERT INTO [User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate])
VALUES
(1, N'Hoàng', N'Nguyễn', N'Nam', '1990-05-15', '0987654321', N'Hà Nội', N'hoangnguyen@example.com', N'https://example.com/hoangnguyen.jpg', N'hoangnguyen', N'password123', N'Nhân viên', 1, '2020-01-01', NULL),
(2, N'Hương', N'Trần', N'Nữ', '1985-08-20', '0976543210', N'Hồ Chí Minh', N'huongtran@example.com', N'https://example.com/huongtran.jpg', N'huongtran', N'abc123', N'Quản lý', 1, '2019-12-10', NULL),
(3, N'Đức', N'Lê', N'Nam', '1988-03-10', '0965432109', N'Hải Phòng', N'ducle@example.com', N'https://example.com/ducle.jpg', N'ducle', N'duc@123', N'Nhân viên', 1, '2020-02-15', NULL),
(4, N'Anh', N'Nguyễn', N'Nam', '1995-12-25', '0954321098', N'Đà Nẵng', N'anhnguyen@example.com', N'https://example.com/anhnguyen.jpg', N'anhnguyen', N'123456', N'Nhân viên', 1, '2020-03-20', NULL),
(5, N'Thảo', N'Phạm', N'Nữ', '1992-09-03', '0943210987', N'Cần Thơ', N'thaopham@example.com', N'https://example.com/thaopham.jpg', N'thaopham', N'thao@789', N'Nhân viên', 1, '2018-11-11', NULL),
(6, N'Tuấn', N'Huỳnh', N'Nam', '1980-07-18', '0932109876', N'Long An', N'tuanhuynh@example.com', N'https://example.com/tuanhuynh.jpg', N'tuanhuynh', N'tuan123', N'Quản lý', 1, '2019-10-05', NULL),
(7, N'Ánh', N'Lý', N'Nữ', '1998-06-30', '0921098765', N'Tây Ninh', N'anhly@example.com', N'https://example.com/anhly.jpg', N'anhly', N'ly456', N'Nhân viên', 1, '2021-01-03', NULL),
(8, N'Thành', N'Võ', N'Nam', '1993-04-12', '0910987654', N'Bình Dương', N'thanhvo@example.com', N'https://example.com/thanhvo.jpg', N'thanhvo', N'vo789', N'Quản lý', 1, '2020-05-15', NULL),
(9, N'Loan', N'Trần', N'Nữ', '1983-11-05', '0909876543', N'Đồng Nai', N'loantran@example.com', N'https://example.com/loantran.jpg', N'loantran', N'loan@2022', N'Nhân viên', 1, '2017-09-20', NULL),
(10, N'Hải', N'Lê', N'Nam', '1987-02-28', '0898765432', N'Vũng Tàu', N'haile@example.com', N'https://example.com/haile.jpg', N'haile', N'haile123', N'Nhân viên', 1, '2019-08-12', NULL),
(11, N'Minh', N'Đặng', N'Nam', '1991-10-17', '0887654321', N'Quảng Nam', N'minhdang@example.com', N'https://example.com/minhdang.jpg', N'minhdang', N'minh@123', N'Nhân viên', 1, '2018-04-25', NULL),
(12, N'Thúy', N'Hoàng', N'Nữ', '1989-07-23', '0876543210', N'Thừa Thiên Huế', N'thuyhoang@example.com', N'https://example.com/thuyhoang.jpg', N'thuyhoang', N'thuy@2023', N'Nhân viên', 1, '2020-11-30', NULL),
(13, N'Dương', N'Lê', N'Nam', '1996-01-08', '0865432109', N'Bà Rịa - Vũng Tàu', N'duongle@example.com', N'https://example.com/duongle.jpg', N'duongle', N'duong123', N'Quản lý', 1, '2021-03-01', NULL),
(14, N'Quỳnh', N'Nguyễn', N'Nữ', '1986-08-09', '0854321098', N'Phú Yên', N'quynhnguyen@example.com', N'https://example.com/quynhnguyen.jpg', N'quynhnguyen', N'quynh@123', N'Nhân viên', 1, '2019-07-10', NULL),
(15, N'Thắng', N'Huỳnh', N'Nam', '1984-03-22', '0843210987', N'Lâm Đồng', N'thanghuynh@example.com', N'https://example.com/thanghuynh.jpg', N'thanghuynh', N'thang789', N'Nhân viên', 1, '2017-12-05', NULL),
(16, N'Thùy', N'Bùi', N'Nữ', '1994-12-10', '0832109876', N'Kon Tum', N'thuybui@example.com', N'https://example.com/thuybui.jpg', N'thuybui', N'bui456', N'Quản lý', 1, '2020-09-18', NULL),
(17, N'Tân', N'Lê', N'Nam', '1997-05-03', '0821098765', N'Lai Châu', N'tanle@example.com', N'https://example.com/tanle.jpg', N'tanle', N'le@123', N'Nhân viên', 1, '2022-02-20', NULL),
(18, N'Thảo', N'Vũ', N'Nữ', '1990-09-15', '0810987654', N'Quảng Bình', N'thaovu@example.com', N'https://example.com/thaovu.jpg', N'thaovu', N'thao789', N'Nhân viên', 1, '2018-10-30', NULL),
(19, N'Quang', N'Trần', N'Nam', '1982-06-27', '0809876543', N'Thái Bình', N'quangtran@example.com', N'https://example.com/quangtran.jpg', N'quangtran', N'quang@2022', N'Quản lý', 1, '2019-03-15', NULL),
(20, N'Thủy', N'Phan', N'Nữ', '1981-01-18', '0798765432', N'Hòa Bình', N'thuyphan@example.com', N'https://example.com/thuyphan.jpg', N'thuyphan', N'thuy@123', N'Nhân viên', 1, '2016-11-20', NULL),
(21, N'Tuấn', N'Trần', N'Nam', '1986-04-30', '0787654321', N'Hậu Giang', N'tuantran@example.com', N'https://example.com/tuantran.jpg', N'tuantran', N'tran123', N'Nhân viên', 1, '2018-08-28', NULL),
(22, N'Phương', N'Võ', N'Nữ', '1987-11-11', '0776543210', N'Bắc Giang', N'phuongvo@example.com', N'https://example.com/phuongvo.jpg', N'phuongvo', N'phuong@2023', N'Quản lý', 1, '2020-12-10', NULL),
(23, N'Thắng', N'Nguyễn', N'Nam', '1993-02-14', '0765432109', N'Cà Mau', N'thangnguyen@example.com', N'https://example.com/thangnguyen.jpg', N'thangnguyen', N'thang@123', N'Nhân viên', 1, '2019-06-03', NULL),
(24, N'Mỹ', N'Phạm', N'Nữ', '1984-08-07', '0754321098', N'Bắc Kạn', N'mypham@example.com', N'https://example.com/mypham.jpg', N'mypham', N'my@123', N'Quản lý', 1, '2018-09-25', NULL),
(25, N'Thị', N'Tran', N'Nữ', '1995-03-28', '0743210987', N'Nam Định', N'thitr@example.com', N'https://example.com/thitr.jpg', N'thitr', N'thitr@123', N'Nhân viên', 1, '2020-04-10', NULL),
(26, N'Thành', N'Nguyễn', N'Nam', '1988-06-19', '0732109876', N'Đồng Tháp', N'thanhnguyen@example.com', N'https://example.com/thanhnguyen.jpg', N'thanhnguyen', N'thanh123', N'Nhân viên', 1, '2019-01-15', NULL),
(27, N'Thủy', N'Lê', N'Nữ', '1989-11-02', '0721098765', N'Bình Thuận', N'thuyle@example.com', N'https://example.com/thuyle.jpg', N'thuyle', N'thuy@2024', N'Nhân viên', 1, '2021-05-20', NULL),
(28, N'Đức', N'Vũ', N'Nam', '1983-04-05', '0710987654', N'Lạng Sơn', N'ducvu@example.com', N'https://example.com/ducvu.jpg', N'ducvu', N'ducvu123', N'Quản lý', 1, '2018-07-12', NULL),
(29, N'An', N'Nguyễn', N'Nữ', '1992-01-23', '0709876543', N'Ninh Bình', N'annguyen@example.com', N'https://example.com/annguyen.jpg', N'annguyen', N'an@2022', N'Nhân viên', 1, '2017-12-30', NULL),
(30, N'Bình', N'Nguyễn', N'Nam', '1991-07-16', '0798765432', N'Phú Thọ', N'binhnguyen@example.com', N'https://example.com/binhnguyen.jpg', N'binhnguyen', N'binh@123', N'Nhân viên', 1, '2019-10-02', NULL),
(31, N'Thùy', N'Võ', N'Nữ', '1988-09-09', '0787654321', N'Thanh Hóa', N'thuyvo@example.com', N'https://example.com/thuyvo.jpg', N'thuyvo', N'thuyvo@123', N'Nhân viên', 1, '2018-05-07', NULL),
(32, N'Đức', N'Hoàng', N'Nam', '1985-02-18', '0776543210', N'Bạc Liêu', N'duchoang@example.com', N'https://example.com/duchoang.jpg', N'duchoang', N'duc@2023', N'Quản lý', 1, '2020-08-22', NULL),
(33, N'Thu', N'Lê', N'Nữ', '1996-11-13', '0765432109', N'Hà Tĩnh', N'thule@example.com', N'https://example.com/thule.jpg', N'thule', N'thule@2022', N'Nhân viên', 1, '2021-02-10', NULL),
(34, N'Thịnh', N'Nguyễn', N'Nam', '1986-05-26', '0754321098', N'Bến Tre', N'thinhnguyen@example.com', N'https://example.com/thinhnguyen.jpg', N'thinhnguyen', N'thinh@123', N'Quản lý', 1, '2019-09-18', NULL),
(35, N'Thảo', N'Phạm', N'Nữ', '1993-12-30', '0743210987', N'Kiên Giang', N'thaopham@example.com', N'https://example.com/thaopham.jpg', N'thaopham', N'thao@1234', N'Nhân viên', 1, '2018-03-23', NULL),
(36, N'Vinh', N'Tran', N'Nam', '1990-08-14', '0732109876', N'Lào Cai', N'vinhtran@example.com', N'https://example.com/vinhtran.jpg', N'vinhtran', N'vinh@2022', N'Nhân viên', 1, '2020-01-05', NULL),
(37, N'Minh', N'Phan', N'Nam', '1987-03-27', '0721098765', N'Lạng Sơn', N'minhphan@example.com', N'https://example.com/minhphan.jpg', N'minhphan', N'minh@2023', N'Quản lý', 1, '2019-04-30', NULL),
(38, N'Thuỳ', N'Hồ', N'Nữ', '1992-06-10', '0710987654', N'Bình Thuận', N'thuyho@example.com', N'https://example.com/thuyho.jpg', N'thuyho', N'thuyho@123', N'Nhân viên', 1, '2017-11-12', NULL),
(39, N'Đức', N'Trần', N'Nam', '1989-09-02', '0709876543', N'Vĩnh Long', N'ductran@example.com', N'https://example.com/ductran.jpg', N'ductran', N'ductran@123', N'Nhân viên', 1, '2018-12-25', NULL),
(40, N'Hoài', N'Lê', N'Nữ', '1988-12-25', '0798765432', N'Đồng Tháp', N'hoaille@example.com', N'https://example.com/hoaille.jpg', N'hoaille', N'hoai@2022', N'Quản lý', 1, '2021-08-17', NULL),
(41, N'Quốc', N'Nguyễn', N'Nam', '1994-02-02', '0787654321', N'Lào Cai', N'quocnguyen@example.com', N'https://example.com/quocnguyen.jpg', N'quocnguyen', N'quoc123', N'Nhân viên', 1, '2019-12-30', NULL),
(42, N'Anh', N'Phạm', N'Nữ', '1991-05-18', '0776543210', N'Thái Bình', N'anhpham@example.com', N'https://example.com/anhpham.jpg', N'anhpham', N'anh@2023', N'Nhân viên', 1, '2018-10-02', NULL),
(43, N'Thắng', N'Vũ', N'Nam', '1990-10-13', '0765432109', N'Thái Nguyên', N'thangvu@example.com', N'https://example.com/thangvu.jpg', N'thangvu', N'thangvu@123', N'Quản lý', 1, '2021-02-28', NULL),
(44, N'Thùy', N'Đặng', N'Nữ', '1985-03-08', '0754321098', N'Sơn La', N'thuydang@example.com', N'https://example.com/thuydang.jpg', N'thuydang', N'thuydang@123', N'Nhân viên', 1, '2019-07-15', NULL),
(45, N'Tuấn', N'Trần', N'Nam', '1983-07-22', '0743210987', N'Lâm Đồng', N'tuantran@example.com', N'https://example.com/tuantran.jpg', N'tuantran', N'tuan@2022', N'Nhân viên', 1, '2018-05-03', NULL),
(46, N'Mai', N'Nguyễn', N'Nữ', '1993-11-19', '0732109876', N'Bạc Giang', N'mainguyen@example.com', N'https://example.com/mainguyen.jpg', N'mainguyen', N'mai@123', N'Quản lý', 1, '2020-10-20', NULL),
(47, N'Đức', N'Phan', N'Nam', '1986-04-02', '0721098765', N'Thái Nguyên', N'ducphan@example.com', N'https://example.com/ducphan.jpg', N'ducphan', N'duc@123', N'Nhân viên', 1, '2019-11-05', NULL),
(48, N'Thảo', N'Vũ', N'Nữ', '1997-09-17', '0710987654', N'Lai Châu', N'thaovu@example.com', N'https://example.com/thaovu.jpg', N'thaovu', N'thaovu@123', N'Nhân viên', 1, '2022-04-15', NULL),
(49, N'Quốc', N'Lê', N'Nam', '1991-12-24', '0709876543', N'Quảng Bình', N'quocle@example.com', N'https://example.com/quocle.jpg', N'quocle', N'quocle@2023', N'Quản lý', 1, '2021-09-12', NULL),
(50, N'Minh', N'Hoàng', N'Nam', '1988-08-09', '0798765432', N'Cần Thơ', N'minhoang@example.com', N'https://example.com/minhoang.jpg', N'minhoang', N'minhoang@123', N'Nhân viên', 1, '2019-04-01', NULL);


--subject

INSERT INTO [Subject] ([SubjectID], [SubjectCode], [SubjectName], [Image])
VALUES
(1, N'MATH101', N'Toán cơ bản', N'https://example.com/math101.jpg'),
(2, N'ENG101', N'Tiếng Anh cơ bản', N'https://example.com/eng101.jpg'),
(3, N'PHY101', N'Vật lý cơ bản', N'https://example.com/phy101.jpg'),
(4, N'CHEM101', N'Hóa học cơ bản', N'https://example.com/chem101.jpg'),
(5, N'BIO101', N'Sinh học cơ bản', N'https://example.com/bio101.jpg'),
(6, N'HIST101', N'Lịch sử cơ bản', N'https://example.com/hist101.jpg'),
(7, N'GEOG101', N'Diễn đạt cơ bản', N'https://example.com/geog101.jpg'),
(8, N'COMP101', N'Tin học cơ bản', N'https://example.com/comp101.jpg'),
(9, N'MUS101', N'Âm nhạc cơ bản', N'https://example.com/mus101.jpg'),
(10, N'ART101', N'Hội họa cơ bản', N'https://example.com/art101.jpg');
