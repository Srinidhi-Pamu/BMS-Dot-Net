using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BMSwebapi.Controllers
{
    public class PassBookController : Controller
    {
        private Models.Context _context = new Models.Context();
        // GET: Passbook
        public ActionResult Pass(int AccountNumber)
        {
            var AccData2 = _context.PassBooks.Where(x => x.AccountNumber == AccountNumber).ToList();
            ViewBag.userdetails = AccData2;
            return View();
        }
    }
}