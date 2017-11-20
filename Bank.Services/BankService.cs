using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Models;

namespace Bank.Services
{
    public class BankService
    {
        public bool CreateCustomer(Customers model)
        {
            using (BankDBEntities db = new BankDBEntities())
            {
                db.Customers.Add(model);
                db.SaveChanges();
                return db.SaveChanges() == 1;
            }

        }
    }
}
