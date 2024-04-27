using System;
using System.Collections.Generic;
using System.Linq;
using BasicLearningManagementSystem.Models;
using System.Data;
using System.Web;

namespace BasicLearningManagementSystem.Manager
{
    public class StudentManager
    {
        public void AddStudent(Student student) 
        {
            Connection.OpenConnection();
            Connection.ExecuteQueries(@"INSERT INTO Student (name, email, password, gender, phone, city, address) 
                                VALUES('"+student.name+"', '"+student.email+"', '"+student.password+"', '"+student.gender+"', '"+student.phone+"', '"+student.city+"', '"+student.address+"')");
            Connection.CloseConnection();
        }

        public List<Student> ViewStudent()
        {
            Connection.OpenConnection();
            DataTable dt = Connection.DataView("SELECT * FROM Student");

            List<Student> data = new List<Student>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Student obj = new Student();
                obj.id = int.Parse(dt.Rows[i][0].ToString());
                obj.name = dt.Rows[i][1].ToString();
                obj.gender = dt.Rows[i][4].ToString();
                obj.phone = dt.Rows[i][5].ToString();
                obj.city = dt.Rows[i][6].ToString();
                obj.address = dt.Rows[i][7].ToString();

                data.Add(obj);
            }
            
            Connection.CloseConnection();
            return data;
        }
    }
}