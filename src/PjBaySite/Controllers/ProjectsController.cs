using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using PjBaySite.Models;
using System;
using System.Collections.Generic;

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
            //-----filling viewData of courses------
            var courses = new List<string>();

            // a query which takes the names of courses
            var coursesQ = from i in _context.Courses
                           select i.Name;
            //put the courses list into courses
            courses.AddRange(coursesQ.Distinct());

            //filling the viewData parameter which passes to the view
            ViewData["courses"] = new SelectList(courses.Distinct());


            //------filling viewData of institutes-------
            var institutes = new List<string>();

            // a query which takes the names of courses
            var institutesQ = from i in _context.Institutes
                              select i.Name;
            //put the courses list into courses
            institutes.AddRange(institutesQ.Distinct());

            //filling the viewData parameter which passes to the view
            ViewData["institutes"] = new SelectList(institutes.Distinct());

            
            
            
            //----filling viewData of fields-------
            var fields = new List<string>();

            // a query which takes the names of courses
            var fieldsQ = from i in _context.Fields
                              select i.fieldName;
            //put the courses list into courses
            fields.AddRange(fieldsQ.Distinct());

            //filling the viewData parameter which passes to the view
            ViewData["fields"] = new SelectList(fields.Distinct());

            return View();
        }
        // GET: Instatutes
        public IActionResult SellProject()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SearchProject(string institutes,string courses, string project,string fields)
        {

            var joinQuery = from i in _context.Institutes
                            join c in _context.Courses on i.ID equals c.InstatuteID
                            join f in _context.Fields on c.FieldID equals f.ID
                            join p in _context.Projects on c.ID equals p.CourseID
                            where i.Name.Equals(institutes)
                                  && c.Name.Equals(courses) && f.fieldName.Equals(fields)
                                  && p.Name.Contains(project)
                            select p;
            

            return View(joinQuery);
        }

        // GET: Projects/Details/5
        public IActionResult Checkout(int? id)
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
    }
}
