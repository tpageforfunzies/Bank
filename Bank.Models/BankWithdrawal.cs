using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Models
{
    public class BankWithdrawal
    {
        public int WithdrawalID { get; set; }

        public int TransactionID { get; set; }

        public decimal Amount { get; set; }
    }
}
