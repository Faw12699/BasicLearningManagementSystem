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
        RegisterManager register;
        public ActionResult Index()
        {
            course = new CourseManager();
            List<Course> courseItem = course.ViewCourse();

            student = new StudentManager();
            List<Student> studentItem = student.ViewStudent();

            register = new RegisterManager();
            List<Register> registerItem = register.ViewRegister();

            int rowCountCourse = courseItem.Count;
            int rowCountStudent = studentItem.Count;
            int rowCountRegister = registerItem.Count;

            ViewBag.CountCourse = rowCountCourse;
            ViewBag.CountStudent = rowCountStudent;
            ViewBag.CountRegister = rowCountRegister;

            return View();
        }
    }
}