using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CharacterSheetApp.Models;

namespace CharacterSheetApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(Character.GetAll());
        }

        public IActionResult Create(string CharacterName)
        {
            new Character(CharacterName);
            return RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
