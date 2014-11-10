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
	@start int = 0,
	@count int = 20
AS
BEGIN
	IF @count = -1 BEGIN

		SELECT * FROM Customers c
		WHERE (@customerId IS NULL OR @customerId = c.CustomerId)
			AND (@sex IS NULL OR @sex = c.Sex)
			AND (@dobMin IS NULL OR @dobMin < c.DateOfBirth)
			AND (@dobMax IS NULL OR @dobMax > c.DateOfBirth)
			AND (@timesPurchasedMin IS NULL OR @timesPurchasedMin < c.EC_TimesPurchased)
			AND (@timesPurchasedMax iS NULL OR @timesPurchasedMax > c.EC_TimesPurchased) 
		ORDER BY CustomerId

	END ELSE BEGIN
		SELECT * FROM Customers c
		WHERE (@customerId IS NULL OR @customerId = c.CustomerId)
			AND (@sex IS NULL OR @sex = c.Sex)
			AND (@dobMin IS NULL OR @dobMin < c.DateOfBirth)
			AND (@dobMax IS NULL OR @dobMax > c.DateOfBirth)
			AND (@timesPurchasedMin IS NULL OR @timesPurchasedMin < c.EC_TimesPurchased)
			AND (@timesPurchasedMax iS NULL OR @timesPurchasedMax > c.EC_TimesPurchased) 
		ORDER BY CustomerId
		OFFSET @start ROWS FETCH NEXT @count ROWS ONLY
	END

	SELECT COUNT(*) AS TotalCount FROM Customers c
	WHERE (@customerId IS NULL OR @customerId = c.CustomerId)
			AND (@sex IS NULL OR @sex = c.Sex)
			AND (@dobMin IS NULL OR @dobMin < c.DateOfBirth)
			AND (@dobMax IS NULL OR @dobMax > c.DateOfBirth)
			AND (@timesPurchasedMin IS NULL OR @timesPurchasedMin < c.EC_TimesPurchased)
			AND (@timesPurchasedMax iS NULL OR @timesPurchasedMax > c.EC_TimesPurchased) 
END

GO


