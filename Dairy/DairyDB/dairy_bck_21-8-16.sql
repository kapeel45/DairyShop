USE [master]
GO
/****** Object:  Database [TeamedDB]    Script Date: 8/21/2016 1:01:34 AM ******/
CREATE DATABASE [TeamedDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TeamedDB_Data', FILENAME = N'c:\dzsqls\TeamedDB.mdf' , SIZE = 3136KB , MAXSIZE = 15360KB , FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TeamedDB_Logs', FILENAME = N'c:\dzsqls\TeamedDB.ldf' , SIZE = 1024KB , MAXSIZE = 20480KB , FILEGROWTH = 10%)
GO
ALTER DATABASE [TeamedDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TeamedDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TeamedDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TeamedDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TeamedDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TeamedDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TeamedDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [TeamedDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TeamedDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [TeamedDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TeamedDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TeamedDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TeamedDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TeamedDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TeamedDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TeamedDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TeamedDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TeamedDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [TeamedDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TeamedDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TeamedDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TeamedDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TeamedDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TeamedDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TeamedDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TeamedDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TeamedDB] SET  MULTI_USER 
GO
ALTER DATABASE [TeamedDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TeamedDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TeamedDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TeamedDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [TeamedDB]
GO
/****** Object:  User [teamed_sql]    Script Date: 8/21/2016 1:01:42 AM ******/
CREATE USER [teamed_sql] FOR LOGIN [teamed_sql] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [teamed_sql]
GO
/****** Object:  Schema [teamed_sql]    Script Date: 8/21/2016 1:01:45 AM ******/
CREATE SCHEMA [teamed_sql]
GO
/****** Object:  Table [dbo].[ItemMaster]    Script Date: 8/21/2016 1:01:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemMaster](
	[ItemId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Discription] [nvarchar](max) NULL,
	[UnitId] [int] NULL,
	[IsDelete] [bit] NULL,
	[DOC] [datetime] NULL,
 CONSTRAINT [PK_ItemMaster] PRIMARY KEY CLUSTERED 
(
	[ItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderCancelMaster]    Script Date: 8/21/2016 1:01:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderCancelMaster](
	[OrderCancelId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[ItemId] [int] NULL,
	[Quantity] [int] NULL,
	[TransType] [nvarchar](20) NULL,
	[Status] [int] NULL,
	[ForDate] [datetime] NULL,
	[DOC] [datetime] NULL,
	[IsDelete] [bit] NULL,
 CONSTRAINT [PK_OrderCancelMaster] PRIMARY KEY CLUSTERED 
(
	[OrderCancelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Permission]    Script Date: 8/21/2016 1:01:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permission](
	[PermissionId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Permission] PRIMARY KEY CLUSTERED 
(
	[PermissionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PermissionType]    Script Date: 8/21/2016 1:01:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PermissionType](
	[TypeId] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [nvarchar](50) NULL,
 CONSTRAINT [PK_PermissionType] PRIMARY KEY CLUSTERED 
(
	[TypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PriceMaster]    Script Date: 8/21/2016 1:01:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PriceMaster](
	[PriceId] [int] IDENTITY(1,1) NOT NULL,
	[ItemId] [int] NULL,
	[Price] [decimal](18, 0) NULL,
	[Date] [datetime] NULL,
	[IsDelete] [bit] NULL,
 CONSTRAINT [PK_PriceMaster] PRIMARY KEY CLUSTERED 
(
	[PriceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RoleMaster]    Script Date: 8/21/2016 1:01:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RoleMaster](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](30) NULL,
	[IsDelete] [bit] NULL,
	[DOC] [datetime] NULL,
 CONSTRAINT [PK_RoleMaster] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RoleRuleRelation]    Script Date: 8/21/2016 1:01:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleRuleRelation](
	[RoleRuleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NULL,
	[RuleId] [int] NULL,
	[IsDelete] [bit] NULL,
 CONSTRAINT [PK_RoleRuleRelation] PRIMARY KEY CLUSTERED 
(
	[RoleRuleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RuleMaster]    Script Date: 8/21/2016 1:01:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RuleMaster](
	[RuleId] [int] IDENTITY(1,1) NOT NULL,
	[TypeId] [int] NULL,
	[PermissionId] [int] NULL,
	[IsDelete] [bit] NULL,
	[DOC] [datetime] NULL,
 CONSTRAINT [PK_RuleMaster] PRIMARY KEY CLUSTERED 
(
	[RuleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SaleDtlMaster]    Script Date: 8/21/2016 1:01:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SaleDtlMaster](
	[SaleDtlID] [int] IDENTITY(1,1) NOT NULL,
	[ItemId] [int] NULL,
	[Quantity] [int] NULL,
	[Remark] [nvarchar](max) NULL,
	[SaleId] [int] NULL,
	[IsDelete] [bit] NULL,
	[DOC] [datetime] NULL,
 CONSTRAINT [PK_SaleDtlMaster] PRIMARY KEY CLUSTERED 
(
	[SaleDtlID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SaleMaster]    Script Date: 8/21/2016 1:01:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SaleMaster](
	[SaleId] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NULL,
	[CustId] [int] NULL,
	[UserId] [int] NULL,
	[Amount] [decimal](18, 5) NULL,
	[IsDelete] [bit] NULL,
	[DOC] [datetime] NULL,
 CONSTRAINT [PK_SaleMaster] PRIMARY KEY CLUSTERED 
(
	[SaleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ShopMaster]    Script Date: 8/21/2016 1:01:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShopMaster](
	[ShopId] [int] IDENTITY(1,1) NOT NULL,
	[ShopName] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[IsDelete] [bit] NULL,
	[DOC] [datetime] NULL,
 CONSTRAINT [PK_ShopMaster] PRIMARY KEY CLUSTERED 
(
	[ShopId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StatusMaster]    Script Date: 8/21/2016 1:01:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StatusMaster](
	[StatusMasterId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_StatusMaster] PRIMARY KEY CLUSTERED 
(
	[StatusMasterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Transection]    Script Date: 8/21/2016 1:01:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transection](
	[TransId] [int] IDENTITY(1,1) NOT NULL,
	[CustomUniqueId] [nvarchar](max) NULL,
	[ResponceUniqueId] [nvarchar](max) NULL,
	[Date] [datetime] NULL,
	[UserId] [int] NULL,
	[TransType] [nchar](10) NULL,
	[Amount] [decimal](18, 5) NULL,
	[Remark] [nvarchar](max) NULL,
	[TransectionId] [nvarchar](50) NULL,
	[SaleId] [int] NULL,
 CONSTRAINT [PK_Transection] PRIMARY KEY CLUSTERED 
(
	[TransId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UnitMaster]    Script Date: 8/21/2016 1:01:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UnitMaster](
	[UnitId] [int] IDENTITY(1,1) NOT NULL,
	[UnitName] [nvarchar](50) NULL,
 CONSTRAINT [PK_UnitMaster] PRIMARY KEY CLUSTERED 
(
	[UnitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserItem]    Script Date: 8/21/2016 1:01:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserItem](
	[UserItemId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[ItemId] [int] NULL,
	[Quantity] [int] NULL,
	[Scheduled] [nvarchar](max) NULL,
	[IsDelete] [bit] NULL,
	[DOC] [datetime] NULL,
 CONSTRAINT [PK_UserItem] PRIMARY KEY CLUSTERED 
(
	[UserItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserMaster]    Script Date: 8/21/2016 1:01:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserMaster](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Address] [varchar](max) NULL,
	[MobileNo] [nchar](10) NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[RoleId] [int] NULL,
	[ShopId] [int] NULL,
	[ActiveBalance] [decimal](18, 5) NULL,
	[IsDelete] [bit] NULL,
	[DOC] [datetime] NULL,
 CONSTRAINT [PK_UserMaster] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[ItemMaster] ON 

INSERT [dbo].[ItemMaster] ([ItemId], [Name], [Discription], [UnitId], [IsDelete], [DOC]) VALUES (1, N'Amul milk', N'Amol milk jhsdfj', 1, 0, CAST(0x0000A5F20002C18D AS DateTime))
INSERT [dbo].[ItemMaster] ([ItemId], [Name], [Discription], [UnitId], [IsDelete], [DOC]) VALUES (2, N'Milk B', N'Bafelow Milk', 1, 0, CAST(0x0000A63801657E09 AS DateTime))
INSERT [dbo].[ItemMaster] ([ItemId], [Name], [Discription], [UnitId], [IsDelete], [DOC]) VALUES (3, N'Milk C', N'Caw Nilk', 1, 0, CAST(0x0000A6380165A33A AS DateTime))
INSERT [dbo].[ItemMaster] ([ItemId], [Name], [Discription], [UnitId], [IsDelete], [DOC]) VALUES (4, N'Taak', N'Butter Milk', 1, 0, CAST(0x0000A6380165C368 AS DateTime))
INSERT [dbo].[ItemMaster] ([ItemId], [Name], [Discription], [UnitId], [IsDelete], [DOC]) VALUES (5, N'Loni', N'Loni', 2, 0, CAST(0x0000A63801666467 AS DateTime))
INSERT [dbo].[ItemMaster] ([ItemId], [Name], [Discription], [UnitId], [IsDelete], [DOC]) VALUES (6, N'Tup', N'Tupe', 2, 0, CAST(0x0000A63801669F2B AS DateTime))
INSERT [dbo].[ItemMaster] ([ItemId], [Name], [Discription], [UnitId], [IsDelete], [DOC]) VALUES (13, N'Chakka', NULL, 2, 0, CAST(0x0000A645017CF465 AS DateTime))
SET IDENTITY_INSERT [dbo].[ItemMaster] OFF
SET IDENTITY_INSERT [dbo].[Permission] ON 

INSERT [dbo].[Permission] ([PermissionId], [Name]) VALUES (1, N'Insert')
INSERT [dbo].[Permission] ([PermissionId], [Name]) VALUES (2, N'Delete')
INSERT [dbo].[Permission] ([PermissionId], [Name]) VALUES (3, N'View')
INSERT [dbo].[Permission] ([PermissionId], [Name]) VALUES (4, N'Update')
SET IDENTITY_INSERT [dbo].[Permission] OFF
SET IDENTITY_INSERT [dbo].[PermissionType] ON 

INSERT [dbo].[PermissionType] ([TypeId], [TypeName]) VALUES (1, N'Cutomer')
INSERT [dbo].[PermissionType] ([TypeId], [TypeName]) VALUES (2, N'Order')
SET IDENTITY_INSERT [dbo].[PermissionType] OFF
SET IDENTITY_INSERT [dbo].[PriceMaster] ON 

INSERT [dbo].[PriceMaster] ([PriceId], [ItemId], [Price], [Date], [IsDelete]) VALUES (25, 13, CAST(200 AS Decimal(18, 0)), CAST(0x0000A645017CF466 AS DateTime), 0)
INSERT [dbo].[PriceMaster] ([PriceId], [ItemId], [Price], [Date], [IsDelete]) VALUES (26, 1, CAST(40 AS Decimal(18, 0)), CAST(0x0000A645017D2CE5 AS DateTime), 0)
INSERT [dbo].[PriceMaster] ([PriceId], [ItemId], [Price], [Date], [IsDelete]) VALUES (27, 2, CAST(40 AS Decimal(18, 0)), CAST(0x0000A6450186644A AS DateTime), 0)
INSERT [dbo].[PriceMaster] ([PriceId], [ItemId], [Price], [Date], [IsDelete]) VALUES (28, 2, CAST(46 AS Decimal(18, 0)), CAST(0x0000A6450186A602 AS DateTime), 0)
INSERT [dbo].[PriceMaster] ([PriceId], [ItemId], [Price], [Date], [IsDelete]) VALUES (29, 3, CAST(40 AS Decimal(18, 0)), CAST(0x0000A6450186BE3E AS DateTime), 0)
INSERT [dbo].[PriceMaster] ([PriceId], [ItemId], [Price], [Date], [IsDelete]) VALUES (30, 4, CAST(30 AS Decimal(18, 0)), CAST(0x0000A6450186F821 AS DateTime), 0)
INSERT [dbo].[PriceMaster] ([PriceId], [ItemId], [Price], [Date], [IsDelete]) VALUES (31, 5, CAST(380 AS Decimal(18, 0)), CAST(0x0000A64501870A9D AS DateTime), 0)
INSERT [dbo].[PriceMaster] ([PriceId], [ItemId], [Price], [Date], [IsDelete]) VALUES (32, 6, CAST(500 AS Decimal(18, 0)), CAST(0x0000A64501871C04 AS DateTime), 0)
INSERT [dbo].[PriceMaster] ([PriceId], [ItemId], [Price], [Date], [IsDelete]) VALUES (33, 13, CAST(300 AS Decimal(18, 0)), CAST(0x0000A64600EEC292 AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[PriceMaster] OFF
SET IDENTITY_INSERT [dbo].[RoleMaster] ON 

INSERT [dbo].[RoleMaster] ([RoleId], [RoleName], [IsDelete], [DOC]) VALUES (1, N'Admin', 0, CAST(0x0000A5F20003AF03 AS DateTime))
INSERT [dbo].[RoleMaster] ([RoleId], [RoleName], [IsDelete], [DOC]) VALUES (2, N'Cutomer', 0, CAST(0x0000A5F20003B609 AS DateTime))
INSERT [dbo].[RoleMaster] ([RoleId], [RoleName], [IsDelete], [DOC]) VALUES (3, N'Employee', 0, CAST(0x0000A5F20003B94F AS DateTime))
SET IDENTITY_INSERT [dbo].[RoleMaster] OFF
SET IDENTITY_INSERT [dbo].[RoleRuleRelation] ON 

INSERT [dbo].[RoleRuleRelation] ([RoleRuleId], [RoleId], [RuleId], [IsDelete]) VALUES (1, 1, 1, 0)
INSERT [dbo].[RoleRuleRelation] ([RoleRuleId], [RoleId], [RuleId], [IsDelete]) VALUES (2, 1, 2, 0)
INSERT [dbo].[RoleRuleRelation] ([RoleRuleId], [RoleId], [RuleId], [IsDelete]) VALUES (3, 1, 3, 0)
INSERT [dbo].[RoleRuleRelation] ([RoleRuleId], [RoleId], [RuleId], [IsDelete]) VALUES (4, 1, 4, 0)
INSERT [dbo].[RoleRuleRelation] ([RoleRuleId], [RoleId], [RuleId], [IsDelete]) VALUES (5, 2, 3, 0)
INSERT [dbo].[RoleRuleRelation] ([RoleRuleId], [RoleId], [RuleId], [IsDelete]) VALUES (6, 2, 4, 0)
SET IDENTITY_INSERT [dbo].[RoleRuleRelation] OFF
SET IDENTITY_INSERT [dbo].[RuleMaster] ON 

INSERT [dbo].[RuleMaster] ([RuleId], [TypeId], [PermissionId], [IsDelete], [DOC]) VALUES (1, 1, 1, 0, NULL)
INSERT [dbo].[RuleMaster] ([RuleId], [TypeId], [PermissionId], [IsDelete], [DOC]) VALUES (2, 1, 2, 0, NULL)
INSERT [dbo].[RuleMaster] ([RuleId], [TypeId], [PermissionId], [IsDelete], [DOC]) VALUES (3, 2, 3, 0, NULL)
INSERT [dbo].[RuleMaster] ([RuleId], [TypeId], [PermissionId], [IsDelete], [DOC]) VALUES (4, 2, 4, 0, NULL)
SET IDENTITY_INSERT [dbo].[RuleMaster] OFF
SET IDENTITY_INSERT [dbo].[SaleDtlMaster] ON 

INSERT [dbo].[SaleDtlMaster] ([SaleDtlID], [ItemId], [Quantity], [Remark], [SaleId], [IsDelete], [DOC]) VALUES (67, 1, 1, N'remark', 41, 0, CAST(0x0000A646002EC7D7 AS DateTime))
INSERT [dbo].[SaleDtlMaster] ([SaleDtlID], [ItemId], [Quantity], [Remark], [SaleId], [IsDelete], [DOC]) VALUES (68, 1, 1, N'remark', 41, 0, CAST(0x0000A646002EC7D7 AS DateTime))
INSERT [dbo].[SaleDtlMaster] ([SaleDtlID], [ItemId], [Quantity], [Remark], [SaleId], [IsDelete], [DOC]) VALUES (69, 2, 1, N'remark', 42, 0, CAST(0x0000A64600322614 AS DateTime))
INSERT [dbo].[SaleDtlMaster] ([SaleDtlID], [ItemId], [Quantity], [Remark], [SaleId], [IsDelete], [DOC]) VALUES (70, 1, 1, N'remark', 42, 0, CAST(0x0000A64600322614 AS DateTime))
INSERT [dbo].[SaleDtlMaster] ([SaleDtlID], [ItemId], [Quantity], [Remark], [SaleId], [IsDelete], [DOC]) VALUES (71, 3, 2, N'remark', 45, 0, CAST(0x0000A64600345AEB AS DateTime))
INSERT [dbo].[SaleDtlMaster] ([SaleDtlID], [ItemId], [Quantity], [Remark], [SaleId], [IsDelete], [DOC]) VALUES (72, 1, 1, N'remark', 45, 0, CAST(0x0000A64600345AEB AS DateTime))
INSERT [dbo].[SaleDtlMaster] ([SaleDtlID], [ItemId], [Quantity], [Remark], [SaleId], [IsDelete], [DOC]) VALUES (80, 4, 1, N'remark', 127, 0, CAST(0x0000A64600CE9E7D AS DateTime))
INSERT [dbo].[SaleDtlMaster] ([SaleDtlID], [ItemId], [Quantity], [Remark], [SaleId], [IsDelete], [DOC]) VALUES (81, 3, 1, N'remark', 127, 0, CAST(0x0000A64600CE9E7D AS DateTime))
SET IDENTITY_INSERT [dbo].[SaleDtlMaster] OFF
SET IDENTITY_INSERT [dbo].[SaleMaster] ON 

INSERT [dbo].[SaleMaster] ([SaleId], [Date], [CustId], [UserId], [Amount], [IsDelete], [DOC]) VALUES (41, CAST(0x0000A646002EC7D6 AS DateTime), 36, 31, CAST(80.00000 AS Decimal(18, 5)), 0, CAST(0x0000A646002EC7D6 AS DateTime))
INSERT [dbo].[SaleMaster] ([SaleId], [Date], [CustId], [UserId], [Amount], [IsDelete], [DOC]) VALUES (42, CAST(0x0000A64600322614 AS DateTime), 37, 31, CAST(86.00000 AS Decimal(18, 5)), 0, CAST(0x0000A64600322614 AS DateTime))
INSERT [dbo].[SaleMaster] ([SaleId], [Date], [CustId], [UserId], [Amount], [IsDelete], [DOC]) VALUES (43, CAST(0x0000A64600336178 AS DateTime), 12, 31, CAST(12345.00000 AS Decimal(18, 5)), 0, CAST(0x0000A64600336178 AS DateTime))
INSERT [dbo].[SaleMaster] ([SaleId], [Date], [CustId], [UserId], [Amount], [IsDelete], [DOC]) VALUES (44, CAST(0x0000A64600339DC2 AS DateTime), 12, 31, CAST(12345.00000 AS Decimal(18, 5)), 0, CAST(0x0000A64600339DC2 AS DateTime))
INSERT [dbo].[SaleMaster] ([SaleId], [Date], [CustId], [UserId], [Amount], [IsDelete], [DOC]) VALUES (45, CAST(0x0000A64600345AEB AS DateTime), 38, 32, CAST(120.00000 AS Decimal(18, 5)), 0, CAST(0x0000A64600345AEB AS DateTime))
INSERT [dbo].[SaleMaster] ([SaleId], [Date], [CustId], [UserId], [Amount], [IsDelete], [DOC]) VALUES (46, CAST(0x0000A64600349059 AS DateTime), 12, 32, CAST(12345.00000 AS Decimal(18, 5)), 0, CAST(0x0000A64600349059 AS DateTime))
INSERT [dbo].[SaleMaster] ([SaleId], [Date], [CustId], [UserId], [Amount], [IsDelete], [DOC]) VALUES (127, CAST(0x0000A64600CE9E7B AS DateTime), 36, 31, CAST(70.00000 AS Decimal(18, 5)), 0, CAST(0x0000A64600CE9E7B AS DateTime))
INSERT [dbo].[SaleMaster] ([SaleId], [Date], [CustId], [UserId], [Amount], [IsDelete], [DOC]) VALUES (133, CAST(0x0000A64600D3FB23 AS DateTime), 36, 31, CAST(44.00000 AS Decimal(18, 5)), 0, CAST(0x0000A64600D3FB23 AS DateTime))
INSERT [dbo].[SaleMaster] ([SaleId], [Date], [CustId], [UserId], [Amount], [IsDelete], [DOC]) VALUES (135, CAST(0x0000A64600D8F45B AS DateTime), 37, 31, CAST(10.00000 AS Decimal(18, 5)), 0, CAST(0x0000A64600D8F45B AS DateTime))
INSERT [dbo].[SaleMaster] ([SaleId], [Date], [CustId], [UserId], [Amount], [IsDelete], [DOC]) VALUES (136, CAST(0x0000A64600DE0B23 AS DateTime), 36, 31, CAST(10.00000 AS Decimal(18, 5)), 0, CAST(0x0000A64600DE0B23 AS DateTime))
SET IDENTITY_INSERT [dbo].[SaleMaster] OFF
SET IDENTITY_INSERT [dbo].[ShopMaster] ON 

INSERT [dbo].[ShopMaster] ([ShopId], [ShopName], [Address], [IsDelete], [DOC]) VALUES (1, N'Admin Shop', N'Thergoan', 0, CAST(0x0000A5F2000267C3 AS DateTime))
INSERT [dbo].[ShopMaster] ([ShopId], [ShopName], [Address], [IsDelete], [DOC]) VALUES (10, N'Shop 1', N'Sanagavi', 0, CAST(0x0000A645017DAE0C AS DateTime))
INSERT [dbo].[ShopMaster] ([ShopId], [ShopName], [Address], [IsDelete], [DOC]) VALUES (11, N'Shop 2', N'Hinjewadi', 0, CAST(0x0000A645017DD35E AS DateTime))
SET IDENTITY_INSERT [dbo].[ShopMaster] OFF
SET IDENTITY_INSERT [dbo].[StatusMaster] ON 

INSERT [dbo].[StatusMaster] ([StatusMasterId], [Name]) VALUES (1, N'Pending')
INSERT [dbo].[StatusMaster] ([StatusMasterId], [Name]) VALUES (2, N'Complete')
INSERT [dbo].[StatusMaster] ([StatusMasterId], [Name]) VALUES (3, N'Cancel')
SET IDENTITY_INSERT [dbo].[StatusMaster] OFF
SET IDENTITY_INSERT [dbo].[Transection] ON 

INSERT [dbo].[Transection] ([TransId], [CustomUniqueId], [ResponceUniqueId], [Date], [UserId], [TransType], [Amount], [Remark], [TransectionId], [SaleId]) VALUES (38, N'15cd8198-140d-4a63-9450-807f007f3c4d', N'0', CAST(0x0000A646002EC7D9 AS DateTime), 31, N'cr        ', CAST(80.00000 AS Decimal(18, 5)), N'', NULL, 41)
INSERT [dbo].[Transection] ([TransId], [CustomUniqueId], [ResponceUniqueId], [Date], [UserId], [TransType], [Amount], [Remark], [TransectionId], [SaleId]) VALUES (39, N'54afc519-2eae-43e9-8e39-e73fc55ac913', N'0', CAST(0x0000A64600322614 AS DateTime), 31, N'cr        ', CAST(86.00000 AS Decimal(18, 5)), N'', NULL, 42)
INSERT [dbo].[Transection] ([TransId], [CustomUniqueId], [ResponceUniqueId], [Date], [UserId], [TransType], [Amount], [Remark], [TransectionId], [SaleId]) VALUES (40, NULL, NULL, CAST(0x0000A64600336179 AS DateTime), 31, N'Manual    ', CAST(12345.00000 AS Decimal(18, 5)), N'Best Remark', NULL, 43)
INSERT [dbo].[Transection] ([TransId], [CustomUniqueId], [ResponceUniqueId], [Date], [UserId], [TransType], [Amount], [Remark], [TransectionId], [SaleId]) VALUES (41, NULL, NULL, CAST(0x0000A64600339DC2 AS DateTime), 31, N'Manual    ', CAST(12345.00000 AS Decimal(18, 5)), N'Best Remark', NULL, 44)
INSERT [dbo].[Transection] ([TransId], [CustomUniqueId], [ResponceUniqueId], [Date], [UserId], [TransType], [Amount], [Remark], [TransectionId], [SaleId]) VALUES (42, N'c3b0f4cc-11e8-43d8-bb05-e74c747fb632', N'0', CAST(0x0000A64600345AEC AS DateTime), 32, N'cr        ', CAST(120.00000 AS Decimal(18, 5)), N'', NULL, 45)
INSERT [dbo].[Transection] ([TransId], [CustomUniqueId], [ResponceUniqueId], [Date], [UserId], [TransType], [Amount], [Remark], [TransectionId], [SaleId]) VALUES (43, NULL, NULL, CAST(0x0000A64600349059 AS DateTime), 32, N'Manual    ', CAST(12345.00000 AS Decimal(18, 5)), N'Best Remark', NULL, 46)
INSERT [dbo].[Transection] ([TransId], [CustomUniqueId], [ResponceUniqueId], [Date], [UserId], [TransType], [Amount], [Remark], [TransectionId], [SaleId]) VALUES (44, N'ee64a487-14bc-413d-82f9-74c3a2883670', N'0', CAST(0x0000A64600CE9E7F AS DateTime), 36, N'Cr        ', CAST(70.00000 AS Decimal(18, 5)), N'', NULL, 127)
INSERT [dbo].[Transection] ([TransId], [CustomUniqueId], [ResponceUniqueId], [Date], [UserId], [TransType], [Amount], [Remark], [TransectionId], [SaleId]) VALUES (46, NULL, NULL, CAST(0x0000A64600D402FD AS DateTime), 36, N'Dr        ', CAST(44.00000 AS Decimal(18, 5)), N'manual', NULL, 133)
INSERT [dbo].[Transection] ([TransId], [CustomUniqueId], [ResponceUniqueId], [Date], [UserId], [TransType], [Amount], [Remark], [TransectionId], [SaleId]) VALUES (48, NULL, NULL, CAST(0x0000A64600D8F45B AS DateTime), 37, N'Dr        ', CAST(10.00000 AS Decimal(18, 5)), N'Manual', NULL, 135)
INSERT [dbo].[Transection] ([TransId], [CustomUniqueId], [ResponceUniqueId], [Date], [UserId], [TransType], [Amount], [Remark], [TransectionId], [SaleId]) VALUES (49, NULL, NULL, CAST(0x0000A64600DE0B23 AS DateTime), 36, N'Dr        ', CAST(10.00000 AS Decimal(18, 5)), N'Manual', NULL, 136)
SET IDENTITY_INSERT [dbo].[Transection] OFF
SET IDENTITY_INSERT [dbo].[UnitMaster] ON 

INSERT [dbo].[UnitMaster] ([UnitId], [UnitName]) VALUES (1, N'Lit')
INSERT [dbo].[UnitMaster] ([UnitId], [UnitName]) VALUES (2, N'Kilo')
INSERT [dbo].[UnitMaster] ([UnitId], [UnitName]) VALUES (3, N'Second')
SET IDENTITY_INSERT [dbo].[UnitMaster] OFF
SET IDENTITY_INSERT [dbo].[UserItem] ON 

INSERT [dbo].[UserItem] ([UserItemId], [UserId], [ItemId], [Quantity], [Scheduled], [IsDelete], [DOC]) VALUES (20, 37, 1, 1, N'DAILY', 0, CAST(0x0000A646002FF319 AS DateTime))
INSERT [dbo].[UserItem] ([UserItemId], [UserId], [ItemId], [Quantity], [Scheduled], [IsDelete], [DOC]) VALUES (21, 37, 2, 1, N'MON,SUN,SAT', 0, CAST(0x0000A64600301405 AS DateTime))
INSERT [dbo].[UserItem] ([UserItemId], [UserId], [ItemId], [Quantity], [Scheduled], [IsDelete], [DOC]) VALUES (22, 36, 3, 1, N'DAILY', 0, CAST(0x0000A64600854202 AS DateTime))
INSERT [dbo].[UserItem] ([UserItemId], [UserId], [ItemId], [Quantity], [Scheduled], [IsDelete], [DOC]) VALUES (23, 36, 4, 1, N'SUN,MON,SAT', 0, CAST(0x0000A64600DDC72B AS DateTime))
INSERT [dbo].[UserItem] ([UserItemId], [UserId], [ItemId], [Quantity], [Scheduled], [IsDelete], [DOC]) VALUES (24, 36, 5, 1, N'DAILY', 0, CAST(0x0000A64600DE7B0E AS DateTime))
INSERT [dbo].[UserItem] ([UserItemId], [UserId], [ItemId], [Quantity], [Scheduled], [IsDelete], [DOC]) VALUES (25, 36, 6, 5, N'DAILY', 0, CAST(0x0000A64600EBB731 AS DateTime))
INSERT [dbo].[UserItem] ([UserItemId], [UserId], [ItemId], [Quantity], [Scheduled], [IsDelete], [DOC]) VALUES (26, 36, 13, 4, N'DAILY', 1, CAST(0x0000A64600EBD538 AS DateTime))
INSERT [dbo].[UserItem] ([UserItemId], [UserId], [ItemId], [Quantity], [Scheduled], [IsDelete], [DOC]) VALUES (27, 40, 5, 1, N'DAILY', 0, CAST(0x0000A64600F18293 AS DateTime))
SET IDENTITY_INSERT [dbo].[UserItem] OFF
SET IDENTITY_INSERT [dbo].[UserMaster] ON 

INSERT [dbo].[UserMaster] ([UserId], [Name], [Address], [MobileNo], [UserName], [Password], [RoleId], [ShopId], [ActiveBalance], [IsDelete], [DOC]) VALUES (28, N'Abhinav Admin', N'Thergoan', N'9999999999', N'admin', N'admin', 1, 1, CAST(0.00000 AS Decimal(18, 5)), 0, CAST(0x0000A645017544FC AS DateTime))
INSERT [dbo].[UserMaster] ([UserId], [Name], [Address], [MobileNo], [UserName], [Password], [RoleId], [ShopId], [ActiveBalance], [IsDelete], [DOC]) VALUES (31, N'Emp 1', N'pune', N'9999999991', N'emp1', N'emp1', 3, 10, CAST(0.00000 AS Decimal(18, 5)), 0, CAST(0x0000A64501854114 AS DateTime))
INSERT [dbo].[UserMaster] ([UserId], [Name], [Address], [MobileNo], [UserName], [Password], [RoleId], [ShopId], [ActiveBalance], [IsDelete], [DOC]) VALUES (32, N'Emp 2', N'pune', N'9999999992', N'emp2', N'emp2', 3, 11, CAST(0.00000 AS Decimal(18, 5)), 0, CAST(0x0000A64501860AE8 AS DateTime))
INSERT [dbo].[UserMaster] ([UserId], [Name], [Address], [MobileNo], [UserName], [Password], [RoleId], [ShopId], [ActiveBalance], [IsDelete], [DOC]) VALUES (36, N'surana', N'pune', N'777777777 ', N'cust1', N'cust1', 2, 10, CAST(96.00000 AS Decimal(18, 5)), 0, CAST(0x0000A646000441E4 AS DateTime))
INSERT [dbo].[UserMaster] ([UserId], [Name], [Address], [MobileNo], [UserName], [Password], [RoleId], [ShopId], [ActiveBalance], [IsDelete], [DOC]) VALUES (37, N'Cust 102', N'pune', N'9999999991', N'cust2', N'cust2', 2, 10, CAST(76.00000 AS Decimal(18, 5)), 0, CAST(0x0000A6460004CA80 AS DateTime))
INSERT [dbo].[UserMaster] ([UserId], [Name], [Address], [MobileNo], [UserName], [Password], [RoleId], [ShopId], [ActiveBalance], [IsDelete], [DOC]) VALUES (38, N'Cust 201', N'pune', N'9999999999', N'cust201', N'cust201', 2, 11, CAST(120.00000 AS Decimal(18, 5)), 0, CAST(0x0000A64600082150 AS DateTime))
INSERT [dbo].[UserMaster] ([UserId], [Name], [Address], [MobileNo], [UserName], [Password], [RoleId], [ShopId], [ActiveBalance], [IsDelete], [DOC]) VALUES (39, N'cust CV 202', N'pune', N'9999999999', N'cust202', N'cust202', 2, 11, CAST(0.00000 AS Decimal(18, 5)), 0, CAST(0x0000A646000CBA10 AS DateTime))
INSERT [dbo].[UserMaster] ([UserId], [Name], [Address], [MobileNo], [UserName], [Password], [RoleId], [ShopId], [ActiveBalance], [IsDelete], [DOC]) VALUES (40, N'customer3', N'pune', N'8524568521', N'customer3', N'cust3', 2, 10, CAST(0.00000 AS Decimal(18, 5)), 0, CAST(0x0000A64600F15151 AS DateTime))
SET IDENTITY_INSERT [dbo].[UserMaster] OFF
ALTER TABLE [dbo].[ItemMaster] ADD  CONSTRAINT [DF_ItemMaster_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[ItemMaster] ADD  CONSTRAINT [DF_ItemMaster_DOC]  DEFAULT (getdate()) FOR [DOC]
GO
ALTER TABLE [dbo].[OrderCancelMaster] ADD  CONSTRAINT [DF_OrderCancelMaster_DOC]  DEFAULT (getdate()) FOR [DOC]
GO
ALTER TABLE [dbo].[OrderCancelMaster] ADD  CONSTRAINT [DF_OrderCancelMaster_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[PriceMaster] ADD  CONSTRAINT [DF_PriceMaster_Date]  DEFAULT (getdate()) FOR [Date]
GO
ALTER TABLE [dbo].[PriceMaster] ADD  CONSTRAINT [DF_PriceMaster_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[RoleMaster] ADD  CONSTRAINT [DF_RoleMaster_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[RoleMaster] ADD  CONSTRAINT [DF_RoleMaster_DOC]  DEFAULT (getdate()) FOR [DOC]
GO
ALTER TABLE [dbo].[RoleRuleRelation] ADD  CONSTRAINT [DF_RoleRuleRelation_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[RuleMaster] ADD  CONSTRAINT [DF_RuleMaster_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[SaleDtlMaster] ADD  CONSTRAINT [DF_SaleDtlMaster_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[SaleDtlMaster] ADD  CONSTRAINT [DF_SaleDtlMaster_DOC]  DEFAULT (getdate()) FOR [DOC]
GO
ALTER TABLE [dbo].[SaleMaster] ADD  CONSTRAINT [DF_SaleMaster_Date]  DEFAULT (getdate()) FOR [Date]
GO
ALTER TABLE [dbo].[SaleMaster] ADD  CONSTRAINT [DF_SaleMaster_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[SaleMaster] ADD  CONSTRAINT [DF_SaleMaster_DOC]  DEFAULT (getdate()) FOR [DOC]
GO
ALTER TABLE [dbo].[ShopMaster] ADD  CONSTRAINT [DF_ShopMaster_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[ShopMaster] ADD  CONSTRAINT [DF_ShopMaster_DOC]  DEFAULT (getdate()) FOR [DOC]
GO
ALTER TABLE [dbo].[Transection] ADD  CONSTRAINT [DF_Transection_Date]  DEFAULT (getdate()) FOR [Date]
GO
ALTER TABLE [dbo].[UserItem] ADD  CONSTRAINT [DF_UserItem_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[UserItem] ADD  CONSTRAINT [DF_UserItem_DOC]  DEFAULT (getdate()) FOR [DOC]
GO
ALTER TABLE [dbo].[UserMaster] ADD  CONSTRAINT [DF_UserMaster_ActiveBalance]  DEFAULT ((0)) FOR [ActiveBalance]
GO
ALTER TABLE [dbo].[UserMaster] ADD  CONSTRAINT [DF_UserMaster_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[UserMaster] ADD  CONSTRAINT [DF_UserMaster_DOC]  DEFAULT (getdate()) FOR [DOC]
GO
ALTER TABLE [dbo].[ItemMaster]  WITH CHECK ADD  CONSTRAINT [FK_ItemMaster_UnitMaster] FOREIGN KEY([UnitId])
REFERENCES [dbo].[UnitMaster] ([UnitId])
GO
ALTER TABLE [dbo].[ItemMaster] CHECK CONSTRAINT [FK_ItemMaster_UnitMaster]
GO
ALTER TABLE [dbo].[OrderCancelMaster]  WITH CHECK ADD  CONSTRAINT [FK_OrderCancelMaster_ItemMaster] FOREIGN KEY([ItemId])
REFERENCES [dbo].[ItemMaster] ([ItemId])
GO
ALTER TABLE [dbo].[OrderCancelMaster] CHECK CONSTRAINT [FK_OrderCancelMaster_ItemMaster]
GO
ALTER TABLE [dbo].[OrderCancelMaster]  WITH CHECK ADD  CONSTRAINT [FK_OrderCancelMaster_StatusMaster] FOREIGN KEY([Status])
REFERENCES [dbo].[StatusMaster] ([StatusMasterId])
GO
ALTER TABLE [dbo].[OrderCancelMaster] CHECK CONSTRAINT [FK_OrderCancelMaster_StatusMaster]
GO
ALTER TABLE [dbo].[OrderCancelMaster]  WITH CHECK ADD  CONSTRAINT [FK_OrderCancelMaster_UserMaster] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserMaster] ([UserId])
GO
ALTER TABLE [dbo].[OrderCancelMaster] CHECK CONSTRAINT [FK_OrderCancelMaster_UserMaster]
GO
ALTER TABLE [dbo].[PriceMaster]  WITH CHECK ADD  CONSTRAINT [FK_PriceMaster_ItemMaster] FOREIGN KEY([ItemId])
REFERENCES [dbo].[ItemMaster] ([ItemId])
GO
ALTER TABLE [dbo].[PriceMaster] CHECK CONSTRAINT [FK_PriceMaster_ItemMaster]
GO
ALTER TABLE [dbo].[RoleRuleRelation]  WITH CHECK ADD  CONSTRAINT [FK_RoleRuleRelation_RoleMaster] FOREIGN KEY([RoleId])
REFERENCES [dbo].[RoleMaster] ([RoleId])
GO
ALTER TABLE [dbo].[RoleRuleRelation] CHECK CONSTRAINT [FK_RoleRuleRelation_RoleMaster]
GO
ALTER TABLE [dbo].[RoleRuleRelation]  WITH CHECK ADD  CONSTRAINT [FK_RoleRuleRelation_RuleMaster] FOREIGN KEY([RuleId])
REFERENCES [dbo].[RuleMaster] ([RuleId])
GO
ALTER TABLE [dbo].[RoleRuleRelation] CHECK CONSTRAINT [FK_RoleRuleRelation_RuleMaster]
GO
ALTER TABLE [dbo].[RuleMaster]  WITH CHECK ADD  CONSTRAINT [FK_RuleMaster_Permission] FOREIGN KEY([PermissionId])
REFERENCES [dbo].[Permission] ([PermissionId])
GO
ALTER TABLE [dbo].[RuleMaster] CHECK CONSTRAINT [FK_RuleMaster_Permission]
GO
ALTER TABLE [dbo].[RuleMaster]  WITH CHECK ADD  CONSTRAINT [FK_RuleMaster_PermissionType1] FOREIGN KEY([TypeId])
REFERENCES [dbo].[PermissionType] ([TypeId])
GO
ALTER TABLE [dbo].[RuleMaster] CHECK CONSTRAINT [FK_RuleMaster_PermissionType1]
GO
ALTER TABLE [dbo].[SaleDtlMaster]  WITH CHECK ADD  CONSTRAINT [FK_SaleDtlMaster_ItemMaster] FOREIGN KEY([ItemId])
REFERENCES [dbo].[ItemMaster] ([ItemId])
GO
ALTER TABLE [dbo].[SaleDtlMaster] CHECK CONSTRAINT [FK_SaleDtlMaster_ItemMaster]
GO
ALTER TABLE [dbo].[SaleDtlMaster]  WITH CHECK ADD  CONSTRAINT [FK_SaleDtlMaster_SaleMaster] FOREIGN KEY([SaleId])
REFERENCES [dbo].[SaleMaster] ([SaleId])
GO
ALTER TABLE [dbo].[SaleDtlMaster] CHECK CONSTRAINT [FK_SaleDtlMaster_SaleMaster]
GO
ALTER TABLE [dbo].[Transection]  WITH CHECK ADD  CONSTRAINT [FK_Transection_UserMaster] FOREIGN KEY([SaleId])
REFERENCES [dbo].[SaleMaster] ([SaleId])
GO
ALTER TABLE [dbo].[Transection] CHECK CONSTRAINT [FK_Transection_UserMaster]
GO
ALTER TABLE [dbo].[Transection]  WITH CHECK ADD  CONSTRAINT [FK_Transection_UserMaster1] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserMaster] ([UserId])
GO
ALTER TABLE [dbo].[Transection] CHECK CONSTRAINT [FK_Transection_UserMaster1]
GO
ALTER TABLE [dbo].[UserItem]  WITH CHECK ADD  CONSTRAINT [FK_UserItem_ItemMaster] FOREIGN KEY([ItemId])
REFERENCES [dbo].[ItemMaster] ([ItemId])
GO
ALTER TABLE [dbo].[UserItem] CHECK CONSTRAINT [FK_UserItem_ItemMaster]
GO
ALTER TABLE [dbo].[UserItem]  WITH CHECK ADD  CONSTRAINT [FK_UserItem_UserMaster] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserMaster] ([UserId])
GO
ALTER TABLE [dbo].[UserItem] CHECK CONSTRAINT [FK_UserItem_UserMaster]
GO
ALTER TABLE [dbo].[UserMaster]  WITH CHECK ADD  CONSTRAINT [FK_UserMaster_RoleMaster] FOREIGN KEY([RoleId])
REFERENCES [dbo].[RoleMaster] ([RoleId])
GO
ALTER TABLE [dbo].[UserMaster] CHECK CONSTRAINT [FK_UserMaster_RoleMaster]
GO
ALTER TABLE [dbo].[UserMaster]  WITH CHECK ADD  CONSTRAINT [FK_UserMaster_ShopMaster] FOREIGN KEY([ShopId])
REFERENCES [dbo].[ShopMaster] ([ShopId])
GO
ALTER TABLE [dbo].[UserMaster] CHECK CONSTRAINT [FK_UserMaster_ShopMaster]
GO
USE [master]
GO
ALTER DATABASE [TeamedDB] SET  READ_WRITE 
GO
