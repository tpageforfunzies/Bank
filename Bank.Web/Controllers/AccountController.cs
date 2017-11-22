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
    }
}