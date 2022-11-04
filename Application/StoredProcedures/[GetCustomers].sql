USE [Software.Solution]
GO

/****** Object:  StoredProcedure [dbo].[GetCustomers]    Script Date: 11/2/2022 3:50:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/*==============================================================================================
   Author			Date			Updated					Description
   -----------------------------------------------------------------------------------------
   Vinh Huynh		2022.11.02								Get danh sách khách hàng
============================================================================================= */

CREATE PROCEDURE [dbo].[GetCustomers]
	@pageNumber INT,
	@pageSize INT,
	@colFil NVARCHAR(MAX),
	@keyword NVARCHAR(MAX),
	@startDob DATETIME,
	@endDob DATETIME,
	@totalItems INT OUTPUT
AS
BEGIN
	SELECT * into #tmpCustomers 
	FROM Customers

	-- tìm kiếm theo column truyền vào
	DECLARE @excFilter NVARCHAR(MAX)
	SET @excFilter = CASE 
						 WHEN @colFil = 'name' THEN 'WHERE FirstName + '' '' + LastName like N''' +'%' + @keyword +'%' +''''
						 WHEN @colFil = 'contact' THEN 'WHERE Contact + '' '' + LastName like N''' +'%' + @keyword +'%' +''''
						 WHEN @colFil = 'email' THEN 'WHERE Email + '' '' + LastName like N''' +'%' + @keyword +'%' +''''
						 WHEN @colFil = 'dob' THEN 'WHERE DateOfBirth >= ''' + CAST(@startDob as NVARCHAR) + ''' and DateOfBirth <= ''' + CAST(@endDob as NVARCHAR) +''''
						 WHEN @colFil is null or @colFil = '' THEN ''
					 END
	
	-- đếm tổng record query
	DECLARE @sql_get_total NVARCHAR(max)
	SET @sql_get_total = 'SELECT @totalItems = COUNT(*) FROM #tmpCustomers ' + @excFilter;

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
	SET @excQuery = 'select * from #tmpCustomers ' + @excFilter + @excOffSetValue
	
	EXECUTE(@excQuery)
	--print @excQuery
END
GO


------------------
declare @TotalItems int
exec GetCustomers 1,10,'dob',null,'2002-10-01','2002-10-31',@TotalItems output
select @TotalItems