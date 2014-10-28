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

	DECLARE @sql nvarchar(MAX) -- bulk insert has to be dynamic sql because it does not support file name as a variable
	SET @sql =
	'BULK INSERT Customers
		FROM ''' + @fileName + '''
		WITH  (
			FIELDTERMINATOR='','',
			DATAFILETYPE = ''widechar''
		);
	';

	EXEC (@sql)

	SELECT @@ROWCOUNT

	COMMIT
END

GO


