USE [DietPlanner]
GO
/****** Object:  Table [dbo].[ErrorDetails]    Script Date: 26-06-2021 11:48:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ErrorDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ErrorDetails] [varchar](max) NULL,
	[Entry_date] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inventory]    Script Date: 26-06-2021 11:48:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](1000) NULL,
	[Description] [nvarchar](max) NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[user_Id] [int] NULL,
	[Entry_date] [datetime] NULL,
	[Modify_date] [datetime] NULL,
	[Is_Active] [bit] NULL,
	[Quantity] [int] NOT NULL,
	[consumed] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
