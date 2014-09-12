USE [gopher]
GO

/****** Object:  Table [dbo].[PageLabels]    Script Date: 12/09/2014 2:22:38 PM ******/
DROP TABLE [dbo].[PageLabels]
GO

/****** Object:  Table [dbo].[PageLabels]    Script Date: 12/09/2014 2:22:38 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PageLabels](
	[PageLabelId] [int] IDENTITY(1,1) NOT NULL,
	[LabelName] [nvarchar](100) NOT NULL
) ON [PRIMARY]

GO


