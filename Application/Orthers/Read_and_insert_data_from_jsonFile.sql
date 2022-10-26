
-- đọc data từ file json
SELECT * 
FROM OPENROWSET (BULK 'C:\Users\Public\ExportJson.json', SINGLE_CLOB) as import

-- xóa bảng tạm lưu data json
drop table JSONTable

-- đọc data từ json và convert các field sang dạng table -> lưu vào table tạm
Declare @JSON varchar(max)
SELECT @JSON=BulkColumn
FROM OPENROWSET (BULK 'C:\Users\Public\ExportJson.json', SINGLE_CLOB) import
SELECT * INTO JSONTable
FROM OPENJSON (@JSON)
WITH
(
	[FirstName] nvarchar(100),
	[LastName] nvarchar(20),
	[Contact] varchar(20),
	[Email] varchar(100),
	[DateOfBirth] varchar(100)
)

Select * from JSONTable
--------------------------------------------

-- tạo cursor và for loop insert data từ table tạm vào table chính
BEGIN
	DECLARE 
		@FirstName nvarchar(100),
		@LastName nvarchar(20),
		@Contact varchar(20),
		@Email varchar(100),
		@DateOfBirth varchar(100)

	DECLARE cursor_customer CURSOR

	FOR SELECT *
		FROM 
			JSONTable;

	OPEN cursor_customer;

	FETCH NEXT FROM cursor_customer INTO 
		@FirstName, 
		@LastName,
		@Contact,
		@Email,
		@DateOfBirth;

	WHILE @@FETCH_STATUS = 0
		BEGIN
			--PRINT @FirstName +' ' + @LastName;
			insert into Customers(FirstName, LastName, Contact, Email) 
			values(@FirstName, @LastName, @Contact, @Email)

			FETCH NEXT FROM cursor_customer INTO 
					@FirstName, 
					@LastName,
					@Contact,
					@Email,
					@DateOfBirth;
		END;

	CLOSE cursor_customer;

	DEALLOCATE cursor_customer;
END

update Customers set DateOfBirth = '2002-10-24'
select * from Customers
select count(*) from Customers
