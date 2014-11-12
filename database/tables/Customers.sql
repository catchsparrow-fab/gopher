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
	[ImportedFrom] [int] NOT NULL,
	[CustomerId] [nvarchar](50) NOT NULL,
	[ShopId] [int] NULL,
	[Prefecture] [nvarchar](250) NULL,
	[NameKanji] [nvarchar](250) NULL,
	[NameKana] [nvarchar](250) NULL,
	[Sex] [int] NULL,
	[DateOfBirth] [datetime] NULL,
	[Email] [nvarchar](250) NULL,
	[EmailMobile] [nvarchar](250) NULL,
	[Phone] [nvarchar](250) NULL,
	[DateRegistered] [datetime] NULL,
	[DateUpdated] [datetime] NULL,
	[Zip] [nvarchar](250) NULL,
	[CellPhone] [nvarchar](250) NULL,
	[Note] [nvarchar](250) NULL,
	[Address] [nvarchar](250) NULL,
	[PointBalance] [int] NULL,
	[TV_CompanyCode] [nvarchar](250) NULL,
	[TV_Area] [int] NULL,
	[TV_Black] [bit] NULL,
	[TV_MemberRank] [int] NULL,
	[TV_Status] [int] NULL,
	[TV_MemberNumber] [nvarchar](250) NULL,
	[TV_DirectMailFlag] [bit] NULL,
	[TV_EmailAccept] [int] NULL,
	[TV_PriceApplication] [int] NULL,
	[TV_PointDeposited] [int] NULL,
	[TV_LastPointIssued] [int] NULL,
	[TV_LastPointIssuedDate] [datetime] NULL,
	[TV_LastPointUsed] [int] NULL,
	[TV_LastPointUsedDate] [datetime] NULL,
	[TV_Fillers] [nvarchar](250) NULL,
	[TV_Operation] [int] NULL,
	[TV_CutoutDate] [datetime] NULL,
	[TV_ExpirationDate] [datetime] NULL,
	[TV_LastVisitedDate] [datetime] NULL,
	[EC_CompanyName] [nvarchar](250) NULL,
	[EC_Fax] [nvarchar](250) NULL,
	[EC_Occupation] [nvarchar](250) NULL,
	[EC_DateFirstPurchased] [datetime] NULL,
	[EC_DateLastPurchased] [datetime] NULL,
	[EC_TimesPurchased] [int] NULL,
	[EC_ProductWarranty] [nvarchar](2000) NULL,
	[EC_Deleted] [bit] NULL,
	[EC_SubscriptionType] [int] NULL,
	[EC_EmailTarget] [int] NULL,
) ON [PRIMARY]

GO


