using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ForgingAhead.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ForgingAhead.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            // We must use "Include" to enable Eager Loading
            var model = _context.Characters.Include(c => c.Equipment).ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
