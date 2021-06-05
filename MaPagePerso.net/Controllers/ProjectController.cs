using System.Diagnostics;
using System.Threading.Tasks;
using MaPagePerso.net.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MaPagePerso.net.Models;

namespace MaPagePerso.net.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ILogger<ProjectController> _logger;

        public ProjectController(ILogger<ProjectController> logger, ApplicationDbContext context)
        {
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}