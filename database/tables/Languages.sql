USE [gopher]
GO

/****** Object:  Table [dbo].[Languages]    Script Date: 12/09/2014 9:05:44 PM ******/
DROP TABLE [dbo].[Languages]
GO

/****** Object:  Table [dbo].[Languages]    Script Date: 12/09/2014 9:05:44 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Languages](
	[LanguageId] [int] NOT NULL,
	[LanguageName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Languages] PRIMARY KEY CLUSTERED 
(
	[LanguageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


