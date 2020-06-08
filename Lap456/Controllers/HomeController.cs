using Lap456.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;


namespace Lap456.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _dbContext;
        public HomeController()
        {
            _dbContext = new ApplicationDbContext(); 
        }
        public ActionResult Index()
        {
            var upcomingCourses = _dbContext.Courses.Include(c => c.Lecture).Include(c => c.Categlory).Where(c => c.DateTime > DateTime.Now);
            return View(upcomingCourses);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}