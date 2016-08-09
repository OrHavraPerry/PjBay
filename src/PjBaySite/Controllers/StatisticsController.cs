using System;
using System.Linq;
using Microsoft.AspNet.Mvc;
using PjBaySite.Models;
using System.IO;
using Microsoft.Data.Entity;

namespace PjBaySite.Controllers
{
    public class StatisticsController : Controller
    {
        private ApplicationDbContext _context;

        public StatisticsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult GraphA()
        {
            return View();
        }

        public ActionResult GraphAData()
        {
            //var query = from p in _context.Projects.Include(p => p.Course)
            //            join f in _context.Fields on p.Course.FieldID equals f.ID
            //            group p by f.fieldName into FieldGroup
            //            select new
            //            {
            //                key = FieldGroup.Key,
            //                value = FieldGroup.Count()
            //            };

            var q = _context.Fields
                            .Join(
                                _context.Courses,
                                f => f.ID,
                                c => c.FieldID,
                                (f, c) => new { FieldName = f.fieldName, CourseID = c.ID }).ToList()
                            .Join(
                                _context.Projects,
                                fc => fc.CourseID,
                                pr => pr.CourseID,
                                (fc, pr) => new { Field = fc.FieldName, Project = pr }).ToList()
                            .GroupBy(fc => fc.Field)
                            .Select(g => new { FieldName = g.Key, Count = g.Count() });

            var p = _context.Projects;

            string path = @"c:\temp\GraphA.tsv";

            try
            {

                // Delete the file if it exists.
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }

                // Create the file.
                using (StreamWriter fs = new StreamWriter(System.IO.File.Create(path)))
                {
                    // Header
                    fs.WriteLine("letter\tfrequency");

                    foreach (var fc in q)
                    {
                        var newLine = string.Format("{0}\t{1}", fc.FieldName, fc.Count);
                        fs.WriteLine(newLine);
                    }
                }

                FileInfo file = new FileInfo(path);
                return File(file.Open(FileMode.Open, FileAccess.Read), "text/tsv", "data.tsv");
            }
            catch (Exception ex)
            {
                // Error ex
            }

            return RedirectToAction("Index");
        }
    }
}