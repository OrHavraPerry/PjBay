using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using PjBaySite.Models;


namespace PjBaySite.Controllers
{
    public class InstitutesController : Controller
    {
        private ApplicationDbContext _context;

        public InstitutesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Instatutes
        public IActionResult Index()
        {
            return View(_context.Institutes.ToList());
        }

        // GET: Instatutes/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Institute institute = _context.Institutes.Single(m => m.ID == id);
            if (institute == null)
            {
                return HttpNotFound();
            }

            return View(institute);
        }

        // GET: Instatutes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Instatutes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Institute instatute)
        {
            if (ModelState.IsValid)
            {
                _context.Institutes.Add(instatute);
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

            Institute instatute = _context.Institutes.Single(m => m.ID == id);
            if (instatute == null)
            {
                return HttpNotFound();
            }
            return View(instatute);
        }

        // POST: Instatutes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Institute instatute)
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

            Institute instatute = _context.Institutes.Single(m => m.ID == id);
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
            Institute instatute = _context.Institutes.Single(m => m.ID == id);
            _context.Institutes.Remove(instatute);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
