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
            return Ok(GetDiffBetweenNow(new DateTime(1990, 6, 19)));
        }

        public IActionResult GetExperienceYears()
        {
            return Ok(GetDiffBetweenNow(new DateTime(2014, 9, 25)));
        }

        private static int GetDiffBetweenNow(DateTime calculateDate)
        {
            var date = DateTime.Now;
            var result = date.Year - calculateDate.Year;
            
            return result - 1;
        }

    }
}