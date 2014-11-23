USE [gopher]
GO

/****** Object:  StoredProcedure [dbo].[GetPrefectures]    Script Date: 12/11/2014 3:54:28 PM ******/
DROP PROCEDURE [dbo].[GetPrefectures]
GO

/****** Object:  StoredProcedure [dbo].[GetPrefectures]    Script Date: 12/11/2014 3:54:28 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetPrefectures]
AS
BEGIN
	SET NOCOUNT ON;

    SELECT DISTINCT Prefecture FROM Customers WHERE Prefecture IS NOT NULL
	ORDER BY Prefecture
END

GO


