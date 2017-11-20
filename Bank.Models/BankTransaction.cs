using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Models
{
    public class BankTransaction
    {
        public int TransactionID { get; set; }

        public int TransactionType { get; set; }

        public int AccountID { get; set; }

        public virtual ICollection<BankDeposit> Deposits { get; set; }

        public virtual ICollection<BankWithdrawal> Withdrawals { get; set; }
    }
}
