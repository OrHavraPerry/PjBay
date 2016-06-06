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


            //-----filling viewData of courses------
            var courses = new List<string>();

            // a query which takes the names of courses
            var coursesQ = from i in _context.Courses
                           select i.Name;
            //put the courses list into courses
            courses.AddRange(coursesQ.Distinct());

            //filling the viewData parameter which passes to the view
            ViewData["courses"] = new SelectList(courses.Distinct());


            //-----filling viewData of projects------
            var projects = new List<string>();

            // a query which takes the names of projects
            var projectsQ = from i in _context.Projects
                           select i.Name;
            //put the projects list into projects
            projects.AddRange(projectsQ.Distinct());

            //filling the viewData parameter which passes to the view
            ViewData["projects"] = new SelectList(projects);

            return View();
        }

        

        [HttpPost]
        public ActionResult GetFieldCourseProjectByInstitute(string Name)
        {
            var queryField = from f in _context.Fields
                        join c in _context.Courses on f.ID equals c.Field.ID
                        join i in _context.Institutes on c.InstatuteID equals i.ID
                        where i.Name.Equals(Name)
                        select f.fieldName;

            SelectList ListFields = new SelectList(queryField.Distinct());


            var queryCourse = from i in _context.Institutes join c in _context.Courses on i.ID equals c.InstatuteID
                              where i.Name.Equals(Name)
                              select c.Name;

            SelectList ListCourses = new SelectList(queryCourse.Distinct());

            var queryProject = from i in _context.Institutes join
                                c in _context.Courses on i.ID equals c.InstatuteID
                               join p in _context.Projects on c.ID equals p.CourseID
                               where i.Name.Equals(Name)
                               select p.Name;
            SelectList ListProjects = new SelectList(queryProject.Distinct());


            var result = new { fieldList = ListFields, courseList = ListCourses, projectList = ListProjects };
            return Json(result);
        }

        //Action result for ajax call
        [HttpPost]
        public ActionResult GetCourseAndProjectByInstituteAndField(string instituteName, string fieldName)
        {
            //joining courses,fields and institutes in order to get list of courses names which their institute name is instituteName nad field name is fieldName
            var queryCourse = from f in _context.Fields
                        join c in _context.Courses on f.ID equals c.Field.ID
                        join i in _context.Institutes on c.InstatuteID equals i.ID
                        where f.fieldName.Equals(fieldName) && i.Name.Equals(instituteName)
                        select c.Name;

            SelectList courseList = new SelectList(queryCourse.Distinct());

            var queryProject = from i in _context.Institutes
                               join c in _context.Courses on i.ID equals c.InstatuteID
                               join f in _context.Fields on c.FieldID equals f.ID
                               join p in _context.Projects on c.ID equals p.CourseID
                               where i.Name.Equals(instituteName) && f.fieldName.Equals(fieldName)
                               select p.Name;

            SelectList projectList = new SelectList(queryProject.Distinct());

            var result = new { courseList = courseList, projectList = projectList };
            return Json(result);
        }

        //Action result for ajax call
        [HttpPost]
        public ActionResult GetProjectsByInstituteFieldCourse(string instituteName, string fieldName,string courseName)
        {
            
            var queryProject = from i in _context.Institutes
                               join c in _context.Courses on i.ID equals c.InstatuteID
                               join f in _context.Fields on c.FieldID equals f.ID
                               join p in _context.Projects on c.ID equals p.CourseID
                               where i.Name.Equals(instituteName) && f.fieldName.Equals(fieldName) && c.Name.Equals(courseName)
                               select p.Name;

            SelectList projectList = new SelectList(queryProject.Distinct());
            
            return Json(projectList);
        }

        // GET: Instatutes
        public IActionResult SellProject()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SearchProject(string institutes, string fields, string courses, string projects)
        {

            var joinQuery = from i in _context.Institutes
                            join c in _context.Courses on i.ID equals c.InstatuteID
                            join f in _context.Fields on c.FieldID equals f.ID
                            join p in _context.Projects on c.ID equals p.CourseID
                            where i.Name.Equals(institutes)
                                  && c.Name.Equals(courses) && f.fieldName.Equals(fields)
                                  && p.Name.Contains(projects)
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
