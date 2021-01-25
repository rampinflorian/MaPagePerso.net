using System.Configuration;
using System.Threading.Tasks;
using Core.Flash;
using MailKit.Net.Smtp;
using MaPagePerso.net.Form;
using MaPagePerso.net.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MimeKit;

namespace MaPagePerso.net.Controllers
{
    public class ContactController : Controller
    {
        private readonly ILogger<ContactController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IFlasher _flasher;
        private readonly MailerService _mailerService;

        public ContactController(ILogger<ContactController> logger, IConfiguration configuration, IFlasher flasher, MailerService mailerService)
        {
            _logger = logger;
            _configuration = configuration;
            _flasher = flasher;
            _mailerService = mailerService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Mailer([Bind("Username,Mail,Content")] Mailer mailer)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            await _mailerService.SendContact(mailer);            
            
            return RedirectToAction("Index");
        }
    }
}