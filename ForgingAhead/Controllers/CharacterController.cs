using System;
using System.Collections.Generic;
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
            var model = new CharacterEditViewModel(){
                Character = new Character(),
                SelectedEquipment = new Dictionary<string,bool>()
            };
            SelectEquipmentItems(model.Character, model.SelectedEquipment);
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CharacterEditViewModel viewModel)
        {
            var character = viewModel.Character;

            // Validation
            if (!IsValidSubmission(character))
                return View(viewModel);

            foreach (var item in viewModel.SelectedEquipment.Where(e => e.Value == true).ToList())
                character.Equipment.Add(_context.Equipment.FirstOrDefault(e => e.Name == item.Key));

            _context.Characters.Add(character);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route(CHARACTER + "/{name}/Edit")]
        public IActionResult Edit(string name)
        {
            var model = new CharacterEditViewModel()
            {
                Character = _context.Characters.FirstOrDefault(c => c.Name == name),
                SelectedEquipment = new Dictionary<string, bool>()
            };
            SelectEquipmentItems(model.Character, model.SelectedEquipment);
            ViewData["Title"] = "Edit " + model.Character.Name ?? string.Empty;
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(CharacterEditViewModel viewModel)
        {
            var character = viewModel.Character;

            // Validation
            if (!IsValidSubmission(character))
                return View(viewModel);

            foreach (var item in viewModel.SelectedEquipment.Where(e => e.Value == true).ToList())
                character.Equipment.Add(_context.Equipment.FirstOrDefault(e => e.Name == item.Key));

            _context.Entry(character).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route(CHARACTER + "/{name}/Details")]
        public IActionResult Details(string name)
        {
            // We must use "Include" to enable Eager Loading
            var model = _context.Characters.Include(c => c.Equipment).FirstOrDefault(c => c.Name == name);
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

        private void SelectEquipmentItems(Character character, Dictionary<string, bool> selectedEquipment)
        {
            foreach (var item in _context.Equipment.ToList())
            {
                var matchedItem = character.Equipment.FirstOrDefault(e => e.Name == item.Name);
                selectedEquipment.Add(item.Name, (matchedItem != null));
            }
        }
    }
}
