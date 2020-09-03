using BMSwebapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
namespace BMSwebapi.Controllers
{
    public class HomeController : Controller
    {
        private Models.Context _context = new Models.Context();

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Register(Account acc)
        {
            Account AccData = new Account();
            var data = _context.Accounts.ToList().Count() + 5;
            var obj1 = _context.Accounts.Where(a => a.Email.Equals(acc.Email)).FirstOrDefault();
            if (obj1 != null)
            {
                TempData["Message"] = " Account already exists with this Email : " + Convert.ToString(acc.Email);
                return View();
            }
            if (ModelState.IsValid)
            {
                AccData.AccountNumber = Convert.ToInt64(data) + 1 + 2000;
                AccData.FirstName = acc.FirstName;
                AccData.LastName = acc.LastName;
                AccData.Email = acc.Email;
                AccData.Password = acc.Password;
                AccData.ConfirmPassword = acc.ConfirmPassword;
                AccData.Phone = acc.Phone;
                AccData.Address = acc.Address;
                AccData.Balance = acc.Balance;
                _context.Accounts.Add(AccData);
                var re = new EmailController().Email(Convert.ToString(AccData.AccountNumber), Convert.ToString(AccData.Email));
                var result = new SmsController().Rr(Convert.ToString(AccData.AccountNumber), Convert.ToString(AccData.Phone));
                _context.SaveChanges();

                TempData["Message"] = " Your generated account Number is : " + Convert.ToString(AccData.AccountNumber);
                return RedirectToAction("Login");
            }
            return View(acc);
        }


        public ActionResult Login()
        {
            ViewBag.Message = "";
            return View();
        }

        [HttpPost]
        public ActionResult Login(Account obj)
        {
            Console.WriteLine("This is C#");
            string Email = (string)TempData["Email"];
            string Password = (string)TempData["Password"];
            var obj1 = _context.Accounts.Where(a => a.Email.Equals(obj.Email) && a.Password.Equals(obj.Password)).FirstOrDefault();
            var AccData = _context.Accounts.Where(x => x.Email == obj.Email).FirstOrDefault();

            if (obj1 != null)
            {
                Session["AccountNumber"] = Convert.ToInt32(AccData.AccountNumber);
                //Session["UserName"] = obj.FirstName.ToString();
                TempData["Message"] = " Login Successful ";
                return RedirectToAction("Redirect");
            }
            else
            {

                ViewBag.Message = "Invalid Login Data...Please try login again with correct credentials";
                // return View();
            }
            return View(obj);
        }


        public ActionResult Redirect()
        {
            return View();
        }


        public ActionResult Details(int AccountNumber)
        {

            var AccData2 = _context.Accounts.Where(x => x.AccountNumber == AccountNumber).FirstOrDefault();
            return View(AccData2);

        }

    }
}
