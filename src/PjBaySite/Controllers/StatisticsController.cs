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

        public ActionResult GraphB()
        {
            return View();
        }

        public ActionResult GraphBData()
        {
            var query0_59 = (from p in _context.Projects
                            where p.Grade>=0 && p.Grade < 60
                            select p).Count();

            var query60_69 = (from p in _context.Projects
                             where p.Grade >= 60 && p.Grade < 70
                             select p).Count();

            var query70_79 = (from p in _context.Projects
                              where p.Grade >= 70 && p.Grade < 80
                              select p).Count();


            var query80_85 = (from p in _context.Projects
                             where p.Grade >= 80 && p.Grade < 85
                             select p).Count();

            var query86_90 = (from p in _context.Projects
                              where p.Grade >= 85 && p.Grade < 90
                              select p).Count();


            var query90_95 = (from p in _context.Projects
                             where p.Grade >= 90 && p.Grade < 95
                             select p).Count();

            var query96_100 = (from p in _context.Projects
                              where p.Grade >= 95 && p.Grade <= 100
                              select p).Count();

            string path = @"C:\Users\liron\Source\Repos\PjBay\src\PjBaySite\wwwroot\files/GraphB.csv";

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
                    fs.WriteLine("age,population");
                    
                    var newLine = string.Format("{0},{1}", "0-59", query0_59);
                    fs.WriteLine(newLine);

                    newLine = string.Format("{0},{1}", "60-69", query60_69);
                    fs.WriteLine(newLine);

                    newLine = string.Format("{0},{1}", "70-79", query70_79);
                    fs.WriteLine(newLine);

                    newLine = string.Format("{0},{1}", "80-85", query80_85);
                    fs.WriteLine(newLine);

                    newLine = string.Format("{0},{1}", "86-90", query86_90);
                    fs.WriteLine(newLine);

                    newLine = string.Format("{0},{1}", "90-95", query90_95);
                    fs.WriteLine(newLine);

                    newLine = string.Format("{0},{1}", "96-100", query96_100);
                    fs.WriteLine(newLine);

                }

                FileInfo file = new FileInfo(path);
                return File(file.Open(FileMode.Open, FileAccess.Read), "text/tsv", "data.csv");
            }
            catch (Exception ex)
            {
                // Error ex
            }
            return RedirectToAction("Index");
        }

    }
}