CREATE TABLE dbo.Customers (
	CustomerID int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	FirstName nvarchar(25) NOT NULL,
	LastName nvarchar(25) NOT NULL
	)
GO