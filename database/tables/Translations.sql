USE [gopher]
GO

/****** Object:  Table [dbo].[Translations]    Script Date: 12/09/2014 2:23:31 PM ******/
DROP TABLE [dbo].[Translations]
GO

/****** Object:  Table [dbo].[Translations]    Script Date: 12/09/2014 2:23:31 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Translations](
	[PageLabelId] [int] NOT NULL,
	[LanguageId] [int] NOT NULL,
	[Translation] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Translations] PRIMARY KEY CLUSTERED 
(
	[PageLabelId] ASC,
	[LanguageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


