using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Models
{
    public class BankUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int UserID { get; set; }

        public virtual ICollection<BankAccount> Accounts { get; set; }
    }
}
