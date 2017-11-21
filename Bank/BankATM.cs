using Bank.Models;
using Bank.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Security.Cryptography;

namespace Bank
{
    public class BankATM
    {
        public static Accounts CurrentUserAccount { get; set; }

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
                Console.Clear();
                Menu();
                string menuChoice = Console.ReadLine();
                while (menuChoice != "9")
                {
                    switch (menuChoice)
                    {
                        case "1":
                            Deposit();
                            Console.Clear();
                            Menu();
                            menuChoice = Console.ReadLine();
                            break;

                        case "2":
                            Withdrawal();
                            Console.Clear();
                            Menu();
                            menuChoice = Console.ReadLine();
                            break;

                        case "3":
                            Console.Clear();
                            AccountInfo(CurrentUserAccount);
                            Thread.Sleep(3000);
                            Console.Clear();
                            Menu();
                            menuChoice = Console.ReadLine();
                            break;

                        case "4":
                            Console.Clear();
                            PinChange();
                            Menu();
                            menuChoice = Console.ReadLine();
                            break;

                        case "9":
                            Console.Clear();
                            Console.WriteLine("Goodbye.");
                            break;

                        default:
                            break;
                    }
                }
                
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

            CustomerService svc = new CustomerService();
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

            AccountService svc = new AccountService();
            svc.CreateAccount(account);
        }

        public static void LogIn()
        {
            Console.WriteLine("What is your account number?");
            int accountInput = Int32.Parse(Console.ReadLine());

            Console.WriteLine("What is the pin for your account?");
            int pinInput = Int32.Parse(Console.ReadLine());

            AccountService svc = new AccountService();
            CurrentUserAccount = svc.GetAccount(accountInput, pinInput);
            
        }

        public static void AccountInfo(Accounts currentUser)
        {
            Console.Clear();
            Console.WriteLine("Your Account Information:");
            Console.WriteLine("Account Number: " + currentUser.AccountNumber);
            if (currentUser.AccountType == 1)
            {
                Console.WriteLine("Account Type: Checking");
            }
            else
            {
                Console.WriteLine("Account Type: Savings");
            }
            Console.WriteLine("Account Balance: " + currentUser.Balance);
        }

        public static void Menu()
        {
            Console.WriteLine("***********************************************************");
            Console.WriteLine("Please choose an option from the ones below");
            Console.WriteLine("1.  Make a deposit");
            Console.WriteLine("2.  Make a withdrawal");
            Console.WriteLine("3.  Get account information");
            Console.WriteLine("4.  Change your PIN");
            Console.WriteLine("");
            Console.WriteLine("9. Exit");
            Console.WriteLine("***********************************************************");
        }

        public static void Deposit()
        {
            Console.WriteLine("How much would you like to deposit?");
            int depositAmount = Int32.Parse(Console.ReadLine());
            var svc = new TransactionService();
            CurrentUserAccount = svc.MakeDeposit(CurrentUserAccount, depositAmount);
            Console.WriteLine("Your deposit was succesful.");
        }

        public static void Withdrawal()
        {
            Console.WriteLine("How much would you like to withdraw?");
            int withdrawalAmount = Int32.Parse(Console.ReadLine());
            var svc = new TransactionService();
            CurrentUserAccount = svc.MakeWithdrawal(CurrentUserAccount, withdrawalAmount);
            Console.WriteLine("Your withdrawal was successful.");
        }

        public static void PinChange()
        {
            Console.WriteLine("Enter your current PIN:");
            int currentPin = Int32.Parse(Console.ReadLine());
            if (currentPin == CurrentUserAccount.PIN)
            {
                Console.WriteLine("What would you like to change your pin to?");
                int newPin = Int32.Parse(Console.ReadLine());
                var svc = new AccountService();
                CurrentUserAccount = svc.ChangePin(CurrentUserAccount, newPin);
                Console.WriteLine("You have successfully changed your PIN.");
                Thread.Sleep(2000);
                Console.Clear();
                
            }
            else
            {
                Console.WriteLine("That is not the correct PIN.");
            }
            

        }
    }
}
