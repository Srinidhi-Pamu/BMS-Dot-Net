using BMSwebapi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BMSwebapi.Controllers
{
    public class AccountController : Controller
    {
        private Models.Context _context = new Models.Context();
        public ActionResult UpdateDetails(int? AccountNumber)
        {

            var AccData2 = _context.Accounts.Where(x => x.AccountNumber == AccountNumber).FirstOrDefault();

            return View(AccData2);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateDetails(Account acc)
        {
            var AccData2 = _context.Accounts.Where(x => x.AccountNumber == acc.AccountNumber).FirstOrDefault();
            if (ModelState.IsValid)
            {
                AccData2.FirstName = acc.FirstName;
                AccData2.LastName = acc.LastName;
                AccData2.Password = acc.Password;
                AccData2.Phone = acc.Phone;
                AccData2.Email = acc.Email;
                AccData2.Address = acc.Address;
                AccData2.ConfirmPassword = acc.ConfirmPassword;
                AccData2.FirstName = acc.FirstName;
                _context.Entry(AccData2).State = EntityState.Modified;
               
                _context.SaveChanges();

                TempData["Message"] = " Your Account Details were Succesfully Updated ";

                return RedirectToAction("../Home/Redirect");
            }


            return View(acc);
        }
     
        public ActionResult Delete(int AccountNumber)
        {

            var AccData2 = _context.Accounts.Where(x => x.AccountNumber == AccountNumber).FirstOrDefault();

            return View(AccData2);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAccount(Account Acc)
        {
            Account Acc1 = new Account();

            Acc1 = _context.Accounts.Where(x => x.AccountNumber == Acc.AccountNumber).FirstOrDefault();
            
           _context.Accounts.Remove(Acc1);
            _context.SaveChanges();
            return RedirectToAction("../Home/Index");
        }
    }
}