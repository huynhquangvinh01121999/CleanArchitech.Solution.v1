USE [Software.Solution]
GO

/****** Object:  StoredProcedure [dbo].[GetCustomers]    Script Date: 29/10/2022 12:57:52 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetCustomers]
	@pageNumber INT,
	@pageSize INT,
	@totalItems INT OUTPUT
AS
BEGIN
	SELECT * into #tmpCustomers FROM Customers
	
	-- đếm tổng record query
	DECLARE @sql_get_total NVARCHAR(max)
	SET @sql_get_total = 'SELECT @totalItems = COUNT(*) FROM #tmpCustomers';

	EXEC sp_executesql 
        @query = @sql_get_total, 
        @params = N'@totalItems INT OUTPUT', 
        @totalItems = @totalItems OUTPUT;

	select * from #tmpCustomers
	ORDER BY Id OFFSET ((@pageNumber - 1) * @pageSize) ROWS FETCH NEXT @pageSize ROWS ONLY
END
GO