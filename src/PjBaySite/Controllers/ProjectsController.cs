using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using PjBaySite.Models;
using System;

namespace PjBaySite.Controllers
{
    public class ProjectsController : Controller
    {
        private ApplicationDbContext _context;

        public ProjectsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Projects
        public IActionResult Index()
        {
            var applicationDbContext = _context.Projects.Include(p => p.Course);
            return View(applicationDbContext.ToList());
        }

        // GET: Projects/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Project project = _context.Projects.Single(m => m.ID == id);
            if (project == null)
            {
                return HttpNotFound();
            }

            return View(project);
        }

        // GET: Projects/Create
        public IActionResult Create()
        {
            ViewData["CourseID"] = new SelectList(_context.Courses, "ID", "Course");
            return View();
        }

        // POST: Projects/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Project project)
        {
            if (ModelState.IsValid)
            {
                _context.Projects.Add(project);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["CourseID"] = new SelectList(_context.Courses, "ID", "Course", project.CourseID);
            return View(project);
        }

        // GET: Projects/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Project project = _context.Projects.Single(m => m.ID == id);
            if (project == null)
            {
                return HttpNotFound();
            }
            ViewData["CourseID"] = new SelectList(_context.Courses, "ID", "Course", project.CourseID);
            return View(project);
        }

        // POST: Projects/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Project project)
        {
            if (ModelState.IsValid)
            {
                _context.Update(project);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["CourseID"] = new SelectList(_context.Courses, "ID", "Course", project.CourseID);
            return View(project);
        }

        // GET: Projects/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Project project = _context.Projects.Single(m => m.ID == id);
            if (project == null)
            {
                return HttpNotFound();
            }

            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Project project = _context.Projects.Single(m => m.ID == id);
            _context.Projects.Remove(project);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET: Instatutes
        public IActionResult BuyProject()
        {
            return View();
        }
        // GET: Instatutes
        public IActionResult SellProject()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SearchProject(string institute, string course, string project,string field)
        {

            var projects = from i in _context.Projects
                             select i;


            if (!String.IsNullOrEmpty(project))
            {
                projects = projects.Where(s => s.Name.Contains(project));
            }
            /*if(!String.IsNullOrEmpty(course))
            {
                institutes = institutes.Where(s => Courses.Name.Contains(course));
            }
            if(!String.IsNullOrEmpty(course))
            {
                institutes = institutes.Projects.Where(s => s.Name.Contains(project));
            }
            var query = context.Hospitals;
            if (HospitalIDsByState.Any())
                query = query.Where(h => HospitalIDsByState.Contains(h.state));
            if (HospitalIDsByCity.Any())
                query = query.Where(h => HospitalIDsByCity.Contains(h.city));
            if (HospitalIDsByZipcodes.Any())
                query = query.Where(h => HospitalIDsByZipcodes(h.zipcode));

            return query*/

            return View(projects);
        }
    }
}
