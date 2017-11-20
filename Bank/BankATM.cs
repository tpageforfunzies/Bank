using Bank.Models;
using Bank.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class BankATM
    {
        public static void Start()
        {
            Console.WriteLine("Do you have an account?");
            string hasAccount = Console.ReadLine();
            if (hasAccount == "no")
            {
                Console.WriteLine("We'll begin with your info, then your account info.");
                GetCustomerInfo();
            }
            else
            {
                Console.WriteLine("ok then");
            }

        }

        public static void GetCustomerInfo()
        {
            Console.WriteLine("What is your first name");
            string userFirstName = Console.ReadLine();
            Console.WriteLine("What is your last name?");
            string userLastName = Console.ReadLine();
            Customers user =
                new Customers
                {
                    FirstName = userFirstName,
                    LastName = userLastName
                };

            BankService svc = new BankService();
            svc.CreateCustomer(user);
            GetAccountInfo(user.CustomerID);
        }


        public static void GetAccountInfo(int id)
        {
            Console.WriteLine("Which kind of account would you like?");
            Console.WriteLine("1 -- Checking");
            Console.WriteLine("2 -- Savings");
            string userType = Console.ReadLine();

            Console.WriteLine("What would you like your pin to be?");
            string userPin = Console.ReadLine();

            Console.WriteLine("What would you like your account number to be?");
            string userAccountNumber = Console.ReadLine();

            Accounts account =
                new Accounts
                {
                    AccountNumber = Int32.Parse(userAccountNumber),
                    PIN = Int32.Parse(userPin),
                    AccountType = Int32.Parse(userType),
                    CustomerID = id,
                    Balance = 0
                };

            BankService svc = new BankService();
            svc.CreateAccount(account);
        }

    }
}
