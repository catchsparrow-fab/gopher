USE [gopher]
GO

/****** Object:  StoredProcedure [dbo].[AddTranslation]    Script Date: 12/09/2014 9:02:35 PM ******/
DROP PROCEDURE [dbo].[AddTranslation]
GO

/****** Object:  StoredProcedure [dbo].[AddTranslation]    Script Date: 12/09/2014 9:02:35 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[AddTranslation]
	@labelName nvarchar(100),
	@translation nvarchar(max),
	@languageId int = NULL
AS
BEGIN
BEGIN TRANSACTION
	DELETE FROM PageLabels WHERE LabelName = @labelName
	INSERT INTO PageLabels (LabelName) VALUES (@labelName)
	DECLARE @pageLabelId int
	SELECT @pageLabelId = SCOPE_IDENTITY()

	CREATE TABLE #lang (LanguageId int)

	IF @languageId IS NULL BEGIN -- inserting for every language
		INSERT INTO #lang SELECT LanguageId FROM Languages
	END ELSE BEGIN
		INSERT INTO #lang SELECT @languageId
	END

	INSERT INTO Translations (PageLabelId, LanguageId, Translation) 
	SELECT @pageLabelId, LanguageId, @translation FROM #lang 
COMMIT
	DROP table #lang
END

GO


