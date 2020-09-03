using BMSwebapi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BMSwebapi.Controllers
{
    public class TransactionDetailController : Controller
    {
        private Models.Context _context = new Models.Context();
        // GET: TransactionDetails
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Deposit(int AccountNumber)
        {

            var AccData = _context.TransactionDetails.Where(x => x.AccountNumber == AccountNumber).FirstOrDefault();
            if (AccData != null)
            {
                TempData["AccountNumber"] = AccountNumber;
                TempData.Keep();
                return View();
            }
            return View();
        }

        [HttpPost]
        public ActionResult Deposit(TransactionDetail obj)
        {
            int AccountNumber = Convert.ToInt32(obj.AccountNumber);
            var AccData2 = _context.Accounts.Where(x => x.AccountNumber == AccountNumber).FirstOrDefault();
            TransactionDetail AccData = new TransactionDetail();
            PassBook AccData3 = new PassBook();

            if (AccData2 != null)
            {
                AccData2.AccountNumber = obj.AccountNumber;
                AccData2.Balance = AccData2.Balance + obj.Amount;
                // AccData.TimeofTransaction = DateTime.Now;
                _context.Entry(AccData2).State = EntityState.Modified;
                _context.SaveChanges();
            }

            AccData.AccountNumber = AccData2.AccountNumber;
            AccData.Amount = obj.Amount;
            AccData.TimeofTransaction = DateTime.Now;

            AccData3.AccountNumber = AccData2.AccountNumber;
            AccData3.Amount = obj.Amount;
            AccData3.TimeofTransaction = DateTime.Now;
            AccData3.Mode = "Deposit";
            _context.TransactionDetails.Add(AccData);
            _context.SaveChanges();
            _context.PassBooks.Add(AccData3);
            _context.SaveChanges();

            TempData["Message"] = " Amount Rs. " + Convert.ToString(AccData.Amount) + " was successfully Deposited ";

            return RedirectToAction("../Home/Redirect");
        }

        public ActionResult Withdraw(int AccountNumber)
        {

            var AccData = _context.TransactionDetails.Where(x => x.AccountNumber == AccountNumber).FirstOrDefault();
            if (AccData != null)
            {
                TempData["AccountNumber"] = AccountNumber;
                TempData.Keep();
                return View();
            }
            return View();
        }

        [HttpPost]
        public ActionResult Withdraw(TransactionDetail obj)
        {
            int AccountNumber = Convert.ToInt32(obj.AccountNumber);
            var AccData2 = _context.Accounts.Where(x => x.AccountNumber == AccountNumber).FirstOrDefault();
            TransactionDetail AccData = new TransactionDetail();
            PassBook AccData3 = new PassBook();

            if (AccData2 != null)
            {
                AccData2.AccountNumber = obj.AccountNumber;
                AccData2.Balance = AccData2.Balance - obj.Amount;
                // AccData.TimeofTransaction = DateTime.Now;
                _context.Entry(AccData2).State = EntityState.Modified;
                _context.SaveChanges();
            }

            AccData.AccountNumber = AccData2.AccountNumber;
            AccData.Amount = obj.Amount;
            AccData.TimeofTransaction = DateTime.Now;

            AccData3.AccountNumber = AccData2.AccountNumber;
            AccData3.Amount = obj.Amount;
            AccData3.TimeofTransaction = DateTime.Now;
            AccData3.Mode = "Withdraw";
            _context.TransactionDetails.Add(AccData);
            _context.SaveChanges();
            _context.PassBooks.Add(AccData3);
            _context.SaveChanges();

            TempData["Message"] = " Amount Withdrawl of Rs. " + Convert.ToString(AccData.Amount) + " was Successful ";

            return RedirectToAction("../Home/Redirect");
        }
        public ActionResult Transfer(int AccountNumber)
        {
            var AccData = _context.TransactionDetails.Where(x => x.AccountNumber == AccountNumber).FirstOrDefault();
            if (AccData != null)
            {
                TempData["AccountNumber"] = AccountNumber;
                TempData.Keep();
                return View();
            }
            return View();
        }

        [HttpPost]
        public ActionResult Transfer(TransactionDetail obj, string YourItemName)
        {
            //int AccountNumber1 = Convert.ToInt32(TempData["AccountNumber1"]); 
            int AccountNumber1 = Convert.ToInt32(YourItemName);
            int AccountNumber = Convert.ToInt32(obj.AccountNumber);
            var AccData2 = _context.Accounts.Where(x => x.AccountNumber == AccountNumber).FirstOrDefault();
            var AccData4 = _context.Accounts.Where(x => x.AccountNumber == AccountNumber1).FirstOrDefault();
            TransactionDetail AccData = new TransactionDetail();
            PassBook AccData3 = new PassBook();
            PassBook AccData5 = new PassBook();
            TransactionDetail AccData6 = new TransactionDetail();

            if (AccData2 != null)
            {
                AccData2.AccountNumber = obj.AccountNumber;
                AccData2.Balance = AccData2.Balance - obj.Amount;
                AccData4.Balance = AccData4.Balance + obj.Amount;
                // AccData.TimeofTransaction = DateTime.Now;
                _context.Entry(AccData2).State = EntityState.Modified;
                _context.Entry(AccData4).State = EntityState.Modified;
                _context.SaveChanges();
            }

            AccData.AccountNumber = AccData2.AccountNumber;
            AccData.Amount = obj.Amount;
            AccData.TimeofTransaction = DateTime.Now;
            AccData6.AccountNumber = AccountNumber1;
            AccData6.Amount = obj.Amount;
            AccData6.TimeofTransaction = DateTime.Now;
            AccData3.AccountNumber = AccData2.AccountNumber;
            AccData3.Amount = obj.Amount;
            AccData3.TimeofTransaction = DateTime.Now;
            AccData3.Mode = "Transfer Sent to  " + Convert.ToString(AccData4.FirstName);
            AccData5.AccountNumber = AccountNumber1;
            AccData5.Amount = obj.Amount;
            AccData5.TimeofTransaction = DateTime.Now;
            AccData5.Mode = "Transfer Recived from " + Convert.ToString(AccData2.FirstName);
            _context.TransactionDetails.Add(AccData);
            _context.TransactionDetails.Add(AccData6);
            _context.PassBooks.Add(AccData3);
            _context.PassBooks.Add(AccData5);
            _context.SaveChanges();

            TempData["Message"] = " Amount is Successfully transfered to " + Convert.ToString(AccData4.FirstName) + " from " + Convert.ToString(AccData2.FirstName);

            return RedirectToAction("../Home/Redirect");


        }

    }
}