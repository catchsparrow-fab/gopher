DROP TYPE [dbo].[ShopsFilter]
GO

-- Create the data type
CREATE TYPE [dbo].[ShopsFilter] AS TABLE 
(
	[c] [int] NOT NULL
)
GO