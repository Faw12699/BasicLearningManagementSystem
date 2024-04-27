using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BasicLearningManagementSystem.Models;
using BasicLearningManagementSystem.Manager;
using System.Web.Mvc;

namespace BasicLearningManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        [HttpGet]
        public ActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddStudent(Student student) 
        {
            StudentManager stdObj = new StudentManager();
            stdObj.AddStudent(student);
            return View();
        }

        public ActionResult ViewStudent() 
        {
            StudentManager student = new StudentManager();
            List<Student> save = student.ViewStudent();
            return View(save);
        }
    }
}