using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using BasicLearningManagementSystem.Models;
using System.Web;

namespace BasicLearningManagementSystem.Manager
{
    public class CourseManager
    {
        public void AddCourse(Course course)
        {
            Connection.OpenConnection();
            Connection.ExecuteQueries(@"INSERT INTO Course(name, crhrs, instructor) 
                                    VALUES('" + course.name + "', " + course.crhrs + ", '" + course.instructor + "')");
            Connection.CloseConnection();
        }

        public List<Course> ViewCourse()
        {
            Connection.OpenConnection();
            DataTable dt = Connection.DataView("SELECT * FROM Course");

            List<Course> data = new List<Course>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Course obj = new Course();
                obj.id = int.Parse(dt.Rows[i][0].ToString());
                obj.name = dt.Rows[i][1].ToString();
                obj.crhrs = int.Parse(dt.Rows[i][2].ToString());
                obj.instructor = dt.Rows[i][3].ToString();

                data.Add(obj);
            }

            Connection.CloseConnection();
            return data;
        }

        public Course GetCourse(int id)
        {
            Course course = new Course();

            Connection.OpenConnection();
            DataTable dt = Connection.DataView("SELECT * FROM Course WHERE id= " + id + "");

            course.id = int.Parse(dt.Rows[0][0].ToString());
            course.name = dt.Rows[0][1].ToString();
            course.crhrs = int.Parse(dt.Rows[0][2].ToString());
            course.instructor = dt.Rows[0][3].ToString();

            Connection.CloseConnection();

            return course;
        }

        public void UpdateCourse(Course course)
        {
            Connection.OpenConnection();
            Connection.ExecuteQueries("UPDATE Course SET name = '" + course.name + "', crhrs = " + course.crhrs + ", instructor = '" + course.instructor + "' WHERE id= " + course.id + "");
            Connection.CloseConnection();
        }

        public void DeleteCourse(int id)
        {
            Connection.OpenConnection();
            Connection.ExecuteQueries("DELETE FROM Course WHERE id= " + id + "");
            Connection.CloseConnection();
        }

        public void Count()
        {
            Connection.OpenConnection();
            Connection.ExecuteQueries("SELECT COUNT(*) FROM Course");
            Connection.CloseConnection();
        }
    }
}