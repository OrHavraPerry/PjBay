using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using PjBaySite.Models;
using Microsoft.Data.Entity;
using Microsoft.AspNet.Mvc.Rendering;
using System.Xml.Serialization;
using System.Xml;


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
            return View();
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

        [HttpGet]
        public string[][] GetInstituteAdresses()
        {
            var query = from i in _context.Institutes
                        select new string[] { i.Name, i.Address };
            return query.ToArray();
        }


        
       
        

    }
}
