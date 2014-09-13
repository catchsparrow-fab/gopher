USE [gopher]
GO

/****** Object:  Table [dbo].[PageLabels]    Script Date: 12/09/2014 8:34:33 PM ******/
DROP TABLE [dbo].[PageLabels]
GO

/****** Object:  Table [dbo].[PageLabels]    Script Date: 12/09/2014 8:34:33 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PageLabels](
	[PageLabelId] [int] IDENTITY(1,1) NOT NULL,
	[LabelName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_PageLabels] PRIMARY KEY CLUSTERED 
(
	[PageLabelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


