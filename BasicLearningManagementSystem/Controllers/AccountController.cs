using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BasicLearningManagementSystem.Manager;
using BasicLearningManagementSystem.Models;
using System.Data.SqlClient;

namespace BasicLearningManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        SqlDataReader dr;

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Verify(Admin admin) 
        {
            Connection.OpenConnection();
            dr = Connection.DataReader("SELECT * FROM AdminAccount WHERE id= " + admin.id + " AND password= '" + admin.password + "'");

            if (dr.Read())
            {
                Connection.CloseConnection();
                return View("~/Views/Dashboard/Index.cshtml");
            }
            else 
            {
                Connection.CloseConnection();
                return View("Error");
            }
        }
    }
}