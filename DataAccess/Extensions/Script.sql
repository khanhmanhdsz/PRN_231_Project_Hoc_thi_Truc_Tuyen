USE [FCMS]
GO
/****** Object:  Table [dbo].[Achievement]    Script Date: 12/6/2023 8:02:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Achievement](
	[AchievementId] [int] IDENTITY(1,1) NOT NULL,
	[AchievementTitle] [nvarchar](200) NOT NULL,
	[AchievementDesc] [nvarchar](500) NULL,
	[SemesterCode] [nvarchar](100) NULL,
	[Email] [nvarchar](max) NULL,
	[UserId] [uniqueidentifier] NULL,
	[AchievementStatus] [int] NOT NULL,
	[EvidenceUrl] [nvarchar](max) NULL,
	[ResponseMessage] [nvarchar](max) NULL,
	[ClubCode] [nvarchar](50) NULL,
	[IsClubAchievement] [bit] NOT NULL,
	[CampusId] [nvarchar](50) NOT NULL,
	[CreatedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_Achievement] PRIMARY KEY CLUSTERED 
(
	[AchievementId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AdminDepartment]    Script Date: 12/6/2023 8:02:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminDepartment](
	[DepartmentCode] [nvarchar](450) NOT NULL,
	[CampusId] [nvarchar](50) NOT NULL,
	[DepartmentName] [nvarchar](512) NOT NULL,
	[Address] [nvarchar](600) NULL,
	[SortDescription] [nvarchar](2000) NULL,
	[Introduction] [nvarchar](4000) NULL,
	[OfficialEmail] [nvarchar](256) NOT NULL,
	[OfficialPhone] [nvarchar](256) NOT NULL,
	[FacebookUrl] [nvarchar](max) NULL,
	[InstagramUrl] [nvarchar](max) NULL,
	[YoutubeUrl] [nvarchar](max) NULL,
	[AvatarURL] [nvarchar](max) NULL,
	[BannerURL] [nvarchar](max) NULL,
 CONSTRAINT [PK_AdminDepartment] PRIMARY KEY CLUSTERED 
(
	[DepartmentCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AdminParticipant]    Script Date: 12/6/2023 8:02:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminParticipant](
	[AdminParticipateId] [int] IDENTITY(1,1) NOT NULL,
	[Position] [nvarchar](128) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DepartmentCode] [nvarchar](450) NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_AdminParticipant] PRIMARY KEY CLUSTERED 
(
	[AdminParticipateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 12/6/2023 8:02:09 AM ******/
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
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 12/6/2023 8:02:09 AM ******/
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
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 12/6/2023 8:02:09 AM ******/
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
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 12/6/2023 8:02:09 AM ******/
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
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 12/6/2023 8:02:09 AM ******/
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
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 12/6/2023 8:02:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [uniqueidentifier] NOT NULL,
	[Fullname] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Address] [nvarchar](500) NULL,
	[Birthday] [datetime2](7) NULL,
	[TotalActivityScore] [int] NULL,
	[Major] [nvarchar](max) NULL,
	[SpecializeMajor] [nvarchar](max) NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[isAccountActive] [bit] NOT NULL,
	[CampusId] [nvarchar](50) NOT NULL,
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
	[Gender] [bit] NULL,
	[AvatarURL] [nvarchar](max) NULL,
	[StudentCode] [nvarchar](50) NULL,
	[FacebookUrl] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 12/6/2023 8:02:09 AM ******/
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
/****** Object:  Table [dbo].[AssignUserSubmitReport]    Script Date: 12/6/2023 8:02:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssignUserSubmitReport](
	[AssignUserSubmitReportID] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [uniqueidentifier] NULL,
	[SubmissionReportRequirementId] [int] NOT NULL,
	[isSubmit] [bit] NOT NULL,
	[ClubCode] [nvarchar](50) NULL,
	[EventId] [int] NULL,
 CONSTRAINT [PK_AssignUserSubmitReport] PRIMARY KEY CLUSTERED 
(
	[AssignUserSubmitReportID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Campus]    Script Date: 12/6/2023 8:02:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Campus](
	[CampusId] [nvarchar](50) NOT NULL,
	[CampusName] [nvarchar](max) NOT NULL,
	[EduSystemId] [int] NOT NULL,
	[CampusDesc] [nvarchar](500) NULL,
 CONSTRAINT [PK_Campus] PRIMARY KEY CLUSTERED 
(
	[CampusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Club]    Script Date: 12/6/2023 8:02:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Club](
	[ClubCode] [nvarchar](50) NOT NULL,
	[NormalizedClubCode] [nvarchar](50) NOT NULL,
	[ClubCategoryId] [int] NOT NULL,
	[CampusId] [nvarchar](max) NOT NULL,
	[ClubName] [nvarchar](500) NOT NULL,
	[ClubDesc] [nvarchar](2000) NULL,
	[ClubEmail] [nvarchar](128) NOT NULL,
	[ClubBirthday] [datetime2](7) NULL,
	[FacebookUrl] [nvarchar](max) NULL,
	[InstagramUrl] [nvarchar](max) NULL,
	[YoutubeUrl] [nvarchar](max) NULL,
	[ClubAvatarURL] [nvarchar](max) NULL,
	[ClubBannerURL] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
	[ManagerEmail] [nvarchar](128) NULL,
	[ManagerName] [nvarchar](128) NULL,
	[ManagerPhoneNumber] [nvarchar](20) NULL,
 CONSTRAINT [PK_Club] PRIMARY KEY CLUSTERED 
(
	[ClubCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClubCategory]    Script Date: 12/6/2023 8:02:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClubCategory](
	[ClubCategoryId] [int] IDENTITY(1,1) NOT NULL,
	[ClubCategoryName] [nvarchar](50) NOT NULL,
	[ClubCategoryDesc] [nvarchar](max) NULL,
	[CampusId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ClubCategory] PRIMARY KEY CLUSTERED 
(
	[ClubCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClubParticipation]    Script Date: 12/6/2023 8:02:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClubParticipation](
	[ClubParticipationId] [int] IDENTITY(1,1) NOT NULL,
	[ClubCode] [nvarchar](50) NOT NULL,
	[SemesterCode] [nvarchar](max) NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[ActivityScore] [int] NULL,
	[Positionid] [int] NOT NULL,
	[Generation] [int] NULL,
	[Email] [nvarchar](max) NULL,
 CONSTRAINT [PK_ClubParticipation] PRIMARY KEY CLUSTERED 
(
	[ClubParticipationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EducationalSystem]    Script Date: 12/6/2023 8:02:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EducationalSystem](
	[EduSystemId] [int] IDENTITY(1,1) NOT NULL,
	[EduSystemName] [nvarchar](256) NOT NULL,
	[Description] [nvarchar](1024) NULL,
 CONSTRAINT [PK_EducationalSystem] PRIMARY KEY CLUSTERED 
(
	[EduSystemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmailSetting]    Script Date: 12/6/2023 8:02:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmailSetting](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MailServer] [nvarchar](max) NOT NULL,
	[MailPort] [int] NOT NULL,
	[SenderEmail] [nvarchar](max) NOT NULL,
	[SenderName] [nvarchar](500) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_EmailSetting] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Event]    Script Date: 12/6/2023 8:02:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Event](
	[EventId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](2550) NOT NULL,
	[Content] [nvarchar](4000) NOT NULL,
	[Location] [nvarchar](max) NOT NULL,
	[CreatedDate] [datetime2](7) NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[EndDate] [datetime2](7) NOT NULL,
	[CampusId] [nvarchar](50) NOT NULL,
	[EventTypeId] [int] NOT NULL,
	[StateId] [int] NOT NULL,
	[VideoUrl] [nvarchar](2500) NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[IsPublic] [bit] NULL,
	[IsPublicTV] [bit] NULL,
	[NumberParticipants] [int] NULL,
	[reply] [nvarchar](max) NULL,
	[ClubCode] [nvarchar](50) NULL,
	[DepartmentCode] [nvarchar](450) NULL,
	[UrlForm] [nvarchar](max) NULL,
 CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED 
(
	[EventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EventImage]    Script Date: 12/6/2023 8:02:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventImage](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[ImageUrl] [nvarchar](max) NULL,
	[isBanner] [bit] NULL,
	[EventId] [int] NOT NULL,
 CONSTRAINT [PK_EventImage] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EventRegisterParticipate]    Script Date: 12/6/2023 8:02:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventRegisterParticipate](
	[UserId] [uniqueidentifier] NOT NULL,
	[EventId] [int] NOT NULL,
	[Reason] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[reply] [nvarchar](max) NULL,
	[StateId] [int] NOT NULL,
 CONSTRAINT [PK_EventRegisterParticipate] PRIMARY KEY CLUSTERED 
(
	[EventId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EventType]    Script Date: 12/6/2023 8:02:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventType](
	[EventTypeId] [int] IDENTITY(1,1) NOT NULL,
	[EventTypeName] [nvarchar](1000) NOT NULL,
 CONSTRAINT [PK_EventType] PRIMARY KEY CLUSTERED 
(
	[EventTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Flag]    Script Date: 12/6/2023 8:02:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Flag](
	[FlagId] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Flag] PRIMARY KEY CLUSTERED 
(
	[FlagId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GoogleDriverSetting]    Script Date: 12/6/2023 8:02:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GoogleDriverSetting](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](500) NOT NULL,
	[Project_id] [nvarchar](500) NOT NULL,
	[Private_key_id] [nvarchar](500) NOT NULL,
	[Private_key] [nvarchar](2500) NOT NULL,
	[Client_email] [nvarchar](1000) NOT NULL,
	[Client_id] [nvarchar](500) NOT NULL,
	[Auth_uri] [nvarchar](500) NOT NULL,
	[Token_uri] [nvarchar](500) NOT NULL,
	[Auth_provider_x509_cert_url] [nvarchar](1000) NOT NULL,
	[Client_x509_cert_url] [nvarchar](1000) NOT NULL,
	[Universe_domain] [nvarchar](500) NOT NULL,
	[Root_folder_id] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_GoogleDriverSetting] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Guideline]    Script Date: 12/6/2023 8:02:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Guideline](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](1000) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[FileUrl] [nvarchar](max) NULL,
	[FileId] [nvarchar](max) NULL,
	[CampusId] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[ContentType] [nvarchar](max) NULL,
 CONSTRAINT [PK_Guideline] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IntroSetting]    Script Date: 12/6/2023 8:02:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IntroSetting](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[YoutubeUrl] [nvarchar](512) NULL,
	[Content] [nvarchar](max) NULL,
	[CampusId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_IntroSetting] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MeetingRequest]    Script Date: 12/6/2023 8:02:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MeetingRequest](
	[MeetingId] [int] IDENTITY(1,1) NOT NULL,
	[StartTime] [datetime2](7) NULL,
	[EndTime] [datetime2](7) NULL,
	[CreatedAt] [datetime2](7) NULL,
	[LastUpdated] [datetime2](7) NULL,
	[MeetingTitle] [nvarchar](1000) NOT NULL,
	[MeetingDesc] [nvarchar](max) NULL,
	[Location] [nvarchar](max) NULL,
	[ResponseMessage] [nvarchar](max) NULL,
	[ClubCode] [nvarchar](50) NOT NULL,
	[StatusId] [int] NOT NULL,
	[CampusId] [nvarchar](50) NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[AttachedDocumentUrl] [nvarchar](max) NULL,
	[IsClubRequest] [bit] NOT NULL,
	[ClubResponseMessage] [nvarchar](max) NULL,
	[OldEndTime] [datetime2](7) NULL,
	[OldStartTime] [datetime2](7) NULL,
 CONSTRAINT [PK_MeetingRequest] PRIMARY KEY CLUSTERED 
(
	[MeetingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MeetingStatus]    Script Date: 12/6/2023 8:02:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MeetingStatus](
	[StatusId] [int] IDENTITY(1,1) NOT NULL,
	[StatusName] [nvarchar](100) NOT NULL,
	[StatusDesc] [nvarchar](500) NULL,
 CONSTRAINT [PK_MeetingStatus] PRIMARY KEY CLUSTERED 
(
	[StatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Position]    Script Date: 12/6/2023 8:02:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Position](
	[Positionid] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](1000) NOT NULL,
 CONSTRAINT [PK_Position] PRIMARY KEY CLUSTERED 
(
	[Positionid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Post]    Script Date: 12/6/2023 8:02:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Post](
	[PostId] [int] IDENTITY(1,1) NOT NULL,
	[PostCategoryId] [int] NOT NULL,
	[Title] [nvarchar](2000) NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[PostImage] [nvarchar](max) NULL,
	[CreateAt] [datetime2](7) NULL,
	[CampusId] [nvarchar](50) NOT NULL,
	[Reply] [nvarchar](max) NULL,
	[StateId] [int] NOT NULL,
	[IsPostPin] [bit] NULL,
	[Abstract] [nvarchar](max) NULL,
	[ClubCode] [nvarchar](50) NULL,
	[DepartmentCode] [nvarchar](450) NULL,
	[UrlVideo] [nvarchar](max) NULL,
	[FacebookUrl] [nvarchar](max) NULL,
 CONSTRAINT [PK_Post] PRIMARY KEY CLUSTERED 
(
	[PostId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PostCategory]    Script Date: 12/6/2023 8:02:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PostCategory](
	[PostCategoryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](1000) NOT NULL,
 CONSTRAINT [PK_PostCategory] PRIMARY KEY CLUSTERED 
(
	[PostCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Recruitment]    Script Date: 12/6/2023 8:02:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recruitment](
	[RecruitmentId] [int] IDENTITY(1,1) NOT NULL,
	[FormUrl] [nvarchar](4000) NOT NULL,
	[IsPublic] [bit] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ClubCode] [nvarchar](50) NULL,
	[Title] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_Recruitment] PRIMARY KEY CLUSTERED 
(
	[RecruitmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Report]    Script Date: 12/6/2023 8:02:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Report](
	[ReportId] [int] IDENTITY(1,1) NOT NULL,
	[Content] [nvarchar](max) NULL,
	[SemesterCode] [nvarchar](100) NULL,
	[CampusId] [nvarchar](50) NOT NULL,
	[SentDate] [datetime2](7) NOT NULL,
	[ReportTypeId] [int] NOT NULL,
	[FeedBack] [nvarchar](max) NULL,
	[FlagId] [int] NOT NULL,
	[StateId] [int] NOT NULL,
	[SubmissionReportRequirementId] [int] NOT NULL,
	[AssignUserSubmitReportID] [int] NOT NULL,
 CONSTRAINT [PK_Report] PRIMARY KEY CLUSTERED 
(
	[ReportId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReportCost]    Script Date: 12/6/2023 8:02:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReportCost](
	[ReportCostId] [int] IDENTITY(1,1) NOT NULL,
	[ReportEventResultId] [int] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Quantity] [int] NULL,
	[Price] [decimal](18, 2) NULL,
	[TotalMoney] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_ReportCost] PRIMARY KEY CLUSTERED 
(
	[ReportCostId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReportEvent]    Script Date: 12/6/2023 8:02:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReportEvent](
	[ReportEventId] [int] IDENTITY(1,1) NOT NULL,
	[ReportId] [int] NOT NULL,
	[ReportEventTypeID] [int] NOT NULL,
	[NameEvent] [nvarchar](max) NOT NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[EndDate] [datetime2](7) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[NumberOfAttendees] [int] NOT NULL,
	[LinkProof] [nvarchar](max) NULL,
 CONSTRAINT [PK_ReportEvent] PRIMARY KEY CLUSTERED 
(
	[ReportEventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReportEventResult]    Script Date: 12/6/2023 8:02:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReportEventResult](
	[ReportEventResultId] [int] IDENTITY(1,1) NOT NULL,
	[ReportId] [int] NOT NULL,
	[Title] [nvarchar](max) NULL,
	[ResultEventDescript] [nvarchar](max) NULL,
	[ExperienceDescript] [nvarchar](max) NULL,
	[MemberJoin] [int] NULL,
	[ResultDescript] [nvarchar](max) NULL,
	[TotalMoney] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_ReportEventResult] PRIMARY KEY CLUSTERED 
(
	[ReportEventResultId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReportEventType]    Script Date: 12/6/2023 8:02:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReportEventType](
	[ReportEventTypeID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](1000) NOT NULL,
 CONSTRAINT [PK_ReportEventType] PRIMARY KEY CLUSTERED 
(
	[ReportEventTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReportPoint]    Script Date: 12/6/2023 8:02:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReportPoint](
	[ReportPointID] [int] IDENTITY(1,1) NOT NULL,
	[ReportId] [int] NOT NULL,
	[FullName] [nvarchar](max) NOT NULL,
	[StudentCode] [nvarchar](max) NOT NULL,
	[Point1] [decimal](18, 2) NOT NULL,
	[Point2] [decimal](18, 2) NULL,
	[PositionName] [nvarchar](max) NULL,
 CONSTRAINT [PK_ReportPoint] PRIMARY KEY CLUSTERED 
(
	[ReportPointID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReportType]    Script Date: 12/6/2023 8:02:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReportType](
	[ReportTypeId] [int] IDENTITY(1,1) NOT NULL,
	[ReportTypeName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ReportType] PRIMARY KEY CLUSTERED 
(
	[ReportTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Request]    Script Date: 12/6/2023 8:02:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Request](
	[RequestId] [int] IDENTITY(1,1) NOT NULL,
	[FeedBack] [nvarchar](2550) NULL,
	[SemesterCode] [nvarchar](100) NULL,
	[ClubCode] [nvarchar](50) NOT NULL,
	[SentDate] [datetime2](7) NOT NULL,
	[RequestTypeId] [int] NOT NULL,
	[CampusId] [nvarchar](50) NOT NULL,
	[Content] [nvarchar](2550) NULL,
	[StateId] [int] NOT NULL,
	[RequestDesc] [nvarchar](2550) NULL,
	[AttachmentsUrl] [nvarchar](2550) NULL,
 CONSTRAINT [PK_Request] PRIMARY KEY CLUSTERED 
(
	[RequestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RequestItem]    Script Date: 12/6/2023 8:02:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RequestItem](
	[RequestItemId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Total] [int] NOT NULL,
	[Location] [nvarchar](2550) NULL,
	[StartTime] [datetime2](7) NOT NULL,
	[EndTime] [datetime2](7) NOT NULL,
	[FeedBack] [nvarchar](2550) NULL,
	[RequestId] [int] NOT NULL,
	[StateId] [int] NOT NULL,
 CONSTRAINT [PK_RequestItem] PRIMARY KEY CLUSTERED 
(
	[RequestItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RequestProtectDetail]    Script Date: 12/6/2023 8:02:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RequestProtectDetail](
	[RequestProtectDetailId] [int] IDENTITY(1,1) NOT NULL,
	[StartTime] [datetime2](7) NOT NULL,
	[FeedBack] [nvarchar](2550) NULL,
	[RequestId] [int] NULL,
	[StateId] [int] NOT NULL,
 CONSTRAINT [PK_RequestProtectDetail] PRIMARY KEY CLUSTERED 
(
	[RequestProtectDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RequestType]    Script Date: 12/6/2023 8:02:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RequestType](
	[RequestTypeId] [int] IDENTITY(1,1) NOT NULL,
	[RequestTypeName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_RequestType] PRIMARY KEY CLUSTERED 
(
	[RequestTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Semester]    Script Date: 12/6/2023 8:02:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Semester](
	[SemesterCode] [nvarchar](100) NOT NULL,
	[SemesterName] [nvarchar](50) NOT NULL,
	[StartDate] [datetime2](7) NULL,
	[EndDate] [datetime2](7) NULL,
	[CampusId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Semester] PRIMARY KEY CLUSTERED 
(
	[SemesterCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staff]    Script Date: 12/6/2023 8:02:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staff](
	[StaffId] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentCode] [nvarchar](450) NOT NULL,
	[Email] [nvarchar](500) NOT NULL,
	[FullName] [nvarchar](100) NOT NULL,
	[gender] [bit] NULL,
	[AvatarUrl] [nvarchar](max) NULL,
	[BirthDay] [datetime2](7) NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](max) NULL,
	[FacebookUrl] [nvarchar](max) NULL,
 CONSTRAINT [PK_Staff] PRIMARY KEY CLUSTERED 
(
	[StaffId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[State]    Script Date: 12/6/2023 8:02:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[State](
	[StateId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_State] PRIMARY KEY CLUSTERED 
(
	[StateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubmissionReportRequirement]    Script Date: 12/6/2023 8:02:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubmissionReportRequirement](
	[SubmissionReportRequirementId] [int] IDENTITY(1,1) NOT NULL,
	[DueDate] [datetime2](7) NOT NULL,
	[CreateAt] [datetime2](7) NOT NULL,
	[SemesterCode] [nvarchar](100) NOT NULL,
	[CampusId] [nvarchar](50) NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[Content] [nvarchar](max) NULL,
	[ReportTypeId] [int] NOT NULL,
 CONSTRAINT [PK_SubmissionReportRequirement] PRIMARY KEY CLUSTERED 
(
	[SubmissionReportRequirementId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[AssignUserSubmitReport] ADD  DEFAULT (CONVERT([bit],(0))) FOR [isSubmit]
GO
ALTER TABLE [dbo].[Campus] ADD  DEFAULT ((0)) FOR [EduSystemId]
GO
ALTER TABLE [dbo].[ClubCategory] ADD  DEFAULT (N'') FOR [CampusId]
GO
ALTER TABLE [dbo].[ClubParticipation] ADD  DEFAULT ((0)) FOR [Positionid]
GO
ALTER TABLE [dbo].[Event] ADD  DEFAULT ('00000000-0000-0000-0000-000000000000') FOR [UserId]
GO
ALTER TABLE [dbo].[EventRegisterParticipate] ADD  DEFAULT ((0)) FOR [StateId]
GO
ALTER TABLE [dbo].[MeetingRequest] ADD  DEFAULT (N'') FOR [CampusId]
GO
ALTER TABLE [dbo].[MeetingRequest] ADD  DEFAULT ('00000000-0000-0000-0000-000000000000') FOR [UserId]
GO
ALTER TABLE [dbo].[MeetingRequest] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsClubRequest]
GO
ALTER TABLE [dbo].[Post] ADD  DEFAULT (N'') FOR [CampusId]
GO
ALTER TABLE [dbo].[Post] ADD  DEFAULT ((0)) FOR [StateId]
GO
ALTER TABLE [dbo].[Recruitment] ADD  DEFAULT (N'') FOR [Title]
GO
ALTER TABLE [dbo].[Report] ADD  DEFAULT ((0)) FOR [FlagId]
GO
ALTER TABLE [dbo].[Report] ADD  DEFAULT ((0)) FOR [StateId]
GO
ALTER TABLE [dbo].[Report] ADD  DEFAULT ((0)) FOR [SubmissionReportRequirementId]
GO
ALTER TABLE [dbo].[Report] ADD  DEFAULT ((0)) FOR [AssignUserSubmitReportID]
GO
ALTER TABLE [dbo].[ReportEventResult] ADD  DEFAULT ((0.0)) FOR [TotalMoney]
GO
ALTER TABLE [dbo].[Request] ADD  DEFAULT (N'') FOR [CampusId]
GO
ALTER TABLE [dbo].[Request] ADD  DEFAULT ((0)) FOR [StateId]
GO
ALTER TABLE [dbo].[RequestProtectDetail] ADD  DEFAULT ((0)) FOR [StateId]
GO
ALTER TABLE [dbo].[Semester] ADD  DEFAULT (N'') FOR [CampusId]
GO
ALTER TABLE [dbo].[Staff] ADD  DEFAULT (N'') FOR [Description]
GO
ALTER TABLE [dbo].[SubmissionReportRequirement] ADD  DEFAULT ((0)) FOR [ReportTypeId]
GO
ALTER TABLE [dbo].[Achievement]  WITH CHECK ADD  CONSTRAINT [FK_Achievement_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Achievement] CHECK CONSTRAINT [FK_Achievement_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Achievement]  WITH CHECK ADD  CONSTRAINT [FK_Achievement_Campus_CampusId] FOREIGN KEY([CampusId])
REFERENCES [dbo].[Campus] ([CampusId])
GO
ALTER TABLE [dbo].[Achievement] CHECK CONSTRAINT [FK_Achievement_Campus_CampusId]
GO
ALTER TABLE [dbo].[Achievement]  WITH CHECK ADD  CONSTRAINT [FK_Achievement_Club_ClubCode] FOREIGN KEY([ClubCode])
REFERENCES [dbo].[Club] ([ClubCode])
GO
ALTER TABLE [dbo].[Achievement] CHECK CONSTRAINT [FK_Achievement_Club_ClubCode]
GO
ALTER TABLE [dbo].[Achievement]  WITH CHECK ADD  CONSTRAINT [FK_Achievement_Semester_SemesterCode] FOREIGN KEY([SemesterCode])
REFERENCES [dbo].[Semester] ([SemesterCode])
GO
ALTER TABLE [dbo].[Achievement] CHECK CONSTRAINT [FK_Achievement_Semester_SemesterCode]
GO
ALTER TABLE [dbo].[AdminDepartment]  WITH CHECK ADD  CONSTRAINT [FK_AdminDepartment_Campus_CampusId] FOREIGN KEY([CampusId])
REFERENCES [dbo].[Campus] ([CampusId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AdminDepartment] CHECK CONSTRAINT [FK_AdminDepartment_Campus_CampusId]
GO
ALTER TABLE [dbo].[AdminParticipant]  WITH CHECK ADD  CONSTRAINT [FK_AdminParticipant_AdminDepartment_DepartmentCode] FOREIGN KEY([DepartmentCode])
REFERENCES [dbo].[AdminDepartment] ([DepartmentCode])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AdminParticipant] CHECK CONSTRAINT [FK_AdminParticipant_AdminDepartment_DepartmentCode]
GO
ALTER TABLE [dbo].[AdminParticipant]  WITH CHECK ADD  CONSTRAINT [FK_AdminParticipant_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AdminParticipant] CHECK CONSTRAINT [FK_AdminParticipant_AspNetUsers_UserId]
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
ALTER TABLE [dbo].[AspNetUsers]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUsers_Campus_CampusId] FOREIGN KEY([CampusId])
REFERENCES [dbo].[Campus] ([CampusId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUsers] CHECK CONSTRAINT [FK_AspNetUsers_Campus_CampusId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AssignUserSubmitReport]  WITH CHECK ADD  CONSTRAINT [FK_AssignUserSubmitReport_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AssignUserSubmitReport] CHECK CONSTRAINT [FK_AssignUserSubmitReport_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AssignUserSubmitReport]  WITH CHECK ADD  CONSTRAINT [FK_AssignUserSubmitReport_Club_ClubCode] FOREIGN KEY([ClubCode])
REFERENCES [dbo].[Club] ([ClubCode])
GO
ALTER TABLE [dbo].[AssignUserSubmitReport] CHECK CONSTRAINT [FK_AssignUserSubmitReport_Club_ClubCode]
GO
ALTER TABLE [dbo].[AssignUserSubmitReport]  WITH CHECK ADD  CONSTRAINT [FK_AssignUserSubmitReport_Event_EventId] FOREIGN KEY([EventId])
REFERENCES [dbo].[Event] ([EventId])
GO
ALTER TABLE [dbo].[AssignUserSubmitReport] CHECK CONSTRAINT [FK_AssignUserSubmitReport_Event_EventId]
GO
ALTER TABLE [dbo].[AssignUserSubmitReport]  WITH CHECK ADD  CONSTRAINT [FK_AssignUserSubmitReport_SubmissionReportRequirement_SubmissionReportRequirementId] FOREIGN KEY([SubmissionReportRequirementId])
REFERENCES [dbo].[SubmissionReportRequirement] ([SubmissionReportRequirementId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AssignUserSubmitReport] CHECK CONSTRAINT [FK_AssignUserSubmitReport_SubmissionReportRequirement_SubmissionReportRequirementId]
GO
ALTER TABLE [dbo].[Campus]  WITH CHECK ADD  CONSTRAINT [FK_Campus_EducationalSystem_EduSystemId] FOREIGN KEY([EduSystemId])
REFERENCES [dbo].[EducationalSystem] ([EduSystemId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Campus] CHECK CONSTRAINT [FK_Campus_EducationalSystem_EduSystemId]
GO
ALTER TABLE [dbo].[Club]  WITH CHECK ADD  CONSTRAINT [FK_Club_ClubCategory_ClubCategoryId] FOREIGN KEY([ClubCategoryId])
REFERENCES [dbo].[ClubCategory] ([ClubCategoryId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Club] CHECK CONSTRAINT [FK_Club_ClubCategory_ClubCategoryId]
GO
ALTER TABLE [dbo].[ClubCategory]  WITH CHECK ADD  CONSTRAINT [FK_ClubCategory_Campus_CampusId] FOREIGN KEY([CampusId])
REFERENCES [dbo].[Campus] ([CampusId])
GO
ALTER TABLE [dbo].[ClubCategory] CHECK CONSTRAINT [FK_ClubCategory_Campus_CampusId]
GO
ALTER TABLE [dbo].[ClubParticipation]  WITH CHECK ADD  CONSTRAINT [FK_ClubParticipation_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ClubParticipation] CHECK CONSTRAINT [FK_ClubParticipation_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[ClubParticipation]  WITH CHECK ADD  CONSTRAINT [FK_ClubParticipation_Club_ClubCode] FOREIGN KEY([ClubCode])
REFERENCES [dbo].[Club] ([ClubCode])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ClubParticipation] CHECK CONSTRAINT [FK_ClubParticipation_Club_ClubCode]
GO
ALTER TABLE [dbo].[ClubParticipation]  WITH CHECK ADD  CONSTRAINT [FK_ClubParticipation_Position_Positionid] FOREIGN KEY([Positionid])
REFERENCES [dbo].[Position] ([Positionid])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ClubParticipation] CHECK CONSTRAINT [FK_ClubParticipation_Position_Positionid]
GO
ALTER TABLE [dbo].[Event]  WITH CHECK ADD  CONSTRAINT [FK_Event_AdminDepartment_DepartmentCode] FOREIGN KEY([DepartmentCode])
REFERENCES [dbo].[AdminDepartment] ([DepartmentCode])
GO
ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FK_Event_AdminDepartment_DepartmentCode]
GO
ALTER TABLE [dbo].[Event]  WITH CHECK ADD  CONSTRAINT [FK_Event_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FK_Event_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Event]  WITH CHECK ADD  CONSTRAINT [FK_Event_Campus_CampusId] FOREIGN KEY([CampusId])
REFERENCES [dbo].[Campus] ([CampusId])
GO
ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FK_Event_Campus_CampusId]
GO
ALTER TABLE [dbo].[Event]  WITH CHECK ADD  CONSTRAINT [FK_Event_Club_ClubCode] FOREIGN KEY([ClubCode])
REFERENCES [dbo].[Club] ([ClubCode])
GO
ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FK_Event_Club_ClubCode]
GO
ALTER TABLE [dbo].[Event]  WITH CHECK ADD  CONSTRAINT [FK_Event_EventType_EventTypeId] FOREIGN KEY([EventTypeId])
REFERENCES [dbo].[EventType] ([EventTypeId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FK_Event_EventType_EventTypeId]
GO
ALTER TABLE [dbo].[Event]  WITH CHECK ADD  CONSTRAINT [FK_Event_State_StateId] FOREIGN KEY([StateId])
REFERENCES [dbo].[State] ([StateId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FK_Event_State_StateId]
GO
ALTER TABLE [dbo].[EventImage]  WITH CHECK ADD  CONSTRAINT [FK_EventImage_Event_EventId] FOREIGN KEY([EventId])
REFERENCES [dbo].[Event] ([EventId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EventImage] CHECK CONSTRAINT [FK_EventImage_Event_EventId]
GO
ALTER TABLE [dbo].[EventRegisterParticipate]  WITH CHECK ADD  CONSTRAINT [FK_EventRegisterParticipate_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[EventRegisterParticipate] CHECK CONSTRAINT [FK_EventRegisterParticipate_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[EventRegisterParticipate]  WITH CHECK ADD  CONSTRAINT [FK_EventRegisterParticipate_Event_EventId] FOREIGN KEY([EventId])
REFERENCES [dbo].[Event] ([EventId])
GO
ALTER TABLE [dbo].[EventRegisterParticipate] CHECK CONSTRAINT [FK_EventRegisterParticipate_Event_EventId]
GO
ALTER TABLE [dbo].[EventRegisterParticipate]  WITH CHECK ADD  CONSTRAINT [FK_EventRegisterParticipate_State_StateId] FOREIGN KEY([StateId])
REFERENCES [dbo].[State] ([StateId])
GO
ALTER TABLE [dbo].[EventRegisterParticipate] CHECK CONSTRAINT [FK_EventRegisterParticipate_State_StateId]
GO
ALTER TABLE [dbo].[Guideline]  WITH CHECK ADD  CONSTRAINT [FK_Guideline_Campus_CampusId] FOREIGN KEY([CampusId])
REFERENCES [dbo].[Campus] ([CampusId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Guideline] CHECK CONSTRAINT [FK_Guideline_Campus_CampusId]
GO
ALTER TABLE [dbo].[IntroSetting]  WITH CHECK ADD  CONSTRAINT [FK_IntroSetting_Campus_CampusId] FOREIGN KEY([CampusId])
REFERENCES [dbo].[Campus] ([CampusId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[IntroSetting] CHECK CONSTRAINT [FK_IntroSetting_Campus_CampusId]
GO
ALTER TABLE [dbo].[MeetingRequest]  WITH CHECK ADD  CONSTRAINT [FK_MeetingRequest_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MeetingRequest] CHECK CONSTRAINT [FK_MeetingRequest_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[MeetingRequest]  WITH CHECK ADD  CONSTRAINT [FK_MeetingRequest_Campus_CampusId] FOREIGN KEY([CampusId])
REFERENCES [dbo].[Campus] ([CampusId])
GO
ALTER TABLE [dbo].[MeetingRequest] CHECK CONSTRAINT [FK_MeetingRequest_Campus_CampusId]
GO
ALTER TABLE [dbo].[MeetingRequest]  WITH CHECK ADD  CONSTRAINT [FK_MeetingRequest_Club_ClubCode] FOREIGN KEY([ClubCode])
REFERENCES [dbo].[Club] ([ClubCode])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MeetingRequest] CHECK CONSTRAINT [FK_MeetingRequest_Club_ClubCode]
GO
ALTER TABLE [dbo].[MeetingRequest]  WITH CHECK ADD  CONSTRAINT [FK_MeetingRequest_MeetingStatus_StatusId] FOREIGN KEY([StatusId])
REFERENCES [dbo].[MeetingStatus] ([StatusId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MeetingRequest] CHECK CONSTRAINT [FK_MeetingRequest_MeetingStatus_StatusId]
GO
ALTER TABLE [dbo].[Post]  WITH CHECK ADD  CONSTRAINT [FK_Post_AdminDepartment_DepartmentCode] FOREIGN KEY([DepartmentCode])
REFERENCES [dbo].[AdminDepartment] ([DepartmentCode])
GO
ALTER TABLE [dbo].[Post] CHECK CONSTRAINT [FK_Post_AdminDepartment_DepartmentCode]
GO
ALTER TABLE [dbo].[Post]  WITH CHECK ADD  CONSTRAINT [FK_Post_Campus_CampusId] FOREIGN KEY([CampusId])
REFERENCES [dbo].[Campus] ([CampusId])
GO
ALTER TABLE [dbo].[Post] CHECK CONSTRAINT [FK_Post_Campus_CampusId]
GO
ALTER TABLE [dbo].[Post]  WITH CHECK ADD  CONSTRAINT [FK_Post_Club_ClubCode] FOREIGN KEY([ClubCode])
REFERENCES [dbo].[Club] ([ClubCode])
GO
ALTER TABLE [dbo].[Post] CHECK CONSTRAINT [FK_Post_Club_ClubCode]
GO
ALTER TABLE [dbo].[Post]  WITH CHECK ADD  CONSTRAINT [FK_Post_PostCategory_PostCategoryId] FOREIGN KEY([PostCategoryId])
REFERENCES [dbo].[PostCategory] ([PostCategoryId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Post] CHECK CONSTRAINT [FK_Post_PostCategory_PostCategoryId]
GO
ALTER TABLE [dbo].[Post]  WITH CHECK ADD  CONSTRAINT [FK_Post_State_StateId] FOREIGN KEY([StateId])
REFERENCES [dbo].[State] ([StateId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Post] CHECK CONSTRAINT [FK_Post_State_StateId]
GO
ALTER TABLE [dbo].[Recruitment]  WITH CHECK ADD  CONSTRAINT [FK_Recruitment_Club_ClubCode] FOREIGN KEY([ClubCode])
REFERENCES [dbo].[Club] ([ClubCode])
GO
ALTER TABLE [dbo].[Recruitment] CHECK CONSTRAINT [FK_Recruitment_Club_ClubCode]
GO
ALTER TABLE [dbo].[Report]  WITH CHECK ADD  CONSTRAINT [FK_Report_AssignUserSubmitReport_AssignUserSubmitReportID] FOREIGN KEY([AssignUserSubmitReportID])
REFERENCES [dbo].[AssignUserSubmitReport] ([AssignUserSubmitReportID])
GO
ALTER TABLE [dbo].[Report] CHECK CONSTRAINT [FK_Report_AssignUserSubmitReport_AssignUserSubmitReportID]
GO
ALTER TABLE [dbo].[Report]  WITH CHECK ADD  CONSTRAINT [FK_Report_Campus_CampusId] FOREIGN KEY([CampusId])
REFERENCES [dbo].[Campus] ([CampusId])
GO
ALTER TABLE [dbo].[Report] CHECK CONSTRAINT [FK_Report_Campus_CampusId]
GO
ALTER TABLE [dbo].[Report]  WITH CHECK ADD  CONSTRAINT [FK_Report_Flag_FlagId] FOREIGN KEY([FlagId])
REFERENCES [dbo].[Flag] ([FlagId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Report] CHECK CONSTRAINT [FK_Report_Flag_FlagId]
GO
ALTER TABLE [dbo].[Report]  WITH CHECK ADD  CONSTRAINT [FK_Report_ReportType_ReportTypeId] FOREIGN KEY([ReportTypeId])
REFERENCES [dbo].[ReportType] ([ReportTypeId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Report] CHECK CONSTRAINT [FK_Report_ReportType_ReportTypeId]
GO
ALTER TABLE [dbo].[Report]  WITH CHECK ADD  CONSTRAINT [FK_Report_Semester_SemesterCode] FOREIGN KEY([SemesterCode])
REFERENCES [dbo].[Semester] ([SemesterCode])
GO
ALTER TABLE [dbo].[Report] CHECK CONSTRAINT [FK_Report_Semester_SemesterCode]
GO
ALTER TABLE [dbo].[Report]  WITH CHECK ADD  CONSTRAINT [FK_Report_State_StateId] FOREIGN KEY([StateId])
REFERENCES [dbo].[State] ([StateId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Report] CHECK CONSTRAINT [FK_Report_State_StateId]
GO
ALTER TABLE [dbo].[Report]  WITH CHECK ADD  CONSTRAINT [FK_Report_SubmissionReportRequirement_SubmissionReportRequirementId] FOREIGN KEY([SubmissionReportRequirementId])
REFERENCES [dbo].[SubmissionReportRequirement] ([SubmissionReportRequirementId])
GO
ALTER TABLE [dbo].[Report] CHECK CONSTRAINT [FK_Report_SubmissionReportRequirement_SubmissionReportRequirementId]
GO
ALTER TABLE [dbo].[ReportCost]  WITH CHECK ADD  CONSTRAINT [FK_ReportCost_ReportEventResult_ReportEventResultId] FOREIGN KEY([ReportEventResultId])
REFERENCES [dbo].[ReportEventResult] ([ReportEventResultId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ReportCost] CHECK CONSTRAINT [FK_ReportCost_ReportEventResult_ReportEventResultId]
GO
ALTER TABLE [dbo].[ReportEvent]  WITH CHECK ADD  CONSTRAINT [FK_ReportEvent_Report_ReportEventId] FOREIGN KEY([ReportId])
REFERENCES [dbo].[Report] ([ReportId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ReportEvent] CHECK CONSTRAINT [FK_ReportEvent_Report_ReportEventId]
GO
ALTER TABLE [dbo].[ReportEvent]  WITH CHECK ADD  CONSTRAINT [FK_ReportEvent_ReportEventType_ReportEventTypeID] FOREIGN KEY([ReportEventTypeID])
REFERENCES [dbo].[ReportEventType] ([ReportEventTypeID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ReportEvent] CHECK CONSTRAINT [FK_ReportEvent_ReportEventType_ReportEventTypeID]
GO
ALTER TABLE [dbo].[ReportEventResult]  WITH CHECK ADD  CONSTRAINT [FK_ReportEventResult_Report_ReportId] FOREIGN KEY([ReportId])
REFERENCES [dbo].[Report] ([ReportId])
GO
ALTER TABLE [dbo].[ReportEventResult] CHECK CONSTRAINT [FK_ReportEventResult_Report_ReportId]
GO
ALTER TABLE [dbo].[ReportPoint]  WITH CHECK ADD  CONSTRAINT [FK_ReportPoint_Report_ReportPointID] FOREIGN KEY([ReportId])
REFERENCES [dbo].[Report] ([ReportId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ReportPoint] CHECK CONSTRAINT [FK_ReportPoint_Report_ReportPointID]
GO
ALTER TABLE [dbo].[Request]  WITH CHECK ADD  CONSTRAINT [FK_Request_Campus_CampusId] FOREIGN KEY([CampusId])
REFERENCES [dbo].[Campus] ([CampusId])
GO
ALTER TABLE [dbo].[Request] CHECK CONSTRAINT [FK_Request_Campus_CampusId]
GO
ALTER TABLE [dbo].[Request]  WITH CHECK ADD  CONSTRAINT [FK_Request_Club_ClubCode] FOREIGN KEY([ClubCode])
REFERENCES [dbo].[Club] ([ClubCode])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Request] CHECK CONSTRAINT [FK_Request_Club_ClubCode]
GO
ALTER TABLE [dbo].[Request]  WITH CHECK ADD  CONSTRAINT [FK_Request_RequestType_RequestTypeId] FOREIGN KEY([RequestTypeId])
REFERENCES [dbo].[RequestType] ([RequestTypeId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Request] CHECK CONSTRAINT [FK_Request_RequestType_RequestTypeId]
GO
ALTER TABLE [dbo].[Request]  WITH CHECK ADD  CONSTRAINT [FK_Request_Semester_SemesterCode] FOREIGN KEY([SemesterCode])
REFERENCES [dbo].[Semester] ([SemesterCode])
GO
ALTER TABLE [dbo].[Request] CHECK CONSTRAINT [FK_Request_Semester_SemesterCode]
GO
ALTER TABLE [dbo].[Request]  WITH CHECK ADD  CONSTRAINT [FK_Request_State_StateId] FOREIGN KEY([StateId])
REFERENCES [dbo].[State] ([StateId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Request] CHECK CONSTRAINT [FK_Request_State_StateId]
GO
ALTER TABLE [dbo].[RequestItem]  WITH CHECK ADD  CONSTRAINT [FK_RequestItem_Request_RequestId] FOREIGN KEY([RequestId])
REFERENCES [dbo].[Request] ([RequestId])
GO
ALTER TABLE [dbo].[RequestItem] CHECK CONSTRAINT [FK_RequestItem_Request_RequestId]
GO
ALTER TABLE [dbo].[RequestItem]  WITH CHECK ADD  CONSTRAINT [FK_RequestItem_State_StateId] FOREIGN KEY([StateId])
REFERENCES [dbo].[State] ([StateId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RequestItem] CHECK CONSTRAINT [FK_RequestItem_State_StateId]
GO
ALTER TABLE [dbo].[RequestProtectDetail]  WITH CHECK ADD  CONSTRAINT [FK_RequestProtectDetail_Request_RequestId] FOREIGN KEY([RequestId])
REFERENCES [dbo].[Request] ([RequestId])
GO
ALTER TABLE [dbo].[RequestProtectDetail] CHECK CONSTRAINT [FK_RequestProtectDetail_Request_RequestId]
GO
ALTER TABLE [dbo].[RequestProtectDetail]  WITH CHECK ADD  CONSTRAINT [FK_RequestProtectDetail_State_StateId] FOREIGN KEY([StateId])
REFERENCES [dbo].[State] ([StateId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RequestProtectDetail] CHECK CONSTRAINT [FK_RequestProtectDetail_State_StateId]
GO
ALTER TABLE [dbo].[Semester]  WITH CHECK ADD  CONSTRAINT [FK_Semester_Campus_CampusId] FOREIGN KEY([CampusId])
REFERENCES [dbo].[Campus] ([CampusId])
GO
ALTER TABLE [dbo].[Semester] CHECK CONSTRAINT [FK_Semester_Campus_CampusId]
GO
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD  CONSTRAINT [FK_Staff_AdminDepartment_DepartmentCode] FOREIGN KEY([DepartmentCode])
REFERENCES [dbo].[AdminDepartment] ([DepartmentCode])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Staff] CHECK CONSTRAINT [FK_Staff_AdminDepartment_DepartmentCode]
GO
ALTER TABLE [dbo].[SubmissionReportRequirement]  WITH CHECK ADD  CONSTRAINT [FK_SubmissionReportRequirement_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SubmissionReportRequirement] CHECK CONSTRAINT [FK_SubmissionReportRequirement_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[SubmissionReportRequirement]  WITH CHECK ADD  CONSTRAINT [FK_SubmissionReportRequirement_Campus_CampusId] FOREIGN KEY([CampusId])
REFERENCES [dbo].[Campus] ([CampusId])
GO
ALTER TABLE [dbo].[SubmissionReportRequirement] CHECK CONSTRAINT [FK_SubmissionReportRequirement_Campus_CampusId]
GO
ALTER TABLE [dbo].[SubmissionReportRequirement]  WITH CHECK ADD  CONSTRAINT [FK_SubmissionReportRequirement_ReportType_ReportTypeId] FOREIGN KEY([ReportTypeId])
REFERENCES [dbo].[ReportType] ([ReportTypeId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SubmissionReportRequirement] CHECK CONSTRAINT [FK_SubmissionReportRequirement_ReportType_ReportTypeId]
GO
ALTER TABLE [dbo].[SubmissionReportRequirement]  WITH CHECK ADD  CONSTRAINT [FK_SubmissionReportRequirement_Semester_SemesterCode] FOREIGN KEY([SemesterCode])
REFERENCES [dbo].[Semester] ([SemesterCode])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SubmissionReportRequirement] CHECK CONSTRAINT [FK_SubmissionReportRequirement_Semester_SemesterCode]
GO
