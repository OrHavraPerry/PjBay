using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using PjBaySite.Models;
using System.Collections.Generic;
using Microsoft.AspNet.Authorization;

namespace PjBaySite.Controllers
{
    public class CoursesController : Controller
    {
        private ApplicationDbContext _context;

        public CoursesController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "Admin")]
        // GET: Courses
        public IActionResult Index()
        {
            var applicationDbContext = _context.Courses.Include(c => c.Field).Include(c => c.Instatute);
            return View(applicationDbContext.ToList());
        }

        // GET: Courses/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Course course = _context.Courses.Single(m => m.ID == id);
            if (course == null)
            {
                return HttpNotFound();
            }

            ViewData["PreviusInstitute"] = (from i in _context.Institutes
                                            where i.ID == course.InstatuteID
                                            select i.Name).First();

            ViewData["PreviousField"] = (from f in _context.Fields
                                         where f.ID == course.FieldID
                                         select f.fieldName).First();

            return View(course);
        }

        // GET: Courses/Create
        public IActionResult Create()
        {

            //------filling viewData of institutes-------
            var institutes = new List<string>();

            // a query which takes the names of courses
            var institutesQ = from i in _context.Institutes
                              select i.Name;
            //put the courses list into courses
            institutes.AddRange(institutesQ.Distinct());

            //filling the viewData parameter which passes to the view
            ViewData["institutes"] = new SelectList(institutes.Distinct());

            //------filling viewData of fields-------
            var fields= new List<string>();

            // a query which takes the names of fields
            var fieldsQ = from f in _context.Fields
                          select f.fieldName;
            //put the fields names list into fields
            fields.AddRange(fieldsQ.Distinct());

            //filling the viewData parameter which passes to the view
            ViewData["fields"] = new SelectList(fields);

            return View();
        }
        //ajax call getting fields by institute name chosen
        [HttpPost]
        public ActionResult GetFieldByInstitute(string Name)
        {
            var queryField = from f in _context.Fields
                             join c in _context.Courses on f.ID equals c.Field.ID
                             join i in _context.Institutes on c.InstatuteID equals i.ID
                             where i.Name.Equals(Name)
                             select f.fieldName;

            SelectList ListFields = new SelectList(queryField.Distinct());

            return Json(ListFields);
        }


        // POST: Courses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Course course,string fields, string institutes)
        {

            if (ModelState.IsValid)
            {
                //finding the institute with the suitable name,and taking the id
                var instituteIdQ = from i in _context.Institutes
                            where i.Name == institutes
                            select i.ID;

                course.InstatuteID = instituteIdQ.First();

                var fieldsIdQ = from f in _context.Fields
                                where f.fieldName == fields
                                select f.ID;

                course.FieldID = fieldsIdQ.First();


                _context.Courses.Add(course);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            //------filling viewData of institutes-------
            var institutes_1 = new List<string>();

            // a query which takes the names of courses
            var institutesQ = from i in _context.Institutes
                              select i.Name;
            //put the courses list into courses
            institutes_1.AddRange(institutesQ.Distinct());

            //filling the viewData parameter which passes to the view
            ViewData["institutes"] = new SelectList(institutes_1.Distinct());

            return View(course);
        }

        // GET: Courses/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Course course = _context.Courses.Single(m => m.ID == id);
            if (course == null)
            {
                return HttpNotFound();
            }
            //------filling viewData of institutes-------
            var institutes = new List<string>();

            // a query which takes the names of courses
            var institutesQ = from i in _context.Institutes
                              select i.Name;
            //put the courses list into courses
            institutes.AddRange(institutesQ.Distinct());

            //filling the viewData parameter which passes to the view
            ViewData["institutes"] = new SelectList(institutes.Distinct());



            //------filling viewData of fields-------
            var fields = new List<string>();

            // a query which takes the names of fields
            var fieldsQ = from f in _context.Fields
                          select f.fieldName;
            //put the fields names list into fields
            fields.AddRange(fieldsQ.Distinct());

            //filling the viewData parameter which passes to the view
            ViewData["fields"] = new SelectList(fields);

            ViewData["PreviusInstitute"] = (from i in _context.Institutes
                                            where i.ID == course.InstatuteID
                                            select i.Name).First();

            ViewData["PreviousField"] = (from f in _context.Fields
                                         where f.ID == course.FieldID
                                         select f.fieldName).First();

            return View(course);
        }

        // POST: Courses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Course course, string institutes, string fields)
        {
            if (ModelState.IsValid)
            {

                //finding the institute with the suitable name,and taking the id
                var instituteIdQ = from i in _context.Institutes
                                   where i.Name == institutes
                                   select i.ID;

                course.InstatuteID = instituteIdQ.First();

                var fieldsIdQ = from f in _context.Fields
                                where f.fieldName == fields
                                select f.ID;

                course.FieldID = fieldsIdQ.First();


                _context.Update(course);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            //------filling viewData of institutes-------
            var institutes_1 = new List<string>();

            // a query which takes the names of courses
            var institutesQ = from i in _context.Institutes
                              select i.Name;
            //put the courses list into courses
            institutes_1.AddRange(institutesQ.Distinct());

            //filling the viewData parameter which passes to the view
            ViewData["institutes"] = new SelectList(institutes_1.Distinct());

            ViewData["PreviusInstitute"] = (from i in _context.Institutes
                                            where i.ID == course.InstatuteID
                                            select i.Name).First();

            ViewData["PreviousField"] = (from f in _context.Fields
                                         where f.ID == course.FieldID
                                         select f.fieldName).First();
            return View(course);
        }

        // GET: Courses/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Course course = _context.Courses.Single(m => m.ID == id);
            if (course == null)
            {
                return HttpNotFound();
            }


            ViewData["PreviusInstitute"] = (from i in _context.Institutes
                                           where i.ID == course.InstatuteID
                                           select i.Name).First();

            ViewData["PreviousField"] = (from f in _context.Fields
                                         where f.ID == course.FieldID
                                         select f.fieldName).First();
            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Course course = _context.Courses.Single(m => m.ID == id);
            _context.Courses.Remove(course);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Search()
        {
            return View();
        }
        //Search result for course
        [HttpPost]
        public IActionResult SearchResult(string name)
        {
            var searchResultQ = from c in _context.Courses
                                where c.Name.Contains(name)
                                select c;

            return View(searchResultQ.Distinct());
        }
    }
}
