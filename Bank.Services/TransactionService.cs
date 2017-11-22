using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Models;

namespace Bank.Services
{
    public class TransactionService
    {
        public Accounts MakeDeposit(Accounts model, int deposit)
        {
            BankDBEntities db = new BankDBEntities();
            
                var entity =
                    db
                    .Accounts
                       .Where(e => e.AccountNumber == model.AccountNumber && e.PIN == model.PIN)
                       .Single();
                entity.Balance += deposit;

                UpdateTables(model, 1, deposit);
                db.SaveChanges();
                return entity;
            
        }

        public Accounts MakeWithdrawal(Accounts model, int withdrawal)
        {
            using (BankDBEntities db = new BankDBEntities())
            {
                var entity =
                    db
                    .Accounts
                       .Where(e => e.AccountNumber == model.AccountNumber && e.PIN == model.PIN)
                       .Single();
                entity.Balance -= withdrawal;

                UpdateTables(model, 2, withdrawal);
                db.SaveChanges();
                return entity;
            }
        }

        public void UpdateTables(Accounts model, int type, int change)
        {
            using (BankDBEntities db = new BankDBEntities())
            {
                Transactions updateTransactions = new Transactions();
                updateTransactions.TransactionType = type;
                updateTransactions.AccountID = model.AccountID;
                db.Transactions.Add(updateTransactions);

                if (type == 1)
                {
                    Deposits updateDeposits = new Deposits();
                    updateDeposits.TransactionID = updateTransactions.TransactionID;
                    updateDeposits.Amount = change;
                    db.Deposits.Add(updateDeposits);
                }

                else
                {
                    Withdrawls updateWithdrawals = new Withdrawls();
                    updateWithdrawals.TransactionID = updateTransactions.TransactionID;
                    updateWithdrawals.Amount = change;
                    db.Withdrawls.Add(updateWithdrawals);
                }
                db.SaveChanges();
            }
                
        }
    }
}
