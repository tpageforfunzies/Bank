CREATE TABLE Transactions (
	TransactionID int NOT NULL,
	TransactionType int NOT NULL,
	AccountID int NOT NULL,
	CONSTRAINT [PK_dbo.Transactions] PRIMARY KEY CLUSTERED ([TransactionID] ASC),
    CONSTRAINT [FK_dbo.Transactions_dbo.Accounts_AccountID] FOREIGN KEY ([AccountID]) REFERENCES [dbo].[Accounts] ([AccountID]) ON DELETE CASCADE
	)
GO