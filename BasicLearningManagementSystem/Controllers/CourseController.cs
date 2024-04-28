using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BasicLearningManagementSystem.Models;
using BasicLearningManagementSystem.Manager;
using System.Web.Mvc;

namespace BasicLearningManagementSystem.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        [HttpGet]
        public ActionResult AddCourse()
        {
            return View();
        }

        CourseManager obj;

        [HttpPost]
        public ActionResult AddCourse(Course course)
        {
            obj = new CourseManager();
            obj.AddCourse(course);

            return RedirectToAction("ViewCourse");
        }
        public ActionResult ViewCourse() 
        {
            obj = new CourseManager();
            List<Course> save = obj.ViewCourse();
            return View(save);
        }
        public ActionResult DeleteCourse(int id)
        {
            obj = new CourseManager();
            obj.DeleteCourse(id);

            return RedirectToAction("ViewCourse");
        }
        [HttpGet]
        public ActionResult EditCourse(int id)
        {
            obj = new CourseManager();
            Course course = obj.GetCourse(id);
            return View(course);
        }
        [HttpPost]
        public ActionResult EditCourse(Course course)
        {
            obj = new CourseManager();
            obj.UpdateCourse(course);
            return RedirectToAction("ViewCourse");
        }

    }
}