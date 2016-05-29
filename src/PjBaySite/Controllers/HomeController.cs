using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using PjBaySite.Models;
using Microsoft.Data.Entity;

namespace PjBaySite.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var ins = _context.Institutes.Cast<IBoxItem>().ToList();

            return View(ins);
        }

        [HttpPost]
        public IActionResult Index(IBoxItem box)
        {
            var ins = _context.Institutes.Include(i=>i.Courses).Cast<IBoxItem>().ToList();

            return View(ins);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
