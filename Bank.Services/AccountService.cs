using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Models;

namespace Bank.Services
{
    public class AccountService
    {
        public Accounts GetAccount(int num, int pin)
        {
            using (BankDBEntities db = new BankDBEntities())
            {
                return
                    db
                       .Accounts
                       .Where(e => e.AccountNumber == num && e.PIN == pin)
                       .Single();
            }
        }

        public void CreateAccount(Accounts model)
        {
            using (BankDBEntities db = new BankDBEntities())
            {
                db.Accounts.Add(model);
                db.SaveChanges();
            }
        }

        public Accounts ChangePin(Accounts model, int newPin)
        {
            using (BankDBEntities db = new BankDBEntities())
            {
                var entity =
                    db
                    .Accounts
                       .Where(e => e.AccountNumber == model.AccountNumber && e.PIN == model.PIN)
                       .Single();

                entity.PIN = newPin;
                db.SaveChanges();
                return entity;
            }
        }

    }
}


