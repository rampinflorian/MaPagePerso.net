using System.Linq;
using System.Threading.Tasks;
using AspNetCore.ReCaptcha;
using Core.Flash;
using MaPagePerso.net.Form;
using Microsoft.AspNetCore.Mvc;
using MaPagePerso.net.Services;
using MaPagePerso.net.ViewsModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MaPagePerso.net.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFlasher _flasher;
        private readonly MailerService _mailerService;
        private readonly GetYearsService _getYearsService;
        private readonly ProjectService _projectService;

        public HomeController(IFlasher flasher, MailerService mailerService, GetYearsService getYearsService, ProjectService projectService)
        {
            _flasher = flasher;
            _mailerService = mailerService;
            _getYearsService = getYearsService;
            _projectService = projectService;
        }
        public async Task<IActionResult> Index()
        {
            

            
            return View(new HomeViewsModels 
                { 
                    Projects = _projectService.GetAllProjects().OrderByDescending(m => m.CreatedAt).ToList(),
                    mailer = new Mailer(),
                    YearsOld = _getYearsService.GetYearsOld(),
                    YearsExperience = _getYearsService.GetExperienceYears()
                }
            );
            
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
                    _flasher.Flash(Types.Danger, "BIP BOOP BUP ! Vous êtes un robot ? Il faut valider le Captcha !", dismissable: false);
                }
                return RedirectToAction("Index");
            }

            await _mailerService.SendContact(mailer);            
            _flasher.Flash(Types.Success, "Votre message a bien été envoyé !", dismissable: false);

            
            return RedirectToAction("Index");
        }
    }
}