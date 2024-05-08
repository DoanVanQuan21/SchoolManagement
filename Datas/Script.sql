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
INSERT [dbo].[User] ([FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate],[LockAccount]) VALUES (N'Đoàn Văn', N'Quân', N'Nam', CAST(N'2002-05-21T00:00:00.000' AS DateTime), N'0987654321', N'Vi?t Ti?n, Vi?t Yên, B?c Giang', N'hoangnguyen@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'admin', N'admin', N'teacher', 1, CAST(N'2017-01-01T00:00:00.000' AS DateTime), NULL,0)
INSERT [dbo].[User] ([FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate],[LockAccount]) VALUES (N'Đoàn Văn', N'Chính', N'Nam', CAST(N'2004-02-21T00:00:00.000' AS DateTime), N'0976543210', N'Vi?t Ti?n, Vi?t Yên, B?c Giang', N'doanvanchinh@gmail.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'chinh', N'chinh', N'teacher', 1, CAST(N'2019-12-10T00:00:00.000' AS DateTime), NULL,0)
INSERT [dbo].[User] ([FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate],[LockAccount]) VALUES (N'An Hương', N'Lan', N'Nữ', CAST(N'2002-05-07T00:00:00.000' AS DateTime), N'0965432109', N'Vi?t Ti?n, Vi?t Yên, B?c Giang', N'ducle@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'lan', N'lan', N'teacher', 1, CAST(N'2017-02-15T00:00:00.000' AS DateTime), NULL,0)
INSERT [dbo].[User] ([FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate],[LockAccount]) VALUES (N'Lê Thị Thu', N'Trà', N'Nữ', CAST(N'2002-05-12T00:00:00.000' AS DateTime), N'0954321098', N'Vi?t Ti?n, Vi?t Yên, B?c Giang', N'anhnguyen@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'tra', N'tra', N'teacher', 1, CAST(N'2017-03-20T00:00:00.000' AS DateTime), NULL,0)
INSERT [dbo].[User] ([FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate],[LockAccount]) VALUES (N'Đỗ Đăng', N'Kiên', N'Nam', CAST(N'2002-05-12T00:00:00.000' AS DateTime), N'0943210987', N'Vi?t Ti?n, Vi?t Yên, B?c Giang', N'thaopham@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'kien', N'kien', N'teacher', 1, CAST(N'2017-11-11T00:00:00.000' AS DateTime), NULL,0)
INSERT [dbo].[User] ([FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate],[LockAccount]) VALUES (N'Phạm Văn', N'Long', N'Nam', CAST(N'2002-05-12T00:00:00.000' AS DateTime), N'0932109876', N'Vi?t Ti?n, Vi?t Yên, B?c Giang', N'tuanhuynh@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'long', N'long', N'teacher', 1, CAST(N'2019-10-05T00:00:00.000' AS DateTime), NULL,0)
INSERT [dbo].[User] ([FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate],[LockAccount]) VALUES (N'Thành', N'Võ', N'Nam', CAST(N'2008-05-12T00:00:00.000' AS DateTime), N'0910987654', N'Vi?t Ti?n, Vi?t Yên, B?c Giang', N'thanhvo@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'student', N'student', N'student', 1, CAST(N'2020-05-15T00:00:00.000' AS DateTime), NULL,0)
INSERT [dbo].[User] ([FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate],[LockAccount]) VALUES (N'Loan', N'Trần', N'Nữ', CAST(N'2008-05-12T00:00:00.000' AS DateTime), N'0909876543', N'Vi?t Ti?n, Vi?t Yên, B?c Giang', N'loantran@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'loantran', N'loan@2022', N'student', 1, CAST(N'2017-09-20T00:00:00.000' AS DateTime), NULL,0)
INSERT [dbo].[User] ([FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate],[LockAccount]) VALUES (N'Hải', N'Lê', N'Nam', CAST(N'2008-05-12T00:00:00.000' AS DateTime), N'0898765432', N'Vi?t Ti?n, Vi?t Yên, B?c Giang', N'haile@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'haile', N'haile123', N'student', 1, CAST(N'2019-08-12T00:00:00.000' AS DateTime), NULL,0)
INSERT [dbo].[User] ([FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate],[LockAccount]) VALUES (N'Minh', N'Đặng', N'Nam', CAST(N'2008-05-12T00:00:00.000' AS DateTime), N'0887654321', N'Vi?t Ti?n, Vi?t Yên, B?c Giang', N'minhdang@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'minhdang', N'minh@123', N'student', 1, CAST(N'2018-04-25T00:00:00.000' AS DateTime), NULL,0)
INSERT [dbo].[User] ([FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate],[LockAccount]) VALUES (N'Thúy', N'Hoàng', N'Nữ', CAST(N'2008-05-12T00:00:00.000' AS DateTime), N'0876543210', N'Vi?t Ti?n, Vi?t Yên, B?c Giang', N'thuyhoang@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'thuyhoang', N'thuy@2023', N'student', 1, CAST(N'2020-11-30T00:00:00.000' AS DateTime), NULL,0)
INSERT [dbo].[User] ([FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate],[LockAccount]) VALUES (N'Dương', N'Lê', N'Nam', CAST(N'2008-05-12T00:00:00.000' AS DateTime), N'0865432109', N'Vi?t Ti?n, Vi?t Yên, B?c Giang', N'duongle@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'duongle', N'duong123', N'student', 1, CAST(N'2021-03-01T00:00:00.000' AS DateTime), NULL,0)
INSERT [dbo].[User] ([FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate],[LockAccount]) VALUES (N'Quỳnh', N'Nguyễn', N'Nữ', CAST(N'2008-05-12T00:00:00.000' AS DateTime), N'0854321098', N'Vi?t Ti?n, Vi?t Yên, B?c Giang', N'quynhnguyen@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'quynhnguyen', N'quynh@123', N'student', 1, CAST(N'2019-07-10T00:00:00.000' AS DateTime), NULL,0)
INSERT [dbo].[User] ([FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate],[LockAccount]) VALUES (N'Thắng', N'Huỳnh', N'Nam', CAST(N'2008-05-12T00:00:00.000' AS DateTime), N'0843210987', N'Vi?t Ti?n, Vi?t Yên, B?c Giang', N'thanghuynh@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'thanghuynh', N'thang789', N'teacher', 1, CAST(N'2017-12-05T00:00:00.000' AS DateTime), NULL,0)

--INSERT [dbo].[User] ([FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate]) VALUES (N'Thùy', N'Bùi', N'Nữ', CAST(N'2008-05-12T00:00:00.000' AS DateTime), N'0832109876', N'Vi?t Ti?n, Vi?t Yên, B?c Giang', N'thuybui@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'dvquan', N'dvquan', N'student', 1, CAST(N'2020-09-18T00:00:00.000' AS DateTime), NULL)
--INSERT [dbo].[User] ([FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate]) VALUES (N'An Huong', N'Lan', N'Nam', CAST(N'2008-05-12T00:00:00.000' AS DateTime), N'0369586716', N'Vi?t Ti?n, Vi?t Yên, B?c Giang', N'huonglan@gmail.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'huonglan', N'huonglan', N'student', 1, CAST(N'2022-02-20T00:00:00.000' AS DateTime), NULL)
--INSERT [dbo].[User] ([FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate]) VALUES (N'Thảo', N'Vũ', N'Nữ', CAST(N'2008-05-12T00:00:00.000' AS DateTime), N'0810987654', N'Vi?t Ti?n, Vi?t Yên, B?c Giang', N'thaovu@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'thaovu', N'thao789', N'student', 1, CAST(N'2018-10-30T00:00:00.000' AS DateTime), NULL)
--INSERT [dbo].[User] ([FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate]) VALUES (N'Quang', N'Trần', N'Nam', CAST(N'2008-05-12T00:00:00.000' AS DateTime), N'0809876543', N'Vi?t Ti?n, Vi?t Yên, B?c Giang', N'quangtran@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'quangtran', N'quang@2022', N'student', 1, CAST(N'2019-03-15T00:00:00.000' AS DateTime), NULL)
--INSERT [dbo].[User] ([FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate]) VALUES (N'Thủy', N'Phan', N'Nữ', CAST(N'2008-05-12T00:00:00.000' AS DateTime), N'0798765432', N'Vi?t Ti?n, Vi?t Yên, B?c Giang', N'thuyphan@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'thuyphan', N'thuy@123', N'student', 1, CAST(N'2016-11-20T00:00:00.000' AS DateTime), NULL)
--INSERT [dbo].[User] ([FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate]) VALUES (N'Tuấn', N'Trần', N'Nam', CAST(N'2008-05-12T00:00:00.000' AS DateTime), N'0787654321', N'Vi?t Ti?n, Vi?t Yên, B?c Giang', N'tuantran@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'tuantran', N'tran123', N'student', 1, CAST(N'2018-08-28T00:00:00.000' AS DateTime), NULL)
--INSERT [dbo].[User] ([FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate]) VALUES (N'Phương', N'Võ', N'Nữ', CAST(N'2008-05-12T00:00:00.000' AS DateTime), N'0776543210', N'Vi?t Ti?n, Vi?t Yên, B?c Giang', N'phuongvo@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'phuongvo', N'phuong@2023', N'student', 1, CAST(N'2020-12-10T00:00:00.000' AS DateTime), NULL)
--INSERT [dbo].[User] ([FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate]) VALUES (N'Thắng', N'Nguyễn', N'Nam', CAST(N'2008-05-12T00:00:00.000' AS DateTime), N'0765432109', N'Vi?t Ti?n, Vi?t Yên, B?c Giang', N'thangnguyen@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'thangnguyen', N'thang@123', N'student', 1, CAST(N'2019-06-03T00:00:00.000' AS DateTime), NULL)
--INSERT [dbo].[User] ([FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate]) VALUES (N'Mỹ', N'Phạm', N'Nữ', CAST(N'2008-05-12T00:00:00.000' AS DateTime), N'0754321098', N'Vi?t Ti?n, Vi?t Yên, B?c Giang', N'mypham@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'mypham', N'my@123', N'student', 1, CAST(N'2018-09-25T00:00:00.000' AS DateTime), NULL)
--INSERT [dbo].[User] ([FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate]) VALUES (N'Thị', N'Tran', N'Nữ', CAST(N'2008-05-12T00:00:00.000' AS DateTime), N'0743210987', N'Vi?t Ti?n, Vi?t Yên, B?c Giang', N'thitr@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'thitr', N'thitr@123', N'student', 1, CAST(N'2020-04-10T00:00:00.000' AS DateTime), NULL)
--INSERT [dbo].[User] ([FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate]) VALUES (N'Thành', N'Nguyễn', N'Nam', CAST(N'2008-05-12T00:00:00.000' AS DateTime), N'0732109876', N'Vi?t Ti?n, Vi?t Yên, B?c Giang', N'thanhnguyen@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'thanhnguyen', N'thanh123', N'student', 1, CAST(N'2019-01-15T00:00:00.000' AS DateTime), NULL)
--INSERT [dbo].[User] ([FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate]) VALUES (N'Thủy', N'Lê', N'Nữ', CAST(N'2008-05-12T00:00:00.000' AS DateTime), N'0721098765', N'Vi?t Ti?n, Vi?t Yên, B?c Giang', N'thuyle@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'thuyle', N'thuy@2024', N'student', 1, CAST(N'2021-05-20T00:00:00.000' AS DateTime), NULL)
--INSERT [dbo].[User] ([FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate]) VALUES (N'Đức', N'Vũ', N'Nam', CAST(N'2008-05-12T00:00:00.000' AS DateTime), N'0710987654', N'Vi?t Ti?n, Vi?t Yên, B?c Giang', N'ducvu@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'ducvu', N'ducvu123', N'student', 1, CAST(N'2018-07-12T00:00:00.000' AS DateTime), NULL)
--INSERT [dbo].[User] ([FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate]) VALUES (N'An', N'Nguyễn', N'Nữ', CAST(N'2008-05-12T00:00:00.000' AS DateTime), N'0709876543', N'Vi?t Ti?n, Vi?t Yên, B?c Giang', N'annguyen@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'annguyen', N'an@2022', N'student', 1, CAST(N'2017-12-30T00:00:00.000' AS DateTime), NULL)
--INSERT [dbo].[User] ([FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate]) VALUES (N'Bình', N'Nguyễn', N'Nam', CAST(N'2008-05-12T00:00:00.000' AS DateTime), N'0798765432', N'Vi?t Ti?n, Vi?t Yên, B?c Giang', N'binhnguyen@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'binhnguyen', N'binh@123', N'student', 1, CAST(N'2019-10-02T00:00:00.000' AS DateTime), NULL)
--INSERT [dbo].[User] ([FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate]) VALUES (N'Thùy', N'Võ', N'Nữ', CAST(N'2008-05-12T00:00:00.000' AS DateTime), N'0787654321', N'Vi?t Ti?n, Vi?t Yên, B?c Giang', N'thuyvo@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'thuyvo', N'thuyvo@123', N'student', 1, CAST(N'2018-05-07T00:00:00.000' AS DateTime), NULL)
--INSERT [dbo].[User] ([FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate]) VALUES (N'Đức', N'Hoàng', N'Nam', CAST(N'2008-05-12T00:00:00.000' AS DateTime), N'0776543210', N'Vi?t Ti?n, Vi?t Yên, B?c Giang', N'duchoang@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'duchoang', N'duc@2023', N'student', 1, CAST(N'2020-08-22T00:00:00.000' AS DateTime), NULL)
--INSERT [dbo].[User] ([FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate]) VALUES (N'Thu', N'Lê', N'Nữ', CAST(N'2008-05-12T00:00:00.000' AS DateTime), N'0765432109', N'Vi?t Ti?n, Vi?t Yên, B?c Giang', N'thule@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'thule', N'thule@2022', N'student', 1, CAST(N'2021-02-10T00:00:00.000' AS DateTime), NULL)
--INSERT [dbo].[User] ([FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate]) VALUES (N'Thịnh', N'Nguyễn', N'Nam', CAST(N'2008-05-12T00:00:00.000' AS DateTime), N'0754321098', N'Vi?t Ti?n, Vi?t Yên, B?c Giang', N'thinhnguyen@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'thinhnguyen', N'thinh@123', N'student', 1, CAST(N'2019-09-18T00:00:00.000' AS DateTime), NULL)
--INSERT [dbo].[User] ([FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate]) VALUES (N'Thảo', N'Phạm', N'Nữ', CAST(N'2008-05-12T00:00:00.000' AS DateTime), N'0743210987', N'Vi?t Ti?n, Vi?t Yên, B?c Giang', N'thaopham@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'thaopham', N'thao@1234', N'student', 1, CAST(N'2018-03-23T00:00:00.000' AS DateTime), NULL)
--INSERT [dbo].[User] ([FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate]) VALUES (N'Vinh', N'Tran', N'Nam', CAST(N'2008-05-12T00:00:00.000' AS DateTime), N'0732109876', N'Vi?t Ti?n, Vi?t Yên, B?c Giang', N'vinhtran@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'vinhtran', N'vinh@2022', N'student', 1, CAST(N'2020-01-05T00:00:00.000' AS DateTime), NULL)
--INSERT [dbo].[User] ([FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate]) VALUES (N'Minh', N'Phan', N'Nam', CAST(N'2008-05-12T00:00:00.000' AS DateTime), N'0721098765', N'Vi?t Ti?n, Vi?t Yên, B?c Giang', N'minhphan@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'minhphan', N'minh@2023', N'student', 1, CAST(N'2019-04-30T00:00:00.000' AS DateTime), NULL)
--INSERT [dbo].[User] ([FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate]) VALUES (N'Thuỳ', N'Hồ', N'Nữ', CAST(N'2008-05-12T00:00:00.000' AS DateTime), N'0710987654', N'Vi?t Ti?n, Vi?t Yên, B?c Giang', N'thuyho@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'thuyho', N'thuyho@123', N'student', 1, CAST(N'2017-11-12T00:00:00.000' AS DateTime), NULL)
--INSERT [dbo].[User] ([FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate]) VALUES (N'Đức', N'Trần', N'Nam', CAST(N'2008-05-12T00:00:00.000' AS DateTime), N'0709876543', N'Vi?t Ti?n, Vi?t Yên, B?c Giang', N'ductran@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'ductran', N'ductran@123', N'student', 1, CAST(N'2018-12-25T00:00:00.000' AS DateTime), NULL)
--INSERT [dbo].[User] ([FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate]) VALUES (N'Hoài', N'Lê', N'Nữ', CAST(N'2008-05-12T00:00:00.000' AS DateTime), N'0798765432', N'Vi?t Ti?n, Vi?t Yên, B?c Giang', N'hoaille@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'hoaille', N'hoai@2022', N'student', 1, CAST(N'2021-08-17T00:00:00.000' AS DateTime), NULL)
--INSERT [dbo].[User] ([FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate]) VALUES (N'Quốc', N'Nguyễn', N'Nam', CAST(N'2008-05-12T00:00:00.000' AS DateTime), N'0787654321', N'Vi?t Ti?n, Vi?t Yên, B?c Giang', N'quocnguyen@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'quocnguyen', N'quoc123', N'student', 1, CAST(N'2019-12-30T00:00:00.000' AS DateTime), NULL)
--INSERT [dbo].[User] ([FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate]) VALUES (N'Anh', N'Phạm', N'Nữ', CAST(N'2008-05-12T00:00:00.000' AS DateTime), N'0776543210', N'Vi?t Ti?n, Vi?t Yên, B?c Giang', N'anhpham@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'anhpham', N'anh@2023', N'student', 1, CAST(N'2018-10-02T00:00:00.000' AS DateTime), NULL)
--INSERT [dbo].[User] ([FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate]) VALUES (N'Thắng', N'Vũ', N'Nam', CAST(N'2008-05-12T00:00:00.000' AS DateTime), N'0765432109', N'Vi?t Ti?n, Vi?t Yên, B?c Giang', N'thangvu@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'thangvu', N'thangvu@123', N'student', 1, CAST(N'2021-02-28T00:00:00.000' AS DateTime), NULL)
--INSERT [dbo].[User] ([FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate]) VALUES (N'Thùy', N'Đặng', N'Nữ', CAST(N'2008-05-12T00:00:00.000' AS DateTime), N'0754321098', N'Vi?t Ti?n, Vi?t Yên, B?c Giang', N'thuydang@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'thuydang', N'thuydang@123', N'student', 1, CAST(N'2019-07-15T00:00:00.000' AS DateTime), NULL)
--INSERT [dbo].[User] ([FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate]) VALUES (N'Tuấn', N'Trần', N'Nam', CAST(N'2008-05-12T00:00:00.000' AS DateTime), N'0743210987', N'Vi?t Ti?n, Vi?t Yên, B?c Giang', N'tuantran@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'tuantran', N'tuantran', N'student', 1, CAST(N'2018-05-03T00:00:00.000' AS DateTime), NULL)
--INSERT [dbo].[User] ([FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate]) VALUES (N'Mai', N'Nguyễn', N'Nữ', CAST(N'2008-05-12T00:00:00.000' AS DateTime), N'0732109876', N'Vi?t Ti?n, Vi?t Yên, B?c Giang', N'mainguyen@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'mainguyen', N'mai@123', N'student', 1, CAST(N'2020-10-20T00:00:00.000' AS DateTime), NULL)
--INSERT [dbo].[User] ([FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate]) VALUES (N'Đức', N'Phan', N'Nam', CAST(N'2008-05-12T00:00:00.000' AS DateTime), N'0721098765', N'Vi?t Ti?n, Vi?t Yên, B?c Giang', N'ducphan@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'ducphan', N'duc@123', N'student', 1, CAST(N'2019-11-05T00:00:00.000' AS DateTime), NULL)
--INSERT [dbo].[User] ([FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate]) VALUES (N'Thảo', N'Vũ', N'Nữ', CAST(N'2008-05-12T00:00:00.000' AS DateTime), N'0710987654', N'Vi?t Ti?n, Vi?t Yên, B?c Giang', N'thaovu@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'thaovu', N'thaovu@123', N'student', 1, CAST(N'2022-04-15T00:00:00.000' AS DateTime), NULL)
--INSERT [dbo].[User] ([FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate]) VALUES (N'Quốc', N'Lê', N'Nam', CAST(N'2008-05-12T00:00:00.000' AS DateTime), N'0709876543', N'Vi?t Ti?n, Vi?t Yên, B?c Giang', N'quocle@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'quocle', N'quocle@2023', N'student', 1, CAST(N'2021-09-12T00:00:00.000' AS DateTime), NULL)
--INSERT [dbo].[User] ([FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate]) VALUES (N'Minh', N'Hoàng', N'Nam', CAST(N'2008-05-12T00:00:00.000' AS DateTime), N'0798765432', N'Vi?t Ti?n, Vi?t Yên, B?c Giang', N'minhoang@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'minhoang', N'minhoang@123', N'student', 1, CAST(N'2019-04-01T00:00:00.000' AS DateTime), NULL)
--INSERT [dbo].[User] ([FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate]) VALUES (N'Doan Van', N'Quan', N'Nam', CAST(N'2008-05-12T00:00:00.000' AS DateTime), N'0867687695', N'Vi?t Ti?n, Vi?t Yên, B?c Giang', N'dvquan210502@gmail.com', NULL, NULL, NULL, N'teacher', NULL, CAST(N'2024-05-05T22:42:08.523' AS DateTime), CAST(N'2024-05-05T22:42:08.523' AS DateTime))
--INSERT [dbo].[User] ([FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate]) VALUES (N'Doan Van', N'Quan', N'Nam', CAST(N'2008-05-12T00:00:00.000' AS DateTime), N'0867687695', N'Vi?t Ti?n, Vi?t Yên, B?c Giang', N'dvquan210502@gmail.com', NULL, NULL, NULL, NULL, NULL, CAST(N'2024-05-06T12:27:54.873' AS DateTime), CAST(N'2024-05-06T12:27:54.873' AS DateTime))
--END USER---


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
INSERT [dbo].[Subject] ([SubjectCode], [SubjectName], [Image]) VALUES (N'GEOG101', N'Diễn đạt', N'https://example.com/geog101.jpg')
INSERT [dbo].[Subject] ([SubjectCode], [SubjectName], [Image]) VALUES (N'COMP101', N'Tin học', N'https://example.com/comp101.jpg')
INSERT [dbo].[Subject] ([SubjectCode], [SubjectName], [Image]) VALUES (N'MUS101', N'Âm nhạc', N'https://example.com/mus101.jpg')
INSERT [dbo].[Subject] ([SubjectCode], [SubjectName], [Image]) VALUES ( N'ART101', N'Hội họa', N'https://example.com/art101.jpg')
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

INSERT [dbo].[Teacher] ([DepartmentID], [UserID], [TeacherCode], [Degree], [Expertise], [University], [GraduationYear], [Major], [OtherCertifications], [Position], [Salary], [AdditionalBenifits], [CurrentHealthStatus], [HealthInsuranceInfo], [SelfIntroduction], [SubjectID]  ,[IsLeader]) VALUES (1, 1, N'TC001', N'Thạc sĩ', N'Toán học', N'Đại học Quốc gia Hà Nội', CAST(N'2010-01-01T00:00:00.000' AS DateTime), N'Toán', NULL, N'Giáo viên', CAST(30000000 AS Decimal(18, 0)), N'Bảo hiểm y tế', N'Bình thường', N'Bảo hiểm BHYT số 123456789', N'Tôi là m?t giáo viên Toán có kinh nghi?m', 1,1)
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
	[ClassID] Integer NOT NULL ,
	[TeacherID] Integer NOT NULL Foreign key ([TeacherID]) REFERENCES Teacher(TeacherID) ON UPDATE no action ON DELETE NO ACTION,
	[SubjectID] Integer NOT NULL,
	[StudentID] Integer NOT NULL,
	[EducationProgramID] Integer NOT NULL Foreign key ([EducationProgramID]) REFERENCES EducationProgram([EducationProgramID]) ON UPDATE no action ON DELETE NO ACTION,
	[StartDate] Datetime NULL,
	[EndDate] Datetime NULL,
	[Status] nvarchar(100) NULL,
	[Semester] nvarchar(100) NULL,
Primary Key ([ClassID],[SubjectID],[StudentID])
) 
go

INSERT [dbo].[Course] ([ClassID], [TeacherID], [SubjectID],[StudentID],[EducationProgramID], [StartDate], [EndDate],[Status],[Semester]) VALUES 
(1, 1, 1, 1,1, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime),N'Đang học','ky_1')
INSERT [dbo].[Course] ([ClassID], [TeacherID], [SubjectID],[StudentID],[EducationProgramID], [StartDate], [EndDate],[Status],[Semester]) VALUES 
(1, 2, 6, 1,4, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime),N'Đang học','ky_1')
INSERT [dbo].[Course] ([ClassID], [TeacherID], [SubjectID],[StudentID],[EducationProgramID], [StartDate], [EndDate],[Status],[Semester]) VALUES 
(1, 3, 4, 1,2, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime),N'Đang học','ky_1')
INSERT [dbo].[Course] ([ClassID], [TeacherID], [SubjectID],[StudentID],[EducationProgramID], [StartDate], [EndDate],[Status],[Semester]) VALUES 
(1, 4, 5, 1,3, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime),N'Đang học','ky_1')
INSERT [dbo].[Course] ([ClassID], [TeacherID], [SubjectID],[StudentID],[EducationProgramID], [StartDate], [EndDate],[Status],[Semester]) VALUES 
(1, 5, 9, 1,5, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime),N'Đang học','ky_1')
INSERT [dbo].[Course] ([ClassID], [TeacherID], [SubjectID],[StudentID],[EducationProgramID], [StartDate], [EndDate],[Status],[Semester]) VALUES 
(1, 6, 10, 1,6, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime),N'Đang học','ky_1')

Create table [GradeSheet]
(
	[GradeSheetID] Integer IDENTITY(1,1) NOT NULL,
	[ClassID] Integer NOT NULL Foreign key ([ClassID]) REFERENCES [Class]([ClassID]) ON UPDATE No action ON DELETE No action,
	[SubjectID] Integer NOT NULL Foreign key ([SubjectID]) REFERENCES [Subject]([SubjectID]) ON UPDATE No action ON DELETE No action,
	[StudentID] Integer NOT NULL Foreign key ([StudentID]) REFERENCES [Student]([StudentID]) ON UPDATE No action ON DELETE No action,
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
drop table [GradeSheet]
    SELECT *
  FROM [SchoolManagement].[dbo].Course

  
INSERT [dbo].[GradeSheet] ([ClassID], [StudentID], [SubjectID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage]) VALUES 
(1, 1, 1, 8.1, 8.3, 8.6, 8.5, 8.6, 8.3, 8.4)
INSERT [dbo].[GradeSheet] ([ClassID], [StudentID], [SubjectID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage]) VALUES 
(1, 1, 4, 10, 10, 10, 10, 10, 10, 10)
INSERT [dbo].[GradeSheet] ([ClassID], [StudentID], [SubjectID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage]) VALUES 
(1, 1, 5, 5, 6, 6, 6, 6, 6, 5.8888888359069824)
INSERT [dbo].[GradeSheet] ([ClassID], [StudentID], [SubjectID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage]) VALUES 
(1, 1, 6, 1, 1, 9.2, 9.1, 9, 8.8, 7.1888885498046875)
INSERT [dbo].[GradeSheet] ([ClassID], [StudentID], [SubjectID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage]) VALUES 
(1,1, 9, 6, 6, 7.8, 7.6, 6, 7.9, 7.0111112594604492)
INSERT [dbo].[GradeSheet] ([ClassID], [StudentID], [SubjectID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage]) VALUES 
(1, 1, 10, 8, 7.9, 8.2, 8.1, 8.3, 8, 8.0888881683349609)

  --end grade sheet



Create table [Schedule]
(
	[ScheduleID] Integer IDENTITY(1,1) NOT NULL,
	[ClassID] Integer NOT NULL,
	[SubjectID] Integer NOT NULL,
	[ScheduleCode] nvarchar(100) NULL,
	[Day] Datetime NULL,
	[Start] Datetime NULL,
	[End] Datetime NULL,
	[StudentID] Integer NOT NULL,
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


Set quoted_identifier on
go


Set quoted_identifier off
go



