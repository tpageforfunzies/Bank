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
                NewCustomerInfo();
            }
            else
            {
                LogIn();

            }

        }

        public static void NewCustomerInfo()
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
            NewAccountInfo(user.CustomerID);
        }


        public static void NewAccountInfo(int id)
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

        public static void LogIn()
        {
            Console.WriteLine("What is your account number?");
            int accountInput = Int32.Parse(Console.ReadLine());

            Console.WriteLine("What is the pin for your account?");
            int pinInput = Int32.Parse(Console.ReadLine());

            BankService svc = new BankService();
            var userAccount = svc.GetAccount(accountInput, pinInput);
            AccountInfo(userAccount);
        }

        public static void AccountInfo(Accounts account)
        {
            Console.Clear();
            Console.WriteLine("Your Account Information:");
            Console.WriteLine("Account Number: " + account.AccountNumber);
            if (account.AccountType == 1)
            {
                Console.WriteLine("Account Type: Checking");
            }
            else
            {
                Console.WriteLine("Account Type: Savings");
            }
            Console.WriteLine("Account Balance: " + account.Balance);
        }

    }
}
