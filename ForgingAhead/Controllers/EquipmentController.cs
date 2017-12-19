using System;
using System.Linq;
using ForgingAhead.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ForgingAhead.Controllers
{
    public class EquipmentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private const string EQUIPMENT = "Equipment";

        public EquipmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _context.Equipment.ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Equipment equipment)
        {
            _context.Equipment.Add(equipment);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route(EQUIPMENT + "/{name}/Edit")]
        public IActionResult Edit(string name)
        {
            var model = _context.Equipment.FirstOrDefault(e => e.Name == name);
            ViewData["Title"] = "Edit " + model.Name ?? string.Empty;
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(Equipment equipment)
        {
            _context.Entry(equipment).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult GetFiltered(Func<Equipment, bool> del)
        {
            var model = _context.Equipment.Where(del).ToList();
            return View(model);
        }

        [HttpGet]
        [Route(EQUIPMENT + "/{name}/Details")]
        public IActionResult Details(string name)
        {
            var model = _context.Equipment.FirstOrDefault(e => e.Name == name);
            return View(model);
        }

        [HttpPost]
        [Route(EQUIPMENT + "/{name}/Delete")]
        public IActionResult Delete(string name)
        {
            var original = _context.Equipment.FirstOrDefault(e => e.Name == name);
            if (original != null)
            {
                _context.Equipment.Remove(original);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteAll()
        {
            foreach(var equipment in _context.Equipment)
            {
                _context.Entry(equipment).State = EntityState.Deleted;
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
