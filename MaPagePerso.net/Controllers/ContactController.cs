using MaPagePerso.net.Form;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MimeKit;

namespace MaPagePerso.net.Controllers
{
    public class ContactController : Controller
    {
        private readonly ILogger<ContactController> _logger;

        public ContactController(ILogger<ContactController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("contact/mailer", Name = "Mailer")]
        public IActionResult Mailer([Bind("Username,Mail,Content")] Mailer mailer)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");

            }

            var email = new MimeMessage();
            
            email.From.Add(MailboxAddress.Parse("contact@florianrampin.fr"));
            email.To.Add(MailboxAddress.Parse("contact@florianrampin.fr"));

            email.Subject = $"FlorianRampin.fr - Nouveau contact : {mailer.Username}";
            
            var toto = mailer;
            return RedirectToAction("Index");
        }
        
        
    }
}