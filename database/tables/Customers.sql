USE [gopher]
GO

/****** Object:  Table [dbo].[Customers]    Script Date: 21/09/2014 12:58:11 PM ******/
DROP TABLE [dbo].[Customers]
GO

/****** Object:  Table [dbo].[Customers]    Script Date: 21/09/2014 12:58:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Customers](
	[CustomerId] [nvarchar](50) NOT NULL,
	[ShopId] [nvarchar](50) NULL,
	[Prefecture] [nvarchar](250) NULL,
	[NameKanji] [nvarchar](250) NULL,
	[NameKana] [nvarchar](250) NULL,
	[Sex] [int] NULL,
	[DateOfBirth] [datetime] NULL,
	[Email] [nvarchar](250) NULL,
	[EmailMobile] [nvarchar](250) NULL,
	[Phone] [nvarchar](250) NULL,
	[AmountPurchased] [money] NULL,
	[DateRegistered] [datetime] NULL,
	[TimesPurchased] [int] NULL,
	[DateUpdated] [datetime] NULL,
	[DateFirstPurchased] [datetime] NULL,
	[DateLastPurchased] [datetime] NULL
) ON [PRIMARY]

GO


