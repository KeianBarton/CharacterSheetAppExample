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

        [HttpPost]
        public IActionResult Create(Equipment equipment)
        {
            _context.Equipment.Add(equipment);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Index()
        {
            var model = _context.Equipment.ToList();
            return View(model);
        }

        public IActionResult GetFiltered(Func<Equipment, bool> del)
        {
            var model = _context.Equipment.Where(del).ToList();
            return View(model);
        }

        public IActionResult Details(Equipment equipment)
        {
            var model = _context.Equipment.FirstOrDefault(c => c.Name == equipment.Name);

            return View(model);
        }

        public IActionResult Update(Equipment equipment)
        {
            _context.Entry(equipment).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Equipment equipment)
        {
            var original = _context.Equipment.FirstOrDefault(c => c.Name == equipment.Name);
            if (original != null)
            {
                _context.Equipment.Remove(original);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult DeleteAllEquipment()
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
