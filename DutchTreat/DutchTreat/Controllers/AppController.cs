using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DutchTreat.Controllers
{
    public class AppController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Contact()
        {
            ViewBag.Title = "Contact Us";
            return View();
        }
        public IActionResult About()
        {
            ViewBag.Title = "About Us";
            return View();
        }
    }
}
