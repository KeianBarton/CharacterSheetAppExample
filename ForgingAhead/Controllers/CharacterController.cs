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
        private const string CHARACTERS = "Characters";

        public CharacterController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(Character character)
        {
            _context.Characters.Add(character);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Index()
        {
            var model = _context.Characters.ToList();
            return View(model);
        }

        public IActionResult GetFiltered(Func<Character,bool> del)
        {
            var model = _context.Characters.Where(del).ToList();
            return View(model);
        }

        public IActionResult Details(Character character)
        {
            var model = _context.Characters.FirstOrDefault(c => c.Name == character.Name);
            // TODO
            return View(model);
        }

        public IActionResult Update(Character character)
        {
            _context.Entry(character).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Character character)
        {
            var original = _context.Characters.FirstOrDefault(c => c.Name == character.Name);
            if (original != null)
            {
                _context.Characters.Remove(original);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
