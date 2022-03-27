using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MaPagePerso.net.Models;

namespace MaPagePerso.net.Controllers.API
{
    public class LayoutController : Controller
    {
        private readonly ILogger<LayoutController> _logger;

        public LayoutController(ILogger<LayoutController> logger)
        {
            _logger = logger;
        }

        public IActionResult GetYearsOld()
        {
            var yo = GetDiffBetweenNow(new DateTime(1990, 6, 19));
            return Ok(yo);
        }

        public IActionResult GetExperienceYears()
        {
            return Ok(GetDiffBetweenNow(new DateTime(2012, 9, 25)));
        }

        private static int GetDiffBetweenNow(DateTime anniversaryDate)
        {
            DateTime now = DateTime.Today;
            var age = now.Year - anniversaryDate.Year;
            if (anniversaryDate > now.AddYears(-age)) 
                age--;
            return age;
        }

    }
}