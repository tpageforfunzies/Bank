CREATE TABLE Deposits(
	DepositID int NOT NULL,
	TransactionID int NOT NULL,
	Amount money NOT NULL,
	CONSTRAINT [PK_dbo.Deposits] PRIMARY KEY CLUSTERED ([DepositID] ASC),
	CONSTRAINT [FK_dbo.Deposits_dbo.Transactions] FOREIGN KEY ([TransactionID]) REFERENCES [dbo].[Transactions] ([TransactionID]) ON DELETE CASCADE
	)

CREATE TABLE Withdrawls(
	WithdrawalID int NOT NULL,
	TransactionID int NOT NULL,
	Amount money NOT NULL,
	CONSTRAINT [PK_dbo.Withdrawals] PRIMARY KEY CLUSTERED ([WithdrawalID] ASC),
	CONSTRAINT [FK_dbo.Withdrawals_dbo.Transactions] FOREIGN KEY ([TransactionID]) REFERENCES [dbo].[Transactions] ([TransactionID]) ON DELETE CASCADE
	)
GO