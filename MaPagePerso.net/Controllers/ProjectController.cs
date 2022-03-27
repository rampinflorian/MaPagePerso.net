using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MaPagePerso.net.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MaPagePerso.net.Models;
using Microsoft.EntityFrameworkCore;

namespace MaPagePerso.net.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectController(ApplicationDbContext context)
        {
            _context = context;
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
    }
}