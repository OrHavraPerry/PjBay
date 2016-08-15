using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using PjBaySite.Models;
using System;
using System.Collections.Generic;
using Microsoft.AspNet.Authorization;

namespace PjBaySite.Controllers
{
    public class ProjectsController : Controller
    {
        private ApplicationDbContext _context;
        

        public ProjectsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        //------------------Manager crud for projects---------------------

        //project manager index
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var applicationDbContext = _context.Projects.Include(p => p.Course);
            return View(applicationDbContext.ToList());
        }

        // GET: Projects/Edit/5
        [Authorize(Roles = "Admin")]
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

            //------filling viewData of institutes-------
            var institutes = new List<string>();

            // a query which takes the names of courses
            var institutesQ = from i in _context.Institutes
                              select i.Name;
            //put the courses list into courses
            institutes.AddRange(institutesQ.Distinct());

            //filling the viewData parameter which passes to the view
            ViewData["institutes"] = new SelectList(institutes.Distinct());

            ViewData["PreviusInstitute"] = (from i in _context.Institutes
                                            join c in _context.Courses on i.ID equals c.InstatuteID
                                            join p in _context.Projects on c.ID equals p.CourseID
                                            where p.ID == project.ID
                                            select i.Name).First();

            ViewData["PreviousCourse"] = (from c in _context.Courses
                                          where c.ID == project.CourseID
                                          select c.Name).First();

            ViewData["PreviousField"] = (from f in _context.Fields
                                         join c in _context.Courses on f.ID equals c.FieldID
                                         where c.ID == project.CourseID
                                         select f.fieldName).First();

