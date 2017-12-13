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
            if(!string.IsNullOrEmpty(CharacterName))
                new Character(CharacterName);

            return RedirectToAction("Index");
        }

        public IActionResult Remove(string CharacterName)
        {
            var characterInList = GlobalVariables.Characters
                .Where(c => string.Equals(c.Name, CharacterName, StringComparison.OrdinalIgnoreCase))
                .FirstOrDefault();
            if (characterInList != null)
            {
                GlobalVariables.Characters.Remove(characterInList);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
