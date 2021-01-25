using System.Linq;
using System.Threading.Tasks;
using AspNetCore.ReCaptcha;
using Core.Flash;
using MaPagePerso.net.Form;
using MaPagePerso.net.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MaPagePerso.net.Controllers
{
    public class ContactController : Controller
    {
        private readonly IFlasher _flasher;
        private readonly MailerService _mailerService;

        public ContactController(IFlasher flasher, MailerService mailerService)
        {
            _flasher = flasher;
            _mailerService = mailerService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateReCaptcha]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Mailer([Bind("Username,Mail,Content")] Mailer mailer)
        {
            if (!ModelState.IsValid)
            {
                var resCaptcha = ModelState.First(k => k.Key == "Recaptcha").Value;
                if (resCaptcha.ValidationState == ModelValidationState.Invalid)
                {
                    _flasher.Flash(Types.Danger, "BIP BOOP BUP ! Vous êtes un robot ? Il faut valider le Captcha !", dismissable: true);
                }
                return RedirectToAction("Index");
            }

            await _mailerService.SendContact(mailer);            
            _flasher.Flash(Types.Success, "Votre message a bien été envoyé !", dismissable: true);

            
            return RedirectToAction("Index");
        }
    }
}