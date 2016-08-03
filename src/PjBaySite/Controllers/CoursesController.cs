using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using PjBaySite.Models;
using System.Collections.Generic;

namespace PjBaySite.Controllers
{
public class CoursesController : Controller
{
    private ApplicationDbContext _context;

    public CoursesController(ApplicationDbContext context)
    {
        _context = context;
    }

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

        return View(course);
    }

    // GET: Courses/Create
    public IActionResult Create()
    {

        var courses = new List<string>();

        var coursesQ = from i in _context.Courses
                        select i.Name;
        courses.AddRange(coursesQ.Distinct());

        var Institutes = new List<string>();
        var InstitutesQ = from i in _context.Institutes
                            select i.Name;
        Institutes.AddRange(InstitutesQ.Distinct());

        ViewData["FieldName"] = new SelectList(courses);
        ViewData["InstatuteName"] = new SelectList(Institutes);
        return View();
    }

    // POST: Courses/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(string FieldName, string InstatuteName, string Name)
    {

        var fieldQ = from i in _context.Fields
            where i.fieldName.Equals(FieldName)
            select i.ID;

        var instatuteQ = from i in _context.Institutes
            where i.Name.Equals(InstatuteName)
            select i.ID;

        Course c = new Course();
        
        c.FieldID = fieldQ.First();
        c.InstatuteID = instatuteQ.First();
        c.Name = Name;


        _context.Courses.Add(c);
        _context.SaveChanges();
        return View(c);
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
        ViewData["FieldID"] = new SelectList(_context.Fields, "ID", "Field", course.FieldID);
        ViewData["InstatuteID"] = new SelectList(_context.Institutes, "ID", "Instatute", course.InstatuteID);
        return View(course);
    }

    // POST: Courses/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Course course)
    {
        if (ModelState.IsValid)
        {
            _context.Update(course);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        ViewData["FieldID"] = new SelectList(_context.Fields, "ID", "Field", course.FieldID);
        ViewData["InstatuteID"] = new SelectList(_context.Institutes, "ID", "Instatute", course.InstatuteID);
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
}
}
