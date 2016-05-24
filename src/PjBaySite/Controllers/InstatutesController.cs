using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using PjBaySite.Models;

namespace PjBaySite.Controllers
{
    public class InstatutesController : Controller
    {
        private ApplicationDbContext _context;

        public InstatutesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Instatutes
        public IActionResult Index()
        {
            return View(_context.Instatutes.ToList());
        }

        // GET: Instatutes/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Instatute instatute = _context.Instatutes.Single(m => m.ID == id);
            if (instatute == null)
            {
                return HttpNotFound();
            }

            return View(instatute);
        }

        // GET: Instatutes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Instatutes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Instatute instatute)
        {
            if (ModelState.IsValid)
            {
                _context.Instatutes.Add(instatute);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(instatute);
        }

        // GET: Instatutes/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Instatute instatute = _context.Instatutes.Single(m => m.ID == id);
            if (instatute == null)
            {
                return HttpNotFound();
            }
            return View(instatute);
        }

        // POST: Instatutes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Instatute instatute)
        {
            if (ModelState.IsValid)
            {
                _context.Update(instatute);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(instatute);
        }

        // GET: Instatutes/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Instatute instatute = _context.Instatutes.Single(m => m.ID == id);
            if (instatute == null)
            {
                return HttpNotFound();
            }

            return View(instatute);
        }

        // POST: Instatutes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Instatute instatute = _context.Instatutes.Single(m => m.ID == id);
            _context.Instatutes.Remove(instatute);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
