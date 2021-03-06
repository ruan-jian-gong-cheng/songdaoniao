USE [master]
GO
/****** Object:  Database [paotui]    Script Date: 2022/4/24 11:04:30 ******/
CREATE DATABASE [paotui]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'paotui', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\paotui.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'paotui_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\paotui_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [paotui] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [paotui].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [paotui] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [paotui] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [paotui] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [paotui] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [paotui] SET ARITHABORT OFF 
GO
ALTER DATABASE [paotui] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [paotui] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [paotui] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [paotui] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [paotui] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [paotui] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [paotui] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [paotui] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [paotui] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [paotui] SET  DISABLE_BROKER 
GO
ALTER DATABASE [paotui] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [paotui] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [paotui] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [paotui] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [paotui] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [paotui] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [paotui] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [paotui] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [paotui] SET  MULTI_USER 
GO
ALTER DATABASE [paotui] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [paotui] SET DB_CHAINING OFF 
GO
ALTER DATABASE [paotui] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [paotui] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [paotui] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [paotui] SET QUERY_STORE = OFF
GO
USE [paotui]
GO
/****** Object:  Table [dbo].[account]    Script Date: 2022/4/24 11:04:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[account](
	[CardNumber] [varchar](30) NOT NULL,
	[Password] [varchar](30) NOT NULL,
	[Name] [varchar](30) NOT NULL,
	[Nickname] [varchar](30) NOT NULL,
	[Telephone] [char](30) NOT NULL,
	[Address] [varchar](80) NOT NULL,
	[Email] [varchar](30) NULL,
	[ApplyFor] [varchar](10) NULL,
 CONSTRAINT [PK_account] PRIMARY KEY CLUSTERED 
(
	[CardNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[administrator]    Script Date: 2022/4/24 11:04:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[administrator](
	[AdminID] [varchar](30) NOT NULL,
	[AdminName] [varchar](30) NOT NULL,
 CONSTRAINT [PK_administrator] PRIMARY KEY CLUSTERED 
(
	[AdminID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[client]    Script Date: 2022/4/24 11:04:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[client](
	[ClientID] [varchar](30) NOT NULL,
	[CardNumber] [varchar](30) NOT NULL,
 CONSTRAINT [PK_client] PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EvaluationForm]    Script Date: 2022/4/24 11:04:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EvaluationForm](
	[RunnerID] [varchar](30) NOT NULL,
	[RunnerName] [varchar](30) NOT NULL,
	[CardNumber] [varchar](30) NOT NULL,
	[Summary] [char](10) NULL,
	[Positive] [char](10) NULL,
	[Negative] [char](10) NULL,
 CONSTRAINT [PK_EvaluationForm] PRIMARY KEY CLUSTERED 
(
	[RunnerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FormerInformation]    Script Date: 2022/4/24 11:04:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FormerInformation](
	[CardNumber] [varchar](30) NOT NULL,
	[ClientName] [varchar](30) NOT NULL,
	[PrimaryPhone] [varchar](30) NULL,
	[PrimaryAddress] [varchar](50) NULL,
 CONSTRAINT [PK_FormerInformation] PRIMARY KEY CLUSTERED 
(
	[CardNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[order]    Script Date: 2022/4/24 11:04:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[order](
	[OrderNumber] [varchar](30) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Text] [varchar](100) NOT NULL,
	[ClientID] [varchar](30) NOT NULL,
	[RunnerID] [varchar](30) NULL,
	[ClientPhone] [char](30) NOT NULL,
	[RunnerPhone] [char](30) NULL,
	[Evaluate] [varchar](100) NULL,
	[Tip] [char](10) NULL,
	[Type] [varchar](50) NULL,
	[State] [varchar](30) NOT NULL
 CONSTRAINT [PK_order] PRIMARY KEY CLUSTERED 
(
	[OrderNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RankingList]    Script Date: 2022/4/24 11:04:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RankingList](
	[RunnerID] [varchar](30) NOT NULL,
	[RunnerName] [varchar](30) NOT NULL,
	[Ranking] [int] NULL,
	[TipSum] [char](10) NULL,
 CONSTRAINT [PK_RankingList] PRIMARY KEY CLUSTERED 
(
	[RunnerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[runner]    Script Date: 2022/4/24 11:04:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[runner](
	[RunnerID] [varchar](30) NOT NULL,
	[CardNumber] [varchar](30) NOT NULL,
	[Ranking] [int] NULL,
	[TipSum] [char](10) NULL,
	[Effective] [varchar](10) NULL,
 CONSTRAINT [PK_runner] PRIMARY KEY CLUSTERED 
(
	[RunnerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[account] ([CardNumber], [Password], [Name], [Nickname], [Telephone], [Address], [Email],[ApplyFor]) VALUES (N'1000000001', N'QWE123', N'管理员', N'管理员', N'13913915151                   ', N'上师大',NULL,NULL)
INSERT [dbo].[account] ([CardNumber], [Password], [Name], [Nickname], [Telephone], [Address], [Email],[ApplyFor]) VALUES (N'1000123456', N'123', N'张一', N'One', N'13912345678                   ', N'上师大三教', N'1000123456@shnu.edu.cn',N'未申请')
INSERT [dbo].[account] ([CardNumber], [Password], [Name], [Nickname], [Telephone], [Address], [Email],[ApplyFor]) VALUES (N'1000481234', N'456', N'李四', N'Serendipity', N'13809854321                   ', N'上师大1号楼', NULL,N'已通过')
INSERT [dbo].[administrator] ([AdminID], [AdminName]) VALUES (N'0001', N'王五')
INSERT [dbo].[client] ([ClientID], [CardNumber]) VALUES (N'10001', N'1000123456')
INSERT [dbo].[client] ([ClientID], [CardNumber]) VALUES (N'10002', N'1000481234')
INSERT [dbo].[EvaluationForm] ([RunnerID], [RunnerName], [CardNumber], [Summary], [Positive], [Negative]) VALUES (N'20001', N'李四', N'1000481234', NULL, NULL, NULL)
INSERT [dbo].[FormerInformation] ([CardNumber], [ClientName], [PrimaryPhone], [PrimaryAddress]) VALUES (N'1000123456', N'张一', NULL, NULL)
INSERT [dbo].[order] ([OrderNumber], [Date], [Text], [ClientID], [RunnerID], [ClientPhone], [RunnerPhone], [Evaluate], [Tip],[State]) VALUES (N'110001', CAST(N'2022-01-01T00:00:00.000' AS DateTime), N'送思修书到三教', N'10001', N'20001', N'13912345678                   ', N'13809854321                   ', NULL, NULL,N'已完成')
INSERT [dbo].[RankingList] ([RunnerID], [RunnerName], [Ranking], [TipSum]) VALUES (N'20001', N'李四', NULL, NULL)
INSERT [dbo].[runner] ([RunnerID], [CardNumber], [Ranking], [TipSum],[Effective] )VALUES (N'20001', N'1000481234', NULL, NULL,N'有效')
ALTER TABLE [dbo].[client]  WITH CHECK ADD  CONSTRAINT [FK_client_account] FOREIGN KEY([CardNumber])
REFERENCES [dbo].[account] ([CardNumber])
GO
ALTER TABLE [dbo].[client] CHECK CONSTRAINT [FK_client_account]
GO
ALTER TABLE [dbo].[EvaluationForm]  WITH CHECK ADD  CONSTRAINT [FK_EvaluationForm_account] FOREIGN KEY([CardNumber])
REFERENCES [dbo].[account] ([CardNumber])
GO
ALTER TABLE [dbo].[EvaluationForm] CHECK CONSTRAINT [FK_EvaluationForm_account]
GO
ALTER TABLE [dbo].[order]  WITH CHECK ADD  CONSTRAINT [FK_order_client] FOREIGN KEY([ClientID])
REFERENCES [dbo].[client] ([ClientID])
GO
ALTER TABLE [dbo].[order] CHECK CONSTRAINT [FK_order_client]
GO
ALTER TABLE [dbo].[order]  WITH CHECK ADD  CONSTRAINT [FK_order_runner] FOREIGN KEY([RunnerID])
REFERENCES [dbo].[runner] ([RunnerID])
GO
ALTER TABLE [dbo].[order] CHECK CONSTRAINT [FK_order_runner]
GO
ALTER TABLE [dbo].[runner]  WITH CHECK ADD  CONSTRAINT [FK_runner_account] FOREIGN KEY([CardNumber])
REFERENCES [dbo].[account] ([CardNumber])
GO
ALTER TABLE [dbo].[runner] CHECK CONSTRAINT [FK_runner_account]
GO
USE [master]
GO
ALTER DATABASE [paotui] SET  READ_WRITE 
GO
