using Bank.Models;
using Bank.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bank.Web.Controllers
{
    public class AccountController : Controller
    {
        public Accounts CurrentUser { get; set; }

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Accounts model)
        {
            Session.Clear();
            AccountService svc = new AccountService();
            var account = svc.GetAccount(model.AccountNumber, model.PIN);
            Session["CurrentUser"] = account;

            return RedirectToAction("Details", account);
        }

        // GET: Details
        public ActionResult Details(Accounts model)
        {
            return View(model);
        }

        // GET: Deposit
        public ActionResult Deposit()
        {
            return View();
        }

        // POST: Deposit
        [HttpPost]
        public ActionResult Deposit(Deposits model)
        {
            TransactionService svc = new TransactionService();
            var account = svc.MakeDeposit((Accounts)Session["CurrentUser"], (int)model.Amount);

            return RedirectToAction("Details", account);
        }

        // GET: Withdraw
        public ActionResult Withdraw()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Withdraw(Withdrawls model)
        {
            TransactionService svc = new TransactionService();
            var account = svc.MakeWithdrawal((Accounts)Session["CurrentUser"], (int)model.Amount);

            return RedirectToAction("Details", account);
        }

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        public ActionResult Create(Accounts model)
        {
            model.CustomerID = 2;
            model.Balance = 0;
            AccountService svc = new AccountService();
            svc.CreateAccount(model);
            Session.Clear();
            Session["CurrentUser"] = model;

            return RedirectToAction("Details", model);
        }

        // GET: ChangePIN
        public ActionResult ChangePIN()
        {
            return View();
        }
        
        // POST: ChangePIN
        [HttpPost]
        public ActionResult ChangePin(Accounts model)
        {
            AccountService svc = new AccountService();
            int newPIN = model.PIN;
            svc.ChangePin((Accounts)Session["CurrentUser"], model.PIN);

            return RedirectToAction("Details", (Accounts)Session["CurrentUser"]);
        }
    }
}