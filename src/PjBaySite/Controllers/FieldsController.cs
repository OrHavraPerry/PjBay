using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using PjBaySite.Models;

namespace PjBaySite.Controllers
{
    public class FieldsController : Controller
    {
        private ApplicationDbContext _context;

        public FieldsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Fields
        public IActionResult Index()
        {
            return View(_context.Fields.ToList());
        }

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

        // GET: Fields/Create
        public IActionResult Create()
        {
            return View();
        }

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
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Field field = _context.Fields.Single(m => m.ID == id);
            _context.Fields.Remove(field);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        //search form for institute name
        public IActionResult Search()
        {
            return View();
        }

        //Search result for institute
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
