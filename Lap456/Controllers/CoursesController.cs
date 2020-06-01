using Lap456.Models;
using Lap456.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lap456.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _dbcontext;
        public CoursesController()
        {
            _dbcontext = new ApplicationDbContext();
        }
        //GET: Courses
        [Authorize]
        //[HttpPost]
        public ActionResult Create()
        {
            var viewModel = new CourseViewModel
            {
                Categlories = _dbcontext.Categlories.ToList()
            };
            return View(viewModel);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categlories = _dbcontext.Categlories.ToList();
                return View("Create", viewModel);
            }
            var course = new Course
            {
                LectureId = User.Identity.GetUserId(),
                DateTime = viewModel.GetDateTime(),
                CategloryId = viewModel.Categlory,
                Place = viewModel.Place
            };
            _dbcontext.Courses.Add(course);
            _dbcontext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}