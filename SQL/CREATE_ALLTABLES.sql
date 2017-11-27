CREATE TABLE Customers (
	CustomerID int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	FirstName nvarchar(25) NOT NULL,
	LastName nvarchar(25) NOT NULL
	);

CREATE TABLE Accounts (
	AccountID int IDENTITY(1,1) NOT NULL,
	AccountNumber int NOT NULL,
	PIN int NOT NULL,
	AccountType int NOT NULL,
	CustomerID int NOT NULL,
	Balance int,
	CONSTRAINT [PK_dbo.Accounts] PRIMARY KEY CLUSTERED ([AccountID]),
	CONSTRAINT [FK_dbo.Accounts_dbo.Customer_CustomerID] FOREIGN KEY ([CustomerID]) REFERENCES [dbo].[Customers] ([CustomerID]) ON DELETE CASCADE
	);

CREATE TABLE Transactions (
	TransactionID int IDENTITY(1,1) NOT NULL,
	TransactionType int NOT NULL,
	AccountID int NOT NULL,
	CONSTRAINT [PK_dbo.Transactions] PRIMARY KEY CLUSTERED ([TransactionID] ASC),
    CONSTRAINT [FK_dbo.Transactions_dbo.Accounts_AccountID] FOREIGN KEY ([AccountID]) REFERENCES [dbo].[Accounts] ([AccountID]) ON DELETE CASCADE
	);

CREATE TABLE Deposits(
	DepositID int IDENTITY(1,1) NOT NULL,
	TransactionID int NOT NULL,
	Amount money NOT NULL,
	CONSTRAINT [PK_dbo.Deposits] PRIMARY KEY CLUSTERED ([DepositID] ASC),
	CONSTRAINT [FK_dbo.Deposits_dbo.Transactions] FOREIGN KEY ([TransactionID]) REFERENCES [dbo].[Transactions] ([TransactionID]) ON DELETE CASCADE
	)

CREATE TABLE Withdrawls(
	WithdrawalID int IDENTITY(1,1) NOT NULL,
	TransactionID int NOT NULL,
	Amount money NOT NULL,
	CONSTRAINT [PK_dbo.Withdrawals] PRIMARY KEY CLUSTERED ([WithdrawalID] ASC),
	CONSTRAINT [FK_dbo.Withdrawals_dbo.Transactions] FOREIGN KEY ([TransactionID]) REFERENCES [dbo].[Transactions] ([TransactionID]) ON DELETE CASCADE
	);

GO