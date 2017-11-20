using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Models
{
    public class BankAccount
    {
        public int AccountID { get; set; }

        public int AccountNumber { get; set; }

        public int PIN { get; set; }

        public int AccountType { get; set; }

        public int CustomerID { get; set; }

        public virtual BankUser User { get; set; }
    }
}
