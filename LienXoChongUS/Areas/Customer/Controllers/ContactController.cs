using LXxUS.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;

namespace LienXoChongUS.Areas.Customer.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Index(Contact contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    MailMessage msz = new MailMessage();
                    msz.From = new MailAddress(contact.Email);//Email which you are getting 
                                                         //from contact us page 
                    msz.To.Add("emailaddrss@gmail.com");//Where mail will be sent 
                    msz.Subject = contact.Subject;
                    msz.Body = contact.Message;
                    SmtpClient smtp = new SmtpClient();

                    smtp.Host = "smtp.gmail.com";

                    smtp.Port = 587;

                    smtp.Credentials = new System.Net.NetworkCredential
                    ("youremailid@gmail.com", "password");

                    smtp.EnableSsl = true;

                    smtp.Send(msz);

                    ModelState.Clear();
                    ViewBag.Message = "Thank you for Contacting us ";
                }
                catch (Exception ex)
                {
                    ModelState.Clear();
                    ViewBag.Message = $" Sorry we are facing Problem here {ex.Message}";
                }
            }

            return View();
        }
        public IActionResult Error()
        {
            return View();
        }
    }
}
