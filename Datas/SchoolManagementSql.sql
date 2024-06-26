USE [master]
GO
/****** Object:  Database [SchoolManagement]    Script Date: 5/14/2024 8:42:11 AM ******/
CREATE DATABASE [SchoolManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SchoolManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\SchoolManagement.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SchoolManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\SchoolManagement_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [SchoolManagement] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SchoolManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SchoolManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SchoolManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SchoolManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SchoolManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SchoolManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [SchoolManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SchoolManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SchoolManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SchoolManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SchoolManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SchoolManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SchoolManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SchoolManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SchoolManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SchoolManagement] SET  ENABLE_BROKER 
GO
ALTER DATABASE [SchoolManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SchoolManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SchoolManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SchoolManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SchoolManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SchoolManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SchoolManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SchoolManagement] SET RECOVERY FULL 
GO
ALTER DATABASE [SchoolManagement] SET  MULTI_USER 
GO
ALTER DATABASE [SchoolManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SchoolManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SchoolManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SchoolManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SchoolManagement] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SchoolManagement] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'SchoolManagement', N'ON'
GO
ALTER DATABASE [SchoolManagement] SET QUERY_STORE = OFF
GO
USE [SchoolManagement]
GO
/****** Object:  Table [dbo].[Class]    Script Date: 5/14/2024 8:42:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Class](
	[ClassID] [int] IDENTITY(1,1) NOT NULL,
	[ClassCode] [nvarchar](100) NULL,
	[ClassName] [nvarchar](100) NULL,
	[NumberOfStudent] [int] NULL,
	[TeacherID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ClassID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 5/14/2024 8:42:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[CourseID] [int] IDENTITY(1,1) NOT NULL,
	[ClassID] [int] NOT NULL,
	[TeacherID] [int] NOT NULL,
	[SubjectID] [int] NOT NULL,
	[EducationProgramID] [int] NOT NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[Status] [nvarchar](100) NULL,
	[Semester] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[CourseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 5/14/2024 8:42:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[DepartmentID] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentCode] [nvarchar](20) NULL,
	[DepartmentName] [nvarchar](100) NULL,
	[FoundingDate] [datetime] NULL,
	[Image] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[DepartmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EditGradeSheetForm]    Script Date: 5/14/2024 8:42:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EditGradeSheetForm](
	[EditGradeSheetFormID] [int] IDENTITY(1,1) NOT NULL,
	[GradeSheetID] [int] NOT NULL,
	[TeacherID] [int] NOT NULL,
	[Time] [datetime] NULL,
	[Status] [nvarchar](100) NULL,
	[reason] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EditGradeSheetFormID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EducationProgram]    Script Date: 5/14/2024 8:42:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EducationProgram](
	[EducationProgramID] [int] IDENTITY(1,1) NOT NULL,
	[EducationProgramCode] [nvarchar](20) NULL,
	[EducationName] [nvarchar](100) NULL,
	[NumberOfLesson] [int] NULL,
	[Status] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[EducationProgramID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GradeSheet]    Script Date: 5/14/2024 8:42:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GradeSheet](
	[GradeSheetID] [int] IDENTITY(1,1) NOT NULL,
	[CourseID] [int] NOT NULL,
	[StudentID] [int] NOT NULL,
	[FirstRegularScore] [float] NULL,
	[SecondRegularScore] [float] NULL,
	[ThirdRegularScore] [float] NULL,
	[FourRegularScore] [float] NULL,
	[MidtermScore] [float] NULL,
	[FinalScore] [float] NULL,
	[SemesterAverage] [float] NULL,
	[PromotionDecision] [bit] NULL,
	[Lock] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[GradeSheetID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HomeroomAssignment]    Script Date: 5/14/2024 8:42:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HomeroomAssignment](
	[ClassID] [int] NOT NULL,
	[TeacherID] [int] NOT NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ClassID] ASC,
	[TeacherID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lesson]    Script Date: 5/14/2024 8:42:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lesson](
	[LessonID] [int] IDENTITY(1,1) NOT NULL,
	[LessonCode] [nvarchar](100) NULL,
	[LessonName] [nvarchar](100) NULL,
	[VideoUrl] [nvarchar](max) NULL,
	[ImageUrl] [nvarchar](max) NULL,
	[Status] [nvarchar](100) NULL,
	[EducationProgramID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[LessonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Schedule]    Script Date: 5/14/2024 8:42:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schedule](
	[ScheduleID] [int] NOT NULL,
	[ScheduleCode] [varchar](100) NULL,
	[Day] [datetime] NULL,
	[Start] [datetime] NULL,
	[End] [datetime] NULL,
	[CourseID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ScheduleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 5/14/2024 8:42:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[StudentID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[StudentCode] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentAssignment]    Script Date: 5/14/2024 8:42:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentAssignment](
	[StudentID] [int] NOT NULL,
	[ClassID] [int] NOT NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[Status] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC,
	[ClassID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subject]    Script Date: 5/14/2024 8:42:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subject](
	[SubjectID] [int] IDENTITY(1,1) NOT NULL,
	[SubjectCode] [nvarchar](15) NULL,
	[SubjectName] [nvarchar](100) NULL,
	[Image] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[SubjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 5/14/2024 8:42:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher](
	[TeacherID] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[SubjectID] [int] NOT NULL,
	[TeacherCode] [nvarchar](100) NULL,
	[Degree] [nvarchar](200) NULL,
	[Expertise] [nvarchar](100) NULL,
	[University] [nvarchar](100) NULL,
	[GraduationYear] [datetime] NULL,
	[Major] [nvarchar](100) NULL,
	[OtherCertifications] [nvarchar](200) NULL,
	[Position] [nvarchar](100) NULL,
	[Salary] [decimal](18, 0) NULL,
	[AdditionalBenifits] [nvarchar](100) NULL,
	[CurrentHealthStatus] [nvarchar](100) NULL,
	[HealthInsuranceInfo] [nvarchar](100) NULL,
	[SelfIntroduction] [text] NULL,
	[IsLeader] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[TeacherID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 5/14/2024 8:42:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](100) NULL,
	[LastName] [nvarchar](100) NULL,
	[Gender] [nvarchar](10) NULL,
	[DateOfBirth] [datetime] NULL,
	[PhoneNumber] [nvarchar](12) NULL,
	[Address] [nvarchar](100) NULL,
	[Email] [nvarchar](100) NULL,
	[Image] [nvarchar](max) NULL,
	[Username] [nvarchar](100) NULL,
	[Password] [nvarchar](100) NULL,
	[Role] [nvarchar](100) NULL,
	[ActiveStatus] [tinyint] NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[LockAccount] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Class] ON 

INSERT [dbo].[Class] ([ClassID], [ClassCode], [ClassName], [NumberOfStudent], [TeacherID]) VALUES (1, N'CL10A1', N'10A1', 30, 1)
INSERT [dbo].[Class] ([ClassID], [ClassCode], [ClassName], [NumberOfStudent], [TeacherID]) VALUES (2, N'CL10A2', N'10A2', 25, 2)
INSERT [dbo].[Class] ([ClassID], [ClassCode], [ClassName], [NumberOfStudent], [TeacherID]) VALUES (3, N'CL10A3', N'10A3', 28, 3)
INSERT [dbo].[Class] ([ClassID], [ClassCode], [ClassName], [NumberOfStudent], [TeacherID]) VALUES (4, N'CL10A4', N'10A4', 32, 4)
INSERT [dbo].[Class] ([ClassID], [ClassCode], [ClassName], [NumberOfStudent], [TeacherID]) VALUES (5, N'CL10A5', N'10A5', 27, 5)
SET IDENTITY_INSERT [dbo].[Class] OFF
GO
SET IDENTITY_INSERT [dbo].[Course] ON 

INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (1, 2, 1, 6, 1, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (2, 1, 2, 5, 4, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (3, 1, 3, 4, 2, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (4, 1, 4, 9, 3, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (5, 1, 5, 10, 5, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (6, 1, 5, 10, 6, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
SET IDENTITY_INSERT [dbo].[Course] OFF
GO
SET IDENTITY_INSERT [dbo].[Department] ON 

INSERT [dbo].[Department] ([DepartmentID], [DepartmentCode], [DepartmentName], [FoundingDate], [Image]) VALUES (1, N'DEPT001', N'Toán học', CAST(N'1990-01-01T00:00:00.000' AS DateTime), N'https://example.com/toanhoc.jpg')
INSERT [dbo].[Department] ([DepartmentID], [DepartmentCode], [DepartmentName], [FoundingDate], [Image]) VALUES (2, N'DEPT002', N'Hóa học', CAST(N'1992-05-10T00:00:00.000' AS DateTime), N'https://example.com/hoahoc.jpg')
INSERT [dbo].[Department] ([DepartmentID], [DepartmentCode], [DepartmentName], [FoundingDate], [Image]) VALUES (3, N'DEPT003', N'Sinh học', CAST(N'1995-09-20T00:00:00.000' AS DateTime), N'https://example.com/sinhhoc.jpg')
INSERT [dbo].[Department] ([DepartmentID], [DepartmentCode], [DepartmentName], [FoundingDate], [Image]) VALUES (4, N'DEPT004', N'Lịch sử', CAST(N'1988-03-15T00:00:00.000' AS DateTime), N'https://example.com/lichsu.jpg')
INSERT [dbo].[Department] ([DepartmentID], [DepartmentCode], [DepartmentName], [FoundingDate], [Image]) VALUES (5, N'DEPT005', N'Văn học', CAST(N'1997-11-30T00:00:00.000' AS DateTime), N'https://example.com/vanhoc.jpg')
INSERT [dbo].[Department] ([DepartmentID], [DepartmentCode], [DepartmentName], [FoundingDate], [Image]) VALUES (6, N'DEPT006', N'Địa lý', CAST(N'1994-07-25T00:00:00.000' AS DateTime), N'https://example.com/diali.jpg')
SET IDENTITY_INSERT [dbo].[Department] OFF
GO
SET IDENTITY_INSERT [dbo].[EditGradeSheetForm] ON 

INSERT [dbo].[EditGradeSheetForm] ([EditGradeSheetFormID], [GradeSheetID], [TeacherID], [Time], [Status], [reason]) VALUES (1, 1, 1, CAST(N'2024-05-09T15:09:08.717' AS DateTime), N'Accept', N'123123')
INSERT [dbo].[EditGradeSheetForm] ([EditGradeSheetFormID], [GradeSheetID], [TeacherID], [Time], [Status], [reason]) VALUES (2, 1, 1, CAST(N'2024-05-09T16:01:03.873' AS DateTime), N'Accept', N'234123')
INSERT [dbo].[EditGradeSheetForm] ([EditGradeSheetFormID], [GradeSheetID], [TeacherID], [Time], [Status], [reason]) VALUES (3, 4, 1, CAST(N'2024-05-09T21:12:51.553' AS DateTime), N'Accept', N'123123')
INSERT [dbo].[EditGradeSheetForm] ([EditGradeSheetFormID], [GradeSheetID], [TeacherID], [Time], [Status], [reason]) VALUES (4, 1, 1, CAST(N'2024-05-10T10:47:53.107' AS DateTime), N'Accept', N'12312312')
INSERT [dbo].[EditGradeSheetForm] ([EditGradeSheetFormID], [GradeSheetID], [TeacherID], [Time], [Status], [reason]) VALUES (5, 1, 1, CAST(N'2024-05-10T10:57:15.997' AS DateTime), N'Accept', N'7421')
INSERT [dbo].[EditGradeSheetForm] ([EditGradeSheetFormID], [GradeSheetID], [TeacherID], [Time], [Status], [reason]) VALUES (6, 1, 1, CAST(N'2024-05-10T11:02:26.693' AS DateTime), N'Accept', N'234324
')
INSERT [dbo].[EditGradeSheetForm] ([EditGradeSheetFormID], [GradeSheetID], [TeacherID], [Time], [Status], [reason]) VALUES (7, 1, 1, CAST(N'2024-05-12T15:30:44.347' AS DateTime), N'Accept', N'12312312')
INSERT [dbo].[EditGradeSheetForm] ([EditGradeSheetFormID], [GradeSheetID], [TeacherID], [Time], [Status], [reason]) VALUES (8, 4, 1, CAST(N'2024-05-14T08:39:01.960' AS DateTime), N'Accept', N'13123')
INSERT [dbo].[EditGradeSheetForm] ([EditGradeSheetFormID], [GradeSheetID], [TeacherID], [Time], [Status], [reason]) VALUES (9, 1, 1, CAST(N'2024-05-14T08:40:36.457' AS DateTime), N'Waitting', N'3123123')
SET IDENTITY_INSERT [dbo].[EditGradeSheetForm] OFF
GO
SET IDENTITY_INSERT [dbo].[EducationProgram] ON 

INSERT [dbo].[EducationProgram] ([EducationProgramID], [EducationProgramCode], [EducationName], [NumberOfLesson], [Status]) VALUES (1, N'EP001', N'Chương trình Toán học', 30, N'Hoạt động')
INSERT [dbo].[EducationProgram] ([EducationProgramID], [EducationProgramCode], [EducationName], [NumberOfLesson], [Status]) VALUES (2, N'EP002', N'Chương trình hóa học', 35, N'Hoạt động')
INSERT [dbo].[EducationProgram] ([EducationProgramID], [EducationProgramCode], [EducationName], [NumberOfLesson], [Status]) VALUES (3, N'EP003', N'Chương trình Sinh học', 25, N'Hoạt động')
INSERT [dbo].[EducationProgram] ([EducationProgramID], [EducationProgramCode], [EducationName], [NumberOfLesson], [Status]) VALUES (4, N'EP004', N'Chương trình Lịch sử', 20, N'Không hoạt động')
INSERT [dbo].[EducationProgram] ([EducationProgramID], [EducationProgramCode], [EducationName], [NumberOfLesson], [Status]) VALUES (5, N'EP005', N'Chương trình Văn học', 40, N'Hoạt động')
INSERT [dbo].[EducationProgram] ([EducationProgramID], [EducationProgramCode], [EducationName], [NumberOfLesson], [Status]) VALUES (6, N'EP005', N'Chương trình Địa lý', 40, N'Hoạt động')
SET IDENTITY_INSERT [dbo].[EducationProgram] OFF
GO
SET IDENTITY_INSERT [dbo].[GradeSheet] ON 

INSERT [dbo].[GradeSheet] ([GradeSheetID], [CourseID], [StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage], [PromotionDecision], [Lock]) VALUES (1, 1, 1, 0, 8.3, 8.6, 8.5, 8.6, 8.3, 7.5, NULL, 1)
INSERT [dbo].[GradeSheet] ([GradeSheetID], [CourseID], [StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage], [PromotionDecision], [Lock]) VALUES (2, 1, 2, 8.1, 8.3, 8.6, 8.5, 8.6, 8.3, 8.4, NULL, 1)
INSERT [dbo].[GradeSheet] ([GradeSheetID], [CourseID], [StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage], [PromotionDecision], [Lock]) VALUES (3, 1, 3, 8.1, 8.3, 8.6, 8.5, 8.6, 8.3, 8.4, NULL, 1)
INSERT [dbo].[GradeSheet] ([GradeSheetID], [CourseID], [StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage], [PromotionDecision], [Lock]) VALUES (4, 1, 4, 8.1, 8.3, 8.6, 8.5, 8.6, 8.3, 8.4, NULL, 1)
INSERT [dbo].[GradeSheet] ([GradeSheetID], [CourseID], [StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage], [PromotionDecision], [Lock]) VALUES (5, 1, 5, 8.1, 8.3, 8.6, 8.5, 8.6, 8.3, 8.4, NULL, 1)
INSERT [dbo].[GradeSheet] ([GradeSheetID], [CourseID], [StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage], [PromotionDecision], [Lock]) VALUES (6, 2, 1, 8.1, 8.3, 8.6, 8.5, 8.6, 8.3, 8.4, NULL, 0)
INSERT [dbo].[GradeSheet] ([GradeSheetID], [CourseID], [StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage], [PromotionDecision], [Lock]) VALUES (7, 2, 2, 8.1, 8.3, 8.6, 8.5, 8.6, 8.3, 8.4, NULL, 0)
INSERT [dbo].[GradeSheet] ([GradeSheetID], [CourseID], [StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage], [PromotionDecision], [Lock]) VALUES (8, 2, 3, 8.1, 8.3, 8.6, 8.5, 8.6, 8.3, 8.4, NULL, 0)
INSERT [dbo].[GradeSheet] ([GradeSheetID], [CourseID], [StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage], [PromotionDecision], [Lock]) VALUES (9, 2, 4, 8.1, 8.3, 8.6, 8.5, 8.6, 8.3, 8.4, NULL, 0)
INSERT [dbo].[GradeSheet] ([GradeSheetID], [CourseID], [StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage], [PromotionDecision], [Lock]) VALUES (10, 2, 5, 8.1, 8.3, 8.6, 8.5, 8.6, 8.3, 8.4, NULL, 0)
INSERT [dbo].[GradeSheet] ([GradeSheetID], [CourseID], [StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage], [PromotionDecision], [Lock]) VALUES (11, 3, 1, 8.1, 8.3, 8.6, 8.5, 8.6, 8.3, 8.4, NULL, 0)
INSERT [dbo].[GradeSheet] ([GradeSheetID], [CourseID], [StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage], [PromotionDecision], [Lock]) VALUES (12, 3, 2, 8.1, 8.3, 8.6, 8.5, 8.6, 8.3, 8.4, NULL, 0)
INSERT [dbo].[GradeSheet] ([GradeSheetID], [CourseID], [StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage], [PromotionDecision], [Lock]) VALUES (13, 3, 3, 8.1, 8.3, 8.6, 8.5, 8.6, 8.3, 8.4, NULL, 0)
INSERT [dbo].[GradeSheet] ([GradeSheetID], [CourseID], [StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage], [PromotionDecision], [Lock]) VALUES (14, 3, 4, 8.1, 8.3, 8.6, 8.5, 8.6, 8.3, 8.4, NULL, 0)
INSERT [dbo].[GradeSheet] ([GradeSheetID], [CourseID], [StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage], [PromotionDecision], [Lock]) VALUES (15, 3, 5, 8.1, 8.3, 8.6, 8.5, 8.6, 8.3, 8.4, NULL, 0)
INSERT [dbo].[GradeSheet] ([GradeSheetID], [CourseID], [StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage], [PromotionDecision], [Lock]) VALUES (16, 4, 1, 8.1, 8.3, 8.6, 8.5, 8.6, 8.3, 8.4, NULL, 0)
INSERT [dbo].[GradeSheet] ([GradeSheetID], [CourseID], [StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage], [PromotionDecision], [Lock]) VALUES (17, 4, 2, 8.1, 8.3, 8.6, 8.5, 8.6, 8.3, 8.4, NULL, 0)
INSERT [dbo].[GradeSheet] ([GradeSheetID], [CourseID], [StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage], [PromotionDecision], [Lock]) VALUES (18, 4, 2, 8.1, 8.3, 8.6, 8.5, 8.6, 8.3, 8.4, NULL, 0)
INSERT [dbo].[GradeSheet] ([GradeSheetID], [CourseID], [StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage], [PromotionDecision], [Lock]) VALUES (19, 4, 2, 8.1, 8.3, 8.6, 8.5, 8.6, 8.3, 8.4, NULL, 0)
INSERT [dbo].[GradeSheet] ([GradeSheetID], [CourseID], [StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage], [PromotionDecision], [Lock]) VALUES (20, 4, 2, 8.1, 8.3, 8.6, 8.5, 8.6, 8.3, 8.4, NULL, 0)
SET IDENTITY_INSERT [dbo].[GradeSheet] OFF
GO
INSERT [dbo].[HomeroomAssignment] ([ClassID], [TeacherID], [StartDate], [EndDate]) VALUES (1, 2, CAST(N'2023-01-01T00:00:00.000' AS DateTime), CAST(N'2024-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[HomeroomAssignment] ([ClassID], [TeacherID], [StartDate], [EndDate]) VALUES (2, 3, CAST(N'2023-01-01T00:00:00.000' AS DateTime), CAST(N'2024-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[HomeroomAssignment] ([ClassID], [TeacherID], [StartDate], [EndDate]) VALUES (3, 4, CAST(N'2023-01-01T00:00:00.000' AS DateTime), CAST(N'2024-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[HomeroomAssignment] ([ClassID], [TeacherID], [StartDate], [EndDate]) VALUES (4, 5, CAST(N'2023-01-01T00:00:00.000' AS DateTime), CAST(N'2024-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[HomeroomAssignment] ([ClassID], [TeacherID], [StartDate], [EndDate]) VALUES (6, 6, CAST(N'2023-01-01T00:00:00.000' AS DateTime), CAST(N'2024-01-01T00:00:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Student] ON 

INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (1, 7, N'STD001')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (2, 8, N'STD002')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (3, 9, N'STD003')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (4, 10, N'STD004')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (5, 11, N'STD005')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (6, 12, N'STD005')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (7, 13, N'STD005')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (9, 23, N'ST20247')
SET IDENTITY_INSERT [dbo].[Student] OFF
GO
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (1, 1, CAST(N'2023-01-01T00:00:00.000' AS DateTime), CAST(N'2024-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (2, 1, CAST(N'2023-01-01T00:00:00.000' AS DateTime), CAST(N'2024-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (3, 1, CAST(N'2023-01-01T00:00:00.000' AS DateTime), CAST(N'2024-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (4, 1, CAST(N'2023-01-01T00:00:00.000' AS DateTime), CAST(N'2024-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (5, 1, CAST(N'2023-01-01T00:00:00.000' AS DateTime), CAST(N'2024-01-01T00:00:00.000' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[Subject] ON 

INSERT [dbo].[Subject] ([SubjectID], [SubjectCode], [SubjectName], [Image]) VALUES (1, N'MATH101', N'Toán', N'https://example.com/math101.jpg')
INSERT [dbo].[Subject] ([SubjectID], [SubjectCode], [SubjectName], [Image]) VALUES (2, N'ENG101', N'Tiếng Anh', N'https://example.com/eng101.jpg')
INSERT [dbo].[Subject] ([SubjectID], [SubjectCode], [SubjectName], [Image]) VALUES (3, N'PHY101', N'Vật lý', N'https://example.com/phy101.jpg')
INSERT [dbo].[Subject] ([SubjectID], [SubjectCode], [SubjectName], [Image]) VALUES (4, N'CHEM101', N'Hóa học', N'https://example.com/chem101.jpg')
INSERT [dbo].[Subject] ([SubjectID], [SubjectCode], [SubjectName], [Image]) VALUES (5, N'BIO101', N'Sinh học', N'https://example.com/bio101.jpg')
INSERT [dbo].[Subject] ([SubjectID], [SubjectCode], [SubjectName], [Image]) VALUES (6, N'HIST101', N'Lịch sử', N'https://example.com/hist101.jpg')
INSERT [dbo].[Subject] ([SubjectID], [SubjectCode], [SubjectName], [Image]) VALUES (7, N'GEOG101', N'Thể dục', N'https://example.com/geog101.jpg')
INSERT [dbo].[Subject] ([SubjectID], [SubjectCode], [SubjectName], [Image]) VALUES (8, N'COMP101', N'Tin học', N'https://example.com/comp101.jpg')
INSERT [dbo].[Subject] ([SubjectID], [SubjectCode], [SubjectName], [Image]) VALUES (9, N'MUS101', N'Văn học', N'https://example.com/mus101.jpg')
INSERT [dbo].[Subject] ([SubjectID], [SubjectCode], [SubjectName], [Image]) VALUES (10, N'ART101', N'Địa lý', N'https://example.com/art101.jpg')
SET IDENTITY_INSERT [dbo].[Subject] OFF
GO
SET IDENTITY_INSERT [dbo].[Teacher] ON 

INSERT [dbo].[Teacher] ([TeacherID], [DepartmentID], [UserID], [SubjectID], [TeacherCode], [Degree], [Expertise], [University], [GraduationYear], [Major], [OtherCertifications], [Position], [Salary], [AdditionalBenifits], [CurrentHealthStatus], [HealthInsuranceInfo], [SelfIntroduction], [IsLeader]) VALUES (1, 4, 2, 6, N'TC001', N'Thạc sĩ', N'Toán học', N'Đại học Quốc gia Hà Nội', CAST(N'2010-01-01T00:00:00.000' AS DateTime), N'Lịch sử', NULL, N'Giáo viên', CAST(30000000 AS Decimal(18, 0)), N'Bảo hiểm y tế', N'Bình thường', N'Bảo hiểm BHYT số 123456789', N'Tôi là m?t giáo viên Toán có kinh nghi?m', 1)
INSERT [dbo].[Teacher] ([TeacherID], [DepartmentID], [UserID], [SubjectID], [TeacherCode], [Degree], [Expertise], [University], [GraduationYear], [Major], [OtherCertifications], [Position], [Salary], [AdditionalBenifits], [CurrentHealthStatus], [HealthInsuranceInfo], [SelfIntroduction], [IsLeader]) VALUES (2, 2, 3, 4, N'TC001', N'Thạc sĩ', N'Toán học', N'Đại học Quốc gia Hà Nội', CAST(N'2010-01-01T00:00:00.000' AS DateTime), N'Hóa học', NULL, N'Giáo viên', CAST(30000000 AS Decimal(18, 0)), N'Bảo hiểm y tế', N'Bình thường', N'Bảo hiểm BHYT số 123456789', N'Tôi là m?t giáo viên Toán có kinh nghi?m', 1)
INSERT [dbo].[Teacher] ([TeacherID], [DepartmentID], [UserID], [SubjectID], [TeacherCode], [Degree], [Expertise], [University], [GraduationYear], [Major], [OtherCertifications], [Position], [Salary], [AdditionalBenifits], [CurrentHealthStatus], [HealthInsuranceInfo], [SelfIntroduction], [IsLeader]) VALUES (3, 3, 4, 5, N'TC001', N'Thạc sĩ', N'Toán học', N'Đại học Quốc gia Hà Nội', CAST(N'2010-01-01T00:00:00.000' AS DateTime), N'Sinh học', NULL, N'Giáo viên', CAST(30000000 AS Decimal(18, 0)), N'Bảo hiểm y tế', N'Bình thường', N'Bảo hiểm BHYT số 123456789', N'Tôi là m?t giáo viên Toán có kinh nghi?m', 1)
INSERT [dbo].[Teacher] ([TeacherID], [DepartmentID], [UserID], [SubjectID], [TeacherCode], [Degree], [Expertise], [University], [GraduationYear], [Major], [OtherCertifications], [Position], [Salary], [AdditionalBenifits], [CurrentHealthStatus], [HealthInsuranceInfo], [SelfIntroduction], [IsLeader]) VALUES (4, 5, 5, 9, N'TC001', N'Thạc sĩ', N'Toán học', N'Đại học Quốc gia Hà Nội', CAST(N'2010-01-01T00:00:00.000' AS DateTime), N'Văn học', NULL, N'Giáo viên', CAST(30000000 AS Decimal(18, 0)), N'Bảo hiểm y tế', N'Bình thường', N'Bảo hiểm BHYT số 123456789', N'Tôi là m?t giáo viên Toán có kinh nghi?m', 1)
INSERT [dbo].[Teacher] ([TeacherID], [DepartmentID], [UserID], [SubjectID], [TeacherCode], [Degree], [Expertise], [University], [GraduationYear], [Major], [OtherCertifications], [Position], [Salary], [AdditionalBenifits], [CurrentHealthStatus], [HealthInsuranceInfo], [SelfIntroduction], [IsLeader]) VALUES (5, 6, 6, 10, N'TC001', N'Thạc sĩ', N'Toán học', N'Đại học Quốc gia Hà Nội', CAST(N'2010-01-01T00:00:00.000' AS DateTime), N'Địa lý', NULL, N'Giáo viên', CAST(30000000 AS Decimal(18, 0)), N'Bảo hiểm y tế', N'Bình thường', N'Bảo hiểm BHYT số 123456789', N'Tôi là m?t giáo viên Toán có kinh nghi?m', 1)
INSERT [dbo].[Teacher] ([TeacherID], [DepartmentID], [UserID], [SubjectID], [TeacherCode], [Degree], [Expertise], [University], [GraduationYear], [Major], [OtherCertifications], [Position], [Salary], [AdditionalBenifits], [CurrentHealthStatus], [HealthInsuranceInfo], [SelfIntroduction], [IsLeader]) VALUES (8, 6, 14, 10, N'GV555', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Teacher] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (1, N'Đoàn Văn', N'Quân', N'Nam', CAST(N'2002-05-21T00:00:00.000' AS DateTime), N'0987654321', N'Việt Tiến, Việt Yên, Bắc Giang', N'hoangnguyen@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'admin', N'admin', N'admin', 1, CAST(N'2017-01-01T00:00:00.000' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (2, N'Đoàn Văn', N'Chính', N'Nam', CAST(N'2004-02-21T00:00:00.000' AS DateTime), N'0976543210', N'Việt Tiến, Việt Yên, Bắc Giang', N'doanvanchinh@gmail.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'chinh', N'chinh', N'teacher', 1, CAST(N'2019-12-10T00:00:00.000' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (3, N'An Hương', N'Lan', N'Nữ', CAST(N'2002-05-07T00:00:00.000' AS DateTime), N'0965432109', N'Việt Tiến, Việt Yên, Bắc Giang', N'ducle@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'lan', N'lan', N'teacher', 1, CAST(N'2017-02-15T00:00:00.000' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (4, N'Lê Thị Thu', N'Trà', N'Nữ', CAST(N'2002-05-12T00:00:00.000' AS DateTime), N'0954321098', N'Việt Tiến, Việt Yên, Bắc Giang', N'anhnguyen@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'tra', N'tra', N'teacher', 1, CAST(N'2017-03-20T00:00:00.000' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (5, N'Đỗ Đăng', N'Kiên', N'Nam', CAST(N'2002-05-12T00:00:00.000' AS DateTime), N'0943210987', N'Việt Tiến, Việt Yên, Bắc Giang', N'thaopham@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'kien', N'kien', N'teacher', 1, CAST(N'2017-11-11T00:00:00.000' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (6, N'Phạm Văn', N'Long', N'Nam', CAST(N'2002-05-12T00:00:00.000' AS DateTime), N'0932109876', N'Việt Tiến, Việt Yên, Bắc Giang', N'tuanhuynh@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'long', N'long', N'teacher', 1, CAST(N'2019-10-05T00:00:00.000' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (7, N'Thành', N'Võ', N'Nam', CAST(N'2008-05-12T00:00:00.000' AS DateTime), N'0910987654', N'Việt Tiến, Việt Yên, Bắc Giang', N'thanhvo@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'student', N'student', N'student', 1, CAST(N'2020-05-15T00:00:00.000' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (8, N'Loan', N'Trần', N'Nữ', CAST(N'2008-05-12T00:00:00.000' AS DateTime), N'0909876543', N'Việt Tiến, Việt Yên, Bắc Giang', N'loantran@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'loantran', N'loan@2022', N'student', 1, CAST(N'2017-09-20T00:00:00.000' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (9, N'Hải', N'Lê', N'Nam', CAST(N'2008-05-12T00:00:00.000' AS DateTime), N'0898765432', N'Việt Tiến, Việt Yên, Bắc Giang', N'haile@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'haile', N'haile123', N'student', 1, CAST(N'2019-08-12T00:00:00.000' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (10, N'Minh', N'Đặng', N'Nam', CAST(N'2008-05-12T00:00:00.000' AS DateTime), N'0887654321', N'Việt Tiến, Việt Yên, Bắc Giang', N'minhdang@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'minhdang', N'minh@123', N'student', 1, CAST(N'2018-04-25T00:00:00.000' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (11, N'Thúy', N'Hoàng', N'Nữ', CAST(N'2008-05-12T00:00:00.000' AS DateTime), N'0876543210', N'Việt Tiến, Việt Yên, Bắc Giang', N'thuyhoang@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'thuyhoang', N'thuy@2023', N'student', 1, CAST(N'2020-11-30T00:00:00.000' AS DateTime), NULL, 1)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (12, N'Dương', N'Lê', N'Nam', CAST(N'2008-05-12T00:00:00.000' AS DateTime), N'0865432109', N'Việt Tiến, Việt Yên, Bắc Giang', N'duongle@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'duongle', N'duong123', N'student', 1, CAST(N'2021-03-01T00:00:00.000' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (13, N'Quỳnh', N'Nguyễn', N'Nữ', CAST(N'2008-05-12T00:00:00.000' AS DateTime), N'0854321098', N'Việt Tiến, Việt Yên, Bắc Giang', N'quynhnguyen@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'quynhnguyen', N'quynh@123', N'student', 1, CAST(N'2019-07-10T00:00:00.000' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (14, N'Thắng', N'Huỳnh', N'Nam', CAST(N'2008-05-12T00:00:00.000' AS DateTime), N'0843210987', N'Việt Tiến, Việt Yên, Bắc Giang', N'thanghuynh@example.com', N'avares://SchoolManagement.UI/Assets/Images/dvquan.jpg', N'thanghuynh', N'thang789', N'teacher', 1, CAST(N'2017-12-05T00:00:00.000' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (22, N'Nguyen Van', N'Trang', N'Nam', CAST(N'2024-05-13T21:29:30.000' AS DateTime), N'091028948', N'Viet Yen, Bac Giang', N'trang@gmail.com', NULL, N'nguyen van trang', N'Nguyen Van Trang@2024', N'student', NULL, CAST(N'2024-05-13T21:30:36.023' AS DateTime), CAST(N'2024-05-13T21:29:30.640' AS DateTime), NULL)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (23, N'Nguyen Van', N'Tu', N'Nam', CAST(N'2024-05-13T21:35:56.000' AS DateTime), N'012391023', N'Viet Tien, Viet Yen, Bac Giang', N'tu@gmail.com', NULL, N'nguyen van tu', N'Nguyen Van Tu@2024', N'student', NULL, CAST(N'2024-05-13T21:36:44.630' AS DateTime), CAST(N'2024-05-13T21:35:56.997' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Class]  WITH CHECK ADD FOREIGN KEY([TeacherID])
REFERENCES [dbo].[Teacher] ([TeacherID])
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD FOREIGN KEY([ClassID])
REFERENCES [dbo].[Class] ([ClassID])
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD FOREIGN KEY([EducationProgramID])
REFERENCES [dbo].[EducationProgram] ([EducationProgramID])
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD FOREIGN KEY([SubjectID])
REFERENCES [dbo].[Subject] ([SubjectID])
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD FOREIGN KEY([TeacherID])
REFERENCES [dbo].[Teacher] ([TeacherID])
GO
ALTER TABLE [dbo].[EditGradeSheetForm]  WITH CHECK ADD FOREIGN KEY([GradeSheetID])
REFERENCES [dbo].[GradeSheet] ([GradeSheetID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EditGradeSheetForm]  WITH CHECK ADD FOREIGN KEY([TeacherID])
REFERENCES [dbo].[Teacher] ([TeacherID])
GO
ALTER TABLE [dbo].[GradeSheet]  WITH CHECK ADD FOREIGN KEY([CourseID])
REFERENCES [dbo].[Course] ([CourseID])
GO
ALTER TABLE [dbo].[GradeSheet]  WITH CHECK ADD FOREIGN KEY([StudentID])
REFERENCES [dbo].[Student] ([StudentID])
GO
ALTER TABLE [dbo].[Lesson]  WITH CHECK ADD FOREIGN KEY([EducationProgramID])
REFERENCES [dbo].[EducationProgram] ([EducationProgramID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[Department] ([DepartmentID])
GO
ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD FOREIGN KEY([SubjectID])
REFERENCES [dbo].[Subject] ([SubjectID])
GO
ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
USE [master]
GO
ALTER DATABASE [SchoolManagement] SET  READ_WRITE 
GO
