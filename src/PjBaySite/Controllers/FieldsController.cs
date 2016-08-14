using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using PjBaySite.Models;
using Microsoft.AspNet.Authorization;

namespace PjBaySite.Controllers
{
    public class FieldsController : Controller
    {
        private ApplicationDbContext _context;

        public FieldsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        [Authorize(Roles = "Admin")]
        // GET: Fields
        public IActionResult Index()
        {
            return View(_context.Fields.ToList());
        }
        [Authorize(Roles = "Admin")]
        // GET: Fields/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Field field = _context.Fields.Single(m => m.ID == id);
            if (field == null)
            {
                return HttpNotFound();
            }

            return View(field);
        }
        [Authorize(Roles = "Admin")]
        // GET: Fields/Create
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        // POST: Fields/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Field field)
        {
            if (ModelState.IsValid)
            {
                _context.Fields.Add(field);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(field);
        }
        [Authorize(Roles = "Admin")]
        // GET: Fields/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Field field = _context.Fields.Single(m => m.ID == id);
            if (field == null)
            {
                return HttpNotFound();
            }
            return View(field);
        }
        [Authorize(Roles = "Admin")]
        // POST: Fields/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Field field)
        {
            if (ModelState.IsValid)
            {
                _context.Update(field);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(field);
        }

        // GET: Fields/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Field field = _context.Fields.Single(m => m.ID == id);
            if (field == null)
            {
                return HttpNotFound();
            }

            return View(field);
        }

        // POST: Fields/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Field field = _context.Fields.Single(m => m.ID == id);
            _context.Fields.Remove(field);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin")]
        //search form for institute name
        public IActionResult Search()
        {
            return View();
        }

        //Search result for institute
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult SearchResult(string name)
        {
            var searchResultQ = from f in _context.Fields
                                where f.fieldName.Contains(name)
                                select f;

            return View(searchResultQ.Distinct());
        }
    }
}
