USE [OnlineExam]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 3/7/2024 2:20:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 3/7/2024 2:20:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 3/7/2024 2:20:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 3/7/2024 2:20:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 3/7/2024 2:20:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 3/7/2024 2:20:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [uniqueidentifier] NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 3/7/2024 2:20:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [uniqueidentifier] NOT NULL,
	[Fullname] [nvarchar](100) NOT NULL,
	[JoinedDate] [datetime2](7) NOT NULL,
	[IsAccountActive] [bit] NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 3/7/2024 2:20:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [uniqueidentifier] NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Question]    Script Date: 3/7/2024 2:20:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Question](
	[QuestionId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[CorrectAnswer] [nvarchar](max) NOT NULL,
	[AnswerA] [nvarchar](max) NOT NULL,
	[AnswerB] [nvarchar](max) NOT NULL,
	[AnswerC] [nvarchar](max) NOT NULL,
	[AnswerD] [nvarchar](max) NOT NULL,
	[QuizId] [int] NOT NULL,
 CONSTRAINT [PK_Question] PRIMARY KEY CLUSTERED 
(
	[QuestionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuestionHistory]    Script Date: 3/7/2024 2:20:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuestionHistory](
	[QuestionHistoryId] [int] IDENTITY(1,1) NOT NULL,
	[SelectedOption] [nvarchar](max) NOT NULL,
	[QuestionId] [int] NOT NULL,
	[QuizHistoryId] [int] NOT NULL,
	[IsCorrect] [bit] NOT NULL,
 CONSTRAINT [PK_QuestionHistory] PRIMARY KEY CLUSTERED 
(
	[QuestionHistoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Quiz]    Script Date: 3/7/2024 2:20:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quiz](
	[QuizId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](500) NOT NULL,
	[Duration] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[SubjectId] [int] NOT NULL,
 CONSTRAINT [PK_Quiz] PRIMARY KEY CLUSTERED 
(
	[QuizId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuizHistory]    Script Date: 3/7/2024 2:20:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuizHistory](
	[QuizHistoryId] [int] IDENTITY(1,1) NOT NULL,
	[DateTaken] [datetime2](7) NOT NULL,
	[Score] [int] NOT NULL,
	[Id] [uniqueidentifier] NOT NULL,
	[QuizId] [int] NOT NULL,
 CONSTRAINT [PK_QuizHistory] PRIMARY KEY CLUSTERED 
(
	[QuizHistoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subject]    Script Date: 3/7/2024 2:20:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subject](
	[SubjectId] [int] IDENTITY(1,1) NOT NULL,
	[SubjectName] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](500) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Subject] PRIMARY KEY CLUSTERED 
(
	[SubjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240306170306_Migrations', N'6.0.21')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'd2d63c5b-d09b-4828-8322-f18ba103fe86', N'Student', N'STUDENT', N'c2ec444e-2409-47e1-9139-71eb5030b8c4')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'b8fd818f-63f1-49ee-bec5-f7b66cafbfca', N'Admin', N'ADMIN', N'db2f98bd-596c-494b-b24a-f62b158d6e62')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'34dd158a-6b96-4149-a3b4-5d1b5cc374a3', N'd2d63c5b-d09b-4828-8322-f18ba103fe86')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'34fb159a-6b96-4149-a3b4-5d1b5cc374a3', N'd2d63c5b-d09b-4828-8322-f18ba103fe86')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b8c777a9-55b9-4b3d-860a-d7b56e4c24b7', N'b8fd818f-63f1-49ee-bec5-f7b66cafbfca')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Fullname], [JoinedDate], [IsAccountActive], [Password], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'34dd158a-6b96-4149-a3b4-5d1b5cc374a3', N'Dinh Cong Thanh', CAST(N'2024-03-07T00:03:06.4295756' AS DateTime2), 1, N'thanhdc', N'thanhdc', N'THANHDC', N'thanhdc@gmail.com', N'THANHDC@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEGfTg5/kir1s/8AmXmd2S65qnZUa2y0ChLkMTK/y7KGqAclHwUf0rTx6TsA7FxPBuQ==', N'207ad11a-488b-4d42-8c63-f14f38f19209', N'af391756-e0e0-4aeb-9e18-a73879ca10ce', NULL, 0, 0, NULL, 0, 0)
INSERT [dbo].[AspNetUsers] ([Id], [Fullname], [JoinedDate], [IsAccountActive], [Password], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'34fb159a-6b96-4149-a3b4-5d1b5cc374a3', N'Tran Van Duc', CAST(N'2024-03-07T00:03:06.4283250' AS DateTime2), 1, N'ductv', N'ductv', N'DUCTV', N'ductv@gmail.com', N'DUCTV@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEElZd1Ub1adAZZ4jbISFxdYX26jbshyIgbWeaGsc4Fx8o+YPBhbfKBH2g3CX77Yr3A==', N'bb7e4cc9-a3a7-48c4-abe9-6f797986f4b6', N'35a4ed7b-070d-4fd4-bfbe-206cd223bf34', NULL, 0, 0, NULL, 0, 0)
INSERT [dbo].[AspNetUsers] ([Id], [Fullname], [JoinedDate], [IsAccountActive], [Password], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'b8c777a9-55b9-4b3d-860a-d7b56e4c24b7', N'Admin', CAST(N'2024-03-07T00:03:06.4270831' AS DateTime2), 1, N'admin', N'admin', N'ICPDPHN', N'admin@gmail.com', N'ADMIN@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEMj2XwD6tB1kuY64toOF3zRy0v0SCaIG65x28oxPppQzNCSprTAJ8hOixa4T5b8EtQ==', N'5c362563-4d97-47c8-a0e6-86da71bb35c4', N'63c9120b-e590-4c9f-a591-0ee4938c46aa', NULL, 0, 0, NULL, 0, 0)
GO
SET IDENTITY_INSERT [dbo].[Question] ON 

INSERT [dbo].[Question] ([QuestionId], [Title], [CorrectAnswer], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [QuizId]) VALUES (1, N'Complete this sentence: At the heart of events are', N'C', N'Delegates', N'Buttons', N'Methods', N'Threads', 1)
INSERT [dbo].[Question] ([QuestionId], [Title], [CorrectAnswer], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [QuizId]) VALUES (2, N'With the constraint "where T: class", what it means?', N'C', N'The type argument must be a non-nullable value type, either nullable or non-nullable', N'The type argument must be a reference type, either nullable or non-nullable. This constraint applies also to any class, interface, delegate, or array type.', N'The type argument must be a reference type. This constraint applies also to any class, interface, delegate, or array type. T must be a non-nullable reference type', N'None of the others', 1)
INSERT [dbo].[Question] ([QuestionId], [Title], [CorrectAnswer], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [QuizId]) VALUES (3, N'Which one in the below events is fired secondly during the page load?', N'C', N'PreRender()', N'Init()', N'Unload()', N'Load()', 1)
INSERT [dbo].[Question] ([QuestionId], [Title], [CorrectAnswer], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [QuizId]) VALUES (4, N'Which keyword is used when you wish to explicitly reference the fields and members of the current object?', N'B', N'abstract', N'base', N'this', N'virtual', 1)
INSERT [dbo].[Question] ([QuestionId], [Title], [CorrectAnswer], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [QuizId]) VALUES (5, N'Which event occurs when the form is closed?', N'B', N'Closed', N'Deleted', N'Destroyed', N'Disposed', 1)
INSERT [dbo].[Question] ([QuestionId], [Title], [CorrectAnswer], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [QuizId]) VALUES (6, N'Complete this sentence: At the heart of events are', N'A', N'Delegates', N'Buttons', N'Methods', N'Threads', 2)
INSERT [dbo].[Question] ([QuestionId], [Title], [CorrectAnswer], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [QuizId]) VALUES (7, N'With the constraint "where T: class", what it means?', N'C', N'The type argument must be a non-nullable value type, either nullable or non-nullable', N'The type argument must be a reference type, either nullable or non-nullable. This constraint applies also to any class, interface, delegate, or array type.', N'The type argument must be a reference type. This constraint applies also to any class, interface, delegate, or array type. T must be a non-nullable reference type', N'None of the others', 2)
INSERT [dbo].[Question] ([QuestionId], [Title], [CorrectAnswer], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [QuizId]) VALUES (8, N'Which one in the below events is fired secondly during the page load?', N'C', N'PreRender()', N'Init()', N'Unload()', N'Load()', 2)
INSERT [dbo].[Question] ([QuestionId], [Title], [CorrectAnswer], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [QuizId]) VALUES (9, N'Which keyword is used when you wish to explicitly reference the fields and members of the current object?', N'B', N'abstract', N'base', N'this', N'virtual', 2)
INSERT [dbo].[Question] ([QuestionId], [Title], [CorrectAnswer], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [QuizId]) VALUES (10, N'Which event occurs when the form is closed?', N'D', N'Closed', N'Deleted', N'Destroyed', N'Disposed', 2)
INSERT [dbo].[Question] ([QuestionId], [Title], [CorrectAnswer], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [QuizId]) VALUES (11, N'Which of the following keyword is used to raise an exception manually?', N'B', N'throw', N'return', N'try', N'catch', 2)
INSERT [dbo].[Question] ([QuestionId], [Title], [CorrectAnswer], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [QuizId]) VALUES (12, N'What will be the output of the following program?', N'C', N'Runtime error', N'Adapter', N'protected', N'All of the others', 2)
INSERT [dbo].[Question] ([QuestionId], [Title], [CorrectAnswer], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [QuizId]) VALUES (13, N'What can Events be declared?', N'B', N'base', N'All of the others', N'Decorator', N'internal', 2)
INSERT [dbo].[Question] ([QuestionId], [Title], [CorrectAnswer], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [QuizId]) VALUES (14, N'Which of the following statements related to Generic Class is True?', N'A', N'Adapter', N'Decorator', N'All of the others', N'public', 2)
INSERT [dbo].[Question] ([QuestionId], [Title], [CorrectAnswer], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [QuizId]) VALUES (15, N'Which of the following is one of the Creational Design Patterns?', N'B', N'Bridge', N'Decorator', N'internal', N'Adapter', 2)
INSERT [dbo].[Question] ([QuestionId], [Title], [CorrectAnswer], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [QuizId]) VALUES (16, N'Which of the following keywords meaning access is limited in the same assembly but not outside the assembly?', N'C', N'this', N'protected', N'Decorator', N'public', 2)
INSERT [dbo].[Question] ([QuestionId], [Title], [CorrectAnswer], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [QuizId]) VALUES (17, N'Which of the following is one of the Behavioral Design Patterns?', N'D', N'SumWhile', N'All of the others', N'SumAll', N'Sum', 2)
INSERT [dbo].[Question] ([QuestionId], [Title], [CorrectAnswer], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [QuizId]) VALUES (18, N'Choose the incorrect statement about the delegate.', N'B', N'A delegate cannot use with event', N'Delegates are of reference types', N'.Delegates are used to invoke methods that have the same signatures', N'Delegates are type-safe', 2)
INSERT [dbo].[Question] ([QuestionId], [Title], [CorrectAnswer], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [QuizId]) VALUES (19, N'In Visual Studio, which utility is used to show all?', N'D', N'Class Viewer', N'Solution Viewe', N'Object Viewer', N'Code Viewer', 2)
INSERT [dbo].[Question] ([QuestionId], [Title], [CorrectAnswer], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [QuizId]) VALUES (20, N'Who wrote "Romeo and Juliet"?', N'C', N'Oxygen', N'Berlin', N'Dollar', N'Jupiter Madrid', 2)
INSERT [dbo].[Question] ([QuestionId], [Title], [CorrectAnswer], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [QuizId]) VALUES (21, N'What is the largest mammal on Earth?', N'B', N'Paris', N'Jupiter', N'Steve Jobs', N'Dollar', 2)
INSERT [dbo].[Question] ([QuestionId], [Title], [CorrectAnswer], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [QuizId]) VALUES (22, N'In what year did the Titanic sink?', N'C', N'Jupiter', N'Silver', N'Jane Austen', N'Steve Jobs', 2)
INSERT [dbo].[Question] ([QuestionId], [Title], [CorrectAnswer], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [QuizId]) VALUES (23, N'Which element has the symbol "O"?', N'B', N'Silver', N'Harper Lee', N'Brasilia', N'George Orwell', 2)
INSERT [dbo].[Question] ([QuestionId], [Title], [CorrectAnswer], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [QuizId]) VALUES (24, N'What is your favorite sport game?', N'A', N'Basketball', N'Golf', N'Cricket', N'Javelin-throwing', 3)
INSERT [dbo].[Question] ([QuestionId], [Title], [CorrectAnswer], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [QuizId]) VALUES (25, N'Which of these animal would you like to keep as a pet?', N'B', N'Cow', N'Bird', N'Dog', N'Rabbits', 3)
INSERT [dbo].[Question] ([QuestionId], [Title], [CorrectAnswer], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [QuizId]) VALUES (26, N'Select a quality that suits your personality the most.', N'C', N'Charismatic and creative', N'Irascible and strict', N'Calm and thoughtful', N'Kind and careful', 3)
INSERT [dbo].[Question] ([QuestionId], [Title], [CorrectAnswer], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [QuizId]) VALUES (27, N'Who is your favorite Bollywood actor?', N'C', N'Amir Khan', N'Shah Rukh Khan', N'Akshay Kumar', N'Hrithik Roshan', 3)
INSERT [dbo].[Question] ([QuestionId], [Title], [CorrectAnswer], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [QuizId]) VALUES (28, N'Pick your favorite Bollywood actress.', N'C', N'Katrina Kaif', N'Deepika Padukone', N'Aishwarya Rai', N'Madhuri Dixit', 3)
INSERT [dbo].[Question] ([QuestionId], [Title], [CorrectAnswer], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [QuizId]) VALUES (29, N'Which of these hobbies do you have?', N'B', N'Painting', N'Partying with family and friends', N'Gardening', N'Reading books', 3)
INSERT [dbo].[Question] ([QuestionId], [Title], [CorrectAnswer], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [QuizId]) VALUES (30, N'Pick an Indian city where you would like to live.', N'B', N'Mumbai', N'Delhi', N'Kerala', N'Goa', 3)
INSERT [dbo].[Question] ([QuestionId], [Title], [CorrectAnswer], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [QuizId]) VALUES (31, N'What is the total weight of four kegs of nails if each keg weighs 100 pounds?', N'A', N'100 pounds', N'300 pounds', N'200 pounds', N'400 pounds', 4)
INSERT [dbo].[Question] ([QuestionId], [Title], [CorrectAnswer], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [QuizId]) VALUES (32, N'A cutting wheel cuts through an inch of glass in 2 minutes. How long will it take to cut 6 inches deep?', N'B', N'10 minutes', N'15 minutes', N'12 minutes', N'20 minutes', 4)
INSERT [dbo].[Question] ([QuestionId], [Title], [CorrectAnswer], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [QuizId]) VALUES (33, N'Which of the following numbers is the same as 6 1/4?', N'C', N'6.4', N'6.14', N'6.5', N'6.01', 4)
INSERT [dbo].[Question] ([QuestionId], [Title], [CorrectAnswer], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [QuizId]) VALUES (34, N'Which of these four numbers is the largest?', N'D', N'.0093', N'.087', N'.12', N'.013', 4)
INSERT [dbo].[Question] ([QuestionId], [Title], [CorrectAnswer], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [QuizId]) VALUES (35, N'Which means intricate?', N'C', N'Brave', N'Decorate', N'Accuse', N'Courage', 4)
INSERT [dbo].[Question] ([QuestionId], [Title], [CorrectAnswer], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [QuizId]) VALUES (36, N'A guarantee always has a', N'C', N'Guard', N'Penalty', N'Signature', N'Seal', 4)
INSERT [dbo].[Question] ([QuestionId], [Title], [CorrectAnswer], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [QuizId]) VALUES (37, N'Which is a disease?', N'C', N'Influenza', N'Antitoxin', N'Fracture', N'Bacteria', 4)
INSERT [dbo].[Question] ([QuestionId], [Title], [CorrectAnswer], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [QuizId]) VALUES (38, N'Which is prestige?', N'C', N'Leveling', N'Equality', N'Distinction', N'Strong', 4)
INSERT [dbo].[Question] ([QuestionId], [Title], [CorrectAnswer], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [QuizId]) VALUES (39, N'The ancient Egyptians did not have compasses therefore used what to align the four sides of the Pyramid?', N'A', N'Measuring tape', N'Moon', N'Sun', N'Stars', 4)
INSERT [dbo].[Question] ([QuestionId], [Title], [CorrectAnswer], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [QuizId]) VALUES (40, N'Who is the leader of the local government unit?', N'B', N'President', N'Congressman', N'Mayor', N'Judge', 4)
SET IDENTITY_INSERT [dbo].[Question] OFF
GO
SET IDENTITY_INSERT [dbo].[QuestionHistory] ON 

INSERT [dbo].[QuestionHistory] ([QuestionHistoryId], [SelectedOption], [QuestionId], [QuizHistoryId], [IsCorrect]) VALUES (1, N'B', 1, 1, 0)
INSERT [dbo].[QuestionHistory] ([QuestionHistoryId], [SelectedOption], [QuestionId], [QuizHistoryId], [IsCorrect]) VALUES (2, N'', 2, 1, 0)
INSERT [dbo].[QuestionHistory] ([QuestionHistoryId], [SelectedOption], [QuestionId], [QuizHistoryId], [IsCorrect]) VALUES (3, N'', 3, 1, 0)
INSERT [dbo].[QuestionHistory] ([QuestionHistoryId], [SelectedOption], [QuestionId], [QuizHistoryId], [IsCorrect]) VALUES (4, N'', 4, 1, 0)
INSERT [dbo].[QuestionHistory] ([QuestionHistoryId], [SelectedOption], [QuestionId], [QuizHistoryId], [IsCorrect]) VALUES (5, N'', 5, 1, 0)
SET IDENTITY_INSERT [dbo].[QuestionHistory] OFF
GO
SET IDENTITY_INSERT [dbo].[Quiz] ON 

INSERT [dbo].[Quiz] ([QuizId], [Title], [Description], [Duration], [CreatedDate], [SubjectId]) VALUES (1, N'Progress test 1', N'Progress Test 1 assesses knowledge and skills, offering insights into individual learning progress', 25, CAST(N'2024-03-07T00:39:09.9362698' AS DateTime2), 1)
INSERT [dbo].[Quiz] ([QuizId], [Title], [Description], [Duration], [CreatedDate], [SubjectId]) VALUES (2, N'Progress Test 2', N'Progress Test 2 assesses knowledge and skills in various subjects, featuring 20 questions with multi', 10, CAST(N'2024-03-07T01:14:16.4042785' AS DateTime2), 1)
INSERT [dbo].[Quiz] ([QuizId], [Title], [Description], [Duration], [CreatedDate], [SubjectId]) VALUES (3, N'Theory Exam', N'A practical exam assesses hands-on skills, applying theoretical knowledge. Candidates demonstrate co', 15, CAST(N'2024-03-07T01:31:48.4189174' AS DateTime2), 2)
INSERT [dbo].[Quiz] ([QuizId], [Title], [Description], [Duration], [CreatedDate], [SubjectId]) VALUES (4, N'Scholarship Exam Quiz', N'Scholarship Exam Quiz: 10 questions testing knowledge across subjects with multiple-choice options', 25, CAST(N'2024-03-07T01:36:40.5255792' AS DateTime2), 4)
SET IDENTITY_INSERT [dbo].[Quiz] OFF
GO
SET IDENTITY_INSERT [dbo].[QuizHistory] ON 

INSERT [dbo].[QuizHistory] ([QuizHistoryId], [DateTaken], [Score], [Id], [QuizId]) VALUES (1, CAST(N'2024-03-07T01:27:02.1535064' AS DateTime2), 0, N'34fb159a-6b96-4149-a3b4-5d1b5cc374a3', 1)
SET IDENTITY_INSERT [dbo].[QuizHistory] OFF
GO
SET IDENTITY_INSERT [dbo].[Subject] ON 

INSERT [dbo].[Subject] ([SubjectId], [SubjectName], [Description], [CreatedDate]) VALUES (1, N'Programming Fundamentals', N'Programming Fundamentals involve mastering basic concepts such as variables, control structures, functions, and algorithms. It lays the foundation for coding, problem-solving, and understanding the core principles', CAST(N'2024-03-07T00:33:46.0441265' AS DateTime2))
INSERT [dbo].[Subject] ([SubjectId], [SubjectName], [Description], [CreatedDate]) VALUES (2, N'Mathematics for Engineering', N'Mathematics for Engineering provides tools to model, analyze, and solve real-world engineering problems. It encompasses calculus, linear algebra, differential equations, and numerical methods essential for designing and optimizing engineering systems.', CAST(N'2024-03-07T00:34:16.1898928' AS DateTime2))
INSERT [dbo].[Subject] ([SubjectId], [SubjectName], [Description], [CreatedDate]) VALUES (3, N'Object-Oriented Programming', N'Object-Oriented Programming (OOP) is a programming paradigm centered around objects, combining data and functions. It promotes code organization, modularity, and reusability, fostering concepts like encapsulation, inheritance, and polymorphism for efficient software development.', CAST(N'2024-03-07T00:34:38.3228448' AS DateTime2))
INSERT [dbo].[Subject] ([SubjectId], [SubjectName], [Description], [CreatedDate]) VALUES (4, N'Data Structures and Algorithms', N'Data Structures organize and store data, facilitating efficient retrieval and manipulation.', CAST(N'2024-03-07T00:35:07.0037584' AS DateTime2))
INSERT [dbo].[Subject] ([SubjectId], [SubjectName], [Description], [CreatedDate]) VALUES (5, N'Advanced Cross-Platform Application Programming With .NET', N'Advanced Cross-Platform Application Programming With .NET involves leveraging Xamarin.Forms to develop sophisticated, native-like mobile applications, seamlessly sharing code across multiple platforms, enhancing user experiences, and optimizing performance.', CAST(N'2024-03-07T00:35:31.1683878' AS DateTime2))
INSERT [dbo].[Subject] ([SubjectId], [SubjectName], [Description], [CreatedDate]) VALUES (6, N'Basic Cross-Platform Application Programming With .NET', N'Develop cross-platform apps using .NET, leveraging Xamarin or MAUI for shared code, UI, and seamless experiences on various devices.', CAST(N'2024-03-07T00:35:53.4125842' AS DateTime2))
INSERT [dbo].[Subject] ([SubjectId], [SubjectName], [Description], [CreatedDate]) VALUES (7, N'Software Requirement', N'Software requirements define functionalities, features, and constraints needed for a system''s development, ensuring alignment with user needs and expectations.', CAST(N'2024-03-07T00:36:14.7710724' AS DateTime2))
INSERT [dbo].[Subject] ([SubjectId], [SubjectName], [Description], [CreatedDate]) VALUES (8, N'C# Programming and Unity', N'C# Programming: Versatile language for software development, part of .NET. Unity: Powerful game development engine using C# for cross-platform interactive experiences.', CAST(N'2024-03-07T00:36:38.5709285' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Subject] OFF
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Question]  WITH CHECK ADD  CONSTRAINT [FK_Question_Quiz_QuizId] FOREIGN KEY([QuizId])
REFERENCES [dbo].[Quiz] ([QuizId])
GO
ALTER TABLE [dbo].[Question] CHECK CONSTRAINT [FK_Question_Quiz_QuizId]
GO
ALTER TABLE [dbo].[QuestionHistory]  WITH CHECK ADD  CONSTRAINT [FK_QuestionHistory_Question_QuestionId] FOREIGN KEY([QuestionId])
REFERENCES [dbo].[Question] ([QuestionId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[QuestionHistory] CHECK CONSTRAINT [FK_QuestionHistory_Question_QuestionId]
GO
ALTER TABLE [dbo].[QuestionHistory]  WITH CHECK ADD  CONSTRAINT [FK_QuestionHistory_QuizHistory_QuizHistoryId] FOREIGN KEY([QuizHistoryId])
REFERENCES [dbo].[QuizHistory] ([QuizHistoryId])
GO
ALTER TABLE [dbo].[QuestionHistory] CHECK CONSTRAINT [FK_QuestionHistory_QuizHistory_QuizHistoryId]
GO
ALTER TABLE [dbo].[Quiz]  WITH CHECK ADD  CONSTRAINT [FK_Quiz_Subject_SubjectId] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subject] ([SubjectId])
GO
ALTER TABLE [dbo].[Quiz] CHECK CONSTRAINT [FK_Quiz_Subject_SubjectId]
GO
ALTER TABLE [dbo].[QuizHistory]  WITH CHECK ADD  CONSTRAINT [FK_QuizHistory_AspNetUsers_Id] FOREIGN KEY([Id])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[QuizHistory] CHECK CONSTRAINT [FK_QuizHistory_AspNetUsers_Id]
GO
ALTER TABLE [dbo].[QuizHistory]  WITH CHECK ADD  CONSTRAINT [FK_QuizHistory_Quiz_QuizId] FOREIGN KEY([QuizId])
REFERENCES [dbo].[Quiz] ([QuizId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[QuizHistory] CHECK CONSTRAINT [FK_QuizHistory_Quiz_QuizId]
GO
