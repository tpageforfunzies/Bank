CREATE TABLE dbo.Accounts (
	AccountID int NOT NULL,
	AccountNumber int NOT NULL,
	PIN int NOT NULL,
	AccountType int NOT NULL,
	CustomerID int NOT NULL,
	CONSTRAINT [PK_dbo.Accounts] PRIMARY KEY CLUSTERED ([AccountID]),
	CONSTRAINT [FK_dbo.Accounts_dbo.Customer_CustomerID] FOREIGN KEY ([CustomerID]) REFERENCES [dbo].[Customers] ([CustomerID]) ON DELETE CASCADE
	)
GO