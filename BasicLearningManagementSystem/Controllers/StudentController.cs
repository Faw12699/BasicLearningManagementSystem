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

        StudentManager obj;
        [HttpPost]
        public ActionResult AddStudent(Student student) 
        {
            obj = new StudentManager();
            obj.AddStudent(student);
            return View();
        }
        public ActionResult ViewStudent() 
        {
            obj = new StudentManager();
            List<Student> save = obj.ViewStudent();
            return View(save);
        }
        public ActionResult DeleteStudent(int id)
        {
            obj = new StudentManager();
            obj.DeleteStudent(id);
            return RedirectToAction("ViewStudent");
        }
        [HttpGet]
        public ActionResult EditStudent(int id)
        {
            obj = new StudentManager();
            Student student = obj.GetStudent(id);
            return View(student);
        }
        [HttpPost]
        public ActionResult EditStudent(Student student)
        {
            obj = new StudentManager();
            obj.UpdateStudent(student);
            return RedirectToAction("ViewStudent");
        }
    }
}