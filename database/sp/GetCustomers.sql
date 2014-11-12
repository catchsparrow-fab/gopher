USE [gopher]
GO

/****** Object:  StoredProcedure [dbo].[GetCustomers]    Script Date: 09/11/2014 1:12:36 AM ******/
DROP PROCEDURE [dbo].[GetCustomers]
GO

/****** Object:  StoredProcedure [dbo].[GetCustomers]    Script Date: 09/11/2014 1:12:36 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE GetCustomers 
	@customerId nvarchar(250) = NULL,
	@sex int = NULL,
	@dobMin datetime = NULL,
	@dobMax datetime = NULL,
	@timesPurchasedMin int = NULL,
	@timesPurchasedMax int = NULL,
	@count int = 20,
	@start int = 0,
	@monthOfBirth int = NULL,
	@nameKanji nvarchar(250) = NULL,
	@nameKana nvarchar(250) = NULL,
	@email nvarchar(250) = NULL,
	@emailMobile nvarchar(250) = NULL,
	@phone nvarchar(250) = NULL,
	@productWarranty nvarchar(250) = NULL,
	@prefecture nvarchar(250) = NULL,
	@shopId int = NULL
AS
BEGIN
	IF @count = -1 BEGIN

		SELECT c.*, s.FullName as ShopName FROM Customers c
		INNER JOIN Shops s ON s.ShopId = c.ShopId
		WHERE (@customerId IS NULL OR @customerId = c.CustomerId)
			AND (@sex IS NULL OR @sex = c.Sex)
			AND (@dobMin IS NULL OR @dobMin < c.DateOfBirth)
			AND (@dobMax IS NULL OR @dobMax > c.DateOfBirth)
			AND (@timesPurchasedMin IS NULL OR @timesPurchasedMin <= c.EC_TimesPurchased)
			AND (@timesPurchasedMax IS NULL OR @timesPurchasedMax >= c.EC_TimesPurchased) 
			AND (@monthOfBirth IS NULL OR DATEPART(month, c.DateOfBirth) = @monthOfBirth)
			AND (@nameKanji IS NULL OR c.NameKanji LIKE '%' + @nameKanji + '%')
			AND (@nameKana IS NULL OR c.NameKana LIKE '%' + @nameKana + '%')
			AND (@email IS NULL OR c.Email LIKE '%' + @email + '%')
			AND (@emailMobile IS NULL OR c.EmailMobile LIKE '%' + @emailMobile + '%')
			AND (@phone IS NULL OR c.Phone LIKE '%' + @phone + '%')
			AND (@productWarranty IS NULL OR c.EC_ProductWarranty LIKE '%' + @productWarranty + '%')
			AND (@prefecture IS NULL OR c.Prefecture = @prefecture)
			AND (@shopId IS NULL OR c.ShopId = @shopId)
		ORDER BY CustomerId

	END ELSE BEGIN
		SELECT c.*, s.FullName as ShopName FROM Customers c
		INNER JOIN Shops s ON s.ShopId = c.ShopId
		WHERE (@customerId IS NULL OR @customerId = c.CustomerId)
			AND (@sex IS NULL OR @sex = c.Sex)
			AND (@dobMin IS NULL OR @dobMin < c.DateOfBirth)
			AND (@dobMax IS NULL OR @dobMax > c.DateOfBirth)
			AND (@timesPurchasedMin IS NULL OR @timesPurchasedMin <= c.EC_TimesPurchased)
			AND (@timesPurchasedMax IS NULL OR @timesPurchasedMax >= c.EC_TimesPurchased) 
			AND (@monthOfBirth IS NULL OR DATEPART(month, c.DateOfBirth) = @monthOfBirth)
			AND (@nameKanji IS NULL OR c.NameKanji LIKE '%' + @nameKanji + '%')
			AND (@nameKana IS NULL OR c.NameKana LIKE '%' + @nameKana + '%')
			AND (@email IS NULL OR c.Email LIKE '%' + @email + '%')
			AND (@emailMobile IS NULL OR c.EmailMobile LIKE '%' + @emailMobile + '%')
			AND (@phone IS NULL OR c.Phone LIKE '%' + @phone + '%')
			AND (@productWarranty IS NULL OR c.EC_ProductWarranty LIKE '%' + @productWarranty + '%')
			AND (@prefecture IS NULL OR c.Prefecture = @prefecture)
			AND (@shopId IS NULL OR c.ShopId = @shopId)
		ORDER BY CustomerId
		OFFSET @start ROWS FETCH NEXT @count ROWS ONLY
	END

	SELECT COUNT(*) AS TotalCount FROM Customers c
		WHERE (@customerId IS NULL OR @customerId = c.CustomerId)
			AND (@sex IS NULL OR @sex = c.Sex)
			AND (@dobMin IS NULL OR @dobMin < c.DateOfBirth)
			AND (@dobMax IS NULL OR @dobMax > c.DateOfBirth)
			AND (@timesPurchasedMin IS NULL OR @timesPurchasedMin <= c.EC_TimesPurchased)
			AND (@timesPurchasedMax IS NULL OR @timesPurchasedMax >= c.EC_TimesPurchased) 
			AND (@monthOfBirth IS NULL OR DATEPART(month, c.DateOfBirth) = @monthOfBirth)
			AND (@nameKanji IS NULL OR c.NameKanji LIKE '%' + @nameKanji + '%')
			AND (@nameKana IS NULL OR c.NameKana LIKE '%' + @nameKana + '%')
			AND (@email IS NULL OR c.Email LIKE '%' + @email + '%')
			AND (@emailMobile IS NULL OR c.EmailMobile LIKE '%' + @emailMobile + '%')
			AND (@phone IS NULL OR c.Phone LIKE '%' + @phone + '%')
			AND (@productWarranty IS NULL OR c.EC_ProductWarranty LIKE '%' + @productWarranty + '%')
			AND (@prefecture IS NULL OR c.Prefecture = @prefecture)
			AND (@shopId IS NULL OR c.ShopId = @shopId)
END

GO


