using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BasicLearningManagementSystem.Models;
using System.Data.SqlClient;

namespace BasicLearningManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        void connectionString()
        {
            con.ConnectionString = @"Data Source=DESKTOP-I5537DP\SQLEXPRESS;Initial Catalog=LMSDatabase;Integrated Security=True";
        }
        [HttpPost]
        public ActionResult Verify(Admin admin) 
        {
            connectionString();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM AdminAccount WHERE id= " + admin.id + " AND password= '" + admin.password + "'";
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                con.Close();
                return View("Create");
            }
            else
            {
                con.Close();
                return View("Error");
            }
        }
    }
}