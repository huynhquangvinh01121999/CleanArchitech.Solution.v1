USE [Software.Solution]
GO

/****** Object:  StoredProcedure [dbo].[GetCustomers]    Script Date: 29/10/2022 11:59:20 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetCustomers]
	@pageNumber INT,
	@pageSize INT
AS
BEGIN
	SELECT * FROM Customers 
	ORDER BY Id OFFSET ((@pageNumber - 1) * @pageSize) ROWS FETCH NEXT @pageSize ROWS ONLY
END
GO