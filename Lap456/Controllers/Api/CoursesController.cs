﻿using Lap456.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Lap456.Controllers.Api
{
    public class CoursesController : ApiController
    {
        public ApplicationDbContext _dbcontext { get; set; }
        public CoursesController()
        {
            _dbcontext = new ApplicationDbContext();
        }
        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userId = User.Identity.GetUserId();
            var course = _dbcontext.Courses.Single(c => c.Id == id && c.LectureId == userId);
            if (course.IsCanceled)
                return NotFound();
            course.IsCanceled = true;
            _dbcontext.SaveChanges();
            return Ok();
        }
    }
}
