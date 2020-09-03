using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.IO;

namespace BMSwebapi.Controllers
{
    public class EmailController : Controller
    {
        // GET: Email
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ViewResult Email(string AccountNumber, string Email)
        {
            if (ModelState.IsValid)
            {
                string toemail = Email;
                string subjectEmail = "Account Created ";
                string comments = "<h3> Your Generated Account Number is: "  + AccountNumber + "</h3>";
                MailMessage message = new MailMessage("pamusrini@gmail.com", toemail, subjectEmail, comments);
                message.IsBodyHtml = true;


                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.Timeout = 8000;
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                //client.Credentials = CredentialCache.DefaultNetworkCredentials;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("pamusrini@gmail.com", "sri10222");
                client.Send(message);
                message.Dispose();
                client.Dispose();
            }

            return View();

        }
    }
}