﻿using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.ReCaptcha;
using Core.Flash;
using MaPagePerso.net.Data;
using MaPagePerso.net.Form;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MaPagePerso.net.Models;
using MaPagePerso.net.Services;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace MaPagePerso.net.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IFlasher _flasher;
        private readonly MailerService _mailerService;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, IFlasher flasher, MailerService mailerService)
        {
            _context = context;
            _flasher = flasher;
            _mailerService = mailerService;
        }
        public async Task<IActionResult> Index()
        {
            var projects = await _context.Projects.OrderByDescending(m => m.CreatedAt).ToListAsync();
            return View(projects);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
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