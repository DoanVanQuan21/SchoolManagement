USE [master]
GO
/****** Object:  Database [SchoolManagement]    Script Date: 5/28/2024 8:40:55 PM ******/
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
/****** Object:  Table [dbo].[Class]    Script Date: 5/28/2024 8:40:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Class](
	[ClassID] [int] IDENTITY(1,1) NOT NULL,
	[ClassCode] [nvarchar](100) NULL,
	[ClassName] [nvarchar](100) NULL,
	[NumberOfStudent] [int] NULL,
	[TeacherID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ClassID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 5/28/2024 8:40:56 PM ******/
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
/****** Object:  Table [dbo].[Department]    Script Date: 5/28/2024 8:40:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[DepartmentID] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentCode] [nvarchar](100) NULL,
	[DepartmentName] [nvarchar](100) NULL,
	[FoundingDate] [datetime] NULL,
	[Image] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[DepartmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EditGradeSheetForm]    Script Date: 5/28/2024 8:40:56 PM ******/
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
/****** Object:  Table [dbo].[EducationProgram]    Script Date: 5/28/2024 8:40:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EducationProgram](
	[EducationProgramID] [int] IDENTITY(1,1) NOT NULL,
	[EducationProgramCode] [nvarchar](100) NULL,
	[EducationName] [nvarchar](100) NULL,
	[NumberOfLesson] [int] NULL,
	[Status] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[EducationProgramID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GradeSheet]    Script Date: 5/28/2024 8:40:56 PM ******/
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
/****** Object:  Table [dbo].[HomeroomAssignment]    Script Date: 5/28/2024 8:40:56 PM ******/
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
/****** Object:  Table [dbo].[Lesson]    Script Date: 5/28/2024 8:40:56 PM ******/
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
/****** Object:  Table [dbo].[Schedule]    Script Date: 5/28/2024 8:40:56 PM ******/
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
/****** Object:  Table [dbo].[Student]    Script Date: 5/28/2024 8:40:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[StudentID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[StudentCode] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentAssignment]    Script Date: 5/28/2024 8:40:56 PM ******/
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
/****** Object:  Table [dbo].[Subject]    Script Date: 5/28/2024 8:40:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subject](
	[SubjectID] [int] IDENTITY(1,1) NOT NULL,
	[SubjectCode] [nvarchar](100) NULL,
	[SubjectName] [nvarchar](100) NULL,
	[Image] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[SubjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 5/28/2024 8:40:56 PM ******/
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
/****** Object:  Table [dbo].[User]    Script Date: 5/28/2024 8:40:56 PM ******/
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

INSERT [dbo].[Class] ([ClassID], [ClassCode], [ClassName], [NumberOfStudent], [TeacherID]) VALUES (1, N'CL10A12024', N'10A1', 30, NULL)
INSERT [dbo].[Class] ([ClassID], [ClassCode], [ClassName], [NumberOfStudent], [TeacherID]) VALUES (2, N'CL10A22024', N'10A2', 30, NULL)
INSERT [dbo].[Class] ([ClassID], [ClassCode], [ClassName], [NumberOfStudent], [TeacherID]) VALUES (3, N'CL10A32024', N'10A3', 30, NULL)
INSERT [dbo].[Class] ([ClassID], [ClassCode], [ClassName], [NumberOfStudent], [TeacherID]) VALUES (4, N'CL10A42024', N'10A4', 30, NULL)
INSERT [dbo].[Class] ([ClassID], [ClassCode], [ClassName], [NumberOfStudent], [TeacherID]) VALUES (5, N'CL10A52024', N'10A5', 30, NULL)
INSERT [dbo].[Class] ([ClassID], [ClassCode], [ClassName], [NumberOfStudent], [TeacherID]) VALUES (6, N'CL10A62024', N'10A6', 30, NULL)
INSERT [dbo].[Class] ([ClassID], [ClassCode], [ClassName], [NumberOfStudent], [TeacherID]) VALUES (7, N'CL10A72024', N'10A7', 30, NULL)
INSERT [dbo].[Class] ([ClassID], [ClassCode], [ClassName], [NumberOfStudent], [TeacherID]) VALUES (8, N'CL10A82024', N'10A8', 30, NULL)
INSERT [dbo].[Class] ([ClassID], [ClassCode], [ClassName], [NumberOfStudent], [TeacherID]) VALUES (9, N'CL10A92024', N'10A9', 30, NULL)
INSERT [dbo].[Class] ([ClassID], [ClassCode], [ClassName], [NumberOfStudent], [TeacherID]) VALUES (10, N'CL10A102024', N'10A10', 30, NULL)
INSERT [dbo].[Class] ([ClassID], [ClassCode], [ClassName], [NumberOfStudent], [TeacherID]) VALUES (11, N'CL10A112024', N'10A11', 30, NULL)
INSERT [dbo].[Class] ([ClassID], [ClassCode], [ClassName], [NumberOfStudent], [TeacherID]) VALUES (12, N'CL11A12024', N'11A1', 30, NULL)
INSERT [dbo].[Class] ([ClassID], [ClassCode], [ClassName], [NumberOfStudent], [TeacherID]) VALUES (13, N'CL11A22024', N'11A2', 30, NULL)
INSERT [dbo].[Class] ([ClassID], [ClassCode], [ClassName], [NumberOfStudent], [TeacherID]) VALUES (14, N'CL11A32024', N'11A3', 30, NULL)
INSERT [dbo].[Class] ([ClassID], [ClassCode], [ClassName], [NumberOfStudent], [TeacherID]) VALUES (15, N'CL11A42024', N'11A4', 30, NULL)
INSERT [dbo].[Class] ([ClassID], [ClassCode], [ClassName], [NumberOfStudent], [TeacherID]) VALUES (16, N'CL11A52024', N'11A5', 30, NULL)
INSERT [dbo].[Class] ([ClassID], [ClassCode], [ClassName], [NumberOfStudent], [TeacherID]) VALUES (17, N'CL11A62024', N'11A6', 30, NULL)
INSERT [dbo].[Class] ([ClassID], [ClassCode], [ClassName], [NumberOfStudent], [TeacherID]) VALUES (18, N'CL11A72024', N'11A7', 30, NULL)
INSERT [dbo].[Class] ([ClassID], [ClassCode], [ClassName], [NumberOfStudent], [TeacherID]) VALUES (19, N'CL11A82024', N'11A8', 30, NULL)
INSERT [dbo].[Class] ([ClassID], [ClassCode], [ClassName], [NumberOfStudent], [TeacherID]) VALUES (20, N'CL11A92024', N'11A9', 30, NULL)
INSERT [dbo].[Class] ([ClassID], [ClassCode], [ClassName], [NumberOfStudent], [TeacherID]) VALUES (21, N'CL11A102024', N'11A10', 30, NULL)
INSERT [dbo].[Class] ([ClassID], [ClassCode], [ClassName], [NumberOfStudent], [TeacherID]) VALUES (22, N'CL11A112024', N'11A11', 30, NULL)
INSERT [dbo].[Class] ([ClassID], [ClassCode], [ClassName], [NumberOfStudent], [TeacherID]) VALUES (23, N'CL12A12024', N'12A1', 30, NULL)
INSERT [dbo].[Class] ([ClassID], [ClassCode], [ClassName], [NumberOfStudent], [TeacherID]) VALUES (24, N'CL12A22024', N'12A2', 30, NULL)
INSERT [dbo].[Class] ([ClassID], [ClassCode], [ClassName], [NumberOfStudent], [TeacherID]) VALUES (25, N'CL12A32024', N'12A3', 30, NULL)
INSERT [dbo].[Class] ([ClassID], [ClassCode], [ClassName], [NumberOfStudent], [TeacherID]) VALUES (26, N'CL12A42024', N'12A4', 30, NULL)
INSERT [dbo].[Class] ([ClassID], [ClassCode], [ClassName], [NumberOfStudent], [TeacherID]) VALUES (27, N'CL12A52024', N'12A5', 30, NULL)
INSERT [dbo].[Class] ([ClassID], [ClassCode], [ClassName], [NumberOfStudent], [TeacherID]) VALUES (28, N'CL12A62024', N'12A6', 30, NULL)
INSERT [dbo].[Class] ([ClassID], [ClassCode], [ClassName], [NumberOfStudent], [TeacherID]) VALUES (29, N'CL12A72024', N'12A7', 30, NULL)
INSERT [dbo].[Class] ([ClassID], [ClassCode], [ClassName], [NumberOfStudent], [TeacherID]) VALUES (30, N'CL12A82024', N'12A8', 30, NULL)
INSERT [dbo].[Class] ([ClassID], [ClassCode], [ClassName], [NumberOfStudent], [TeacherID]) VALUES (31, N'CL12A92024', N'12A9', 30, NULL)
INSERT [dbo].[Class] ([ClassID], [ClassCode], [ClassName], [NumberOfStudent], [TeacherID]) VALUES (32, N'CL12A102024', N'12A10', 30, NULL)
INSERT [dbo].[Class] ([ClassID], [ClassCode], [ClassName], [NumberOfStudent], [TeacherID]) VALUES (33, N'CL12A112024', N'12A11', 30, NULL)
SET IDENTITY_INSERT [dbo].[Class] OFF
GO
SET IDENTITY_INSERT [dbo].[Course] ON 

INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (1, 1, 1, 1, 1, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (2, 1, 2, 2, 2, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (3, 1, 3, 3, 3, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (4, 1, 4, 4, 4, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (5, 1, 5, 5, 5, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (6, 1, 6, 6, 6, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (7, 1, 7, 7, 7, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (8, 1, 8, 8, 8, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (9, 1, 9, 9, 9, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (10, 1, 10, 10, 10, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (11, 1, 11, 11, 11, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (12, 1, 12, 12, 12, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (13, 1, 13, 13, 13, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (14, 2, 1, 1, 1, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (15, 2, 2, 2, 2, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (16, 2, 3, 3, 3, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (17, 2, 4, 4, 4, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (18, 2, 5, 5, 5, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (19, 2, 6, 6, 6, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (20, 2, 7, 7, 7, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (21, 2, 8, 8, 8, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (22, 2, 9, 9, 9, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (23, 2, 10, 10, 10, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (24, 2, 11, 11, 11, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (25, 2, 12, 12, 12, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (26, 2, 13, 13, 13, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (27, 3, 1, 1, 1, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (28, 3, 2, 2, 2, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (29, 3, 3, 3, 3, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (30, 3, 4, 4, 4, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (31, 3, 5, 5, 5, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (32, 3, 6, 6, 6, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (33, 3, 7, 7, 7, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (34, 3, 8, 8, 8, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (35, 3, 9, 9, 9, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (36, 3, 10, 10, 10, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (37, 3, 11, 11, 11, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (38, 3, 12, 12, 12, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (39, 3, 13, 13, 13, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (40, 4, 1, 1, 1, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (41, 4, 2, 2, 2, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (42, 4, 3, 3, 3, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (43, 4, 4, 4, 4, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (44, 4, 5, 5, 5, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (45, 4, 6, 6, 6, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (46, 4, 7, 7, 7, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (47, 4, 8, 8, 8, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (48, 4, 9, 9, 9, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (49, 4, 10, 10, 10, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (50, 4, 11, 11, 11, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (51, 4, 12, 12, 12, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (52, 4, 13, 13, 13, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (53, 5, 1, 1, 1, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (54, 5, 2, 2, 2, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (55, 5, 3, 3, 3, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (56, 5, 4, 4, 4, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (57, 5, 5, 5, 5, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (58, 5, 6, 6, 6, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (59, 5, 7, 7, 7, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (60, 5, 8, 8, 8, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (61, 5, 9, 9, 9, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (62, 5, 10, 10, 10, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (63, 5, 11, 11, 11, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (64, 5, 12, 12, 12, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (65, 5, 13, 13, 13, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (66, 6, 1, 1, 1, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (67, 6, 2, 2, 2, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (68, 6, 3, 3, 3, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (69, 6, 4, 4, 4, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (70, 6, 5, 5, 5, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (71, 6, 6, 6, 6, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (72, 6, 7, 7, 7, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (73, 6, 8, 8, 8, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (74, 6, 9, 9, 9, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (75, 6, 10, 10, 10, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (76, 6, 11, 11, 11, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (77, 6, 12, 12, 12, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (78, 6, 13, 13, 13, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (79, 7, 1, 1, 1, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (80, 7, 2, 2, 2, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (81, 7, 3, 3, 3, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (82, 7, 4, 4, 4, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (83, 7, 5, 5, 5, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (84, 7, 6, 6, 6, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (85, 7, 7, 7, 7, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (86, 7, 8, 8, 8, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (87, 7, 9, 9, 9, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (88, 7, 10, 10, 10, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (89, 7, 11, 11, 11, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (90, 7, 12, 12, 12, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (91, 7, 13, 13, 13, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (92, 8, 1, 1, 1, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (93, 8, 2, 2, 2, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (94, 8, 3, 3, 3, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (95, 8, 4, 4, 4, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (96, 8, 5, 5, 5, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (97, 8, 6, 6, 6, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (98, 8, 7, 7, 7, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (99, 8, 8, 8, 8, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
GO
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (100, 8, 9, 9, 9, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (101, 8, 10, 10, 10, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (102, 8, 11, 11, 11, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (103, 8, 12, 12, 12, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (104, 8, 13, 13, 13, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (105, 9, 1, 1, 1, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (106, 9, 2, 2, 2, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (107, 9, 3, 3, 3, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (108, 9, 4, 4, 4, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (109, 9, 5, 5, 5, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (110, 9, 6, 6, 6, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (111, 9, 7, 7, 7, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (112, 9, 8, 8, 8, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (113, 9, 9, 9, 9, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (114, 9, 10, 10, 10, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (115, 9, 11, 11, 11, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (116, 9, 12, 12, 12, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (117, 9, 13, 13, 13, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (118, 10, 1, 1, 1, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (119, 10, 2, 2, 2, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (120, 10, 3, 3, 3, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (121, 10, 4, 4, 4, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (122, 10, 5, 5, 5, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (123, 10, 6, 6, 6, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (124, 10, 7, 7, 7, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (125, 10, 8, 8, 8, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (126, 10, 9, 9, 9, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (127, 10, 10, 10, 10, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (128, 10, 11, 11, 11, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (129, 10, 12, 12, 12, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (130, 10, 13, 13, 13, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (131, 11, 1, 1, 1, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (132, 11, 2, 2, 2, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (133, 11, 3, 3, 3, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (134, 11, 4, 4, 4, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (135, 11, 5, 5, 5, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (136, 11, 6, 6, 6, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (137, 11, 7, 7, 7, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (138, 11, 8, 8, 8, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (139, 11, 9, 9, 9, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (140, 11, 10, 10, 10, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (141, 11, 11, 11, 11, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (142, 11, 12, 12, 12, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
INSERT [dbo].[Course] ([CourseID], [ClassID], [TeacherID], [SubjectID], [EducationProgramID], [StartDate], [EndDate], [Status], [Semester]) VALUES (143, 11, 13, 13, 13, CAST(N'2024-04-14T00:00:00.000' AS DateTime), CAST(N'2024-05-14T00:00:00.000' AS DateTime), N'Đang học', N'Kỳ 1')
SET IDENTITY_INSERT [dbo].[Course] OFF
GO
SET IDENTITY_INSERT [dbo].[Department] ON 

INSERT [dbo].[Department] ([DepartmentID], [DepartmentCode], [DepartmentName], [FoundingDate], [Image]) VALUES (1, N'DEPT0012024', N'Hóa - sinh, nông nghiệp', CAST(N'1990-01-01T00:00:00.000' AS DateTime), N'https://example.com/toanhoc.jpg')
INSERT [dbo].[Department] ([DepartmentID], [DepartmentCode], [DepartmentName], [FoundingDate], [Image]) VALUES (2, N'DEPT0022024', N'Toán, văn', CAST(N'1992-05-10T00:00:00.000' AS DateTime), N'https://example.com/hoahoc.jpg')
INSERT [dbo].[Department] ([DepartmentID], [DepartmentCode], [DepartmentName], [FoundingDate], [Image]) VALUES (3, N'DEPT0032024', N'Tiếng anh và tin học', CAST(N'1995-09-20T00:00:00.000' AS DateTime), N'https://example.com/sinhhoc.jpg')
INSERT [dbo].[Department] ([DepartmentID], [DepartmentCode], [DepartmentName], [FoundingDate], [Image]) VALUES (4, N'DEPT0042024', N'Sử, kinh tế và pháp luật', CAST(N'1988-03-15T00:00:00.000' AS DateTime), N'https://example.com/lichsu.jpg')
INSERT [dbo].[Department] ([DepartmentID], [DepartmentCode], [DepartmentName], [FoundingDate], [Image]) VALUES (5, N'DEPT0052024', N'Lý và kỹ thuật công nghiệp', CAST(N'1997-11-30T00:00:00.000' AS DateTime), N'https://example.com/vanhoc.jpg')
INSERT [dbo].[Department] ([DepartmentID], [DepartmentCode], [DepartmentName], [FoundingDate], [Image]) VALUES (6, N'DEPT0062024', N'Thể dục và quốc phòng an ninh', CAST(N'1994-07-25T00:00:00.000' AS DateTime), N'https://example.com/diali.jpg')
INSERT [dbo].[Department] ([DepartmentID], [DepartmentCode], [DepartmentName], [FoundingDate], [Image]) VALUES (7, N'DEPT0072024', N'Văn phòng', CAST(N'1994-07-25T00:00:00.000' AS DateTime), N'https://example.com/diali.jpg')
SET IDENTITY_INSERT [dbo].[Department] OFF
GO
SET IDENTITY_INSERT [dbo].[EditGradeSheetForm] ON 

INSERT [dbo].[EditGradeSheetForm] ([EditGradeSheetFormID], [GradeSheetID], [TeacherID], [Time], [Status], [reason]) VALUES (1, 15, 1, CAST(N'2024-05-27T20:35:18.057' AS DateTime), N'Waitting', N'23424')
SET IDENTITY_INSERT [dbo].[EditGradeSheetForm] OFF
GO
SET IDENTITY_INSERT [dbo].[EducationProgram] ON 

INSERT [dbo].[EducationProgram] ([EducationProgramID], [EducationProgramCode], [EducationName], [NumberOfLesson], [Status]) VALUES (1, N'EP0012024', N'Chương trình toán học', 30, N'Hoạt động')
INSERT [dbo].[EducationProgram] ([EducationProgramID], [EducationProgramCode], [EducationName], [NumberOfLesson], [Status]) VALUES (2, N'EP0022024', N'Chương trình hóa học', 35, N'Hoạt động')
INSERT [dbo].[EducationProgram] ([EducationProgramID], [EducationProgramCode], [EducationName], [NumberOfLesson], [Status]) VALUES (3, N'EP0032024', N'Chương trình sinh học', 25, N'Hoạt động')
INSERT [dbo].[EducationProgram] ([EducationProgramID], [EducationProgramCode], [EducationName], [NumberOfLesson], [Status]) VALUES (4, N'EP0042024', N'Chương trình lịch sử', 20, N'Không hoạt động')
INSERT [dbo].[EducationProgram] ([EducationProgramID], [EducationProgramCode], [EducationName], [NumberOfLesson], [Status]) VALUES (5, N'EP0052024', N'Chương trình văn học', 40, N'Hoạt động')
INSERT [dbo].[EducationProgram] ([EducationProgramID], [EducationProgramCode], [EducationName], [NumberOfLesson], [Status]) VALUES (6, N'EP0062024', N'Chương trình tin học', 40, N'Hoạt động')
INSERT [dbo].[EducationProgram] ([EducationProgramID], [EducationProgramCode], [EducationName], [NumberOfLesson], [Status]) VALUES (7, N'EP0072024', N'Chương trình địa lý', 40, N'Hoạt động')
INSERT [dbo].[EducationProgram] ([EducationProgramID], [EducationProgramCode], [EducationName], [NumberOfLesson], [Status]) VALUES (8, N'EP0082024', N'Chương trình lịch sử', 40, N'Hoạt động')
INSERT [dbo].[EducationProgram] ([EducationProgramID], [EducationProgramCode], [EducationName], [NumberOfLesson], [Status]) VALUES (9, N'EP0092024', N'Chương trình tiếng anh', 40, N'Hoạt động')
INSERT [dbo].[EducationProgram] ([EducationProgramID], [EducationProgramCode], [EducationName], [NumberOfLesson], [Status]) VALUES (10, N'EP0102024', N'Chương trình thể dục', 40, N'Hoạt động')
INSERT [dbo].[EducationProgram] ([EducationProgramID], [EducationProgramCode], [EducationName], [NumberOfLesson], [Status]) VALUES (11, N'EP0112024', N'Chương trình quốc phòng an ninh', 40, N'Hoạt động')
INSERT [dbo].[EducationProgram] ([EducationProgramID], [EducationProgramCode], [EducationName], [NumberOfLesson], [Status]) VALUES (12, N'EP0122024', N'Chương trình kinh tế và pháp luật', 40, N'Hoạt động')
INSERT [dbo].[EducationProgram] ([EducationProgramID], [EducationProgramCode], [EducationName], [NumberOfLesson], [Status]) VALUES (13, N'EP0132024', N'Chương trình kỹ thuật công nghiệp', 40, N'Hoạt động')
SET IDENTITY_INSERT [dbo].[EducationProgram] OFF
GO
SET IDENTITY_INSERT [dbo].[GradeSheet] ON 

INSERT [dbo].[GradeSheet] ([GradeSheetID], [CourseID], [StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage], [PromotionDecision], [Lock]) VALUES (14, 1, 1, 10, 10, 10, 10, 10, 10, 10, 1, 1)
INSERT [dbo].[GradeSheet] ([GradeSheetID], [CourseID], [StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage], [PromotionDecision], [Lock]) VALUES (15, 1, 2, 10, 10, 10, 10, 10, 10, 10, 1, 1)
INSERT [dbo].[GradeSheet] ([GradeSheetID], [CourseID], [StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage], [PromotionDecision], [Lock]) VALUES (16, 1, 3, 10, 10, 10, 10, 10, 10, 10, 1, 1)
INSERT [dbo].[GradeSheet] ([GradeSheetID], [CourseID], [StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage], [PromotionDecision], [Lock]) VALUES (17, 1, 4, 10, 10, 10, 10, 10, 10, 10, 1, 1)
INSERT [dbo].[GradeSheet] ([GradeSheetID], [CourseID], [StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage], [PromotionDecision], [Lock]) VALUES (18, 1, 5, 10, 10, 10, 10, 10, 10, 10, 1, 1)
INSERT [dbo].[GradeSheet] ([GradeSheetID], [CourseID], [StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage], [PromotionDecision], [Lock]) VALUES (19, 1, 6, 10, 10, 10, 10, 10, 10, 10, 1, 1)
INSERT [dbo].[GradeSheet] ([GradeSheetID], [CourseID], [StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage], [PromotionDecision], [Lock]) VALUES (20, 1, 7, 10, 10, 10, 10, 10, 10, 10, 1, 1)
INSERT [dbo].[GradeSheet] ([GradeSheetID], [CourseID], [StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage], [PromotionDecision], [Lock]) VALUES (21, 1, 8, 10, 10, 10, 10, 10, 10, 10, 1, 1)
INSERT [dbo].[GradeSheet] ([GradeSheetID], [CourseID], [StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage], [PromotionDecision], [Lock]) VALUES (22, 1, 9, 10, 10, 10, 10, 10, 10, 10, 1, 1)
INSERT [dbo].[GradeSheet] ([GradeSheetID], [CourseID], [StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage], [PromotionDecision], [Lock]) VALUES (23, 1, 10, 10, 10, 10, 10, 10, 10, 10, 1, 1)
INSERT [dbo].[GradeSheet] ([GradeSheetID], [CourseID], [StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage], [PromotionDecision], [Lock]) VALUES (24, 1, 11, 10, 10, 10, 10, 10, 10, 10, 1, 1)
INSERT [dbo].[GradeSheet] ([GradeSheetID], [CourseID], [StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage], [PromotionDecision], [Lock]) VALUES (25, 1, 12, 10, 10, 10, 10, 10, 10, 10, 1, 1)
INSERT [dbo].[GradeSheet] ([GradeSheetID], [CourseID], [StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage], [PromotionDecision], [Lock]) VALUES (26, 1, 13, 10, 10, 10, 10, 10, 10, 10, 1, 1)
INSERT [dbo].[GradeSheet] ([GradeSheetID], [CourseID], [StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage], [PromotionDecision], [Lock]) VALUES (27, 1, 14, 10, 10, 10, 10, 10, 10, 10, 1, 1)
INSERT [dbo].[GradeSheet] ([GradeSheetID], [CourseID], [StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage], [PromotionDecision], [Lock]) VALUES (28, 1, 15, 10, 10, 10, 10, 10, 10, 10, 1, 1)
INSERT [dbo].[GradeSheet] ([GradeSheetID], [CourseID], [StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage], [PromotionDecision], [Lock]) VALUES (29, 1, 16, 10, 10, 10, 10, 10, 10, 10, 1, 1)
INSERT [dbo].[GradeSheet] ([GradeSheetID], [CourseID], [StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage], [PromotionDecision], [Lock]) VALUES (30, 1, 17, 10, 10, 10, 10, 10, 10, 10, 1, 1)
INSERT [dbo].[GradeSheet] ([GradeSheetID], [CourseID], [StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage], [PromotionDecision], [Lock]) VALUES (31, 1, 18, 10, 10, 10, 10, 10, 10, 10, 1, 1)
INSERT [dbo].[GradeSheet] ([GradeSheetID], [CourseID], [StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage], [PromotionDecision], [Lock]) VALUES (32, 1, 19, 10, 10, 10, 10, 10, 10, 10, 1, 1)
INSERT [dbo].[GradeSheet] ([GradeSheetID], [CourseID], [StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage], [PromotionDecision], [Lock]) VALUES (33, 1, 20, 10, 10, 10, 10, 10, 10, 10, 1, 1)
INSERT [dbo].[GradeSheet] ([GradeSheetID], [CourseID], [StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage], [PromotionDecision], [Lock]) VALUES (34, 1, 21, 10, 10, 10, 10, 10, 10, 10, 1, 1)
INSERT [dbo].[GradeSheet] ([GradeSheetID], [CourseID], [StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage], [PromotionDecision], [Lock]) VALUES (35, 1, 22, 10, 10, 10, 10, 10, 10, 10, 1, 1)
INSERT [dbo].[GradeSheet] ([GradeSheetID], [CourseID], [StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage], [PromotionDecision], [Lock]) VALUES (36, 1, 23, 10, 10, 10, 10, 10, 10, 10, 1, 1)
INSERT [dbo].[GradeSheet] ([GradeSheetID], [CourseID], [StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage], [PromotionDecision], [Lock]) VALUES (37, 1, 24, 10, 10, 10, 10, 10, 10, 10, 1, 1)
INSERT [dbo].[GradeSheet] ([GradeSheetID], [CourseID], [StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage], [PromotionDecision], [Lock]) VALUES (38, 1, 25, 10, 10, 10, 10, 10, 10, 10, 1, 1)
INSERT [dbo].[GradeSheet] ([GradeSheetID], [CourseID], [StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage], [PromotionDecision], [Lock]) VALUES (39, 1, 26, 10, 10, 10, 10, 10, 10, 10, 1, 1)
INSERT [dbo].[GradeSheet] ([GradeSheetID], [CourseID], [StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage], [PromotionDecision], [Lock]) VALUES (40, 1, 27, 10, 10, 10, 10, 10, 10, 10, 1, 1)
INSERT [dbo].[GradeSheet] ([GradeSheetID], [CourseID], [StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage], [PromotionDecision], [Lock]) VALUES (41, 1, 28, 10, 10, 10, 10, 10, 10, 10, 1, 1)
INSERT [dbo].[GradeSheet] ([GradeSheetID], [CourseID], [StudentID], [FirstRegularScore], [SecondRegularScore], [ThirdRegularScore], [FourRegularScore], [MidtermScore], [FinalScore], [SemesterAverage], [PromotionDecision], [Lock]) VALUES (42, 1, 29, 10, 10, 10, 10, 10, 10, 10, 1, 1)
SET IDENTITY_INSERT [dbo].[GradeSheet] OFF
GO
INSERT [dbo].[HomeroomAssignment] ([ClassID], [TeacherID], [StartDate], [EndDate]) VALUES (1, 1, CAST(N'2023-01-01T00:00:00.000' AS DateTime), CAST(N'2024-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[HomeroomAssignment] ([ClassID], [TeacherID], [StartDate], [EndDate]) VALUES (2, 2, CAST(N'2023-01-01T00:00:00.000' AS DateTime), CAST(N'2024-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[HomeroomAssignment] ([ClassID], [TeacherID], [StartDate], [EndDate]) VALUES (3, 3, CAST(N'2023-01-01T00:00:00.000' AS DateTime), CAST(N'2024-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[HomeroomAssignment] ([ClassID], [TeacherID], [StartDate], [EndDate]) VALUES (4, 4, CAST(N'2023-01-01T00:00:00.000' AS DateTime), CAST(N'2024-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[HomeroomAssignment] ([ClassID], [TeacherID], [StartDate], [EndDate]) VALUES (6, 6, CAST(N'2023-01-01T00:00:00.000' AS DateTime), CAST(N'2024-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[HomeroomAssignment] ([ClassID], [TeacherID], [StartDate], [EndDate]) VALUES (7, 7, CAST(N'2023-01-01T00:00:00.000' AS DateTime), CAST(N'2024-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[HomeroomAssignment] ([ClassID], [TeacherID], [StartDate], [EndDate]) VALUES (8, 8, CAST(N'2023-01-01T00:00:00.000' AS DateTime), CAST(N'2024-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[HomeroomAssignment] ([ClassID], [TeacherID], [StartDate], [EndDate]) VALUES (9, 9, CAST(N'2023-01-01T00:00:00.000' AS DateTime), CAST(N'2024-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[HomeroomAssignment] ([ClassID], [TeacherID], [StartDate], [EndDate]) VALUES (10, 10, CAST(N'2023-01-01T00:00:00.000' AS DateTime), CAST(N'2024-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[HomeroomAssignment] ([ClassID], [TeacherID], [StartDate], [EndDate]) VALUES (11, 11, CAST(N'2023-01-01T00:00:00.000' AS DateTime), CAST(N'2024-01-01T00:00:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Student] ON 

INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (1, 14, N'ST12024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (2, 15, N'ST22024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (3, 16, N'ST32024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (4, 17, N'ST42024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (5, 18, N'ST52024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (6, 19, N'ST62024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (7, 20, N'ST72024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (8, 21, N'ST82024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (9, 22, N'ST92024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (10, 23, N'ST102024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (11, 24, N'ST112024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (12, 25, N'ST122024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (13, 26, N'ST132024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (14, 27, N'ST142024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (15, 28, N'ST152024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (16, 29, N'ST162024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (17, 30, N'ST172024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (18, 31, N'ST182024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (19, 32, N'ST192024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (20, 33, N'ST202024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (21, 34, N'ST212024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (22, 35, N'ST222024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (23, 36, N'ST232024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (24, 37, N'ST242024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (25, 38, N'ST252024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (26, 39, N'ST262024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (27, 40, N'ST272024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (28, 41, N'ST282024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (29, 42, N'ST292024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (30, 43, N'ST302024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (31, 44, N'ST312024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (32, 45, N'ST322024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (33, 46, N'ST332024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (34, 47, N'ST342024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (35, 48, N'ST352024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (36, 49, N'ST362024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (37, 50, N'ST372024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (38, 51, N'ST382024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (39, 52, N'ST392024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (40, 53, N'ST402024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (41, 54, N'ST412024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (42, 55, N'ST422024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (43, 56, N'ST432024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (44, 57, N'ST442024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (45, 58, N'ST452024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (46, 59, N'ST462024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (47, 60, N'ST472024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (48, 61, N'ST482024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (49, 62, N'ST492024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (50, 63, N'ST502024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (51, 64, N'ST512024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (52, 65, N'ST522024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (53, 66, N'ST532024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (54, 67, N'ST542024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (55, 68, N'ST552024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (56, 69, N'ST562024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (57, 70, N'ST572024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (58, 71, N'ST582024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (59, 72, N'ST592024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (60, 73, N'ST602024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (61, 74, N'ST612024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (62, 75, N'ST622024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (63, 76, N'ST632024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (64, 77, N'ST642024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (65, 78, N'ST652024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (66, 79, N'ST662024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (67, 80, N'ST672024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (68, 81, N'ST682024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (69, 82, N'ST692024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (70, 83, N'ST702024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (71, 84, N'ST712024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (72, 85, N'ST722024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (73, 86, N'ST732024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (74, 87, N'ST742024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (75, 88, N'ST752024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (76, 89, N'ST762024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (77, 90, N'ST772024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (78, 91, N'ST782024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (79, 92, N'ST792024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (80, 93, N'ST802024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (81, 94, N'ST812024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (82, 95, N'ST822024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (83, 96, N'ST832024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (84, 97, N'ST842024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (85, 98, N'ST852024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (86, 99, N'ST862024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (87, 100, N'ST872024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (88, 101, N'ST882024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (89, 102, N'ST892024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (90, 103, N'ST902024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (91, 104, N'ST912024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (92, 105, N'ST922024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (93, 106, N'ST932024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (94, 107, N'ST942024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (95, 108, N'ST952024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (96, 109, N'ST962024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (97, 110, N'ST972024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (98, 111, N'ST982024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (99, 112, N'ST992024')
GO
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (100, 113, N'ST1002024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (101, 114, N'ST1012024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (102, 115, N'ST1022024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (103, 116, N'ST1032024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (104, 117, N'ST1042024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (105, 118, N'ST1052024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (106, 119, N'ST1062024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (107, 120, N'ST1072024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (108, 121, N'ST1082024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (109, 122, N'ST1092024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (110, 123, N'ST1102024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (111, 124, N'ST1112024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (112, 125, N'ST1122024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (113, 126, N'ST1132024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (114, 127, N'ST1142024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (115, 128, N'ST1152024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (116, 129, N'ST1162024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (117, 130, N'ST1172024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (118, 131, N'ST1182024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (119, 132, N'ST1192024')
INSERT [dbo].[Student] ([StudentID], [UserID], [StudentCode]) VALUES (120, 133, N'ST1202024')
SET IDENTITY_INSERT [dbo].[Student] OFF
GO
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (1, 1, CAST(N'2024-05-27T09:57:30.903' AS DateTime), CAST(N'2024-11-27T09:57:30.903' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (2, 1, CAST(N'2024-05-27T09:57:30.903' AS DateTime), CAST(N'2024-11-27T09:57:30.903' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (3, 1, CAST(N'2024-05-27T09:57:30.903' AS DateTime), CAST(N'2024-11-27T09:57:30.903' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (4, 1, CAST(N'2024-05-27T09:57:30.907' AS DateTime), CAST(N'2024-11-27T09:57:30.907' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (5, 1, CAST(N'2024-05-27T09:57:30.907' AS DateTime), CAST(N'2024-11-27T09:57:30.907' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (6, 1, CAST(N'2024-05-27T09:57:30.907' AS DateTime), CAST(N'2024-11-27T09:57:30.907' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (7, 1, CAST(N'2024-05-27T09:57:30.907' AS DateTime), CAST(N'2024-11-27T09:57:30.907' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (8, 1, CAST(N'2024-05-27T09:57:30.907' AS DateTime), CAST(N'2024-11-27T09:57:30.907' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (9, 1, CAST(N'2024-05-27T09:57:30.907' AS DateTime), CAST(N'2024-11-27T09:57:30.907' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (10, 1, CAST(N'2024-05-27T09:57:30.907' AS DateTime), CAST(N'2024-11-27T09:57:30.907' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (11, 1, CAST(N'2024-05-27T09:57:30.907' AS DateTime), CAST(N'2024-11-27T09:57:30.907' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (12, 1, CAST(N'2024-05-27T09:57:30.907' AS DateTime), CAST(N'2024-11-27T09:57:30.907' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (13, 1, CAST(N'2024-05-27T09:57:30.910' AS DateTime), CAST(N'2024-11-27T09:57:30.910' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (14, 1, CAST(N'2024-05-27T09:57:30.910' AS DateTime), CAST(N'2024-11-27T09:57:30.910' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (15, 1, CAST(N'2024-05-27T09:57:30.910' AS DateTime), CAST(N'2024-11-27T09:57:30.910' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (16, 1, CAST(N'2024-05-27T09:57:30.910' AS DateTime), CAST(N'2024-11-27T09:57:30.910' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (17, 1, CAST(N'2024-05-27T09:57:30.910' AS DateTime), CAST(N'2024-11-27T09:57:30.910' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (18, 1, CAST(N'2024-05-27T09:57:30.910' AS DateTime), CAST(N'2024-11-27T09:57:30.910' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (19, 1, CAST(N'2024-05-27T09:57:30.910' AS DateTime), CAST(N'2024-11-27T09:57:30.910' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (20, 1, CAST(N'2024-05-27T09:57:30.910' AS DateTime), CAST(N'2024-11-27T09:57:30.910' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (21, 1, CAST(N'2024-05-27T09:57:30.910' AS DateTime), CAST(N'2024-11-27T09:57:30.910' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (22, 1, CAST(N'2024-05-27T09:57:30.910' AS DateTime), CAST(N'2024-11-27T09:57:30.910' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (23, 1, CAST(N'2024-05-27T09:57:30.910' AS DateTime), CAST(N'2024-11-27T09:57:30.910' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (24, 1, CAST(N'2024-05-27T09:57:30.910' AS DateTime), CAST(N'2024-11-27T09:57:30.910' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (25, 1, CAST(N'2024-05-27T09:57:30.910' AS DateTime), CAST(N'2024-11-27T09:57:30.910' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (26, 1, CAST(N'2024-05-27T09:57:30.910' AS DateTime), CAST(N'2024-11-27T09:57:30.910' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (27, 1, CAST(N'2024-05-27T09:57:30.910' AS DateTime), CAST(N'2024-11-27T09:57:30.910' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (28, 1, CAST(N'2024-05-27T09:57:30.910' AS DateTime), CAST(N'2024-11-27T09:57:30.910' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (29, 1, CAST(N'2024-05-27T09:57:30.910' AS DateTime), CAST(N'2024-11-27T09:57:30.910' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (30, 1, CAST(N'2024-05-27T09:57:30.913' AS DateTime), CAST(N'2024-11-27T09:57:30.913' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (31, 2, CAST(N'2024-05-27T09:57:30.913' AS DateTime), CAST(N'2024-11-27T09:57:30.913' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (32, 2, CAST(N'2024-05-27T09:57:30.913' AS DateTime), CAST(N'2024-11-27T09:57:30.913' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (33, 2, CAST(N'2024-05-27T09:57:30.913' AS DateTime), CAST(N'2024-11-27T09:57:30.913' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (34, 2, CAST(N'2024-05-27T09:57:30.913' AS DateTime), CAST(N'2024-11-27T09:57:30.913' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (35, 2, CAST(N'2024-05-27T09:57:30.913' AS DateTime), CAST(N'2024-11-27T09:57:30.913' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (36, 2, CAST(N'2024-05-27T09:57:30.913' AS DateTime), CAST(N'2024-11-27T09:57:30.913' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (37, 2, CAST(N'2024-05-27T09:57:30.913' AS DateTime), CAST(N'2024-11-27T09:57:30.913' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (38, 2, CAST(N'2024-05-27T09:57:30.913' AS DateTime), CAST(N'2024-11-27T09:57:30.913' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (39, 2, CAST(N'2024-05-27T09:57:30.913' AS DateTime), CAST(N'2024-11-27T09:57:30.913' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (40, 2, CAST(N'2024-05-27T09:57:30.913' AS DateTime), CAST(N'2024-11-27T09:57:30.913' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (41, 2, CAST(N'2024-05-27T09:57:30.913' AS DateTime), CAST(N'2024-11-27T09:57:30.913' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (42, 2, CAST(N'2024-05-27T09:57:30.913' AS DateTime), CAST(N'2024-11-27T09:57:30.913' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (43, 2, CAST(N'2024-05-27T09:57:30.913' AS DateTime), CAST(N'2024-11-27T09:57:30.913' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (44, 2, CAST(N'2024-05-27T09:57:30.913' AS DateTime), CAST(N'2024-11-27T09:57:30.913' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (45, 2, CAST(N'2024-05-27T09:57:30.913' AS DateTime), CAST(N'2024-11-27T09:57:30.913' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (46, 2, CAST(N'2024-05-27T09:57:30.913' AS DateTime), CAST(N'2024-11-27T09:57:30.913' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (47, 2, CAST(N'2024-05-27T09:57:30.913' AS DateTime), CAST(N'2024-11-27T09:57:30.913' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (48, 2, CAST(N'2024-05-27T09:57:30.913' AS DateTime), CAST(N'2024-11-27T09:57:30.913' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (49, 2, CAST(N'2024-05-27T09:57:30.913' AS DateTime), CAST(N'2024-11-27T09:57:30.913' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (50, 2, CAST(N'2024-05-27T09:57:30.913' AS DateTime), CAST(N'2024-11-27T09:57:30.913' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (51, 2, CAST(N'2024-05-27T09:57:30.913' AS DateTime), CAST(N'2024-11-27T09:57:30.913' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (52, 2, CAST(N'2024-05-27T09:57:30.913' AS DateTime), CAST(N'2024-11-27T09:57:30.913' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (53, 2, CAST(N'2024-05-27T09:57:30.913' AS DateTime), CAST(N'2024-11-27T09:57:30.913' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (54, 2, CAST(N'2024-05-27T09:57:30.913' AS DateTime), CAST(N'2024-11-27T09:57:30.913' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (55, 2, CAST(N'2024-05-27T09:57:30.913' AS DateTime), CAST(N'2024-11-27T09:57:30.913' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (56, 2, CAST(N'2024-05-27T09:57:30.917' AS DateTime), CAST(N'2024-11-27T09:57:30.917' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (57, 2, CAST(N'2024-05-27T09:57:30.917' AS DateTime), CAST(N'2024-11-27T09:57:30.917' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (58, 2, CAST(N'2024-05-27T09:57:30.917' AS DateTime), CAST(N'2024-11-27T09:57:30.917' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (59, 2, CAST(N'2024-05-27T09:57:30.917' AS DateTime), CAST(N'2024-11-27T09:57:30.917' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (60, 2, CAST(N'2024-05-27T09:57:30.917' AS DateTime), CAST(N'2024-11-27T09:57:30.917' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (61, 3, CAST(N'2024-05-27T09:57:30.917' AS DateTime), CAST(N'2024-11-27T09:57:30.917' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (62, 3, CAST(N'2024-05-27T09:57:30.917' AS DateTime), CAST(N'2024-11-27T09:57:30.917' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (63, 3, CAST(N'2024-05-27T09:57:30.917' AS DateTime), CAST(N'2024-11-27T09:57:30.917' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (64, 3, CAST(N'2024-05-27T09:57:30.917' AS DateTime), CAST(N'2024-11-27T09:57:30.917' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (65, 3, CAST(N'2024-05-27T09:57:30.917' AS DateTime), CAST(N'2024-11-27T09:57:30.917' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (66, 3, CAST(N'2024-05-27T09:57:30.917' AS DateTime), CAST(N'2024-11-27T09:57:30.917' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (67, 3, CAST(N'2024-05-27T09:57:30.917' AS DateTime), CAST(N'2024-11-27T09:57:30.917' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (68, 3, CAST(N'2024-05-27T09:57:30.917' AS DateTime), CAST(N'2024-11-27T09:57:30.917' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (69, 3, CAST(N'2024-05-27T09:57:30.917' AS DateTime), CAST(N'2024-11-27T09:57:30.917' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (70, 3, CAST(N'2024-05-27T09:57:30.917' AS DateTime), CAST(N'2024-11-27T09:57:30.917' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (71, 3, CAST(N'2024-05-27T09:57:30.917' AS DateTime), CAST(N'2024-11-27T09:57:30.917' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (72, 3, CAST(N'2024-05-27T09:57:30.920' AS DateTime), CAST(N'2024-11-27T09:57:30.920' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (73, 3, CAST(N'2024-05-27T09:57:30.920' AS DateTime), CAST(N'2024-11-27T09:57:30.920' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (74, 3, CAST(N'2024-05-27T09:57:30.920' AS DateTime), CAST(N'2024-11-27T09:57:30.920' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (75, 3, CAST(N'2024-05-27T09:57:30.920' AS DateTime), CAST(N'2024-11-27T09:57:30.920' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (76, 3, CAST(N'2024-05-27T09:57:30.920' AS DateTime), CAST(N'2024-11-27T09:57:30.920' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (77, 3, CAST(N'2024-05-27T09:57:30.920' AS DateTime), CAST(N'2024-11-27T09:57:30.920' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (78, 3, CAST(N'2024-05-27T09:57:30.920' AS DateTime), CAST(N'2024-11-27T09:57:30.920' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (79, 3, CAST(N'2024-05-27T09:57:30.920' AS DateTime), CAST(N'2024-11-27T09:57:30.920' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (80, 3, CAST(N'2024-05-27T09:57:30.920' AS DateTime), CAST(N'2024-11-27T09:57:30.920' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (81, 3, CAST(N'2024-05-27T09:57:30.920' AS DateTime), CAST(N'2024-11-27T09:57:30.920' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (82, 3, CAST(N'2024-05-27T09:57:30.920' AS DateTime), CAST(N'2024-11-27T09:57:30.920' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (83, 3, CAST(N'2024-05-27T09:57:30.920' AS DateTime), CAST(N'2024-11-27T09:57:30.920' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (84, 3, CAST(N'2024-05-27T09:57:30.920' AS DateTime), CAST(N'2024-11-27T09:57:30.920' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (85, 3, CAST(N'2024-05-27T09:57:30.920' AS DateTime), CAST(N'2024-11-27T09:57:30.920' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (86, 3, CAST(N'2024-05-27T09:57:30.923' AS DateTime), CAST(N'2024-11-27T09:57:30.923' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (87, 3, CAST(N'2024-05-27T09:57:30.923' AS DateTime), CAST(N'2024-11-27T09:57:30.923' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (88, 3, CAST(N'2024-05-27T09:57:30.923' AS DateTime), CAST(N'2024-11-27T09:57:30.923' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (89, 3, CAST(N'2024-05-27T09:57:30.923' AS DateTime), CAST(N'2024-11-27T09:57:30.923' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (90, 3, CAST(N'2024-05-27T09:57:30.923' AS DateTime), CAST(N'2024-11-27T09:57:30.923' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (91, 4, CAST(N'2024-05-27T09:57:30.923' AS DateTime), CAST(N'2024-11-27T09:57:30.923' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (92, 4, CAST(N'2024-05-27T09:57:30.923' AS DateTime), CAST(N'2024-11-27T09:57:30.923' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (93, 4, CAST(N'2024-05-27T09:57:30.923' AS DateTime), CAST(N'2024-11-27T09:57:30.923' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (94, 4, CAST(N'2024-05-27T09:57:30.923' AS DateTime), CAST(N'2024-11-27T09:57:30.923' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (95, 4, CAST(N'2024-05-27T09:57:30.923' AS DateTime), CAST(N'2024-11-27T09:57:30.923' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (96, 4, CAST(N'2024-05-27T09:57:30.923' AS DateTime), CAST(N'2024-11-27T09:57:30.923' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (97, 4, CAST(N'2024-05-27T09:57:30.923' AS DateTime), CAST(N'2024-11-27T09:57:30.923' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (98, 4, CAST(N'2024-05-27T09:57:30.923' AS DateTime), CAST(N'2024-11-27T09:57:30.923' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (99, 4, CAST(N'2024-05-27T09:57:30.923' AS DateTime), CAST(N'2024-11-27T09:57:30.923' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (100, 4, CAST(N'2024-05-27T09:57:30.927' AS DateTime), CAST(N'2024-11-27T09:57:30.927' AS DateTime), N'Active')
GO
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (101, 4, CAST(N'2024-05-27T09:57:30.927' AS DateTime), CAST(N'2024-11-27T09:57:30.927' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (102, 4, CAST(N'2024-05-27T09:57:30.927' AS DateTime), CAST(N'2024-11-27T09:57:30.927' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (103, 4, CAST(N'2024-05-27T09:57:30.927' AS DateTime), CAST(N'2024-11-27T09:57:30.927' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (104, 4, CAST(N'2024-05-27T09:57:30.927' AS DateTime), CAST(N'2024-11-27T09:57:30.927' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (105, 4, CAST(N'2024-05-27T09:57:30.927' AS DateTime), CAST(N'2024-11-27T09:57:30.927' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (106, 4, CAST(N'2024-05-27T09:57:30.927' AS DateTime), CAST(N'2024-11-27T09:57:30.927' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (107, 4, CAST(N'2024-05-27T09:57:30.927' AS DateTime), CAST(N'2024-11-27T09:57:30.927' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (108, 4, CAST(N'2024-05-27T09:57:30.927' AS DateTime), CAST(N'2024-11-27T09:57:30.927' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (109, 4, CAST(N'2024-05-27T09:57:30.927' AS DateTime), CAST(N'2024-11-27T09:57:30.927' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (110, 4, CAST(N'2024-05-27T09:57:30.927' AS DateTime), CAST(N'2024-11-27T09:57:30.927' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (111, 4, CAST(N'2024-05-27T09:57:30.927' AS DateTime), CAST(N'2024-11-27T09:57:30.927' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (112, 4, CAST(N'2024-05-27T09:57:30.927' AS DateTime), CAST(N'2024-11-27T09:57:30.927' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (113, 4, CAST(N'2024-05-27T09:57:30.927' AS DateTime), CAST(N'2024-11-27T09:57:30.927' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (114, 4, CAST(N'2024-05-27T09:57:30.930' AS DateTime), CAST(N'2024-11-27T09:57:30.930' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (115, 4, CAST(N'2024-05-27T09:57:30.930' AS DateTime), CAST(N'2024-11-27T09:57:30.930' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (116, 4, CAST(N'2024-05-27T09:57:30.930' AS DateTime), CAST(N'2024-11-27T09:57:30.930' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (117, 4, CAST(N'2024-05-27T09:57:30.930' AS DateTime), CAST(N'2024-11-27T09:57:30.930' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (118, 4, CAST(N'2024-05-27T09:57:30.930' AS DateTime), CAST(N'2024-11-27T09:57:30.930' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (119, 4, CAST(N'2024-05-27T09:57:30.930' AS DateTime), CAST(N'2024-11-27T09:57:30.930' AS DateTime), N'Active')
INSERT [dbo].[StudentAssignment] ([StudentID], [ClassID], [StartDate], [EndDate], [Status]) VALUES (120, 4, CAST(N'2024-05-27T09:57:30.930' AS DateTime), CAST(N'2024-11-27T09:57:30.930' AS DateTime), N'Active')
GO
SET IDENTITY_INSERT [dbo].[Subject] ON 

INSERT [dbo].[Subject] ([SubjectID], [SubjectCode], [SubjectName], [Image]) VALUES (1, N'SJ012024', N'Toán', N'https://example.com/math101.jpg')
INSERT [dbo].[Subject] ([SubjectID], [SubjectCode], [SubjectName], [Image]) VALUES (2, N'SJ022024', N'Tiếng Anh', N'https://example.com/eng101.jpg')
INSERT [dbo].[Subject] ([SubjectID], [SubjectCode], [SubjectName], [Image]) VALUES (3, N'SJ032024', N'Vật lý', N'https://example.com/phy101.jpg')
INSERT [dbo].[Subject] ([SubjectID], [SubjectCode], [SubjectName], [Image]) VALUES (4, N'SJ042024', N'Hóa học', N'https://example.com/chem101.jpg')
INSERT [dbo].[Subject] ([SubjectID], [SubjectCode], [SubjectName], [Image]) VALUES (5, N'SJ052024', N'Sinh học', N'https://example.com/bio101.jpg')
INSERT [dbo].[Subject] ([SubjectID], [SubjectCode], [SubjectName], [Image]) VALUES (6, N'SJ062024', N'Lịch sử', N'https://example.com/hist101.jpg')
INSERT [dbo].[Subject] ([SubjectID], [SubjectCode], [SubjectName], [Image]) VALUES (7, N'SJ072024', N'Thể dục', N'https://example.com/geog101.jpg')
INSERT [dbo].[Subject] ([SubjectID], [SubjectCode], [SubjectName], [Image]) VALUES (8, N'SJ082024', N'Tin học', N'https://example.com/comp101.jpg')
INSERT [dbo].[Subject] ([SubjectID], [SubjectCode], [SubjectName], [Image]) VALUES (9, N'SJ092024', N'Văn học', N'https://example.com/mus101.jpg')
INSERT [dbo].[Subject] ([SubjectID], [SubjectCode], [SubjectName], [Image]) VALUES (10, N'SJ0102024', N'Địa lý', N'https://example.com/art101.jpg')
INSERT [dbo].[Subject] ([SubjectID], [SubjectCode], [SubjectName], [Image]) VALUES (11, N'SJ0112024', N'Kinh tế và pháp luật', N'https://example.com/art101.jpg')
INSERT [dbo].[Subject] ([SubjectID], [SubjectCode], [SubjectName], [Image]) VALUES (12, N'SJ0122024', N'Kỹ thuật công nghiệp', N'https://example.com/art101.jpg')
INSERT [dbo].[Subject] ([SubjectID], [SubjectCode], [SubjectName], [Image]) VALUES (13, N'SJ0132024', N'Quốc phòng an ninh', N'https://example.com/art101.jpg')
SET IDENTITY_INSERT [dbo].[Subject] OFF
GO
SET IDENTITY_INSERT [dbo].[Teacher] ON 

INSERT [dbo].[Teacher] ([TeacherID], [DepartmentID], [UserID], [SubjectID], [TeacherCode], [Degree], [Expertise], [University], [GraduationYear], [Major], [OtherCertifications], [Position], [Salary], [AdditionalBenifits], [CurrentHealthStatus], [HealthInsuranceInfo], [SelfIntroduction], [IsLeader]) VALUES (1, 2, 1, 1, N'TC0012024', N'Thạc sĩ', N'Toán học', N'Đại học Quốc gia Hà Nội', CAST(N'2010-01-01T00:00:00.000' AS DateTime), N'Toán học', NULL, N'Giáo viên', CAST(30000000 AS Decimal(18, 0)), N'Bảo hiểm y tế', N'Bình thường', N'Bảo hiểm BHYT số 123456789', N'Tôi là m?t giáo viên Toán có kinh nghi?m', 1)
INSERT [dbo].[Teacher] ([TeacherID], [DepartmentID], [UserID], [SubjectID], [TeacherCode], [Degree], [Expertise], [University], [GraduationYear], [Major], [OtherCertifications], [Position], [Salary], [AdditionalBenifits], [CurrentHealthStatus], [HealthInsuranceInfo], [SelfIntroduction], [IsLeader]) VALUES (2, 3, 2, 2, N'TC0022024', N'Thạc sĩ', N'Tiếng anh', N'Đại học Quốc gia Hà Nội', CAST(N'2010-01-01T00:00:00.000' AS DateTime), N'Ngôn ngữ anh', NULL, N'Giáo viên', CAST(30000000 AS Decimal(18, 0)), N'Bảo hiểm y tế', N'Bình thường', N'Bảo hiểm BHYT số 123456789', N'Tôi là m?t giáo viên Toán có kinh nghi?m', 1)
INSERT [dbo].[Teacher] ([TeacherID], [DepartmentID], [UserID], [SubjectID], [TeacherCode], [Degree], [Expertise], [University], [GraduationYear], [Major], [OtherCertifications], [Position], [Salary], [AdditionalBenifits], [CurrentHealthStatus], [HealthInsuranceInfo], [SelfIntroduction], [IsLeader]) VALUES (3, 5, 3, 3, N'TC0032024', N'Thạc sĩ', N'Vật lý', N'Đại học Quốc gia Hà Nội', CAST(N'2010-01-01T00:00:00.000' AS DateTime), N'Vật lý', NULL, N'Giáo viên', CAST(30000000 AS Decimal(18, 0)), N'Bảo hiểm y tế', N'Bình thường', N'Bảo hiểm BHYT số 123456789', N'Tôi là m?t giáo viên Toán có kinh nghi?m', 1)
INSERT [dbo].[Teacher] ([TeacherID], [DepartmentID], [UserID], [SubjectID], [TeacherCode], [Degree], [Expertise], [University], [GraduationYear], [Major], [OtherCertifications], [Position], [Salary], [AdditionalBenifits], [CurrentHealthStatus], [HealthInsuranceInfo], [SelfIntroduction], [IsLeader]) VALUES (4, 1, 4, 4, N'TC0042024', N'Thạc sĩ', N'Hóa học', N'Đại học Quốc gia Hà Nội', CAST(N'2010-01-01T00:00:00.000' AS DateTime), N'Hóa học', NULL, N'Giáo viên', CAST(30000000 AS Decimal(18, 0)), N'Bảo hiểm y tế', N'Bình thường', N'Bảo hiểm BHYT số 123456789', N'Tôi là m?t giáo viên Toán có kinh nghi?m', 1)
INSERT [dbo].[Teacher] ([TeacherID], [DepartmentID], [UserID], [SubjectID], [TeacherCode], [Degree], [Expertise], [University], [GraduationYear], [Major], [OtherCertifications], [Position], [Salary], [AdditionalBenifits], [CurrentHealthStatus], [HealthInsuranceInfo], [SelfIntroduction], [IsLeader]) VALUES (5, 1, 5, 5, N'TC0052024', N'Thạc sĩ', N'Sinh học', N'Đại học Quốc gia Hà Nội', CAST(N'2010-01-01T00:00:00.000' AS DateTime), N'Sinh học', NULL, N'Giáo viên', CAST(30000000 AS Decimal(18, 0)), N'Bảo hiểm y tế', N'Bình thường', N'Bảo hiểm BHYT số 123456789', N'Tôi là m?t giáo viên Toán có kinh nghi?m', 1)
INSERT [dbo].[Teacher] ([TeacherID], [DepartmentID], [UserID], [SubjectID], [TeacherCode], [Degree], [Expertise], [University], [GraduationYear], [Major], [OtherCertifications], [Position], [Salary], [AdditionalBenifits], [CurrentHealthStatus], [HealthInsuranceInfo], [SelfIntroduction], [IsLeader]) VALUES (6, 4, 6, 6, N'TC0062024', N'Thạc sĩ', N'Lịch sử', N'Đại học Quốc gia Hà Nội', CAST(N'2010-01-01T00:00:00.000' AS DateTime), N'Lịch sử', NULL, N'Giáo viên', CAST(30000000 AS Decimal(18, 0)), N'Bảo hiểm y tế', N'Bình thường', N'Bảo hiểm BHYT số 123456789', N'Tôi là m?t giáo viên Toán có kinh nghi?m', 1)
INSERT [dbo].[Teacher] ([TeacherID], [DepartmentID], [UserID], [SubjectID], [TeacherCode], [Degree], [Expertise], [University], [GraduationYear], [Major], [OtherCertifications], [Position], [Salary], [AdditionalBenifits], [CurrentHealthStatus], [HealthInsuranceInfo], [SelfIntroduction], [IsLeader]) VALUES (7, 6, 7, 7, N'TC0072024', N'Thạc sĩ', N'Thể dục', N'Đại học Quốc gia Hà Nội', CAST(N'2010-01-01T00:00:00.000' AS DateTime), N'Thể dục', NULL, N'Giáo viên', CAST(30000000 AS Decimal(18, 0)), N'Bảo hiểm y tế', N'Bình thường', N'Bảo hiểm BHYT số 123456789', N'Tôi là m?t giáo viên Toán có kinh nghi?m', 1)
INSERT [dbo].[Teacher] ([TeacherID], [DepartmentID], [UserID], [SubjectID], [TeacherCode], [Degree], [Expertise], [University], [GraduationYear], [Major], [OtherCertifications], [Position], [Salary], [AdditionalBenifits], [CurrentHealthStatus], [HealthInsuranceInfo], [SelfIntroduction], [IsLeader]) VALUES (8, 3, 8, 8, N'TC0082024', N'Thạc sĩ', N'Tin học', N'Đại học Quốc gia Hà Nội', CAST(N'2010-01-01T00:00:00.000' AS DateTime), N'Tin học', NULL, N'Giáo viên', CAST(30000000 AS Decimal(18, 0)), N'Bảo hiểm y tế', N'Bình thường', N'Bảo hiểm BHYT số 123456789', N'Tôi là m?t giáo viên Toán có kinh nghi?m', 1)
INSERT [dbo].[Teacher] ([TeacherID], [DepartmentID], [UserID], [SubjectID], [TeacherCode], [Degree], [Expertise], [University], [GraduationYear], [Major], [OtherCertifications], [Position], [Salary], [AdditionalBenifits], [CurrentHealthStatus], [HealthInsuranceInfo], [SelfIntroduction], [IsLeader]) VALUES (9, 2, 9, 9, N'TC0092024', N'Thạc sĩ', N'Văn học', N'Đại học Quốc gia Hà Nội', CAST(N'2010-01-01T00:00:00.000' AS DateTime), N'Văn học', NULL, N'Giáo viên', CAST(30000000 AS Decimal(18, 0)), N'Bảo hiểm y tế', N'Bình thường', N'Bảo hiểm BHYT số 123456789', N'Tôi là m?t giáo viên Toán có kinh nghi?m', 1)
INSERT [dbo].[Teacher] ([TeacherID], [DepartmentID], [UserID], [SubjectID], [TeacherCode], [Degree], [Expertise], [University], [GraduationYear], [Major], [OtherCertifications], [Position], [Salary], [AdditionalBenifits], [CurrentHealthStatus], [HealthInsuranceInfo], [SelfIntroduction], [IsLeader]) VALUES (10, 4, 10, 10, N'TC0102024', N'Thạc sĩ', N'Địa lý', N'Đại học Quốc gia Hà Nội', CAST(N'2010-01-01T00:00:00.000' AS DateTime), N'Địa lý', NULL, N'Giáo viên', CAST(30000000 AS Decimal(18, 0)), N'Bảo hiểm y tế', N'Bình thường', N'Bảo hiểm BHYT số 123456789', N'Tôi là m?t giáo viên Toán có kinh nghi?m', 1)
INSERT [dbo].[Teacher] ([TeacherID], [DepartmentID], [UserID], [SubjectID], [TeacherCode], [Degree], [Expertise], [University], [GraduationYear], [Major], [OtherCertifications], [Position], [Salary], [AdditionalBenifits], [CurrentHealthStatus], [HealthInsuranceInfo], [SelfIntroduction], [IsLeader]) VALUES (11, 4, 11, 11, N'TC0112024', N'Thạc sĩ', N'Kinh tế và pháp luật', N'Đại học Quốc gia Hà Nội', CAST(N'2010-01-01T00:00:00.000' AS DateTime), N'Kinh tế và pháp luật', NULL, N'Giáo viên', CAST(30000000 AS Decimal(18, 0)), N'Bảo hiểm y tế', N'Bình thường', N'Bảo hiểm BHYT số 123456789', N'Tôi là m?t giáo viên Toán có kinh nghi?m', 1)
INSERT [dbo].[Teacher] ([TeacherID], [DepartmentID], [UserID], [SubjectID], [TeacherCode], [Degree], [Expertise], [University], [GraduationYear], [Major], [OtherCertifications], [Position], [Salary], [AdditionalBenifits], [CurrentHealthStatus], [HealthInsuranceInfo], [SelfIntroduction], [IsLeader]) VALUES (12, 5, 12, 12, N'TC0122024', N'Thạc sĩ', N'Kỹ thuật công nghiệp', N'Đại học Quốc gia Hà Nội', CAST(N'2010-01-01T00:00:00.000' AS DateTime), N'Kỹ thuật công nghiệp', NULL, N'Giáo viên', CAST(30000000 AS Decimal(18, 0)), N'Bảo hiểm y tế', N'Bình thường', N'Bảo hiểm BHYT số 123456789', N'Tôi là m?t giáo viên Toán có kinh nghi?m', 1)
INSERT [dbo].[Teacher] ([TeacherID], [DepartmentID], [UserID], [SubjectID], [TeacherCode], [Degree], [Expertise], [University], [GraduationYear], [Major], [OtherCertifications], [Position], [Salary], [AdditionalBenifits], [CurrentHealthStatus], [HealthInsuranceInfo], [SelfIntroduction], [IsLeader]) VALUES (13, 6, 13, 13, N'TC0132024', N'Thạc sĩ', N'Quốc phòng an ninh', N'Đại học Quốc gia Hà Nội', CAST(N'2010-01-01T00:00:00.000' AS DateTime), N'Quốc phòng an ninh', NULL, N'Giáo viên', CAST(30000000 AS Decimal(18, 0)), N'Bảo hiểm y tế', N'Bình thường', N'Bảo hiểm BHYT số 123456789', N'Tôi là m?t giáo viên Toán có kinh nghi?m', 1)
INSERT [dbo].[Teacher] ([TeacherID], [DepartmentID], [UserID], [SubjectID], [TeacherCode], [Degree], [Expertise], [University], [GraduationYear], [Major], [OtherCertifications], [Position], [Salary], [AdditionalBenifits], [CurrentHealthStatus], [HealthInsuranceInfo], [SelfIntroduction], [IsLeader]) VALUES (14, 2, 151, 1, N'GV202414', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Teacher] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (1, N'Phan', N'Thanh Nhàn', N'Male', CAST(N'1990-05-27T10:26:46.000' AS DateTime), N'0393849859', N'Địa chỉ 1', N'user1@example.com', NULL, N'thanhnhan', N'thanhnhan', N'teacher', 1, CAST(N'2024-05-27T10:26:46.587' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (2, N'Phạm', N'Ngọc Doanh', N'Male', CAST(N'1984-05-27T10:26:46.000' AS DateTime), N'0393849859', N'Địa chỉ 2', N'user2@example.com', NULL, N'username2', N'password', N'teacher', 1, CAST(N'2024-05-27T10:26:46.587' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (3, N'Trần', N'Thị Bình', N'Male', CAST(N'1990-05-27T10:26:46.000' AS DateTime), N'0393849859', N'Địa chỉ 3', N'user3@example.com', NULL, N'username3', N'password', N'teacher', 1, CAST(N'2024-05-27T10:26:46.590' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (4, N'Bùi', N'Khánh Ngân', N'Male', CAST(N'1994-05-27T10:26:46.000' AS DateTime), N'0393849859', N'Địa chỉ 4', N'user4@example.com', NULL, N'username4', N'password', N'teacher', 1, CAST(N'2024-05-27T10:26:46.590' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (5, N'Phạm', N'Ngọc Doanh', N'Female', CAST(N'1985-05-27T10:26:46.000' AS DateTime), N'0393849859', N'Địa chỉ 5', N'user5@example.com', NULL, N'username5', N'password', N'teacher', 1, CAST(N'2024-05-27T10:26:46.590' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (6, N'Phan', N'Thanh Nhàn', N'Male', CAST(N'1990-05-27T10:26:46.000' AS DateTime), N'0393849859', N'Địa chỉ 6', N'user6@example.com', NULL, N'username6', N'password', N'teacher', 1, CAST(N'2024-05-27T10:26:46.590' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (7, N'Bùi', N'Khánh Ngân', N'Female', CAST(N'1985-05-27T10:26:46.000' AS DateTime), N'0393849859', N'Địa chỉ 7', N'user7@example.com', NULL, N'username7', N'password', N'teacher', 1, CAST(N'2024-05-27T10:26:46.590' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (8, N'Đỗ', N'Thảo Mai', N'Male', CAST(N'1986-05-27T10:26:46.000' AS DateTime), N'0393849859', N'Địa chỉ 8', N'user8@example.com', NULL, N'username8', N'password', N'teacher', 1, CAST(N'2024-05-27T10:26:46.590' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (9, N'Ngô', N'Anh Khánh', N'Female', CAST(N'1991-05-27T10:26:46.000' AS DateTime), N'0393849859', N'Địa chỉ 9', N'user9@example.com', NULL, N'username9', N'password', N'teacher', 1, CAST(N'2024-05-27T10:26:46.590' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (10, N'Phan', N'Thanh Nhàn', N'Male', CAST(N'1994-05-27T10:26:46.000' AS DateTime), N'0393849859', N'Địa chỉ 10', N'user10@example.com', NULL, N'username10', N'password', N'teacher', 1, CAST(N'2024-05-27T10:26:46.590' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (11, N'Vũ', N'Hoài Giang', N'Female', CAST(N'1984-05-27T10:26:46.000' AS DateTime), N'0393849859', N'Địa chỉ 11', N'user11@example.com', NULL, N'username11', N'password', N'teacher', 1, CAST(N'2024-05-27T10:26:46.593' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (12, N'Ngô', N'Anh Khánh', N'Male', CAST(N'1985-05-27T10:26:46.000' AS DateTime), N'0393849859', N'Địa chỉ 12', N'user12@example.com', NULL, N'username12', N'password', N'teacher', 1, CAST(N'2024-05-27T10:26:46.593' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (13, N'Hồ', N'Việt Long', N'Female', CAST(N'1994-05-27T10:26:46.000' AS DateTime), N'0393849859', N'Địa chỉ 13', N'user13@example.com', NULL, N'username13', N'password', N'teacher', 1, CAST(N'2024-05-27T10:26:46.593' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (14, N'Phan', N'Thanh Nhàn', N'Female', CAST(N'2008-05-27T10:26:46.000' AS DateTime), N'0393849859', N'Địa chỉ 14', N'user14@example.com', NULL, N'student', N'student', N'student', 1, CAST(N'2024-05-27T10:26:46.593' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (15, N'Ngô', N'Anh Khánh', N'Male', CAST(N'2008-05-27T10:26:46.000' AS DateTime), N'0393849859', N'Địa chỉ 15', N'user15@example.com', NULL, N'username15', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.593' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (16, N'Vũ', N'Hoài Giang', N'Female', CAST(N'2006-05-27T10:26:46.000' AS DateTime), N'0393849859', N'Địa chỉ 16', N'user16@example.com', NULL, N'username16', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.593' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (17, N'Vũ', N'Hoài Giang', N'Female', CAST(N'2006-05-27T10:26:46.000' AS DateTime), N'0393849859', N'Địa chỉ 17', N'user17@example.com', NULL, N'username17', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.593' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (18, N'Phạm', N'Ngọc Doanh', N'Female', CAST(N'2008-05-27T10:26:46.000' AS DateTime), N'0393849859', N'Địa chỉ 18', N'user18@example.com', NULL, N'username18', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.597' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (19, N'Vũ', N'Hoài Giang', N'Female', CAST(N'2007-05-27T10:26:46.000' AS DateTime), N'0393849859', N'Địa chỉ 19', N'user19@example.com', NULL, N'username19', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.597' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (20, N'Nguyễn', N'Văn Anh', N'Female', CAST(N'2006-05-27T10:26:46.597' AS DateTime), N'0393849859', N'Địa chỉ 20', N'user20@example.com', NULL, N'username20', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.597' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (21, N'Lý', N'Thùy Ninh', N'Female', CAST(N'2007-05-27T10:26:46.597' AS DateTime), N'0393849859', N'Địa chỉ 21', N'user21@example.com', NULL, N'username21', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.597' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (22, N'Đỗ', N'Thảo Mai', N'Female', CAST(N'2006-05-27T10:26:46.597' AS DateTime), N'0393849859', N'Địa chỉ 22', N'user22@example.com', NULL, N'username22', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.597' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (23, N'Trần', N'Thị Bình', N'Male', CAST(N'2008-05-27T10:26:46.597' AS DateTime), N'0393849859', N'Địa chỉ 23', N'user23@example.com', NULL, N'username23', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.597' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (24, N'Dương', N'Quốc Minh', N'Male', CAST(N'2008-05-27T10:26:46.597' AS DateTime), N'0393849859', N'Địa chỉ 24', N'user24@example.com', NULL, N'username24', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.597' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (25, N'Nguyễn', N'Văn Anh', N'Female', CAST(N'2007-05-27T10:26:46.600' AS DateTime), N'0393849859', N'Địa chỉ 25', N'user25@example.com', NULL, N'username25', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.600' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (26, N'Lý', N'Thùy Ninh', N'Male', CAST(N'2008-05-27T10:26:46.600' AS DateTime), N'0393849859', N'Địa chỉ 26', N'user26@example.com', NULL, N'username26', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.600' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (27, N'Hoàng', N'Huy Tuấn', N'Male', CAST(N'2006-05-27T10:26:46.600' AS DateTime), N'0393849859', N'Địa chỉ 27', N'user27@example.com', NULL, N'username27', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.600' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (28, N'Dương', N'Quốc Minh', N'Female', CAST(N'2006-05-27T10:26:46.600' AS DateTime), N'0393849859', N'Địa chỉ 28', N'user28@example.com', NULL, N'username28', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.600' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (29, N'Đỗ', N'Thảo Mai', N'Female', CAST(N'2006-05-27T10:26:46.600' AS DateTime), N'0393849859', N'Địa chỉ 29', N'user29@example.com', NULL, N'username29', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.600' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (30, N'Dương', N'Quốc Minh', N'Female', CAST(N'2008-05-27T10:26:46.600' AS DateTime), N'0393849859', N'Địa chỉ 30', N'user30@example.com', NULL, N'username30', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.600' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (31, N'Phan', N'Thanh Nhàn', N'Female', CAST(N'2006-05-27T10:26:46.600' AS DateTime), N'0393849859', N'Địa chỉ 31', N'user31@example.com', NULL, N'username31', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.600' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (32, N'Vũ', N'Hoài Giang', N'Female', CAST(N'2006-05-27T10:26:46.600' AS DateTime), N'0393849859', N'Địa chỉ 32', N'user32@example.com', NULL, N'username32', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.600' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (33, N'Hoàng', N'Huy Tuấn', N'Female', CAST(N'2007-05-27T10:26:46.600' AS DateTime), N'0393849859', N'Địa chỉ 33', N'user33@example.com', NULL, N'username33', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.600' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (34, N'Hồ', N'Việt Long', N'Female', CAST(N'2007-05-27T10:26:46.600' AS DateTime), N'0393849859', N'Địa chỉ 34', N'user34@example.com', NULL, N'username34', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.600' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (35, N'Trần', N'Thị Bình', N'Female', CAST(N'2007-05-27T10:26:46.603' AS DateTime), N'0393849859', N'Địa chỉ 35', N'user35@example.com', NULL, N'username35', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.603' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (36, N'Trần', N'Thị Bình', N'Female', CAST(N'2008-05-27T10:26:46.603' AS DateTime), N'0393849859', N'Địa chỉ 36', N'user36@example.com', NULL, N'username36', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.603' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (37, N'Vũ', N'Hoài Giang', N'Female', CAST(N'2008-05-27T10:26:46.603' AS DateTime), N'0393849859', N'Địa chỉ 37', N'user37@example.com', NULL, N'username37', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.603' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (38, N'Lý', N'Thùy Ninh', N'Male', CAST(N'2008-05-27T10:26:46.603' AS DateTime), N'0393849859', N'Địa chỉ 38', N'user38@example.com', NULL, N'username38', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.603' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (39, N'Đỗ', N'Thảo Mai', N'Female', CAST(N'2007-05-27T10:26:46.603' AS DateTime), N'0393849859', N'Địa chỉ 39', N'user39@example.com', NULL, N'username39', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.603' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (40, N'Hồ', N'Việt Long', N'Male', CAST(N'2008-05-27T10:26:46.603' AS DateTime), N'0393849859', N'Địa chỉ 40', N'user40@example.com', NULL, N'username40', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.603' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (41, N'Lê', N'Minh Chính', N'Female', CAST(N'2007-05-27T10:26:46.603' AS DateTime), N'0393849859', N'Địa chỉ 41', N'user41@example.com', NULL, N'username41', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.607' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (42, N'Hoàng', N'Huy Tuấn', N'Male', CAST(N'2006-05-27T10:26:46.607' AS DateTime), N'0393849859', N'Địa chỉ 42', N'user42@example.com', NULL, N'username42', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.607' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (43, N'Hồ', N'Việt Long', N'Male', CAST(N'2008-05-27T10:26:46.607' AS DateTime), N'0393849859', N'Địa chỉ 43', N'user43@example.com', NULL, N'username43', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.607' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (44, N'Phạm', N'Ngọc Doanh', N'Female', CAST(N'2008-05-27T10:26:46.607' AS DateTime), N'0393849859', N'Địa chỉ 44', N'user44@example.com', NULL, N'username44', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.607' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (45, N'Phạm', N'Ngọc Doanh', N'Male', CAST(N'2006-05-27T10:26:46.607' AS DateTime), N'0393849859', N'Địa chỉ 45', N'user45@example.com', NULL, N'username45', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.607' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (46, N'Bùi', N'Khánh Ngân', N'Female', CAST(N'2007-05-27T10:26:46.607' AS DateTime), N'0393849859', N'Địa chỉ 46', N'user46@example.com', NULL, N'username46', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.607' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (47, N'Dương', N'Quốc Minh', N'Female', CAST(N'2007-05-27T10:26:46.607' AS DateTime), N'0393849859', N'Địa chỉ 47', N'user47@example.com', NULL, N'username47', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.607' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (48, N'Ngô', N'Anh Khánh', N'Male', CAST(N'2006-05-27T10:26:46.610' AS DateTime), N'0393849859', N'Địa chỉ 48', N'user48@example.com', NULL, N'username48', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.610' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (49, N'Lý', N'Thùy Ninh', N'Male', CAST(N'2008-05-27T10:26:46.610' AS DateTime), N'0393849859', N'Địa chỉ 49', N'user49@example.com', NULL, N'username49', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.610' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (50, N'Hoàng', N'Huy Tuấn', N'Male', CAST(N'2008-05-27T10:26:46.610' AS DateTime), N'0393849859', N'Địa chỉ 50', N'user50@example.com', NULL, N'username50', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.610' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (51, N'Ngô', N'Anh Khánh', N'Male', CAST(N'2006-05-27T10:26:46.610' AS DateTime), N'0393849859', N'Địa chỉ 51', N'user51@example.com', NULL, N'username51', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.610' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (52, N'Ngô', N'Anh Khánh', N'Female', CAST(N'2007-05-27T10:26:46.610' AS DateTime), N'0393849859', N'Địa chỉ 52', N'user52@example.com', NULL, N'username52', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.610' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (53, N'Hồ', N'Việt Long', N'Female', CAST(N'2006-05-27T10:26:46.610' AS DateTime), N'0393849859', N'Địa chỉ 53', N'user53@example.com', NULL, N'username53', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.610' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (54, N'Hồ', N'Việt Long', N'Female', CAST(N'2008-05-27T10:26:46.610' AS DateTime), N'0393849859', N'Địa chỉ 54', N'user54@example.com', NULL, N'username54', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.610' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (55, N'Lê', N'Minh Chính', N'Male', CAST(N'2006-05-27T10:26:46.610' AS DateTime), N'0393849859', N'Địa chỉ 55', N'user55@example.com', NULL, N'username55', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.610' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (56, N'Hoàng', N'Huy Tuấn', N'Female', CAST(N'2008-05-27T10:26:46.610' AS DateTime), N'0393849859', N'Địa chỉ 56', N'user56@example.com', NULL, N'username56', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.610' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (57, N'Trần', N'Thị Bình', N'Male', CAST(N'2006-05-27T10:26:46.610' AS DateTime), N'0393849859', N'Địa chỉ 57', N'user57@example.com', NULL, N'username57', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.610' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (58, N'Dương', N'Quốc Minh', N'Male', CAST(N'2008-05-27T10:26:46.613' AS DateTime), N'0393849859', N'Địa chỉ 58', N'user58@example.com', NULL, N'username58', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.613' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (59, N'Bùi', N'Khánh Ngân', N'Male', CAST(N'2007-05-27T10:26:46.613' AS DateTime), N'0393849859', N'Địa chỉ 59', N'user59@example.com', NULL, N'username59', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.613' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (60, N'Hoàng', N'Huy Tuấn', N'Female', CAST(N'2008-05-27T10:26:46.613' AS DateTime), N'0393849859', N'Địa chỉ 60', N'user60@example.com', NULL, N'username60', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.613' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (61, N'Nguyễn', N'Văn Anh', N'Female', CAST(N'2007-05-27T10:26:46.613' AS DateTime), N'0393849859', N'Địa chỉ 61', N'user61@example.com', NULL, N'username61', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.613' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (62, N'Vũ', N'Hoài Giang', N'Female', CAST(N'2007-05-27T10:26:46.613' AS DateTime), N'0393849859', N'Địa chỉ 62', N'user62@example.com', NULL, N'username62', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.613' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (63, N'Lê', N'Minh Chính', N'Female', CAST(N'2007-05-27T10:26:46.613' AS DateTime), N'0393849859', N'Địa chỉ 63', N'user63@example.com', NULL, N'username63', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.613' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (64, N'Dương', N'Quốc Minh', N'Female', CAST(N'2007-05-27T10:26:46.613' AS DateTime), N'0393849859', N'Địa chỉ 64', N'user64@example.com', NULL, N'username64', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.613' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (65, N'Nguyễn', N'Văn Anh', N'Female', CAST(N'2006-05-27T10:26:46.617' AS DateTime), N'0393849859', N'Địa chỉ 65', N'user65@example.com', NULL, N'username65', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.617' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (66, N'Lý', N'Thùy Ninh', N'Female', CAST(N'2008-05-27T10:26:46.617' AS DateTime), N'0393849859', N'Địa chỉ 66', N'user66@example.com', NULL, N'username66', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.617' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (67, N'Đặng', N'Bảo Huy', N'Female', CAST(N'2008-05-27T10:26:46.617' AS DateTime), N'0393849859', N'Địa chỉ 67', N'user67@example.com', NULL, N'username67', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.617' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (68, N'Lý', N'Thùy Ninh', N'Male', CAST(N'2006-05-27T10:26:46.617' AS DateTime), N'0393849859', N'Địa chỉ 68', N'user68@example.com', NULL, N'username68', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.617' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (69, N'Dương', N'Quốc Minh', N'Male', CAST(N'2007-05-27T10:26:46.617' AS DateTime), N'0393849859', N'Địa chỉ 69', N'user69@example.com', NULL, N'username69', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.617' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (70, N'Nguyễn', N'Văn Anh', N'Female', CAST(N'2008-05-27T10:26:46.617' AS DateTime), N'0393849859', N'Địa chỉ 70', N'user70@example.com', NULL, N'username70', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.617' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (71, N'Bùi', N'Khánh Ngân', N'Male', CAST(N'2006-05-27T10:26:46.617' AS DateTime), N'0393849859', N'Địa chỉ 71', N'user71@example.com', NULL, N'username71', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.617' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (72, N'Phan', N'Thanh Nhàn', N'Female', CAST(N'2006-05-27T10:26:46.620' AS DateTime), N'0393849859', N'Địa chỉ 72', N'user72@example.com', NULL, N'username72', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.620' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (73, N'Lý', N'Thùy Ninh', N'Female', CAST(N'2008-05-27T10:26:46.620' AS DateTime), N'0393849859', N'Địa chỉ 73', N'user73@example.com', NULL, N'username73', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.620' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (74, N'Đỗ', N'Thảo Mai', N'Male', CAST(N'2006-05-27T10:26:46.620' AS DateTime), N'0393849859', N'Địa chỉ 74', N'user74@example.com', NULL, N'username74', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.620' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (75, N'Phan', N'Thanh Nhàn', N'Female', CAST(N'2007-05-27T10:26:46.620' AS DateTime), N'0393849859', N'Địa chỉ 75', N'user75@example.com', NULL, N'username75', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.620' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (76, N'Ngô', N'Anh Khánh', N'Male', CAST(N'2008-05-27T10:26:46.620' AS DateTime), N'0393849859', N'Địa chỉ 76', N'user76@example.com', NULL, N'username76', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.620' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (77, N'Bùi', N'Khánh Ngân', N'Male', CAST(N'2006-05-27T10:26:46.620' AS DateTime), N'0393849859', N'Địa chỉ 77', N'user77@example.com', NULL, N'username77', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.620' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (78, N'Bùi', N'Khánh Ngân', N'Male', CAST(N'2007-05-27T10:26:46.620' AS DateTime), N'0393849859', N'Địa chỉ 78', N'user78@example.com', NULL, N'username78', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.620' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (79, N'Nguyễn', N'Văn Anh', N'Female', CAST(N'2008-05-27T10:26:46.620' AS DateTime), N'0393849859', N'Địa chỉ 79', N'user79@example.com', NULL, N'username79', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.620' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (80, N'Hồ', N'Việt Long', N'Male', CAST(N'2008-05-27T10:26:46.620' AS DateTime), N'0393849859', N'Địa chỉ 80', N'user80@example.com', NULL, N'username80', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.620' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (81, N'Phạm', N'Ngọc Doanh', N'Female', CAST(N'2006-05-27T10:26:46.620' AS DateTime), N'0393849859', N'Địa chỉ 81', N'user81@example.com', NULL, N'username81', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.620' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (82, N'Ngô', N'Anh Khánh', N'Female', CAST(N'2006-05-27T10:26:46.623' AS DateTime), N'0393849859', N'Địa chỉ 82', N'user82@example.com', NULL, N'username82', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.623' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (83, N'Phan', N'Thanh Nhàn', N'Male', CAST(N'2008-05-27T10:26:46.623' AS DateTime), N'0393849859', N'Địa chỉ 83', N'user83@example.com', NULL, N'username83', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.623' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (84, N'Phan', N'Thanh Nhàn', N'Female', CAST(N'2008-05-27T10:26:46.623' AS DateTime), N'0393849859', N'Địa chỉ 84', N'user84@example.com', NULL, N'username84', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.623' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (85, N'Đặng', N'Bảo Huy', N'Female', CAST(N'2008-05-27T10:26:46.623' AS DateTime), N'0393849859', N'Địa chỉ 85', N'user85@example.com', NULL, N'username85', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.623' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (86, N'Phạm', N'Ngọc Doanh', N'Female', CAST(N'2006-05-27T10:26:46.623' AS DateTime), N'0393849859', N'Địa chỉ 86', N'user86@example.com', NULL, N'username86', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.623' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (87, N'Bùi', N'Khánh Ngân', N'Female', CAST(N'2008-05-27T10:26:46.623' AS DateTime), N'0393849859', N'Địa chỉ 87', N'user87@example.com', NULL, N'username87', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.623' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (88, N'Phan', N'Thanh Nhàn', N'Male', CAST(N'2007-05-27T10:26:46.623' AS DateTime), N'0393849859', N'Địa chỉ 88', N'user88@example.com', NULL, N'username88', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.623' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (89, N'Hồ', N'Việt Long', N'Female', CAST(N'2008-05-27T10:26:46.623' AS DateTime), N'0393849859', N'Địa chỉ 89', N'user89@example.com', NULL, N'username89', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.623' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (90, N'Phan', N'Thanh Nhàn', N'Male', CAST(N'2006-05-27T10:26:46.623' AS DateTime), N'0393849859', N'Địa chỉ 90', N'user90@example.com', NULL, N'username90', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.623' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (91, N'Lê', N'Minh Chính', N'Female', CAST(N'2008-05-27T10:26:46.627' AS DateTime), N'0393849859', N'Địa chỉ 91', N'user91@example.com', NULL, N'username91', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.627' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (92, N'Đặng', N'Bảo Huy', N'Male', CAST(N'2007-05-27T10:26:46.627' AS DateTime), N'0393849859', N'Địa chỉ 92', N'user92@example.com', NULL, N'username92', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.627' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (93, N'Vũ', N'Hoài Giang', N'Male', CAST(N'2007-05-27T10:26:46.627' AS DateTime), N'0393849859', N'Địa chỉ 93', N'user93@example.com', NULL, N'username93', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.627' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (94, N'Lê', N'Minh Chính', N'Female', CAST(N'2007-05-27T10:26:46.627' AS DateTime), N'0393849859', N'Địa chỉ 94', N'user94@example.com', NULL, N'username94', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.627' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (95, N'Vũ', N'Hoài Giang', N'Female', CAST(N'2007-05-27T10:26:46.627' AS DateTime), N'0393849859', N'Địa chỉ 95', N'user95@example.com', NULL, N'username95', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.627' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (96, N'Bùi', N'Khánh Ngân', N'Female', CAST(N'2007-05-27T10:26:46.627' AS DateTime), N'0393849859', N'Địa chỉ 96', N'user96@example.com', NULL, N'username96', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.627' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (97, N'Đặng', N'Bảo Huy', N'Male', CAST(N'2007-05-27T10:26:46.627' AS DateTime), N'0393849859', N'Địa chỉ 97', N'user97@example.com', NULL, N'username97', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.627' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (98, N'Vũ', N'Hoài Giang', N'Male', CAST(N'2008-05-27T10:26:46.627' AS DateTime), N'0393849859', N'Địa chỉ 98', N'user98@example.com', NULL, N'username98', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.627' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (99, N'Nguyễn', N'Văn Anh', N'Male', CAST(N'2006-05-27T10:26:46.627' AS DateTime), N'0393849859', N'Địa chỉ 99', N'user99@example.com', NULL, N'username99', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.627' AS DateTime), NULL, 0)
GO
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (100, N'Đặng', N'Bảo Huy', N'Female', CAST(N'2006-05-27T10:26:46.630' AS DateTime), N'0393849859', N'Địa chỉ 100', N'user100@example.com', NULL, N'username100', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.630' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (101, N'Phạm', N'Ngọc Doanh', N'Female', CAST(N'2008-05-27T10:26:46.630' AS DateTime), N'0393849859', N'Địa chỉ 101', N'user101@example.com', NULL, N'username101', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.630' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (102, N'Nguyễn', N'Văn Anh', N'Male', CAST(N'2007-05-27T10:26:46.630' AS DateTime), N'0393849859', N'Địa chỉ 102', N'user102@example.com', NULL, N'username102', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.630' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (103, N'Phạm', N'Ngọc Doanh', N'Male', CAST(N'2007-05-27T10:26:46.630' AS DateTime), N'0393849859', N'Địa chỉ 103', N'user103@example.com', NULL, N'username103', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.630' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (104, N'Trần', N'Thị Bình', N'Female', CAST(N'2008-05-27T10:26:46.630' AS DateTime), N'0393849859', N'Địa chỉ 104', N'user104@example.com', NULL, N'username104', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.630' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (105, N'Đỗ', N'Thảo Mai', N'Female', CAST(N'2007-05-27T10:26:46.630' AS DateTime), N'0393849859', N'Địa chỉ 105', N'user105@example.com', NULL, N'username105', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.630' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (106, N'Ngô', N'Anh Khánh', N'Male', CAST(N'2007-05-27T10:26:46.630' AS DateTime), N'0393849859', N'Địa chỉ 106', N'user106@example.com', NULL, N'username106', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.630' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (107, N'Lê', N'Minh Chính', N'Female', CAST(N'2007-05-27T10:26:46.630' AS DateTime), N'0393849859', N'Địa chỉ 107', N'user107@example.com', NULL, N'username107', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.630' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (108, N'Đỗ', N'Thảo Mai', N'Female', CAST(N'2006-05-27T10:26:46.630' AS DateTime), N'0393849859', N'Địa chỉ 108', N'user108@example.com', NULL, N'username108', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.630' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (109, N'Dương', N'Quốc Minh', N'Male', CAST(N'2007-05-27T10:26:46.630' AS DateTime), N'0393849859', N'Địa chỉ 109', N'user109@example.com', NULL, N'username109', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.630' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (110, N'Phan', N'Thanh Nhàn', N'Male', CAST(N'2008-05-27T10:26:46.630' AS DateTime), N'0393849859', N'Địa chỉ 110', N'user110@example.com', NULL, N'username110', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.630' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (111, N'Phạm', N'Ngọc Doanh', N'Female', CAST(N'2008-05-27T10:26:46.630' AS DateTime), N'0393849859', N'Địa chỉ 111', N'user111@example.com', NULL, N'username111', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.630' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (112, N'Phan', N'Thanh Nhàn', N'Female', CAST(N'2008-05-27T10:26:46.633' AS DateTime), N'0393849859', N'Địa chỉ 112', N'user112@example.com', NULL, N'username112', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.633' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (113, N'Bùi', N'Khánh Ngân', N'Female', CAST(N'2008-05-27T10:26:46.633' AS DateTime), N'0393849859', N'Địa chỉ 113', N'user113@example.com', NULL, N'username113', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.633' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (114, N'Lý', N'Thùy Ninh', N'Female', CAST(N'2006-05-27T10:26:46.633' AS DateTime), N'0393849859', N'Địa chỉ 114', N'user114@example.com', NULL, N'username114', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.633' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (115, N'Dương', N'Quốc Minh', N'Female', CAST(N'2006-05-27T10:26:46.633' AS DateTime), N'0393849859', N'Địa chỉ 115', N'user115@example.com', NULL, N'username115', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.633' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (116, N'Bùi', N'Khánh Ngân', N'Male', CAST(N'2006-05-27T10:26:46.633' AS DateTime), N'0393849859', N'Địa chỉ 116', N'user116@example.com', NULL, N'username116', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.633' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (117, N'Đặng', N'Bảo Huy', N'Female', CAST(N'2007-05-27T10:26:46.633' AS DateTime), N'0393849859', N'Địa chỉ 117', N'user117@example.com', NULL, N'username117', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.633' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (118, N'Phan', N'Thanh Nhàn', N'Male', CAST(N'2006-05-27T10:26:46.633' AS DateTime), N'0393849859', N'Địa chỉ 118', N'user118@example.com', NULL, N'username118', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.633' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (119, N'Phạm', N'Ngọc Doanh', N'Male', CAST(N'2007-05-27T10:26:46.633' AS DateTime), N'0393849859', N'Địa chỉ 119', N'user119@example.com', NULL, N'username119', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.633' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (120, N'Phạm', N'Ngọc Doanh', N'Male', CAST(N'2008-05-27T10:26:46.633' AS DateTime), N'0393849859', N'Địa chỉ 120', N'user120@example.com', NULL, N'username120', N'password', N'student', 1, CAST(N'2024-05-27T10:26:46.633' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (121, N'Đặng', N'Bảo Huy', N'Male', CAST(N'1991-05-27T10:26:46.637' AS DateTime), N'0393849859', N'Địa chỉ 121', N'user121@example.com', NULL, N'admin', N'admin', N'admin', 1, CAST(N'2024-05-27T10:26:46.637' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (122, N'Dương', N'Quốc Minh', N'Male', CAST(N'1985-05-27T10:26:46.637' AS DateTime), N'0393849859', N'Địa chỉ 122', N'user122@example.com', NULL, N'username122', N'password', N'admin', 1, CAST(N'2024-05-27T10:26:46.637' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (123, N'Bùi', N'Khánh Ngân', N'Female', CAST(N'1988-05-27T10:26:46.637' AS DateTime), N'0393849859', N'Địa chỉ 123', N'user123@example.com', NULL, N'username123', N'password', N'admin', 1, CAST(N'2024-05-27T10:26:46.637' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (124, N'Nguyễn', N'Văn Anh', N'Female', CAST(N'1991-05-27T10:26:46.637' AS DateTime), N'0393849859', N'Địa chỉ 124', N'user124@example.com', NULL, N'username124', N'password', N'admin', 1, CAST(N'2024-05-27T10:26:46.637' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (125, N'Ngô', N'Anh Khánh', N'Female', CAST(N'1984-05-27T10:26:46.637' AS DateTime), N'0393849859', N'Địa chỉ 125', N'user125@example.com', NULL, N'username125', N'password', N'admin', 1, CAST(N'2024-05-27T10:26:46.637' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (126, N'Đỗ', N'Thảo Mai', N'Female', CAST(N'1989-05-27T10:26:46.637' AS DateTime), N'0393849859', N'Địa chỉ 126', N'user126@example.com', NULL, N'username126', N'password', N'admin', 1, CAST(N'2024-05-27T10:26:46.637' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (127, N'Bùi', N'Khánh Ngân', N'Male', CAST(N'1988-05-27T10:26:46.637' AS DateTime), N'0393849859', N'Địa chỉ 127', N'user127@example.com', NULL, N'username127', N'password', N'admin', 1, CAST(N'2024-05-27T10:26:46.637' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (128, N'Vũ', N'Hoài Giang', N'Female', CAST(N'1988-05-27T10:26:46.640' AS DateTime), N'0393849859', N'Địa chỉ 128', N'user128@example.com', NULL, N'username128', N'password', N'admin', 1, CAST(N'2024-05-27T10:26:46.640' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (129, N'Dương', N'Quốc Minh', N'Female', CAST(N'1987-05-27T10:26:46.640' AS DateTime), N'0393849859', N'Địa chỉ 129', N'user129@example.com', NULL, N'username129', N'password', N'admin', 1, CAST(N'2024-05-27T10:26:46.640' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (130, N'Ngô', N'Anh Khánh', N'Female', CAST(N'1985-05-27T10:26:46.640' AS DateTime), N'0393849859', N'Địa chỉ 130', N'user130@example.com', NULL, N'username130', N'password', N'admin', 1, CAST(N'2024-05-27T10:26:46.640' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (131, N'Nguyễn', N'Văn Anh', N'Female', CAST(N'1989-05-27T10:26:46.640' AS DateTime), N'0393849859', N'Địa chỉ 131', N'user131@example.com', NULL, N'username131', N'password', N'admin', 1, CAST(N'2024-05-27T10:26:46.640' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (132, N'Lê', N'Minh Chính', N'Male', CAST(N'1991-05-27T10:26:46.640' AS DateTime), N'0393849859', N'Địa chỉ 132', N'user132@example.com', NULL, N'username132', N'password', N'admin', 1, CAST(N'2024-05-27T10:26:46.640' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (133, N'Vũ', N'Hoài Giang', N'Female', CAST(N'1990-05-27T10:26:46.640' AS DateTime), N'0393849859', N'Địa chỉ 133', N'user133@example.com', NULL, N'username133', N'password', N'admin', 1, CAST(N'2024-05-27T10:26:46.640' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (134, N'Đỗ', N'Thảo Mai', N'Male', CAST(N'1986-05-27T10:26:46.640' AS DateTime), N'0393849859', N'Địa chỉ 134', N'user134@example.com', NULL, N'username134', N'password', N'admin', 1, CAST(N'2024-05-27T10:26:46.640' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (135, N'Lý', N'Thùy Ninh', N'Male', CAST(N'1988-05-27T10:26:46.640' AS DateTime), N'0393849859', N'Địa chỉ 135', N'user135@example.com', NULL, N'username135', N'password', N'admin', 1, CAST(N'2024-05-27T10:26:46.640' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (136, N'Đặng', N'Bảo Huy', N'Male', CAST(N'1990-05-27T10:26:46.640' AS DateTime), N'0393849859', N'Địa chỉ 136', N'user136@example.com', NULL, N'username136', N'password', N'admin', 1, CAST(N'2024-05-27T10:26:46.640' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (137, N'Phạm', N'Ngọc Doanh', N'Female', CAST(N'1989-05-27T10:26:46.640' AS DateTime), N'0393849859', N'Địa chỉ 137', N'user137@example.com', NULL, N'username137', N'password', N'admin', 1, CAST(N'2024-05-27T10:26:46.640' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (138, N'Hồ', N'Việt Long', N'Male', CAST(N'1986-05-27T10:26:46.640' AS DateTime), N'0393849859', N'Địa chỉ 138', N'user138@example.com', NULL, N'username138', N'password', N'admin', 1, CAST(N'2024-05-27T10:26:46.640' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (139, N'Dương', N'Quốc Minh', N'Female', CAST(N'1988-05-27T10:26:46.640' AS DateTime), N'0393849859', N'Địa chỉ 139', N'user139@example.com', NULL, N'username139', N'password', N'admin', 1, CAST(N'2024-05-27T10:26:46.640' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (140, N'Phạm', N'Ngọc Doanh', N'Male', CAST(N'1986-05-27T10:26:46.640' AS DateTime), N'0393849859', N'Địa chỉ 140', N'user140@example.com', NULL, N'username140', N'password', N'admin', 1, CAST(N'2024-05-27T10:26:46.640' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (141, N'Dương', N'Quốc Minh', N'Female', CAST(N'1988-05-27T10:26:46.643' AS DateTime), N'0393849859', N'Địa chỉ 141', N'user141@example.com', NULL, N'username141', N'password', N'admin', 1, CAST(N'2024-05-27T10:26:46.643' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (142, N'Phạm', N'Ngọc Doanh', N'Male', CAST(N'1990-05-27T10:26:46.643' AS DateTime), N'0393849859', N'Địa chỉ 142', N'user142@example.com', NULL, N'username142', N'password', N'admin', 1, CAST(N'2024-05-27T10:26:46.643' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (143, N'Nguyễn', N'Văn Anh', N'Male', CAST(N'1993-05-27T10:26:46.643' AS DateTime), N'0393849859', N'Địa chỉ 143', N'user143@example.com', NULL, N'username143', N'password', N'admin', 1, CAST(N'2024-05-27T10:26:46.643' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (144, N'Phạm', N'Ngọc Doanh', N'Female', CAST(N'1984-05-27T10:26:46.643' AS DateTime), N'0393849859', N'Địa chỉ 144', N'user144@example.com', NULL, N'username144', N'password', N'admin', 1, CAST(N'2024-05-27T10:26:46.643' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (145, N'Phan', N'Thanh Nhàn', N'Female', CAST(N'1988-05-27T10:26:46.643' AS DateTime), N'0393849859', N'Địa chỉ 145', N'user145@example.com', NULL, N'username145', N'password', N'admin', 1, CAST(N'2024-05-27T10:26:46.643' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (146, N'Hồ', N'Việt Long', N'Male', CAST(N'1989-05-27T10:26:46.643' AS DateTime), N'0393849859', N'Địa chỉ 146', N'user146@example.com', NULL, N'username146', N'password', N'admin', 1, CAST(N'2024-05-27T10:26:46.643' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (147, N'Phạm', N'Ngọc Doanh', N'Female', CAST(N'1988-05-27T10:26:46.643' AS DateTime), N'0393849859', N'Địa chỉ 147', N'user147@example.com', NULL, N'username147', N'password', N'admin', 1, CAST(N'2024-05-27T10:26:46.643' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (148, N'Đỗ', N'Thảo Mai', N'Female', CAST(N'1994-05-27T10:26:46.643' AS DateTime), N'0393849859', N'Địa chỉ 148', N'user148@example.com', NULL, N'username148', N'password', N'admin', 1, CAST(N'2024-05-27T10:26:46.643' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (149, N'Phạm', N'Ngọc Doanh', N'Male', CAST(N'1990-05-27T10:26:46.643' AS DateTime), N'0393849859', N'Địa chỉ 149', N'user149@example.com', NULL, N'username149', N'password', N'admin', 1, CAST(N'2024-05-27T10:26:46.643' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (150, N'Đỗ', N'Thảo Mai', N'Male', CAST(N'1992-05-27T10:26:46.643' AS DateTime), N'0393849859', N'Địa chỉ 150', N'user150@example.com', NULL, N'username150', N'password', N'admin', 1, CAST(N'2024-05-27T10:26:46.643' AS DateTime), NULL, 0)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Gender], [DateOfBirth], [PhoneNumber], [Address], [Email], [Image], [Username], [Password], [Role], [ActiveStatus], [StartDate], [EndDate], [LockAccount]) VALUES (151, N'An Huong ', N'Lan', N'Female', CAST(N'2024-05-27T21:07:21.000' AS DateTime), N'012391230', N'Hiep Hoa, Bac Giang', N'lan@gmail.com', NULL, N'an huong  lan', N'An Huong  Lan@2024', N'teacher', NULL, CAST(N'2024-05-27T21:08:10.193' AS DateTime), CAST(N'2024-05-27T21:07:21.983' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[User] OFF
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
