using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.ContactViewModels;

namespace WebApplication1.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Send([Bind("Naam, Email, Onderwerp, Bericht")] ContactEmailViewModel contactEmailViewModel)
        {
            if (ModelState.IsValid)
            {
                var smtpClient = new SmtpClient
                {
                    Host = "smtp.gmail.com", // set your SMTP server name here
                    Port = 587, // Port 
                    EnableSsl = true,
                    Credentials = new NetworkCredential("noreplyraphaelborro@gmail.com", "pomqedioxlnsgecz")
                };

                using (var message = new MailMessage("noreplyraphaelborro@gmail.com", contactEmailViewModel.Email)
                {
                    Subject = contactEmailViewModel.Onderwerp,
                    Body = string.Format(
                    @"
Bericht van: {0}
E-mail: {1}

Bericht: {2}
                    ", 
                    contactEmailViewModel.Naam,
                    contactEmailViewModel.Email,
                    contactEmailViewModel.Bericht)
                })
                {
                   await smtpClient.SendMailAsync(message);
                }
            }
            ViewData["Status"] = "Email verzonden";
            return View(nameof(Index));
        }
    }


}