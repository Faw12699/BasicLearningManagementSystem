using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BasicLearningManagementSystem.Models;
using BasicLearningManagementSystem.Manager;
using System.Web.Mvc;

namespace BasicLearningManagementSystem.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        CourseManager course;
        StudentManager student;

        public ActionResult Index()
        {
            course = new CourseManager();
            List<Course> courseItem = course.ViewCourse();

            student = new StudentManager();
            List<Student> studentItem = student.ViewStudent();

            int rowCountCourse = courseItem.Count;
            int rowCountStudent = studentItem.Count;

            ViewBag.CountCourse = rowCountCourse;
            ViewBag.CountStudent = rowCountStudent;

            return View();
        }
    }
}