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
	@fileName varchar(255),
	@inputType int -- 1: eccube 2: tempovisor
AS
BEGIN
	BEGIN TRANSACTION

	DELETE FROM Customers_Stage

	SET DATEFORMAT dmy

	DECLARE @sql nvarchar(MAX) -- bulk insert has to be dynamic sql because it does not support file name as a variable
	SET @sql =
	'BULK INSERT Customers_Stage
		FROM ''' + @fileName + '''
		WITH  (
			FIELDTERMINATOR='','',
			DATAFILETYPE = ''widechar''
		);
	';

	EXEC (@sql)

	IF @inputType = 1 BEGIN
		DELETE FROM Customers WHERE ImportedFrom = 1 -- for eccube, delete all customers previously imported from eccube
	END ELSE BEGIN
		DELETE FROM Customers WHERE ImportedFrom = 2 AND CustomerId IN (SELECT CustomerId FROM Customers_Stage)
	END

	INSERT INTO Customers SELECT * FROM Customers_Stage

	SELECT @@ROWCOUNT

	COMMIT
END

GO


