using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using BasicLearningManagementSystem.Models;

namespace BasicLearningManagementSystem.Manager
{
    public class RegisterManager
    {
        public void AddRegister(Register register)
        {
            Connection.OpenConnection();
            Connection.ExecuteQueries("INSERT INTO Register (studName, courseName) VALUES ('" + register.student_name + "', '" + register.course_name + "')");
            Connection.CloseConnection();
        }

        public List<Register> ViewRegister()
        {
            Connection.OpenConnection();
            DataTable dt = Connection.DataView("SELECT * FROM Register");

            List<Register> data = new List<Register>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Register obj = new Register();
                obj.id = int.Parse(dt.Rows[i][0].ToString());
                obj.student_name = dt.Rows[i][1].ToString();
                obj.course_name = dt.Rows[i][2].ToString();

                data.Add(obj);
            }

            Connection.CloseConnection();
            return data;
        }
        public void Delete(int id)
        {
            Connection.OpenConnection();
            Connection.ExecuteQueries("DELETE FROM Register WHERE id= " + id + "");
            Connection.CloseConnection();
        }
    }
}