using Lap456.Models;
using Lap456.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                Categlories = _dbcontext.Categlories.ToList(),
                Heading="Add Course"
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
        [Authorize]
        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();
            var courses = _dbcontext.Attendances.Where(a => a.AttendeeId == userId).Select(a => a.Course).Include(l => l.Lecture).Include(l => l.Categlory).ToList();
            var viewModel = new CoursesViewModel
            {
                UpcomingCourses = courses,
                ShowAction = User.Identity.IsAuthenticated
            };
            return View(viewModel);
        }
        [Authorize]
        public ActionResult Flowing()
        {
            var userId = User.Identity.GetUserId();
            var courses = _dbcontext.Followings.Where(a => a.FollowerId == userId).Select(a => a.FolloweeId).ToList();
            //var viewModel = new CoursesViewModel
            //{
            //    UpcomingCourses = courses,
            //    ShowAction = User.Identity.IsAuthenticated
            //};
            return View(courses);

        }
        [Authorize]
        public ActionResult Mine()
        {
            var userId = User.Identity.GetUserId();
            var courses = _dbcontext.Courses.Where(c => c.LectureId == userId && c.DateTime > DateTime.Now).Include(l => l.Lecture).Include(l => l.Categlory).ToList();
            return View(courses);
        }
        [Authorize]
        public ActionResult Edit(int id)
        {
            var userId = User.Identity.GetUserId();
            var courses = _dbcontext.Courses.Single(c => c.Id == id && c.LectureId == userId);
            var viewModel = new CourseViewModel
            {
                Categlories = _dbcontext.Categlories.ToList(),
                Date = courses.DateTime.ToString("dd/M/yyyy"),
                Time = courses.DateTime.ToString("HH:mm"),
                Categlory = courses.CategloryId,
                Place = courses.Place,
                Heading = "Edit Course",
                Id = courses.Id
            };
            return View("Create", viewModel);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(CourseViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categlories = _dbcontext.Categlories.ToList();
                return View("Create", viewModel);
            }
            var userId = User.Identity.GetUserId();
            var courses = _dbcontext.Courses.Single(c => c.Id == viewModel.Id && c.LectureId == userId);
            courses.Place = viewModel.Place;
            courses.DateTime = viewModel.GetDateTime();
            courses.CategloryId = viewModel.Categlory;
            _dbcontext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}