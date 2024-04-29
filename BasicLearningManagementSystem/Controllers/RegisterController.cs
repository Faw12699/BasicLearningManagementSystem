using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BasicLearningManagementSystem.Manager;
using BasicLearningManagementSystem.Models;
using System.Web.Mvc;

namespace BasicLearningManagementSystem.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        CourseManager obj;
        RegisterManager reg;

        [HttpGet]
        public ActionResult Index()
        {

            obj = new CourseManager();
            reg= new RegisterManager();

            var Student = TempData["student"] as Student;

            if (Student == null)
            {
                return RedirectToAction("StudentLogin", "Account");
            }
            StudentCourseViewModel model = new StudentCourseViewModel
            {
                Course = obj.ViewCourse(),
                Student = Student,
                Register = reg.ViewRegister()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(Register register)
        {

            RegisterManager obj = new RegisterManager();
            obj.AddRegister(register);

            List<Register> save = obj.ViewRegister();

            return RedirectToAction("Index", "Register", save);
        }
        public ActionResult ViewRegister()
        {
            List<Register> save = reg.ViewRegister();
            return View(save);
        }

        public ActionResult DeleteRegister(int id)
        {
            RegisterManager obj = new RegisterManager();
            obj.Delete(id);
            return RedirectToAction("Index");
        }
    }
}