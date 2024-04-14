
create database SchoolManagement
go
use SchoolManagement
go

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
Primary Key ([UserID])
) 
go

Create table [Subject]
(
	[SubjectID] Integer  IDENTITY(1,1) NOT NULL,
	[SubjectCode] nvarchar(15) NULL,
	[SubjectName] nvarchar(100) NULL,
	[Image] nvarchar(max) NULL,
Primary Key ([SubjectID])
) 
go

Create table [Class]
(
	[ClassID] Integer  IDENTITY(1,1) NOT NULL,
	[TeacherID] Integer NOT NULL,
	[ClassCode] Datetime NULL,
	[ClassName] nvarchar(100) NULL,
	[NumberOfStudent] Integer NULL,
Primary Key ([ClassID])
) 
go

Create table [Student]
(
	[StudentID] Integer  IDENTITY(1,1) NOT NULL,
	[UserID] Integer NOT NULL,
	[StudentCode] nvarchar(20) NULL,
	[ClassID] Integer NOT NULL,
Primary Key ([StudentID])
) 
go

Create table [Teacher]
(
	[TeacherID] Integer  IDENTITY(1,1) NOT NULL,
	[DepartmentID] Integer NOT NULL,
	[LeaderID] Integer NOT NULL,
	[UserID] Integer NOT NULL,
	[TeacherCode] nvarchar(100) NULL,
	[Degree] nvarchar(200) NULL,
	[Expertise_] nvarchar(100) NULL,
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
	[SubjectID] Integer NOT NULL,
Primary Key ([TeacherID])
) 
go

Create table [Course]
(
	[ClassID] Integer NOT NULL,
	[TeacherID] Integer NOT NULL,
	[SubjectID] Integer NOT NULL,
	[NumberOfLessons] Integer NULL,
	[StartDate] Datetime NULL,
	[EndDate] Datetime NULL,
Primary Key ([ClassID],[SubjectID])
) 
go

Create table [Department]
(
	[DepartmentID] Integer  IDENTITY(1,1) NOT NULL,
	[DepartmentCode] nvarchar(20) NULL,
	[DepartmentName] nvarchar(100) NULL,
	[FoundingDate] Datetime NULL,
	[Image] nvarchar(max) NULL,
Primary Key ([DepartmentID])
) 
go

Create table [GradeSheet]
(
	[GradeSheetID] Integer  IDENTITY(1,1) NOT NULL,
	[ClassID] Integer NOT NULL,
	[StudentID] Integer NOT NULL,
	[SubjectID] Integer NOT NULL,
	[FirstRegularScore] float NULL,
	[SecondRegularScore] float NULL,
	[ThirdRegularScore] float NULL,
	[FourRegularScore] float NULL,
	[MidtermScore] float NULL,
	[FinalScore] float NULL,
	[SemesterAverage] float NULL,
Primary Key ([GradeSheetID])
) 
go

Create table [Schedule]
(
	[ScheduleID] Integer  IDENTITY(1,1) NOT NULL,
	[ClassID] Integer NOT NULL,
	[SubjectID] Integer NOT NULL,
	[ScheduleCode] nvarchar(100) NULL,
	[Day] Datetime NULL,
	[Start] Datetime NULL,
	[End] Datetime NULL,
Primary Key ([ScheduleID])
) 
go

Create table [EducationProgram]
(
	[EducationProgramID] Integer   IDENTITY(1,1)NOT NULL,
	[ClassID] Integer NOT NULL,
	[SubjectID] Integer NOT NULL,
	[EducationProgramCode] nvarchar(20) NULL,
	[EducationName] nvarchar(100) NULL,
	[Status] nvarchar(100) NULL,
Primary Key ([EducationProgramID])
) 
go