            return View(project);
        }

        // POST: Projects/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Project project, string courses, string institutes, string fields)
        {
            if (ModelState.IsValid)
            {
                //find the id of course according to the course name
                var query = from i in _context.Institutes
                            join c in _context.Courses on i.ID equals c.InstatuteID
                            join f in _context.Fields on c.FieldID equals f.ID
                            where i.Name == institutes && c.Name == courses && f.fieldName == fields
                            select c.ID;

                //updating the id of course in project
                project.CourseID = query.First();

                _context.Update(project);
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
                                            join c in _context.Courses on i.ID equals c.InstatuteID
                                            join p in _context.Projects on c.ID equals p.CourseID
                                            where p.ID == project.ID
                                            select i.Name).First();

            ViewData["PreviousCourse"] = (from c in _context.Courses
                                          where c.ID == project.CourseID
                                          select c.Name).First();

            ViewData["PreviousField"] = (from f in _context.Fields
                                         join c in _context.Courses on f.ID equals c.FieldID
                                         where c.ID == project.CourseID
                                         select f.fieldName).First();


            return View(project);
        }

        // GET: Projects/Delete/5
        [Authorize(Roles = "Admin")]
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
            ViewData["PreviusInstitute"] = (from i in _context.Institutes
                                            join c in _context.Courses on i.ID equals c.InstatuteID
                                            join p in _context.Projects on c.ID equals p.CourseID
                                            where p.ID == project.ID
                                            select i.Name).First();

            ViewData["PreviousCourse"] = (from c in _context.Courses
                                          where c.ID == project.CourseID
                                          select c.Name).First();

            ViewData["PreviousField"] = (from f in _context.Fields
                                         join c in _context.Courses on f.ID equals c.FieldID
                                         where c.ID == project.CourseID
                                         select f.fieldName).First();
            return View(project);
        }

        [Authorize(Roles = "Admin")]
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

        // details for manager in prjects
        [Authorize(Roles = "Admin")]
        public IActionResult ManageDetails(int? id)
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
            ViewData["PreviusInstitute"] = (from i in _context.Institutes
                                            join c in _context.Courses on i.ID equals c.InstatuteID
                                            join p in _context.Projects on c.ID equals p.CourseID
                                            where p.ID == project.ID
                                            select i.Name).First();

            ViewData["PreviousCourse"] = (from c in _context.Courses
                                          where c.ID == project.CourseID
                                          select c.Name).First();

            ViewData["PreviousField"] = (from f in _context.Fields
                                         join c in _context.Courses on f.ID equals c.FieldID
                                         where c.ID == project.CourseID
                                         select f.fieldName).First();

            return View(project);
        }

        // GET: Projects/Create
        [Authorize(Roles = "Admin")]
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

            return View();
        }
        
        // POST: Projects/Create
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(string institutes, string fields, string courses, Project project)
        {
            if (ModelState.IsValid)
            {
                var query = from i in _context.Institutes
                            join c in _context.Courses on i.ID equals c.InstatuteID
                            join f in _context.Fields on c.FieldID equals f.ID
                            where i.Name.Equals(institutes) && c.Name.Equals(courses) && f.fieldName.Equals(fields)
                            select c;

                project.CourseID = query.First().ID;

                _context.Projects.Add(project);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            //------filling viewData of institutes-------
            var instituteList = new List<string>();

            // a query which takes the names of courses
            var institutesQ = from i in _context.Institutes
                              select i.Name;
            //put the courses list into courses
            instituteList.AddRange(institutesQ.Distinct());

            //filling the viewData parameter which passes to the view
            ViewData["institutes"] = new SelectList(instituteList.Distinct());
            return View(project);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult ManagerSearch()
        {
            return View();
        }

        //Search result for institute
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult ManagerSearchResult(string name)
        {
            var searchResultQ = from p in _context.Projects
                                where p.Name.Contains(name)
                                select p;

            return View(searchResultQ.Distinct());
        }


        //------------------end manager crud---------------------




        //----------user actions(sellProject,buyProject,search from bar,advanced serach)-----

        // user details(buyProject and sellProject)
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

        // projects regular search(not advanced)
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
            ViewData["institutes"] = new SelectList(institutes);
            

            return View();
        }

        [HttpPost]
        public IActionResult SearchProject(string institutes, string fields, string courses, string projects)
        {
            
            var searchQ = from i in _context.Institutes
                            join c in _context.Courses on i.ID equals c.InstatuteID
                            join f in _context.Fields on c.FieldID equals f.ID
                            join p in _context.Projects on c.ID equals p.CourseID
                            where i.Name.Equals(institutes) && f.fieldName.Equals(fields) && c.Name.Equals(courses) 
                                  && p.Name.Contains(projects) && p.Purchased == false
                            select p;
            

            return View(searchQ.Distinct());
        }

        // GET: Projects/Details/5
        public IActionResult Checkout(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

           
            return View(id);
        }

        // GET: Projects/Checkout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Paid(int? id)
        {
            
            var query =from p in _context.Projects where p.ID == id select p;

            query.First().Purchased = true;

            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                
            }

            return View();
        }


        // GET: Projects/SellProject
        public IActionResult SellProject()
        {
            //ViewData["CourseId"] = new SelectList(_context.Courses, "ID", "Course");

            //------filling viewData of institutes-------
            var institutes = new List<string>();

            // a query which takes the names of courses
            var institutesQ = from i in _context.Institutes
                              select i.Name;
            //put the courses list into courses
            institutes.AddRange(institutesQ.Distinct());

            //filling the viewData parameter which passes to the view
            ViewData["institutes"] = new SelectList(institutes.Distinct());


            return View();
        }

        // POST: Projects/SellProject
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SellProject(string institutes, string fields, string courses,Project project)
        {
            
            if (ModelState.IsValid)
            {
                var query = from i in _context.Institutes
                            join c in _context.Courses on i.ID equals c.InstatuteID
                            join f in _context.Fields on c.FieldID equals f.ID
                            where i.Name.Equals(institutes) && c.Name.Equals(courses) && f.fieldName.Equals(fields)
                            select c;

                project.CourseID = query.First().ID;


                project.Purchased = false;
                project.SubmitDate = DateTime.Now;
                _context.Projects.Add(project);
                _context.SaveChanges();
                return RedirectToAction("SellingConfiramtion");
            }

            //------filling viewData of institutes-------
            var instituteList = new List<string>();

            // a query which takes the names of institutes
            var institutesQ = from i in _context.Institutes
                              select i.Name;
            //put the institutes list into institutes
            instituteList.AddRange(institutesQ.Distinct());

            //filling the viewData parameter which passes to the view
            ViewData["institutes"] = new SelectList(instituteList.Distinct());
            return View(project);
        }

        // GET: Projects
        public IActionResult SellingConfiramtion()
        {
            return View();
        }

        //searching project from toolbar(nav bar)
        [HttpPost]
        public IActionResult SearchProjectFromBar(string projectName)
        {
            //searching for a project that have in it's name the string above
            var searchProjectQuery = from p in _context.Projects
                                     where p.Name.Contains(projectName) && p.Purchased == false
                                     select p;
          
            return View(searchProjectQuery.Distinct());
        }
        //Advanced search in buy project
        public IActionResult AdvancedSearch()
        {
            return View();
        }
        //Advanced search result
        [HttpPost]
        public IActionResult AdvancedSearchResult(string gradeMin, string gradeMax, string priceMin, string priceMax, string description)
        {
            //searching for a project that have in it's name the string above
            var searchProjectQuery = from p in _context.Projects
                                     where p.Grade >= (Convert.ToInt32(gradeMin)) && p.Grade <= (Convert.ToInt32(gradeMax))
                                        && p.Price >= (Convert.ToInt32(priceMin)) && p.Price <= (Convert.ToInt32(priceMax))
                                        && p.Description.Contains(description)
                                     select p;

            return View(searchProjectQuery.Distinct());
        }
        
        //------end user actions--------------------




        //------------Ajax calls:-----------------------

        //----------------ajax calls for buyProject--------

        //ajax call for fields that match with the selected institute
        [HttpPost]
        public ActionResult GetFieldByInstitute(string Name)
        {

            var queryField = from f in _context.Fields
                             join c in _context.Courses on f.ID equals c.Field.ID
                             join i in _context.Institutes on c.InstatuteID equals i.ID
                             join p in _context.Projects on c.ID equals p.CourseID
                             where i.Name.Equals(Name) && p.Purchased == false
                             select f.fieldName;

            SelectList ListFields = new SelectList(queryField.Distinct());

            return Json(ListFields);
        }

        //Action result for ajax call
        [HttpPost]
        public ActionResult GetCourseByInstituteAndField(string instituteName, string fieldName)
        {
            //joining courses,fields and institutes in order to get list of courses names which their institute name is instituteName nad field name is fieldName
            var queryCourse = from f in _context.Fields
                              join c in _context.Courses on f.ID equals c.Field.ID
                              join i in _context.Institutes on c.InstatuteID equals i.ID
                              join p in _context.Projects on c.ID equals p.CourseID
                              where f.fieldName.Equals(fieldName) && i.Name.Equals(instituteName) && p.Purchased == false
                              select c.Name;

            SelectList courseList = new SelectList(queryCourse.Distinct());

            return Json(courseList);
        }

        //Action result for ajax call
        [HttpPost]
        public ActionResult GetProjectsByInstituteFieldCourse(string instituteName, string fieldName, string courseName)
        {

            var queryProject = from i in _context.Institutes
                               join c in _context.Courses on i.ID equals c.InstatuteID
                               join f in _context.Fields on c.FieldID equals f.ID
                               join p in _context.Projects on c.ID equals p.CourseID
                               where i.Name.Equals(instituteName) && f.fieldName.Equals(fieldName) && c.Name.Equals(courseName) && p.Purchased == false
                               select p.Name;

            SelectList projectList = new SelectList(queryProject.Distinct());

            return Json(projectList);
        }

        //-----------------------end ajax calls-----------------------

        //-----------------ajax call for sellProject and manager--------
        //sellProject view
        [HttpPost]
        public ActionResult GetFieldByInstituteForSellView(string Name)
        {
            var queryField = from f in _context.Fields
                             join c in _context.Courses on f.ID equals c.Field.ID
                             join i in _context.Institutes on c.InstatuteID equals i.ID
                             where i.Name.Equals(Name)
                             select f.fieldName;

            SelectList ListFields = new SelectList(queryField.Distinct());

            return Json(ListFields);
        }

        //Action result for ajax call
        [HttpPost]
        public ActionResult GetCourseByInstituteAndFieldForSellView(string instituteName, string fieldName)
        {
            //joining courses,fields and institutes in order to get list of courses names which their institute name is instituteName nad field name is fieldName
            var queryCourse = from f in _context.Fields
                              join c in _context.Courses on f.ID equals c.Field.ID
                              join i in _context.Institutes on c.InstatuteID equals i.ID
                              where f.fieldName.Equals(fieldName) && i.Name.Equals(instituteName)
                              select c.Name;

            SelectList courseList = new SelectList(queryCourse.Distinct());

            return Json(courseList);
        }
        //----------------end ajax calls for sellProject and manager------
    }
}
