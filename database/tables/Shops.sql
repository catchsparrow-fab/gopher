USE [gopher]
GO

/****** Object:  Table [dbo].[Shops]    Script Date: 03/11/2014 10:17:22 PM ******/
DROP TABLE [dbo].[Shops]
GO

/****** Object:  Table [dbo].[Shops]    Script Date: 03/11/2014 10:17:22 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Shops](
	[ShopId] [int] IDENTITY(1, 1) NOT NULL,
	[ShopImportedId] [int] NOT NULL,
	[FullName] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_Shops] PRIMARY KEY CLUSTERED 
(
	[ShopId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


