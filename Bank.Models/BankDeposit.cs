using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Models
{
    public class BankDeposit
    {
        public int DepositID { get; set; }

        public int TransactionID { get; set; }

        public decimal Amount { get; set; }

        public virtual BankTransaction Transaction { get; set; }
    }
}
