﻿using Lap456.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Lap456.ViewModels;

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
            var viewModel = new CoursesViewModel{UpcomingCourses = upcomingCourses,ShowAction = User.Identity.IsAuthenticated};
            return View(viewModel);
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
        public ActionResult TheoCatagory(int id)
        {
            //.Single(c => c.Id == id)
            //var courses = _dbContext.Courses.Include(c => c.Lecture).Include(c => c.Categlory).Where(c => c.DateTime > DateTime.Now); ;
            //var viewModel = new CoursesViewModel { UpcomingCourses = courses, ShowAction = User.Identity.IsAuthenticated };
            var courses = _dbContext.Courses.Where(c => c.CategloryId == id && c.DateTime > DateTime.Now).Include(l => l.Lecture).Include(l => l.Categlory).ToList();
            return View(courses);
            //return View(viewModel);

        }
    }
}