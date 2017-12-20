using System;
using System.Linq;
using ForgingAhead.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ForgingAhead.Controllers
{
    public class CharacterController : Controller
    {
        private readonly ApplicationDbContext _context;
        private const string CHARACTER = "Character";

        public CharacterController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _context.Characters.ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Character character)
        {
            // Validation
            if (!IsValidSubmission(character))
                return View(character);

            _context.Characters.Add(character);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route(CHARACTER + "/{name}/Edit")]
        public IActionResult Edit(string name)
        {
            var model = _context.Characters.FirstOrDefault(c => c.Name == name);
            ViewData["Title"] = "Edit " + model.Name ?? string.Empty;
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(Character character)
        {
            // Validation
            if (!IsValidSubmission(character))
                return View(character);

            _context.Entry(character).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult GetFiltered(Func<Character,bool> del)
        {
            var model = _context.Characters.Where(del).ToList();
            return View(model);
        }

        [HttpGet]
        [Route(CHARACTER + "/{name}/Details")]
        public IActionResult Details(string name)
        {
            var model = _context.Characters.FirstOrDefault(c => c.Name == name);
            return View(model);
        }

        [HttpPost]
        [Route(CHARACTER + "/{name}/Delete")]
        public IActionResult Delete(string name)
        {
            var original = _context.Characters.FirstOrDefault(c => c.Name == name);
            if (original != null)
            {
                _context.Characters.Remove(original);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        [HttpPost]
        public IActionResult DeleteAll()
        {
            foreach(var character in _context.Characters)
            {
                Delete(character.Name);
            }
            return RedirectToAction("Index");
        }

        private bool IsValidSubmission(Character character)
        {
            if (_context.Characters.Any(c => c.Name == character.Name))
                ModelState.AddModelError("Name", "Name is already in use.");
            return ModelState.IsValid;
        }
    }
}
