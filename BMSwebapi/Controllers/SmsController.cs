using Nexmo.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BMSwebapi.Models;

namespace BMSwebapi.Controllers
{
    public class SmsController : Controller
    {
        // GET: SMS
        private Models.Context _context = new Models.Context();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Rr(string AccountNumber, string PhoneNumber)
        {
            var results = SMS.Send(new SMS.SMSRequest
            {
                from = Configuration.Instance.Settings["appsettings:NEXMO_FROM_NUMBER"],
                to = PhoneNumber,
                text = "Your generated Account Number is : " + AccountNumber
            }) ;

            return View();
        }

    }
}