Create table [Lesson]
(
	[LessonID] Integer  IDENTITY(1,1) NOT NULL,
	[EducationProgramID] Integer NOT NULL,
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




-- Thêm hành động cho foreign key trong bảng Student
ALTER TABLE Student
ADD FOREIGN KEY (ClassID) REFERENCES Class(ClassID)
ON DELETE CASCADE
ON UPDATE CASCADE;
ALTER TABLE Student
ADD FOREIGN KEY (UserID) REFERENCES [User](UserID)
ON DELETE CASCADE
ON UPDATE CASCADE;

-- Thêm hành động cho foreign key trong bảng Class
ALTER TABLE Class
ADD FOREIGN KEY (TeacherID) REFERENCES Teacher(TeacherID)
ON DELETE CASCADE
ON UPDATE CASCADE;

-- Thêm hành động cho foreign key trong bảng Course
ALTER TABLE Course
ADD FOREIGN KEY (TeacherID) REFERENCES Teacher(TeacherID)
ON DELETE CASCADE
ON UPDATE CASCADE;

-- Thêm hành động cho foreign key trong bảng GradeSheet
ALTER TABLE GradeSheet
ADD FOREIGN KEY (ClassID) REFERENCES Class(ClassID)
ON DELETE No action
ON UPDATE No action
ALTER TABLE GradeSheet
ADD FOREIGN KEY (StudentID) REFERENCES Student(StudentID)
ON DELETE No action
ON UPDATE No action;
ALTER TABLE GradeSheet
ADD FOREIGN KEY (SubjectID) REFERENCES Subject(SubjectID)
ON DELETE No action
ON UPDATE No action;

-- Thêm hành động cho foreign key trong bảng Schedule
ALTER TABLE Schedule
ADD FOREIGN KEY (ClassID) REFERENCES Class(ClassID)
ON DELETE No action
ON UPDATE No action;
ALTER TABLE Schedule
ADD FOREIGN KEY (SubjectID) REFERENCES Subject(SubjectID)
ON DELETE No action
ON UPDATE No action;

-- Thêm hành động cho foreign key trong bảng EducationProgram
ALTER TABLE EducationProgram
ADD FOREIGN KEY (ClassID) REFERENCES Class(ClassID)
ON DELETE CASCADE
ON UPDATE CASCADE;
ALTER TABLE EducationProgram
ADD FOREIGN KEY (SubjectID) REFERENCES Subject(SubjectID)
ON DELETE No action
ON UPDATE No action;

-- Thêm hành động cho foreign key trong bảng Lesson
ALTER TABLE Lesson
ADD FOREIGN KEY (EducationProgramID) REFERENCES EducationProgram(EducationProgramID)
ON DELETE CASCADE
ON UPDATE CASCADE;


ALTER TABLE Teacher
ADD FOREIGN KEY (DepartmentID) REFERENCES Department(DepartmentID)
ON DELETE No action
ON UPDATE No action;

ALTER TABLE Teacher
ADD FOREIGN KEY (UserID) REFERENCES [User](UserID)
ON DELETE No action
ON UPDATE No action;

ALTER TABLE Teacher
ADD FOREIGN KEY (SubjectID) REFERENCES Subject(SubjectID)
ON DELETE CASCADE
ON UPDATE CASCADE;





INSERT INTO [User] ( [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate])
VALUES
( N'Hoàng', N'Nguyễn', N'Nam', '1990-05-15', '0987654321', N'Hà Nội', N'hoangnguyen@example.com', N'https://example.com/hoangnguyen.jpg', N'admin', N'admin', N'Nhân viên', 1, '2020-01-01', NULL),
( N'Hương', N'Trần', N'Nữ', '1985-08-20', '0976543210', N'Hồ Chí Minh', N'huongtran@example.com', N'https://example.com/huongtran.jpg', N'huongtran', N'abc123', N'Quản lý', 1, '2019-12-10', NULL),
( N'Đức', N'Lê', N'Nam', '1988-03-10', '0965432109', N'Hải Phòng', N'ducle@example.com', N'https://example.com/ducle.jpg', N'ducle', N'duc@123', N'Nhân viên', 1, '2020-02-15', NULL),
( N'Anh', N'Nguyễn', N'Nam', '1995-12-25', '0954321098', N'Đà Nẵng', N'anhnguyen@example.com', N'https://example.com/anhnguyen.jpg', N'anhnguyen', N'123456', N'Nhân viên', 1, '2020-03-20', NULL),
(N'Thảo', N'Phạm', N'Nữ', '1992-09-03', '0943210987', N'Cần Thơ', N'thaopham@example.com', N'https://example.com/thaopham.jpg', N'thaopham', N'thao@789', N'Nhân viên', 1, '2018-11-11', NULL),
( N'Tuấn', N'Huỳnh', N'Nam', '1980-07-18', '0932109876', N'Long An', N'tuanhuynh@example.com', N'https://example.com/tuanhuynh.jpg', N'tuanhuynh', N'tuan123', N'Quản lý', 1, '2019-10-05', NULL),
( N'Ánh', N'Lý', N'Nữ', '1998-06-30', '0921098765', N'Tây Ninh', N'anhly@example.com', N'https://example.com/anhly.jpg', N'anhly', N'ly456', N'Nhân viên', 1, '2021-01-03', NULL),
( N'Thành', N'Võ', N'Nam', '1993-04-12', '0910987654', N'Bình Dương', N'thanhvo@example.com', N'https://example.com/thanhvo.jpg', N'thanhvo', N'vo789', N'Quản lý', 1, '2020-05-15', NULL),
( N'Loan', N'Trần', N'Nữ', '1983-11-05', '0909876543', N'Đồng Nai', N'loantran@example.com', N'https://example.com/loantran.jpg', N'loantran', N'loan@2022', N'Nhân viên', 1, '2017-09-20', NULL),
( N'Hải', N'Lê', N'Nam', '1987-02-28', '0898765432', N'Vũng Tàu', N'haile@example.com', N'https://example.com/haile.jpg', N'haile', N'haile123', N'Nhân viên', 1, '2019-08-12', NULL),
( N'Minh', N'Đặng', N'Nam', '1991-10-17', '0887654321', N'Quảng Nam', N'minhdang@example.com', N'https://example.com/minhdang.jpg', N'minhdang', N'minh@123', N'Nhân viên', 1, '2018-04-25', NULL),
( N'Thúy', N'Hoàng', N'Nữ', '1989-07-23', '0876543210', N'Thừa Thiên Huế', N'thuyhoang@example.com', N'https://example.com/thuyhoang.jpg', N'thuyhoang', N'thuy@2023', N'Nhân viên', 1, '2020-11-30', NULL),
( N'Dương', N'Lê', N'Nam', '1996-01-08', '0865432109', N'Bà Rịa - Vũng Tàu', N'duongle@example.com', N'https://example.com/duongle.jpg', N'duongle', N'duong123', N'Quản lý', 1, '2021-03-01', NULL),
( N'Quỳnh', N'Nguyễn', N'Nữ', '1986-08-09', '0854321098', N'Phú Yên', N'quynhnguyen@example.com', N'https://example.com/quynhnguyen.jpg', N'quynhnguyen', N'quynh@123', N'Nhân viên', 1, '2019-07-10', NULL),
( N'Thắng', N'Huỳnh', N'Nam', '1984-03-22', '0843210987', N'Lâm Đồng', N'thanghuynh@example.com', N'https://example.com/thanghuynh.jpg', N'thanghuynh', N'thang789', N'Nhân viên', 1, '2017-12-05', NULL),
(N'Thùy', N'Bùi', N'Nữ', '1994-12-10', '0832109876', N'Kon Tum', N'thuybui@example.com', N'https://example.com/thuybui.jpg', N'thuybui', N'bui456', N'Quản lý', 1, '2020-09-18', NULL),
(N'Tân', N'Lê', N'Nam', '1997-05-03', '0821098765', N'Lai Châu', N'tanle@example.com', N'https://example.com/tanle.jpg', N'tanle', N'le@123', N'Nhân viên', 1, '2022-02-20', NULL),
(N'Thảo', N'Vũ', N'Nữ', '1990-09-15', '0810987654', N'Quảng Bình', N'thaovu@example.com', N'https://example.com/thaovu.jpg', N'thaovu', N'thao789', N'Nhân viên', 1, '2018-10-30', NULL),
(N'Quang', N'Trần', N'Nam', '1982-06-27', '0809876543', N'Thái Bình', N'quangtran@example.com', N'https://example.com/quangtran.jpg', N'quangtran', N'quang@2022', N'Quản lý', 1, '2019-03-15', NULL),
( N'Thủy', N'Phan', N'Nữ', '1981-01-18', '0798765432', N'Hòa Bình', N'thuyphan@example.com', N'https://example.com/thuyphan.jpg', N'thuyphan', N'thuy@123', N'Nhân viên', 1, '2016-11-20', NULL),
( N'Tuấn', N'Trần', N'Nam', '1986-04-30', '0787654321', N'Hậu Giang', N'tuantran@example.com', N'https://example.com/tuantran.jpg', N'tuantran', N'tran123', N'Nhân viên', 1, '2018-08-28', NULL),
( N'Phương', N'Võ', N'Nữ', '1987-11-11', '0776543210', N'Bắc Giang', N'phuongvo@example.com', N'https://example.com/phuongvo.jpg', N'phuongvo', N'phuong@2023', N'Quản lý', 1, '2020-12-10', NULL),
(N'Thắng', N'Nguyễn', N'Nam', '1993-02-14', '0765432109', N'Cà Mau', N'thangnguyen@example.com', N'https://example.com/thangnguyen.jpg', N'thangnguyen', N'thang@123', N'Nhân viên', 1, '2019-06-03', NULL),
( N'Mỹ', N'Phạm', N'Nữ', '1984-08-07', '0754321098', N'Bắc Kạn', N'mypham@example.com', N'https://example.com/mypham.jpg', N'mypham', N'my@123', N'Quản lý', 1, '2018-09-25', NULL),
( N'Thị', N'Tran', N'Nữ', '1995-03-28', '0743210987', N'Nam Định', N'thitr@example.com', N'https://example.com/thitr.jpg', N'thitr', N'thitr@123', N'Nhân viên', 1, '2020-04-10', NULL),
( N'Thành', N'Nguyễn', N'Nam', '1988-06-19', '0732109876', N'Đồng Tháp', N'thanhnguyen@example.com', N'https://example.com/thanhnguyen.jpg', N'thanhnguyen', N'thanh123', N'Nhân viên', 1, '2019-01-15', NULL),
(N'Thủy', N'Lê', N'Nữ', '1989-11-02', '0721098765', N'Bình Thuận', N'thuyle@example.com', N'https://example.com/thuyle.jpg', N'thuyle', N'thuy@2024', N'Nhân viên', 1, '2021-05-20', NULL),
( N'Đức', N'Vũ', N'Nam', '1983-04-05', '0710987654', N'Lạng Sơn', N'ducvu@example.com', N'https://example.com/ducvu.jpg', N'ducvu', N'ducvu123', N'Quản lý', 1, '2018-07-12', NULL),
(N'An', N'Nguyễn', N'Nữ', '1992-01-23', '0709876543', N'Ninh Bình', N'annguyen@example.com', N'https://example.com/annguyen.jpg', N'annguyen', N'an@2022', N'Nhân viên', 1, '2017-12-30', NULL),
( N'Bình', N'Nguyễn', N'Nam', '1991-07-16', '0798765432', N'Phú Thọ', N'binhnguyen@example.com', N'https://example.com/binhnguyen.jpg', N'binhnguyen', N'binh@123', N'Nhân viên', 1, '2019-10-02', NULL),
( N'Thùy', N'Võ', N'Nữ', '1988-09-09', '0787654321', N'Thanh Hóa', N'thuyvo@example.com', N'https://example.com/thuyvo.jpg', N'thuyvo', N'thuyvo@123', N'Nhân viên', 1, '2018-05-07', NULL),
( N'Đức', N'Hoàng', N'Nam', '1985-02-18', '0776543210', N'Bạc Liêu', N'duchoang@example.com', N'https://example.com/duchoang.jpg', N'duchoang', N'duc@2023', N'Quản lý', 1, '2020-08-22', NULL),
( N'Thu', N'Lê', N'Nữ', '1996-11-13', '0765432109', N'Hà Tĩnh', N'thule@example.com', N'https://example.com/thule.jpg', N'thule', N'thule@2022', N'Nhân viên', 1, '2021-02-10', NULL),
( N'Thịnh', N'Nguyễn', N'Nam', '1986-05-26', '0754321098', N'Bến Tre', N'thinhnguyen@example.com', N'https://example.com/thinhnguyen.jpg', N'thinhnguyen', N'thinh@123', N'Quản lý', 1, '2019-09-18', NULL),
( N'Thảo', N'Phạm', N'Nữ', '1993-12-30', '0743210987', N'Kiên Giang', N'thaopham@example.com', N'https://example.com/thaopham.jpg', N'thaopham', N'thao@1234', N'Nhân viên', 1, '2018-03-23', NULL),
( N'Vinh', N'Tran', N'Nam', '1990-08-14', '0732109876', N'Lào Cai', N'vinhtran@example.com', N'https://example.com/vinhtran.jpg', N'vinhtran', N'vinh@2022', N'Nhân viên', 1, '2020-01-05', NULL),
( N'Minh', N'Phan', N'Nam', '1987-03-27', '0721098765', N'Lạng Sơn', N'minhphan@example.com', N'https://example.com/minhphan.jpg', N'minhphan', N'minh@2023', N'Quản lý', 1, '2019-04-30', NULL),
( N'Thuỳ', N'Hồ', N'Nữ', '1992-06-10', '0710987654', N'Bình Thuận', N'thuyho@example.com', N'https://example.com/thuyho.jpg', N'thuyho', N'thuyho@123', N'Nhân viên', 1, '2017-11-12', NULL),
( N'Đức', N'Trần', N'Nam', '1989-09-02', '0709876543', N'Vĩnh Long', N'ductran@example.com', N'https://example.com/ductran.jpg', N'ductran', N'ductran@123', N'Nhân viên', 1, '2018-12-25', NULL),
( N'Hoài', N'Lê', N'Nữ', '1988-12-25', '0798765432', N'Đồng Tháp', N'hoaille@example.com', N'https://example.com/hoaille.jpg', N'hoaille', N'hoai@2022', N'Quản lý', 1, '2021-08-17', NULL),
( N'Quốc', N'Nguyễn', N'Nam', '1994-02-02', '0787654321', N'Lào Cai', N'quocnguyen@example.com', N'https://example.com/quocnguyen.jpg', N'quocnguyen', N'quoc123', N'Nhân viên', 1, '2019-12-30', NULL),
(N'Anh', N'Phạm', N'Nữ', '1991-05-18', '0776543210', N'Thái Bình', N'anhpham@example.com', N'https://example.com/anhpham.jpg', N'anhpham', N'anh@2023', N'Nhân viên', 1, '2018-10-02', NULL),
( N'Thắng', N'Vũ', N'Nam', '1990-10-13', '0765432109', N'Thái Nguyên', N'thangvu@example.com', N'https://example.com/thangvu.jpg', N'thangvu', N'thangvu@123', N'Quản lý', 1, '2021-02-28', NULL),
( N'Thùy', N'Đặng', N'Nữ', '1985-03-08', '0754321098', N'Sơn La', N'thuydang@example.com', N'https://example.com/thuydang.jpg', N'thuydang', N'thuydang@123', N'Nhân viên', 1, '2019-07-15', NULL),
( N'Tuấn', N'Trần', N'Nam', '1983-07-22', '0743210987', N'Lâm Đồng', N'tuantran@example.com', N'https://example.com/tuantran.jpg', N'tuantran', N'tuan@2022', N'Nhân viên', 1, '2018-05-03', NULL),
( N'Mai', N'Nguyễn', N'Nữ', '1993-11-19', '0732109876', N'Bạc Giang', N'mainguyen@example.com', N'https://example.com/mainguyen.jpg', N'mainguyen', N'mai@123', N'Quản lý', 1, '2020-10-20', NULL),
( N'Đức', N'Phan', N'Nam', '1986-04-02', '0721098765', N'Thái Nguyên', N'ducphan@example.com', N'https://example.com/ducphan.jpg', N'ducphan', N'duc@123', N'Nhân viên', 1, '2019-11-05', NULL),
(N'Thảo', N'Vũ', N'Nữ', '1997-09-17', '0710987654', N'Lai Châu', N'thaovu@example.com', N'https://example.com/thaovu.jpg', N'thaovu', N'thaovu@123', N'Nhân viên', 1, '2022-04-15', NULL),
( N'Quốc', N'Lê', N'Nam', '1991-12-24', '0709876543', N'Quảng Bình', N'quocle@example.com', N'https://example.com/quocle.jpg', N'quocle', N'quocle@2023', N'Quản lý', 1, '2021-09-12', NULL),
( N'Minh', N'Hoàng', N'Nam', '1988-08-09', '0798765432', N'Cần Thơ', N'minhoang@example.com', N'https://example.com/minhoang.jpg', N'minhoang', N'minhoang@123', N'Nhân viên', 1, '2019-04-01', NULL);


--subject

INSERT INTO [Subject] ([SubjectCode], [SubjectName], [Image])
VALUES
( N'MATH101', N'Toán', N'https://example.com/math101.jpg'),
( N'ENG101', N'Tiếng Anh', N'https://example.com/eng101.jpg'),
(N'PHY101', N'Vật lý', N'https://example.com/phy101.jpg'),
(N'CHEM101', N'Hóa học', N'https://example.com/chem101.jpg'),
(N'BIO101', N'Sinh học', N'https://example.com/bio101.jpg'),
(N'HIST101', N'Lịch sử', N'https://example.com/hist101.jpg'),
(N'GEOG101', N'Diễn đạt', N'https://example.com/geog101.jpg'),
(N'COMP101', N'Tin học', N'https://example.com/comp101.jpg'),
(N'MUS101', N'Âm nhạc', N'https://example.com/mus101.jpg'),
( N'ART101', N'Hội họa', N'https://example.com/art101.jpg');

INSERT INTO Department ([DepartmentCode], [DepartmentName], [FoundingDate], [Image])
VALUES
(N'DEPT001', N'Toán học', '1990-01-01', N'https://example.com/toanhoc.jpg'),
(N'DEPT002', N'Hóa học', '1992-05-10', N'https://example.com/hoahoc.jpg'),
(N'DEPT003', N'Sinh học', '1995-09-20', N'https://example.com/sinhhoc.jpg'),
(N'DEPT004', N'Lịch sử', '1988-03-15', N'https://example.com/lichsu.jpg'),
(N'DEPT005', N'Văn học', '1997-11-30', N'https://example.com/vanhoc.jpg'),
(N'DEPT006', N'Địa lý', '1994-07-25', N'https://example.com/diali.jpg');


-- delete from Teacher
INSERT INTO Teacher ( [DepartmentID], [LeaderID], [UserID], [TeacherCode], [Degree], [Expertise_], [University], [GraduationYear], [Major], [OtherCertifications_], [Position], [Salary], [AdditionalBenifits], [CurrentHealthStatus], [HealthInsuranceInfo_], [SelfIntroduction_], [SubjectID])
VALUES
( 1, 6, 1, 'TC001', N'Thạc sĩ', N'Toán học', N'Đại học Quốc gia Hà Nội', '2010-01-01', N'Toán', NULL, N'Giáo viên', 30000000, N'Bảo hiểm y tế', N'Bình thường', N'Bảo hiểm BHYT số 123456789', N'Tôi là một giáo viên Toán có kinh nghiệm', 1),
(1, 6, 2, 'TC002', N'Tiến sĩ', N'Hóa học', N'Đại học Quốc gia Hà Nội', '2012-01-01', N'Hóa học', NULL, N'Giáo viên', 35000000, N'Bảo hiểm y tế', N'Bình thường', N'Bảo hiểm BHYT số 234567890', N'Tôi là một giáo viên Hóa học có kinh nghiệm', 4),
(1, 6, 3, 'TC003', N'Đại học', N'Sinh học', N'Đại học Quốc gia Hà Nội', '2015-01-01', N'Sinh học', NULL, N'Giáo viên', 32000000, N'Bảo hiểm y tế', N'Bình thường', N'Bảo hiểm BHYT số 345678901', N'Tôi là một giáo viên Sinh học có kinh nghiệm', 5),
(2, 6, 4, 'TC004', N'Cử nhân', N'Lịch sử', N'Đại học Sư phạm Hà Nội', '2014-01-01', N'Lịch sử', NULL, N'Giáo viên', 29000000, N'Bảo hiểm y tế', N'Bình thường', N'Bảo hiểm BHYT số 456789012', N'Tôi là một giáo viên Lịch sử có kinh nghiệm', 6),
( 2, 6, 5, 'TC005', N'Tiến sĩ', N'Văn học', N'Đại học Quốc gia Hồ Chí Minh', '2013-01-01', N'Văn học', NULL, N'Giáo viên', 31000000, N'Bảo hiểm y tế', N'Bình thường', N'Bảo hiểm BHYT số 567890123', N'Tôi là một giáo viên Văn học có kinh nghiệm', 7),
(3, 6, 6, 'TC006', N'Thạc sĩ', N'Địa lý', N'Đại học Sư phạm Thành phố Hồ Chí Minh', '2011-01-01', N'Địa lý', NULL, N'Giáo viên', 33000000, N'Bảo hiểm y tế', N'Bình thường', N'Bảo hiểm BHYT số 678901234', N'Tôi là một giáo viên Địa lý có kinh nghiệm', 8),
(3, 6, 7, 'TC007', N'Tiến sĩ', N'Thể dục', N'Đại học Sư phạm Thành phố Hồ Chí Minh', '2010-01-01', N'Thể dục', NULL, N'Giáo viên', 32000000, N'Bảo hiểm y tế', N'Bình thường', N'Bảo hiểm BHYT số 789012345', N'Tôi là một giáo viên Thể dục có kinh nghiệm', 9),
( 4, 6, 8, 'TC008', N'Cử nhân', N'Nghệ thuật', N'Đại học Mỹ thuật Hà Nội', '2013-01-01', N'Nghệ thuật', NULL, N'Giáo viên', 28000000, N'Bảo hiểm y tế', N'Bình thường', N'Bảo hiểm BHYT số 890123456', N'Tôi là một giáo viên Nghệ thuật có kinh nghiệm', 10),
(4, 6, 9, 'TC009', N'Thạc sĩ', N'Âm nhạc', N'Đại học Mỹ thuật Hà Nội', '2015-01-01', N'Âm nhạc', NULL, N'Giáo viên', 30000000, N'Bảo hiểm y tế', N'Bình thường', N'Bảo hiểm BHYT số 901234567', N'Tôi là một giáo viên Âm nhạc có kinh nghiệm', 9),
( 5, 6, 10, 'TC010', N'Đại học', N'Toán học', N'Đại học Công nghệ Hà Nội', '2012-01-01', N'Toán học', NULL, N'Giáo viên', 31000000, N'Bảo hiểm y tế', N'Bình thường', N'Bảo hiểm BHYT số 012345678', N'Tôi là một giáo viên Toán học có kinh nghiệm', 1),
( 5, 6, 11, 'TC011', N'Cử nhân', N'Ngữ văn', N'Đại học Công nghệ Hà Nội', '2014-01-01', N'Ngữ văn', NULL, N'Giáo viên', 32000000, N'Bảo hiểm y tế', N'Bình thường', N'Bảo hiểm BHYT số 123456780', N'Tôi là một giáo viên Ngữ văn có kinh nghiệm', 2),
( 6, 6, 12, 'TC012', N'Thạc sĩ', N'Lịch sử', N'Đại học Sư phạm Thành phố Hồ Chí Minh', '2011-01-01', N'Lịch sử', NULL, N'Giáo viên', 33000000, N'Bảo hiểm y tế', N'Bình thường', N'Bảo hiểm BHYT số 234567890', N'Tôi là một giáo viên Lịch sử có kinh nghiệm', 3),
( 6, 6, 13, 'TC013', N'Tiến sĩ', N'Văn hóa', N'Đại học Sư phạm Thành phố Hồ Chí Minh', '2013-01-01', N'Văn hóa', NULL, N'Giáo viên', 34000000, N'Bảo hiểm y tế', N'Bình thường', N'Bảo hiểm BHYT số 345678901', N'Tôi là một giáo viên Văn hóa có kinh nghiệm', 4),
( 6, 6, 14, 'TC014', N'Thạc sĩ', N'Tâm lý học', N'Đại học Sư phạm Thành phố Hồ Chí Minh', '2014-01-01', N'Tâm lý học', NULL, N'Giáo viên', 35000000, N'Bảo hiểm y tế', N'Bình thường', N'Bảo hiểm BHYT số 456789012', N'Tôi là một giáo viên Tâm lý học có kinh nghiệm', 5),
( 6, 6, 15, 'TC015', N'Cử nhân', N'Tiếng Anh', N'Đại học Ngoại ngữ Hà Nội', '2012-01-01', N'Tiếng Anh', NULL, N'Giáo viên', 36000000, N'Bảo hiểm y tế', N'Bình thường', N'Bảo hiểm BHYT số 567890123', N'Tôi là một giáo viên Tiếng Anh có kinh nghiệm', 6)


--delete from Class
INSERT INTO Class ([TeacherID], [ClassCode], [ClassName], [NumberOfStudent])
VALUES
(1, '2024-04-14', N'10A1', 30),
(2, '2024-04-14', N'10A2', 25),
(3, '2024-04-14', N'10A3', 28),
(4, '2024-04-14', N'10A4', 32),
(5, '2024-04-14', N'10A5', 27),
(6, '2024-04-14', N'10A6', 29),
( 7, '2024-04-14',  N'11A1', 30),
( 8, '2024-04-14',  N'11A2', 25),
( 9, '2024-04-14',  N'11A3', 28),
( 10, '2024-04-14', N'11A4', 32),
(11, '2024-04-14',  N'11A5', 27),
( 12, '2024-04-14', N'11A6', 29),
(13, '2024-04-14',  N'12A1', 30),
( 14, '2024-04-14', N'12A2', 25),
( 15, '2024-04-14', N'12A3', 28)

--delete from Course  10A5
-- Tạo bảng Student	  10A6
INSERT INTO Student (UserID, StudentCode, ClassID)
VALUES 
    (16, 'STD001', 1),
    (17, 'STD002', 1),
    (18, 'STD003', 1),
    (19, 'STD004', 1),
    (20, 'STD005', 1),
    (21, 'STD006', 1),
    (22, 'STD007', 1),
    (23, 'STD008', 1),
    (24, 'STD009', 1),
    (25, 'STD010', 1),
    (26, 'STD011', 1),
    (27, 'STD012', 1),
    (28, 'STD013', 1),
    (29, 'STD014', 1),
    (30, 'STD015', 1),
    (31, 'STD016', 1),
    (32, 'STD017', 1),
    (33, 'STD018', 1),
    (34, 'STD019', 1),
    (35, 'STD020', 1),
    (36, 'STD021', 2),
    (37, 'STD022', 2),
    (38, 'STD023', 2),
    (39, 'STD024', 2),
    (40, 'STD025', 2),
    (41, 'STD026', 2),
    (42, 'STD027', 2),
    (43, 'STD028', 2),
    (44, 'STD029', 2),
    (45, 'STD030', 2),
    (46, 'STD031', 2),
    (47, 'STD032', 2),
    (48, 'STD033', 2),
    (49, 'STD034', 2),
    (50, 'STD035', 2)
INSERT INTO Course ([ClassID], [TeacherID], [SubjectID], [NumberOfLessons], [StartDate], [EndDate])
VALUES
(1, 1, 1, 30, '2024-04-14', '2024-05-14'),
(2, 1, 1, 25, '2024-04-14', '2024-05-14'),
(3, 3, 3, 28, '2024-04-14', '2024-05-14'),
(4, 1, 1, 32, '2024-04-14', '2024-05-14'),
(5, 5, 5, 27, '2024-04-14', '2024-05-14'),
(6, 1, 1, 29, '2024-04-14', '2024-05-14'),
(7, 7, 1, 30, '2024-04-14', '2024-05-14'),
(8, 1, 1, 25, '2024-04-14', '2024-05-14'),
(9, 9, 3, 28, '2024-04-14', '2024-05-14'),
(10, 10, 4, 32, '2024-04-14', '2024-05-14'),
(11, 1, 1, 27, '2024-04-14', '2024-05-14'),
(12, 12, 6, 29, '2024-04-14', '2024-05-14'),
(13, 1, 1, 30, '2024-04-14', '2024-05-14'),
(14, 14, 2, 25, '2024-04-14', '2024-05-14'),
(15, 15, 3, 28, '2024-04-14', '2024-05-14'),
(16, 1, 1, 32, '2024-04-14', '2024-05-14'),
(17, 1, 1, 27, '2024-04-14', '2024-05-14'),
(18, 1, 1, 29, '2024-04-14', '2024-05-14'),
(19, 1, 1, 30, '2024-04-14', '2024-05-14'),
(20, 1, 1, 25, '2024-04-14', '2024-05-14');




-----
INSERT INTO GradeSheet ([ClassID], [StudentID], [SubjectID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage])
VALUES
(1, 31, 1, 8.5, 7.2, 9.0, 8.8, 8.9, 8.7, 8.6),
(1, 2, 1, 7.8, 8.0, 8.5, 8.3, 8.6, 8.4, 8.2),
(1, 3, 1, 8.2, 8.6, 8.9, 8.7, 8.8, 8.5, 8.7),
(1, 4, 1, 8.9, 9.0, 9.2, 9.1, 9.0, 8.8, 8.9),
(1, 5, 1, 7.5, 8.0, 7.8, 7.6, 8.1, 7.9, 7.8),
(1, 6, 1, 8.0, 7.9, 8.2, 8.1, 8.3, 8.0, 8.1),
(1, 7, 1, 8.3, 8.4, 8.6, 8.5, 8.7, 8.4, 8.5),
(1, 8, 1, 8.6, 8.8, 9.0, 8.9, 9.0, 8.7, 8.8),
(1, 9, 1, 7.9, 8.1, 8.4, 8.3, 8.5, 8.2, 8.3),
(1, 10, 1, 8.4, 8.7, 8.9, 8.8, 8.9, 8.6, 8.7),
(1, 11, 1, 8.8, 9.0, 9.2, 9.1, 9.1, 8.9, 9.0),
(1, 12, 1, 7.7, 7.9, 8.1, 8.0, 8.2, 7.9, 8.0),
(1, 13, 1, 8.2, 8.5, 8.8, 8.7, 8.8, 8.6, 8.6),
(1, 14, 1, 8.7, 8.9, 9.1, 9.0, 9.1, 8.8, 8.9),
(1, 15, 1, 8.0, 8.3, 8.6, 8.5, 8.7, 8.4, 8.5),
(1, 16, 1, 8.5, 8.8, 9.0, 8.9, 9.0, 8.7, 8.8),
(1, 17, 1, 8.9, 9.1, 9.3, 9.2, 9.2, 9.0, 9.1),
(1, 18, 1, 7.8, 8.0, 8.3, 8.2, 8.4, 8.1, 8.2),
(1, 19, 1, 8.1, 8.3, 8.6, 8.5, 8.6, 8.4, 8.4),
(1, 20, 1, 8.5, 8.7, 8.9, 8.8, 8.9, 8.6, 8.7),
(1, 21, 1, 8.6, 7.9, 9.1, 8.8, 9.0, 8.7, 8.8),
(1, 22, 1, 8.2, 8.5, 8.8, 8.7, 8.8, 8.6, 8.6),
(1, 23, 1, 8.7, 8.9, 9.1, 9.0, 9.1, 8.8, 8.9),
(1, 24, 1, 8.4, 8.6, 8.9, 8.7, 8.8, 8.5, 8.6),
(1, 25, 1, 8.8, 9.0, 9.2, 9.1, 9.1, 8.9, 9.0),
(1, 26, 1, 8.1, 8.3, 8.6, 8.5, 8.7, 8.4, 8.5),
(1, 27, 1, 8.5, 8.7, 8.9, 8.8, 8.9, 8.6, 8.7),
(1, 28, 1, 8.9, 9.1, 9.3, 9.2, 9.2, 9.0, 9.1),
(1, 29, 1, 8.2, 8.4, 8.7, 8.6, 8.8, 8.5, 8.6),
(1, 30, 1, 8.6, 8.8, 9.0, 8.9, 9.0, 8.7, 8.8)



INSERT INTO GradeSheet ([ClassID], [StudentID], [SubjectID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage])
VALUES
(2, 31, 1, 8.5, 7.2, 9.0, 8.8, 8.9, 8.7, 8.6),
(2, 2, 1, 7.8, 8.0, 8.5, 8.3, 8.6, 8.4, 8.2),
(2, 3, 1, 8.2, 8.6, 8.9, 8.7, 8.8, 8.5, 8.7),
(2, 4, 1, 8.9, 9.0, 9.2, 9.1, 9.0, 8.8, 8.9),
(2, 5, 1, 7.5, 8.0, 7.8, 7.6, 8.1, 7.9, 7.8),
(2, 6, 1, 8.0, 7.9, 8.2, 8.1, 8.3, 8.0, 8.1),
(2, 7, 1, 8.3, 8.4, 8.6, 8.5, 8.7, 8.4, 8.5),
(2, 8, 1, 8.6, 8.8, 9.0, 8.9, 9.0, 8.7, 8.8),
(2, 9, 1, 7.9, 8.1, 8.4, 8.3, 8.5, 8.2, 8.3),
(2, 10, 1, 8.4, 8.7, 8.9, 8.8, 8.9, 8.6, 8.7),
(2, 11, 1, 8.8, 9.0, 9.2, 9.1, 9.1, 8.9, 9.0),
(2, 12, 1, 7.7, 7.9, 8.1, 8.0, 8.2, 7.9, 8.0),
(2, 13, 1, 8.2, 8.5, 8.8, 8.7, 8.8, 8.6, 8.6),
(2, 14, 1, 8.7, 8.9, 9.1, 9.0, 9.1, 8.8, 8.9),
(2, 15, 1, 8.0, 8.3, 8.6, 8.5, 8.7, 8.4, 8.5),
(2, 16, 1, 8.5, 8.8, 9.0, 8.9, 9.0, 8.7, 8.8),
(2, 17, 1, 8.9, 9.1, 9.3, 9.2, 9.2, 9.0, 9.1),
(2, 18, 1, 7.8, 8.0, 8.3, 8.2, 8.4, 8.1, 8.2),
(2, 19, 1, 8.1, 8.3, 8.6, 8.5, 8.6, 8.4, 8.4),
(2, 20, 1, 8.5, 8.7, 8.9, 8.8, 8.9, 8.6, 8.7),
(2, 21, 1, 8.6, 7.9, 9.1, 8.8, 9.0, 8.7, 8.8),
(2, 22, 1, 8.2, 8.5, 8.8, 8.7, 8.8, 8.6, 8.6),
(2, 23, 1, 8.7, 8.9, 9.1, 9.0, 9.1, 8.8, 8.9),
(2, 24, 1, 8.4, 8.6, 8.9, 8.7, 8.8, 8.5, 8.6),
(2, 25, 1, 8.8, 9.0, 9.2, 9.1, 9.1, 8.9, 9.0),
(2, 26, 1, 8.1, 8.3, 8.6, 8.5, 8.7, 8.4, 8.5),
(2, 27, 1, 8.5, 8.7, 8.9, 8.8, 8.9, 8.6, 8.7),
(2, 28, 1, 8.9, 9.1, 9.3, 9.2, 9.2, 9.0, 9.1),
(2, 29, 1, 8.2, 8.4, 8.7, 8.6, 8.8, 8.5, 8.6),
(2, 30, 1, 8.6, 8.8, 9.0, 8.9, 9.0, 8.7, 8.8)

INSERT INTO GradeSheet ([ClassID], [StudentID], [SubjectID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage])
VALUES
(4, 31, 1, 8.5, 7.2, 9.0, 8.8, 8.9, 8.7, 8.6),
(4, 2, 1, 7.8, 8.0, 8.5, 8.3, 8.6, 8.4, 8.2),
(4, 3, 1, 8.2, 8.6, 8.9, 8.7, 8.8, 8.5, 8.7),
(4, 4, 1, 8.9, 9.0, 9.2, 9.1, 9.0, 8.8, 8.9),
(4, 5, 1, 7.5, 8.0, 7.8, 7.6, 8.1, 7.9, 7.8),
(4, 6, 1, 8.0, 7.9, 8.2, 8.1, 8.3, 8.0, 8.1),
(4, 7, 1, 8.3, 8.4, 8.6, 8.5, 8.7, 8.4, 8.5),
(4, 8, 1, 8.6, 8.8, 9.0, 8.9, 9.0, 8.7, 8.8),
(4, 9, 1, 7.9, 8.1, 8.4, 8.3, 8.5, 8.2, 8.3),
(4, 10, 1, 8.4, 8.7, 8.9, 8.8, 8.9, 8.6, 8.7),
(4, 11, 1, 8.8, 9.0, 9.2, 9.1, 9.1, 8.9, 9.0),
(4, 12, 1, 7.7, 7.9, 8.1, 8.0, 8.2, 7.9, 8.0),
(4, 13, 1, 8.2, 8.5, 8.8, 8.7, 8.8, 8.6, 8.6),
(4, 14, 1, 8.7, 8.9, 9.1, 9.0, 9.1, 8.8, 8.9),
(4, 15, 1, 8.0, 8.3, 8.6, 8.5, 8.7, 8.4, 8.5),
(4, 16, 1, 8.5, 8.8, 9.0, 8.9, 9.0, 8.7, 8.8),
(4, 17, 1, 8.9, 9.1, 9.3, 9.2, 9.2, 9.0, 9.1),
(4, 18, 1, 7.8, 8.0, 8.3, 8.2, 8.4, 8.1, 8.2),
(4, 19, 1, 8.1, 8.3, 8.6, 8.5, 8.6, 8.4, 8.4),
(4, 20, 1, 8.5, 8.7, 8.9, 8.8, 8.9, 8.6, 8.7),
(4, 21, 1, 8.6, 7.9, 9.1, 8.8, 9.0, 8.7, 8.8),
(4, 22, 1, 8.2, 8.5, 8.8, 8.7, 8.8, 8.6, 8.6),
(4, 23, 1, 8.7, 8.9, 9.1, 9.0, 9.1, 8.8, 8.9),
(4, 24, 1, 8.4, 8.6, 8.9, 8.7, 8.8, 8.5, 8.6),
(4, 25, 1, 8.8, 9.0, 9.2, 9.1, 9.1, 8.9, 9.0),
(4, 26, 1, 8.1, 8.3, 8.6, 8.5, 8.7, 8.4, 8.5),
(4, 27, 1, 8.5, 8.7, 8.9, 8.8, 8.9, 8.6, 8.7),
(4, 28, 1, 8.9, 9.1, 9.3, 9.2, 9.2, 9.0, 9.1),
(4, 29, 1, 8.2, 8.4, 8.7, 8.6, 8.8, 8.5, 8.6),
(4, 30, 1, 8.6, 8.8, 9.0, 8.9, 9.0, 8.7, 8.8)

INSERT INTO GradeSheet ([ClassID], [StudentID], [SubjectID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage])
VALUES
(6, 31, 1, 8.5, 7.2, 9.0, 8.8, 8.9, 8.7, 8.6),
(6, 2, 1, 7.8, 8.0, 8.5, 8.3, 8.6, 8.4, 8.2),
(6, 3, 1, 8.2, 8.6, 8.9, 8.7, 8.8, 8.5, 8.7),
(6, 4, 1, 8.9, 9.0, 9.2, 9.1, 9.0, 8.8, 8.9),
(6, 5, 1, 7.5, 8.0, 7.8, 7.6, 8.1, 7.9, 7.8),
(6, 6, 1, 8.0, 7.9, 8.2, 8.1, 8.3, 8.0, 8.1),
(6, 7, 1, 8.3, 8.4, 8.6, 8.5, 8.7, 8.4, 8.5),
(6, 8, 1, 8.6, 8.8, 9.0, 8.9, 9.0, 8.7, 8.8),
(6, 9, 1, 7.9, 8.1, 8.4, 8.3, 8.5, 8.2, 8.3),
(6, 10, 1, 8.4, 8.7, 8.9, 8.8, 8.9, 8.6, 8.7),
(6, 11, 1, 8.8, 9.0, 9.2, 9.1, 9.1, 8.9, 9.0),
(6, 12, 1, 7.7, 7.9, 8.1, 8.0, 8.2, 7.9, 8.0),
(6, 13, 1, 8.2, 8.5, 8.8, 8.7, 8.8, 8.6, 8.6),
(6, 14, 1, 8.7, 8.9, 9.1, 9.0, 9.1, 8.8, 8.9),
(6, 15, 1, 8.0, 8.3, 8.6, 8.5, 8.7, 8.4, 8.5),
(6, 16, 1, 8.5, 8.8, 9.0, 8.9, 9.0, 8.7, 8.8),
(6, 17, 1, 8.9, 9.1, 9.3, 9.2, 9.2, 9.0, 9.1),
(6, 18, 1, 7.8, 8.0, 8.3, 8.2, 8.4, 8.1, 8.2),
(6, 19, 1, 8.1, 8.3, 8.6, 8.5, 8.6, 8.4, 8.4),
(6, 20, 1, 8.5, 8.7, 8.9, 8.8, 8.9, 8.6, 8.7),
(6, 21, 1, 8.6, 7.9, 9.1, 8.8, 9.0, 8.7, 8.8),
(6, 22, 1, 8.2, 8.5, 8.8, 8.7, 8.8, 8.6, 8.6),
(6, 23, 1, 8.7, 8.9, 9.1, 9.0, 9.1, 8.8, 8.9),
(6, 24, 1, 8.4, 8.6, 8.9, 8.7, 8.8, 8.5, 8.6),
(6, 25, 1, 8.8, 9.0, 9.2, 9.1, 9.1, 8.9, 9.0),
(6, 26, 1, 8.1, 8.3, 8.6, 8.5, 8.7, 8.4, 8.5),
(6, 27, 1, 8.5, 8.7, 8.9, 8.8, 8.9, 8.6, 8.7),
(6, 28, 1, 8.9, 9.1, 9.3, 9.2, 9.2, 9.0, 9.1),
(6, 29, 1, 8.2, 8.4, 8.7, 8.6, 8.8, 8.5, 8.6),
(6, 30, 1, 8.6, 8.8, 9.0, 8.9, 9.0, 8.7, 8.8)
