USE [gopher]
GO

/****** Object:  StoredProcedure [dbo].[UploadData]    Script Date: 26/10/2014 11:50:14 PM ******/
DROP PROCEDURE [dbo].[UploadData]
GO

/****** Object:  StoredProcedure [dbo].[UploadData]    Script Date: 26/10/2014 11:50:14 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[UploadData] 
	@fileName varchar(255)
AS
BEGIN
	BEGIN TRANSACTION

	SET DATEFORMAT dmy

	BULK INSERT Customers
		FROM 'f:\projects\gopher-project\data\output.csv'
		WITH  (
			FIELDTERMINATOR=',',
			DATAFILETYPE = 'widechar'
		);
	
	SELECT @@ROWCOUNT

	COMMIT
END

GO


