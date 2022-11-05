USE [Software.Solution]
GO

/****** Object:  StoredProcedure [dbo].[GetCustomers_test]    Script Date: 11/5/2022 12:37:57 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[GetCustomers_test]
	@pageNumber INT,
	@pageSize INT,
	@totalItems INT OUTPUT
AS
BEGIN
	SELECT * 
	into #tmpCustomers 
	FROM Customers
	
	-- đếm tổng record query
	DECLARE @sql_get_total NVARCHAR(max)
	SET @sql_get_total = 'SELECT @totalItems = COUNT(*) FROM #tmpCustomers ';

	EXEC sp_executesql 
        @query = @sql_get_total, 
        @params = N'@totalItems INT OUTPUT', 
        @totalItems = @totalItems OUTPUT;

	-- công thức tính phân trang
	DECLARE @offSetValue INT 
	SET @offSetValue = ((@pageNumber - 1) * @pageSize) 

	DECLARE @excOffSetValue NVARCHAR(MAX)
	SET @excOffSetValue = ' ORDER BY Id OFFSET ' + CAST(@offSetValue as NVARCHAR) +' ROWS FETCH NEXT ' + CAST(@pageSize as NVARCHAR) +' ROWS ONLY'

	-- chuẩn bị câu truy vấn để execute
	DECLARE @excQuery NVARCHAR(MAX)
	SET @excQuery = 'select * from #tmpCustomers ' + @excOffSetValue
	
	EXECUTE(@excQuery)
END
GO


