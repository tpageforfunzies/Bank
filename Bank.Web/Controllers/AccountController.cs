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
            return RedirectToAction("Details", account);
        }

        // GET: Details
        public ActionResult Details(Accounts model)
        {
            return View(model);
        }
    }
}