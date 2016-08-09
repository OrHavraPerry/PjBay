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

            var q = from f in _context.Fields
                    join c in _context.Courses on f.ID equals c.FieldID
                    join p in _context.Projects on c.ID equals p.CourseID
                    group p by f.fieldName into FieldsGroup
                    select FieldsGroup;

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

                    //foreach (var field in q)
                    //{
                    //    //var newLine = string.Format("{0}\t{1}", field.Key, field.Count);
                    //    fs.WriteLine(newLine);
                    //}
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