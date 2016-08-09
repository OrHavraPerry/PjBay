using System.Linq;
using Microsoft.AspNet.Mvc;
using PjBaySite.Models;
using System;

namespace PjBaySite.Controllers
{
    public class StatisticsController : Controller
    {
        private ApplicationDbContext _context;
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult GraphA()
        {
            /*
            var queryField = from fields in _context.Fields
                             join c in _context.Courses on fields.ID equals c.Field.ID
                             join i in _context.Institutes on c.InstatuteID equals i.ID
                             join p in _context.Projects on c.ID equals p.CourseID
                             where i.Name.Equals(Name) && p.Purchased == false
                             select fields.fieldName;

            SelectList ListFields = new SelectList(queryField.Distinct());
            return Json(ListFields);
            */
            throw new NotImplementedException();
        }
    }
}