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
            using (BankDBEntities db = new BankDBEntities())
            {
                var entity =
                    db
                    .Accounts
                       .Where(e => e.AccountNumber == model.AccountNumber && e.PIN == model.PIN)
                       .Single();

                entity.Balance += deposit;
                db.SaveChanges();
                return entity;
            }
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
                db.SaveChanges();
                return entity;
            }
        }
    }
}
